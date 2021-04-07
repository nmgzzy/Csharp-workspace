
namespace Animals
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
            this.btnCat = new System.Windows.Forms.Button();
            this.btnDog = new System.Windows.Forms.Button();
            this.btnGame = new System.Windows.Forms.Button();
            this.btnSign = new System.Windows.Forms.Button();
            this.btnJump = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCat
            // 
            this.btnCat.Location = new System.Drawing.Point(170, 54);
            this.btnCat.Name = "btnCat";
            this.btnCat.Size = new System.Drawing.Size(154, 76);
            this.btnCat.TabIndex = 0;
            this.btnCat.Text = "猫叫";
            this.btnCat.UseVisualStyleBackColor = true;
            this.btnCat.Click += new System.EventHandler(this.btnCat_Click);
            // 
            // btnDog
            // 
            this.btnDog.Location = new System.Drawing.Point(170, 146);
            this.btnDog.Name = "btnDog";
            this.btnDog.Size = new System.Drawing.Size(154, 78);
            this.btnDog.TabIndex = 1;
            this.btnDog.Text = "狗叫";
            this.btnDog.UseVisualStyleBackColor = true;
            this.btnDog.Click += new System.EventHandler(this.btnDog_Click);
            // 
            // btnGame
            // 
            this.btnGame.Location = new System.Drawing.Point(170, 338);
            this.btnGame.Name = "btnGame";
            this.btnGame.Size = new System.Drawing.Size(154, 78);
            this.btnGame.TabIndex = 3;
            this.btnGame.Text = "比赛";
            this.btnGame.UseVisualStyleBackColor = true;
            this.btnGame.Click += new System.EventHandler(this.btnGame_Click);
            // 
            // btnSign
            // 
            this.btnSign.Location = new System.Drawing.Point(170, 246);
            this.btnSign.Name = "btnSign";
            this.btnSign.Size = new System.Drawing.Size(154, 76);
            this.btnSign.TabIndex = 2;
            this.btnSign.Text = "报名";
            this.btnSign.UseVisualStyleBackColor = true;
            this.btnSign.Click += new System.EventHandler(this.btnSign_Click);
            // 
            // btnJump
            // 
            this.btnJump.Location = new System.Drawing.Point(170, 443);
            this.btnJump.Name = "btnJump";
            this.btnJump.Size = new System.Drawing.Size(153, 72);
            this.btnJump.TabIndex = 4;
            this.btnJump.Text = "跳远";
            this.btnJump.UseVisualStyleBackColor = true;
            this.btnJump.Click += new System.EventHandler(this.btnJump_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 558);
            this.Controls.Add(this.btnJump);
            this.Controls.Add(this.btnGame);
            this.Controls.Add(this.btnSign);
            this.Controls.Add(this.btnDog);
            this.Controls.Add(this.btnCat);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCat;
        private System.Windows.Forms.Button btnDog;
        private System.Windows.Forms.Button btnGame;
        private System.Windows.Forms.Button btnSign;
        private System.Windows.Forms.Button btnJump;
    }
}

