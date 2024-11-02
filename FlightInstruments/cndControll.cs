using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightInstruments
{
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;

    public class CondorControl : UserControl
    {
        public CondorControl()
        {
            DoubleBuffered = true;
        }

        // Automatically register callback when the parent is set
        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);

            // Try to find UdpListenerControl in the parent controls
            if (Parent != null)
            {
                foreach (Control control in Parent.Controls)
                {
                    if (control is CondorUDPListener UDPListener)
                    {
                        UDPListener.AddCallback(OnUDPDataReceived);
                        break;
                    }
                }
            }
        }

        // Virtual method for handling UDP data, to be overridden by derived classes
        protected virtual void OnUDPDataReceived(string udpData)
        {
            // Default behavior: do nothing
            // Derived classes will override this to handle the UDP data
        }
    }
}
