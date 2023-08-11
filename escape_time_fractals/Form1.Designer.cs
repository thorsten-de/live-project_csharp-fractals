namespace escape_time_fractals
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSettingsMandelbrotSet = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSettingsJuliaSet = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSettingsVortexFractal = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSettingsNoSmoothing = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSettingsSmooth1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSettingsSmooth2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSettingsChangeMaxIterations = new System.Windows.Forms.ToolStripMenuItem();
            this.scaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuScaleRedraw = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuScaleX2 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuScaleX4 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuScaleX8 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuScaleFullScale = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuScaleEnterSelectedArea = new System.Windows.Forms.ToolStripMenuItem();
            this.fractalPictureBox = new System.Windows.Forms.PictureBox();
            this.sfdFractal = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fractalPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.scaleToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(976, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileSaveAs,
            this.toolStripMenuItem1,
            this.mnuFileExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 19);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // mnuFileSaveAs
            // 
            this.mnuFileSaveAs.Name = "mnuFileSaveAs";
            this.mnuFileSaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuFileSaveAs.Size = new System.Drawing.Size(163, 22);
            this.mnuFileSaveAs.Text = "Save &As...";
            this.mnuFileSaveAs.Click += new System.EventHandler(this.mnuFileSaveAs_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(160, 6);
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.Size = new System.Drawing.Size(163, 22);
            this.mnuFileExit.Text = "E&xit";
            this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSettingsMandelbrotSet,
            this.mnuSettingsJuliaSet,
            this.mnuSettingsVortexFractal,
            this.toolStripMenuItem2,
            this.mnuSettingsNoSmoothing,
            this.mnuSettingsSmooth1,
            this.mnuSettingsSmooth2,
            this.toolStripMenuItem3,
            this.mnuSettingsChangeMaxIterations});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 19);
            this.settingsToolStripMenuItem.Text = "&Settings";
            // 
            // mnuSettingsMandelbrotSet
            // 
            this.mnuSettingsMandelbrotSet.Checked = true;
            this.mnuSettingsMandelbrotSet.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuSettingsMandelbrotSet.Name = "mnuSettingsMandelbrotSet";
            this.mnuSettingsMandelbrotSet.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.mnuSettingsMandelbrotSet.Size = new System.Drawing.Size(202, 22);
            this.mnuSettingsMandelbrotSet.Text = "&Madelbrot Set";
            this.mnuSettingsMandelbrotSet.Click += new System.EventHandler(this.mnuSettingsMandelbrotSet_Click);
            // 
            // mnuSettingsJuliaSet
            // 
            this.mnuSettingsJuliaSet.Name = "mnuSettingsJuliaSet";
            this.mnuSettingsJuliaSet.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.J)));
            this.mnuSettingsJuliaSet.Size = new System.Drawing.Size(202, 22);
            this.mnuSettingsJuliaSet.Text = "&Julia Set";
            this.mnuSettingsJuliaSet.Click += new System.EventHandler(this.mnuSettingsJuliaSet_Click);
            // 
            // mnuSettingsVortexFractal
            // 
            this.mnuSettingsVortexFractal.Name = "mnuSettingsVortexFractal";
            this.mnuSettingsVortexFractal.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.mnuSettingsVortexFractal.Size = new System.Drawing.Size(202, 22);
            this.mnuSettingsVortexFractal.Text = "&Vortex Fractal";
            this.mnuSettingsVortexFractal.Click += new System.EventHandler(this.mnuSettingsVortexFractal_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(199, 6);
            // 
            // mnuSettingsNoSmoothing
            // 
            this.mnuSettingsNoSmoothing.Checked = true;
            this.mnuSettingsNoSmoothing.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuSettingsNoSmoothing.Name = "mnuSettingsNoSmoothing";
            this.mnuSettingsNoSmoothing.Size = new System.Drawing.Size(202, 22);
            this.mnuSettingsNoSmoothing.Text = "&No Smoothing";
            this.mnuSettingsNoSmoothing.Click += new System.EventHandler(this.mnuSettingsNoSmoothing_Click);
            // 
            // mnuSettingsSmooth1
            // 
            this.mnuSettingsSmooth1.Name = "mnuSettingsSmooth1";
            this.mnuSettingsSmooth1.Size = new System.Drawing.Size(202, 22);
            this.mnuSettingsSmooth1.Text = "Smooth &1";
            this.mnuSettingsSmooth1.Click += new System.EventHandler(this.mnuSettingsSmooth1_Click);
            // 
            // mnuSettingsSmooth2
            // 
            this.mnuSettingsSmooth2.Name = "mnuSettingsSmooth2";
            this.mnuSettingsSmooth2.Size = new System.Drawing.Size(202, 22);
            this.mnuSettingsSmooth2.Text = "Smooth &2";
            this.mnuSettingsSmooth2.Click += new System.EventHandler(this.mnuSettingsSmooth2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(199, 6);
            // 
            // mnuSettingsChangeMaxIterations
            // 
            this.mnuSettingsChangeMaxIterations.Name = "mnuSettingsChangeMaxIterations";
            this.mnuSettingsChangeMaxIterations.Size = new System.Drawing.Size(202, 22);
            this.mnuSettingsChangeMaxIterations.Text = "Change Max Iterations...";
            this.mnuSettingsChangeMaxIterations.Click += new System.EventHandler(this.mnuSettingsChangeMaxIterations_Click);
            // 
            // scaleToolStripMenuItem
            // 
            this.scaleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuScaleRedraw,
            this.toolStripMenuItem4,
            this.mnuScaleX2,
            this.mnuScaleX4,
            this.mnuScaleX8,
            this.mnuScaleFullScale,
            this.toolStripMenuItem5,
            this.mnuScaleEnterSelectedArea});
            this.scaleToolStripMenuItem.Name = "scaleToolStripMenuItem";
            this.scaleToolStripMenuItem.Size = new System.Drawing.Size(46, 19);
            this.scaleToolStripMenuItem.Text = "S&cale";
            // 
            // mnuScaleRedraw
            // 
            this.mnuScaleRedraw.Name = "mnuScaleRedraw";
            this.mnuScaleRedraw.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.mnuScaleRedraw.Size = new System.Drawing.Size(184, 22);
            this.mnuScaleRedraw.Text = "&Redraw";
            this.mnuScaleRedraw.Click += new System.EventHandler(this.mnuScaleRedraw_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(181, 6);
            // 
            // mnuScaleX2
            // 
            this.mnuScaleX2.Name = "mnuScaleX2";
            this.mnuScaleX2.Size = new System.Drawing.Size(184, 22);
            this.mnuScaleX2.Text = "x&2";
            this.mnuScaleX2.Click += new System.EventHandler(this.mnuScaleX2_Click);
            // 
            // mnuScaleX4
            // 
            this.mnuScaleX4.Name = "mnuScaleX4";
            this.mnuScaleX4.Size = new System.Drawing.Size(184, 22);
            this.mnuScaleX4.Text = "x&4";
            this.mnuScaleX4.Click += new System.EventHandler(this.mnuScaleX4_Click);
            // 
            // mnuScaleX8
            // 
            this.mnuScaleX8.Name = "mnuScaleX8";
            this.mnuScaleX8.Size = new System.Drawing.Size(184, 22);
            this.mnuScaleX8.Text = "x&8";
            this.mnuScaleX8.Click += new System.EventHandler(this.mnuScaleX8_Click);
            // 
            // mnuScaleFullScale
            // 
            this.mnuScaleFullScale.Name = "mnuScaleFullScale";
            this.mnuScaleFullScale.Size = new System.Drawing.Size(184, 22);
            this.mnuScaleFullScale.Text = "&Full Scale";
            this.mnuScaleFullScale.Click += new System.EventHandler(this.mnuScaleFullScale_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(181, 6);
            // 
            // mnuScaleEnterSelectedArea
            // 
            this.mnuScaleEnterSelectedArea.Name = "mnuScaleEnterSelectedArea";
            this.mnuScaleEnterSelectedArea.Size = new System.Drawing.Size(184, 22);
            this.mnuScaleEnterSelectedArea.Text = "Enter Selected Area...";
            this.mnuScaleEnterSelectedArea.Click += new System.EventHandler(this.mnuScaleEnterSelectedArea_Click);
            // 
            // fractalPictureBox
            // 
            this.fractalPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fractalPictureBox.BackColor = System.Drawing.Color.Black;
            this.fractalPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.fractalPictureBox.Cursor = System.Windows.Forms.Cursors.Cross;
            this.fractalPictureBox.Location = new System.Drawing.Point(18, 42);
            this.fractalPictureBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fractalPictureBox.Name = "fractalPictureBox";
            this.fractalPictureBox.Size = new System.Drawing.Size(938, 952);
            this.fractalPictureBox.TabIndex = 1;
            this.fractalPictureBox.TabStop = false;
            this.fractalPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.fractalPictureBox_Paint);
            this.fractalPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.fractalPictureBox_MouseDown);
            // 
            // sfdFractal
            // 
            this.sfdFractal.DefaultExt = "png";
            this.sfdFractal.Filter = "Graphics Files|*.png;*.jpg;*.bmp;*.gif;*.tif;*.exif|All Files|*.*";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 1014);
            this.Controls.Add(this.fractalPictureBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "escape_time_fractals";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fractalPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuFileSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuSettingsMandelbrotSet;
        private System.Windows.Forms.ToolStripMenuItem mnuSettingsJuliaSet;
        private System.Windows.Forms.ToolStripMenuItem mnuSettingsVortexFractal;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mnuSettingsNoSmoothing;
        private System.Windows.Forms.ToolStripMenuItem mnuSettingsSmooth1;
        private System.Windows.Forms.ToolStripMenuItem mnuSettingsSmooth2;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem mnuSettingsChangeMaxIterations;
        private System.Windows.Forms.ToolStripMenuItem scaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuScaleRedraw;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem mnuScaleX2;
        private System.Windows.Forms.ToolStripMenuItem mnuScaleX4;
        private System.Windows.Forms.ToolStripMenuItem mnuScaleX8;
        private System.Windows.Forms.ToolStripMenuItem mnuScaleFullScale;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem mnuScaleEnterSelectedArea;
        private System.Windows.Forms.PictureBox fractalPictureBox;
        private System.Windows.Forms.SaveFileDialog sfdFractal;
    }
}

