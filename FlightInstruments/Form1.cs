using System;

namespace FlightInstruments
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            CondorUdpTestSender condorUdpTestSender = new CondorUdpTestSender();

            condorUdpTestSender.StartSendingTestData(500);
            //Task.Run(() => UpdateVerticalSpeed());
        }

        private static readonly Random random = new Random();
        private double GetRandomValue()
        {
            // Generate a random double between -10 and 10
            return random.NextDouble() * 20 - 10;
        }
        private void UpdateVerticalSpeed()
        {
            while (true)
            {
                //for (double vs = -10.0; vs <= 10; vs += 0.5)
                //{
                //    // Update the VerticalSpeed property on the UI thread
                //    this.Invoke((Action)(() =>
                //    {
                //        this.winterVarioControl1.VerticalSpeed = vs;
                //        this.winterVarioControl1.Invalidate();
                //    }));
                //
                //    Thread.Sleep(500);
                //}
                //for(int x = 0; x < 12; x++)
                {
                    this.Invoke((Action)(() =>
                    {
                        this.winterVarioControl1.VerticalSpeed = GetRandomValue();
                        this.winterVarioControl1.Invalidate();
                    }));
                    Thread.Sleep(500);
                }
            }
        }
    }
}

