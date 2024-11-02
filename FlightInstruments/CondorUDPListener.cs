using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace FlightInstruments
{
    public class CondorUDPListener : UserControl
    {
        private readonly List<Action<string>> callbacks = new List<Action<string>>();
        private readonly BackgroundWorker backgroundWorker = new BackgroundWorker();
        private UdpClient udpClient;
        private int port = 12345; // Default port, configurable in code

        // Port property that stops and restarts the listener if changed
        public int Port
        {
            get => port;
            set
            {
                if (port != value)
                {
                    StopListener();
                    port = value;
                    StartListener();
                }
            }
        }

        // Designer requires a parameterless constructor
        public CondorUDPListener()
        {
            InitializeBackgroundWorker();
            StartListener();
        }

        // Constructor that allows setting a port
        public CondorUDPListener(int port) : this()
        {
            this.port = port;
            StartListener(); // Explicitly start the listener with the specified port
        }

        // Initialize the BackgroundWorker (called by constructors)
        private void InitializeBackgroundWorker()
        {
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.DoWork += BackgroundWorker_DoWork;
        }

        // Method to start the UDP listener
        public void StartListener()
        {
            if (udpClient == null)
            {
                udpClient = new UdpClient(port);
                backgroundWorker.RunWorkerAsync();
            }
        }

        // Method for other controls to register callbacks
        public void AddCallback(Action<string> callback)
        {
            if (callback != null)
            {
                lock (callbacks)
                {
                    callbacks.Add(callback);
                }
            }
        }

        // BackgroundWorker method to listen for UDP packets
        private void BackgroundWorker_DoWork(object? sender, DoWorkEventArgs e)
        {
            IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, port);

            while (!backgroundWorker.CancellationPending)
            {
                try
                {
                    // Listen for UDP data
                    byte[] data = udpClient.Receive(ref remoteEndPoint);
                    string receivedData = Encoding.UTF8.GetString(data);

                    // Convert data to JSON
                    string jsonData = ConvertToJson(receivedData);

                    // Call all registered callbacks with the JSON data
                    List<Action<string>> currentCallbacks;
                    lock (callbacks)
                    {
                        currentCallbacks = new List<Action<string>>(callbacks);
                    }

                    foreach (var callback in currentCallbacks)
                    {
                        try
                        {
                            BeginInvoke(callback, jsonData);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error invoking callback: {ex.Message}");
                        }
                    }
                }
                catch (SocketException ex)
                {
                    Console.WriteLine($"Socket error: {ex.Message}");
                    Thread.Sleep(100); // Wait a bit before retrying
                }
            }
        }

        // Converts Condor UDP data to JSON format
        private string ConvertToJson(string data)
        {
            var keyValuePairs = new Dictionary<string, object>();
            var dataParts = data.Split(';');

            foreach (var part in dataParts)
            {
                var keyValue = part.Split('=');
                if (keyValue.Length == 2)
                {
                    string key = keyValue[0].Trim();
                    string value = keyValue[1].Trim();

                    if (float.TryParse(value, out float numericValue))
                    {
                        keyValuePairs[key] = numericValue; // Store as number if possible
                    }
                    else
                    {
                        keyValuePairs[key] = value; // Store as string if parsing fails
                    }
                }
            }

            return JsonConvert.SerializeObject(keyValuePairs, Formatting.Indented);
        }

        // Method to stop the BackgroundWorker and clean up resources
        public void StopListener()
        {
            if (backgroundWorker.IsBusy)
            {
                backgroundWorker.CancelAsync();
            }
            udpClient?.Close();
        }

        // Override Dispose to ensure resources are cleaned up
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                StopListener();
                backgroundWorker.Dispose();
                udpClient?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
