
namespace EnglishWords
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
            this.components = new System.ComponentModel.Container();
            this.labelEn = new System.Windows.Forms.Label();
            this.buttonFM = new System.Windows.Forms.Button();
            this.buttonUFM = new System.Windows.Forms.Button();
            this.buttonDK = new System.Windows.Forms.Button();
            this.checkBoxAuto = new System.Windows.Forms.CheckBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textBoxCn = new System.Windows.Forms.TextBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelEn
            // 
            this.labelEn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelEn.AutoSize = true;
            this.labelEn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelEn.Font = new System.Drawing.Font("Arial", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelEn.Location = new System.Drawing.Point(245, 59);
            this.labelEn.Name = "labelEn";
            this.labelEn.Size = new System.Drawing.Size(140, 44);
            this.labelEn.TabIndex = 0;
            this.labelEn.Text = "English";
            this.labelEn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonFM
            // 
            this.buttonFM.Location = new System.Drawing.Point(57, 285);
            this.buttonFM.Name = "buttonFM";
            this.buttonFM.Size = new System.Drawing.Size(186, 68);
            this.buttonFM.TabIndex = 2;
            this.buttonFM.Text = "熟悉";
            this.buttonFM.UseVisualStyleBackColor = true;
            this.buttonFM.Click += new System.EventHandler(this.buttonFM_Click);
            // 
            // buttonUFM
            // 
            this.buttonUFM.Location = new System.Drawing.Point(285, 285);
            this.buttonUFM.Name = "buttonUFM";
            this.buttonUFM.Size = new System.Drawing.Size(186, 68);
            this.buttonUFM.TabIndex = 3;
            this.buttonUFM.Text = "不熟悉";
            this.buttonUFM.UseVisualStyleBackColor = true;
            this.buttonUFM.Click += new System.EventHandler(this.buttonUFM_Click);
            // 
            // buttonDK
            // 
            this.buttonDK.Location = new System.Drawing.Point(519, 285);
            this.buttonDK.Name = "buttonDK";
            this.buttonDK.Size = new System.Drawing.Size(186, 68);
            this.buttonDK.TabIndex = 4;
            this.buttonDK.Text = "不认识";
            this.buttonDK.UseVisualStyleBackColor = true;
            this.buttonDK.Click += new System.EventHandler(this.buttonDK_Click);
            // 
            // checkBoxAuto
            // 
            this.checkBoxAuto.AutoSize = true;
            this.checkBoxAuto.Location = new System.Drawing.Point(73, 416);
            this.checkBoxAuto.Name = "checkBoxAuto";
            this.checkBoxAuto.Size = new System.Drawing.Size(142, 35);
            this.checkBoxAuto.TabIndex = 5;
            this.checkBoxAuto.Text = "自动切换";
            this.checkBoxAuto.UseVisualStyleBackColor = true;
            this.checkBoxAuto.CheckedChanged += new System.EventHandler(this.checkBoxAuto_CheckedChanged);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(313, 416);
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(392, 90);
            this.trackBar1.TabIndex = 6;
            this.trackBar1.Value = 5;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(231, 417);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 31);
            this.label1.TabIndex = 7;
            this.label1.Text = "速度：";
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // textBoxCn
            // 
            this.textBoxCn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxCn.Location = new System.Drawing.Point(131, 166);
            this.textBoxCn.Name = "textBoxCn";
            this.textBoxCn.Size = new System.Drawing.Size(508, 50);
            this.textBoxCn.TabIndex = 8;
            this.textBoxCn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 3000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 532);
            this.Controls.Add(this.textBoxCn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.checkBoxAuto);
            this.Controls.Add(this.buttonDK);
            this.Controls.Add(this.buttonUFM);
            this.Controls.Add(this.buttonFM);
            this.Controls.Add(this.labelEn);
            this.Name = "Form1";
            this.Text = "背单词";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelEn;
        private System.Windows.Forms.Button buttonFM;
        private System.Windows.Forms.Button buttonUFM;
        private System.Windows.Forms.Button buttonDK;
        private System.Windows.Forms.CheckBox checkBoxAuto;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBoxCn;
        private System.Windows.Forms.Timer timer2;
    }
}

