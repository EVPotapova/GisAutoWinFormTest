namespace GisAutoWinFormTest
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PeugeotWB = new System.Windows.Forms.WebBrowser();
            this.LoadPB = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // PeugeotWB
            // 
            this.PeugeotWB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PeugeotWB.IsWebBrowserContextMenuEnabled = false;
            this.PeugeotWB.Location = new System.Drawing.Point(0, 0);
            this.PeugeotWB.MinimumSize = new System.Drawing.Size(20, 20);
            this.PeugeotWB.Name = "PeugeotWB";
            this.PeugeotWB.Size = new System.Drawing.Size(800, 450);
            this.PeugeotWB.TabIndex = 0;
            this.PeugeotWB.Visible = false;
            this.PeugeotWB.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.PeugeotWB_DocumentCompleted);
            // 
            // LoadPB
            // 
            this.LoadPB.Location = new System.Drawing.Point(197, 198);
            this.LoadPB.MarqueeAnimationSpeed = 1;
            this.LoadPB.Name = "LoadPB";
            this.LoadPB.Size = new System.Drawing.Size(400, 30);
            this.LoadPB.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.LoadPB.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LoadPB);
            this.Controls.Add(this.PeugeotWB);
            this.Name = "MainForm";
            this.Text = "Peugeot Web Catalogue";
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser PeugeotWB;
        private System.Windows.Forms.ProgressBar LoadPB;
    }
}

