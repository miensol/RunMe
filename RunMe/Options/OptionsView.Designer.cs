namespace miensol.RunMe.Options
{
    partial class OptionsView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.openRubyExeButton = new System.Windows.Forms.Button();
            this.rubyExePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openRubyExeDialog = new System.Windows.Forms.OpenFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.rubyWorkingDir = new System.Windows.Forms.TextBox();
            this.openRubyWorkingDir = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.openRubyWorkingDir);
            this.groupBox1.Controls.Add(this.rubyWorkingDir);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.openRubyExeButton);
            this.groupBox1.Controls.Add(this.rubyExePath);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(392, 103);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ruby";
            // 
            // openRubyExeButton
            // 
            this.openRubyExeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openRubyExeButton.Location = new System.Drawing.Point(355, 23);
            this.openRubyExeButton.Name = "openRubyExeButton";
            this.openRubyExeButton.Size = new System.Drawing.Size(21, 20);
            this.openRubyExeButton.TabIndex = 1;
            this.openRubyExeButton.Text = "...";
            this.openRubyExeButton.UseVisualStyleBackColor = true;
            // 
            // rubyExePath
            // 
            this.rubyExePath.Location = new System.Drawing.Point(76, 23);
            this.rubyExePath.Name = "rubyExePath";
            this.rubyExePath.Size = new System.Drawing.Size(273, 20);
            this.rubyExePath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Path";
            // 
            // openRubyExeDialog
            // 
            this.openRubyExeDialog.CheckFileExists = false;
            this.openRubyExeDialog.FileName = "ruby.exe";
            this.openRubyExeDialog.Filter = "Ruby|*.exe";
            // 
            // label2
            // 
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Location = new System.Drawing.Point(21, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "Working Directory";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // rubyWorkingDir
            // 
            this.rubyWorkingDir.Location = new System.Drawing.Point(76, 56);
            this.rubyWorkingDir.Name = "rubyWorkingDir";
            this.rubyWorkingDir.Size = new System.Drawing.Size(273, 20);
            this.rubyWorkingDir.TabIndex = 3;
            // 
            // openRubyWorkingDir
            // 
            this.openRubyWorkingDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openRubyWorkingDir.Location = new System.Drawing.Point(355, 56);
            this.openRubyWorkingDir.Name = "openRubyWorkingDir";
            this.openRubyWorkingDir.Size = new System.Drawing.Size(21, 20);
            this.openRubyWorkingDir.TabIndex = 4;
            this.openRubyWorkingDir.Text = "...";
            this.openRubyWorkingDir.UseVisualStyleBackColor = true;
            // 
            // OptionsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "OptionsView";
            this.Size = new System.Drawing.Size(399, 400);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox rubyExePath;
        private System.Windows.Forms.OpenFileDialog openRubyExeDialog;
        private System.Windows.Forms.Button openRubyExeButton;
        private System.Windows.Forms.Button openRubyWorkingDir;
        private System.Windows.Forms.TextBox rubyWorkingDir;
        private System.Windows.Forms.Label label2;
    }
}
