using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Threading;


namespace FlightInstruments
{
    public class CondorUdpTestSender
    {
        private readonly int port;
        private readonly UdpClient udpClient;
        private readonly IPEndPoint remoteEndPoint;
        private readonly Random random;

        public CondorUdpTestSender(int port = 12345)
        {
            this.port = port;
            udpClient = new UdpClient();
            remoteEndPoint = new IPEndPoint(IPAddress.Loopback, port); // Sends to localhost on specified port
            random = new Random();
        }

        // Method to send a single test message with random data
        public void SendTestMessage()
        {
            // Generate random data for altitude (0-2000) and vario (-10 to 10)
            float altitude = (float)(random.NextDouble() * 2000); // Altitude between 0 and 2000
            float vario = (float)(random.NextDouble() * 20 - 10); // Vario between -10 and 10

            // Format the test data string
            string testData = $"time={DateTime.Now.TimeOfDay.TotalHours:F2};altitude={altitude:F1};vario={vario:F1};evario=2.0;compass=45;slipball=0.1;turnrate=0.2";

            byte[] data = Encoding.UTF8.GetBytes(testData);
            udpClient.Send(data, data.Length, remoteEndPoint);

            Console.WriteLine("Sent test data: " + testData);
        }

        // Method to send continuous test data at regular intervals
        public void StartSendingTestData(int intervalMilliseconds = 1000)
        {
            new Thread(() =>
            {
                while (true)
                {
                    SendTestMessage();
                    Thread.Sleep(intervalMilliseconds); // Waits for specified interval before sending the next message
                }
            }).Start();
        }

        // Cleanup resources
        public void Stop()
        {
            udpClient.Close();
        }
    }

}
