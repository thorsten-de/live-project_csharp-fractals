namespace ChaosGame
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            toolStrip1 = new ToolStrip();
            startButton = new ToolStripButton();
            chaosPictureBox = new PictureBox();
            dotsTimer = new System.Windows.Forms.Timer(components);
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chaosPictureBox).BeginInit();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(24, 24);
            toolStrip1.Items.AddRange(new ToolStripItem[] { startButton });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(778, 34);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // startButton
            // 
            startButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            startButton.Image = (Image)resources.GetObject("startButton.Image");
            startButton.ImageTransparentColor = Color.Magenta;
            startButton.Name = "startButton";
            startButton.Size = new Size(52, 29);
            startButton.Text = "Start";
            startButton.Click += startButton_Click;
            // 
            // chaosPictureBox
            // 
            chaosPictureBox.BorderStyle = BorderStyle.Fixed3D;
            chaosPictureBox.Dock = DockStyle.Fill;
            chaosPictureBox.Location = new Point(0, 34);
            chaosPictureBox.Margin = new Padding(8);
            chaosPictureBox.Name = "chaosPictureBox";
            chaosPictureBox.Size = new Size(778, 730);
            chaosPictureBox.TabIndex = 1;
            chaosPictureBox.TabStop = false;
            // 
            // dotsTimer
            // 
            dotsTimer.Tick += dotsTimer_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(778, 764);
            Controls.Add(chaosPictureBox);
            Controls.Add(toolStrip1);
            Name = "Form1";
            Text = "Chaos Game";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)chaosPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton startButton;
        private PictureBox chaosPictureBox;
        private System.Windows.Forms.Timer dotsTimer;
    }
}