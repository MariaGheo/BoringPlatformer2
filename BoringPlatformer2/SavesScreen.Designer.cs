namespace BoringPlatformer2
{
    partial class SavesScreen
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
            this.save1Button = new System.Windows.Forms.Button();
            this.save2Button = new System.Windows.Forms.Button();
            this.save3Button = new System.Windows.Forms.Button();
            this.save4Button = new System.Windows.Forms.Button();
            this.save5Button = new System.Windows.Forms.Button();
            this.titleLabel = new System.Windows.Forms.Label();
            this.subtitleLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // save1Button
            // 
            this.save1Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.save1Button.Font = new System.Drawing.Font("Lucida Console", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save1Button.Location = new System.Drawing.Point(189, 95);
            this.save1Button.Name = "save1Button";
            this.save1Button.Size = new System.Drawing.Size(411, 37);
            this.save1Button.TabIndex = 0;
            this.save1Button.Tag = "0";
            this.save1Button.Text = "save1Button";
            this.save1Button.UseVisualStyleBackColor = true;
            this.save1Button.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // save2Button
            // 
            this.save2Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.save2Button.Font = new System.Drawing.Font("Lucida Console", 15.75F);
            this.save2Button.Location = new System.Drawing.Point(189, 138);
            this.save2Button.Name = "save2Button";
            this.save2Button.Size = new System.Drawing.Size(411, 37);
            this.save2Button.TabIndex = 1;
            this.save2Button.Tag = "1";
            this.save2Button.Text = "save2Button";
            this.save2Button.UseVisualStyleBackColor = true;
            this.save2Button.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // save3Button
            // 
            this.save3Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.save3Button.Font = new System.Drawing.Font("Lucida Console", 15.75F);
            this.save3Button.Location = new System.Drawing.Point(189, 181);
            this.save3Button.Name = "save3Button";
            this.save3Button.Size = new System.Drawing.Size(411, 37);
            this.save3Button.TabIndex = 2;
            this.save3Button.Tag = "2";
            this.save3Button.Text = "save3Button";
            this.save3Button.UseVisualStyleBackColor = true;
            this.save3Button.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // save4Button
            // 
            this.save4Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.save4Button.Font = new System.Drawing.Font("Lucida Console", 15.75F);
            this.save4Button.Location = new System.Drawing.Point(189, 224);
            this.save4Button.Name = "save4Button";
            this.save4Button.Size = new System.Drawing.Size(411, 37);
            this.save4Button.TabIndex = 3;
            this.save4Button.Tag = "3";
            this.save4Button.Text = "save4Button";
            this.save4Button.UseVisualStyleBackColor = true;
            this.save4Button.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // save5Button
            // 
            this.save5Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.save5Button.Font = new System.Drawing.Font("Lucida Console", 15.75F);
            this.save5Button.Location = new System.Drawing.Point(189, 267);
            this.save5Button.Name = "save5Button";
            this.save5Button.Size = new System.Drawing.Size(411, 37);
            this.save5Button.TabIndex = 4;
            this.save5Button.Tag = "4";
            this.save5Button.Text = "save5Button";
            this.save5Button.UseVisualStyleBackColor = true;
            this.save5Button.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.Font = new System.Drawing.Font("Lucida Console", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Location = new System.Drawing.Point(189, 29);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(411, 30);
            this.titleLabel.TabIndex = 6;
            this.titleLabel.Text = "SAVES";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // subtitleLabel
            // 
            this.subtitleLabel.Font = new System.Drawing.Font("Lucida Console", 15.75F);
            this.subtitleLabel.ForeColor = System.Drawing.Color.White;
            this.subtitleLabel.Location = new System.Drawing.Point(134, 335);
            this.subtitleLabel.Name = "subtitleLabel";
            this.subtitleLabel.Size = new System.Drawing.Size(527, 25);
            this.subtitleLabel.TabIndex = 7;
            this.subtitleLabel.Text = "Press Esc to Return to Main Menu";
            this.subtitleLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // SavesScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.subtitleLabel);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.save5Button);
            this.Controls.Add(this.save4Button);
            this.Controls.Add(this.save3Button);
            this.Controls.Add(this.save2Button);
            this.Controls.Add(this.save1Button);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "SavesScreen";
            this.Size = new System.Drawing.Size(760, 400);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.SavesScreen_PreviewKeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button save1Button;
        private System.Windows.Forms.Button save2Button;
        private System.Windows.Forms.Button save3Button;
        private System.Windows.Forms.Button save4Button;
        private System.Windows.Forms.Button save5Button;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label subtitleLabel;
    }
}
