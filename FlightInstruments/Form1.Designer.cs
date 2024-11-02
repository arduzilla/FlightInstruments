namespace FlightInstruments
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            winterVarioControl1 = new WinterVarioControl();
            condorudpListener1 = new CondorUDPListener();
            SuspendLayout();
            // 
            // winterVarioControl1
            // 
            winterVarioControl1.Location = new Point(496, 265);
            winterVarioControl1.Name = "winterVarioControl1";
            winterVarioControl1.Size = new Size(456, 440);
            winterVarioControl1.TabIndex = 0;
            winterVarioControl1.VerticalSpeed = 0D;
            // 
            // condorudpListener1
            // 
            condorudpListener1.Location = new Point(1428, 917);
            condorudpListener1.Name = "condorudpListener1";
            condorudpListener1.Size = new Size(33, 30);
            condorudpListener1.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1522, 959);
            Controls.Add(condorudpListener1);
            Controls.Add(winterVarioControl1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private WinterVarioControl winterVarioControl1;
        private CondorUDPListener condorudpListener1;
    }
}
