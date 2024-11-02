using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FlightInstruments
{
    using Newtonsoft.Json.Linq;
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    public partial class InstrumentBase : CondorControl
    {
        private double targetValue = 0.0; // The speed we want to animate to
        private double currentValue = 0.0; // The speed currently displayed by the needle
        private Timer animationTimer;

        public InstrumentBase()
        {
            DoubleBuffered = true;
            this.Size = new Size(300, 300);

            // Initialize the animation timer
            animationTimer = new Timer();
            animationTimer.Interval = 10; // 10ms for smooth updates within 250ms total
            animationTimer.Tick += AnimationTimer_Tick;
        }

        public double TargetValue
        {
            get { return targetValue; }
            set
            {
                // Clamp the target value
                targetValue = NormalizeValue(value);

                // Start the animation timer to move the needle to the new target speed
                if (!animationTimer.Enabled)
                {
                    animationTimer.Start();
                }
            }
        }

        public double CurrentValue
        {
            get { return currentValue; }
        }


        private void AnimationTimer_Tick(object? sender, EventArgs e)
        {
            // Calculate the step size to reach targetValue within 250ms
            double step = (targetValue - currentValue) * 0.1;

            // If the difference is small, snap to targetValue and stop the timer
            if (Math.Abs(targetValue - currentValue) < 0.1)
            {
                currentValue = targetValue;
                animationTimer.Stop();
            }
            else
            {
                // Smoothly move currentValue towards targetValue
                currentValue += step;
            }

            // Redraw the control with the updated currentValue
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawInstrument(e);
        }

        protected virtual void DrawInstrument(PaintEventArgs e)
        {
        }

        protected virtual double NormalizeValue(double val)
        {
            return val;
        }


    }
}

