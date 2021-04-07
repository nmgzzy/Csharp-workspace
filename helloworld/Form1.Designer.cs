namespace helloworld
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.rBtn20 = new System.Windows.Forms.RadioButton();
            this.rBtnM = new System.Windows.Forms.RadioButton();
            this.questionType = new System.Windows.Forms.GroupBox();
            this.rBtn10 = new System.Windows.Forms.RadioButton();
            this.btnNext = new System.Windows.Forms.Button();
            this.checkBoxNext = new System.Windows.Forms.CheckBox();
            this.btnFast = new System.Windows.Forms.Button();
            this.btnSlow = new System.Windows.Forms.Button();
            this.question = new System.Windows.Forms.Label();
            this.answer = new System.Windows.Forms.TextBox();
            this.result = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rate = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.keyAnswer = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.questionType.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // rBtn20
            // 
            this.rBtn20.AutoSize = true;
            this.rBtn20.Location = new System.Drawing.Point(28, 92);
            this.rBtn20.Name = "rBtn20";
            this.rBtn20.Size = new System.Drawing.Size(185, 28);
            this.rBtn20.TabIndex = 7;
            this.rBtn20.TabStop = true;
            this.rBtn20.Text = "20以内加减法";
            this.rBtn20.UseVisualStyleBackColor = true;
            this.rBtn20.CheckedChanged += new System.EventHandler(this.rBtn20_CheckedChanged);
            // 
            // rBtnM
            // 
            this.rBtnM.AutoSize = true;
            this.rBtnM.Location = new System.Drawing.Point(28, 127);
            this.rBtnM.Name = "rBtnM";
            this.rBtnM.Size = new System.Drawing.Size(89, 28);
            this.rBtnM.TabIndex = 8;
            this.rBtnM.TabStop = true;
            this.rBtnM.Text = "乘法";
            this.rBtnM.UseVisualStyleBackColor = true;
            this.rBtnM.CheckedChanged += new System.EventHandler(this.rBtnM_CheckedChanged);
            // 
            // questionType
            // 
            this.questionType.Controls.Add(this.rBtn10);
            this.questionType.Controls.Add(this.rBtnM);
            this.questionType.Controls.Add(this.rBtn20);
            this.questionType.Location = new System.Drawing.Point(32, 33);
            this.questionType.Name = "questionType";
            this.questionType.Size = new System.Drawing.Size(334, 190);
            this.questionType.TabIndex = 9;
            this.questionType.TabStop = false;
            this.questionType.Text = "题目类型";
            // 
            // rBtn10
            // 
            this.rBtn10.AutoSize = true;
            this.rBtn10.Location = new System.Drawing.Point(28, 57);
            this.rBtn10.Name = "rBtn10";
            this.rBtn10.Size = new System.Drawing.Size(185, 28);
            this.rBtn10.TabIndex = 6;
            this.rBtn10.TabStop = true;
            this.rBtn10.Text = "10以内加减法";
            this.rBtn10.UseVisualStyleBackColor = true;
            this.rBtn10.CheckedChanged += new System.EventHandler(this.rBtn10_CheckedChanged);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(412, 129);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(127, 59);
            this.btnNext.TabIndex = 10;
            this.btnNext.Text = "下一题";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // checkBoxNext
            // 
            this.checkBoxNext.AutoSize = true;
            this.checkBoxNext.Location = new System.Drawing.Point(390, 62);
            this.checkBoxNext.Name = "checkBoxNext";
            this.checkBoxNext.Size = new System.Drawing.Size(210, 28);
            this.checkBoxNext.TabIndex = 11;
            this.checkBoxNext.Text = "自动显示下一题";
            this.checkBoxNext.UseVisualStyleBackColor = true;
            this.checkBoxNext.CheckedChanged += new System.EventHandler(this.checkBoxNext_CheckedChanged);
            // 
            // btnFast
            // 
            this.btnFast.Location = new System.Drawing.Point(632, 54);
            this.btnFast.Name = "btnFast";
            this.btnFast.Size = new System.Drawing.Size(103, 43);
            this.btnFast.TabIndex = 12;
            this.btnFast.Text = "快些";
            this.btnFast.UseVisualStyleBackColor = true;
            this.btnFast.Click += new System.EventHandler(this.btnFast_Click);
            // 
            // btnSlow
            // 
            this.btnSlow.Location = new System.Drawing.Point(766, 54);
            this.btnSlow.Name = "btnSlow";
            this.btnSlow.Size = new System.Drawing.Size(106, 43);
            this.btnSlow.TabIndex = 13;
            this.btnSlow.Text = "慢些";
            this.btnSlow.UseVisualStyleBackColor = true;
            this.btnSlow.Click += new System.EventHandler(this.btnSlow_Click);
            // 
            // question
            // 
            this.question.AutoSize = true;
            this.question.Font = new System.Drawing.Font("宋体", 22.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.question.Location = new System.Drawing.Point(116, 288);
            this.question.Name = "question";
            this.question.Size = new System.Drawing.Size(0, 59);
            this.question.TabIndex = 14;
            // 
            // answer
            // 
            this.answer.Font = new System.Drawing.Font("宋体", 22.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.answer.Location = new System.Drawing.Point(728, 272);
            this.answer.Name = "answer";
            this.answer.Size = new System.Drawing.Size(216, 75);
            this.answer.TabIndex = 15;
            this.answer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.answer_KeyPress);
            // 
            // result
            // 
            this.result.AutoSize = true;
            this.result.Font = new System.Drawing.Font("微软雅黑", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.result.Location = new System.Drawing.Point(784, 394);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(0, 57);
            this.result.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(90, 466);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 33);
            this.label1.TabIndex = 17;
            this.label1.Text = "正确率：";
            // 
            // rate
            // 
            this.rate.AutoSize = true;
            this.rate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rate.Location = new System.Drawing.Point(251, 466);
            this.rate.Name = "rate";
            this.rate.Size = new System.Drawing.Size(0, 33);
            this.rate.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(90, 394);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 33);
            this.label2.TabIndex = 19;
            this.label2.Text = "答案：";
            // 
            // keyAnswer
            // 
            this.keyAnswer.AutoSize = true;
            this.keyAnswer.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.keyAnswer.Location = new System.Drawing.Point(237, 395);
            this.keyAnswer.Name = "keyAnswer";
            this.keyAnswer.Size = new System.Drawing.Size(0, 33);
            this.keyAnswer.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 22.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(622, 275);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 59);
            this.label3.TabIndex = 21;
            this.label3.Text = "=";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 570);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.keyAnswer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.result);
            this.Controls.Add(this.answer);
            this.Controls.Add(this.question);
            this.Controls.Add(this.btnSlow);
            this.Controls.Add(this.btnFast);
            this.Controls.Add(this.checkBoxNext);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.questionType);
            this.Name = "Form1";
            this.questionType.ResumeLayout(false);
            this.questionType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.RadioButton rBtn20;
        private System.Windows.Forms.RadioButton rBtnM;
        private System.Windows.Forms.GroupBox questionType;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.CheckBox checkBoxNext;
        private System.Windows.Forms.Button btnFast;
        private System.Windows.Forms.Button btnSlow;
        private System.Windows.Forms.Label question;
        private System.Windows.Forms.TextBox answer;
        private System.Windows.Forms.Label result;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label rate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label keyAnswer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rBtn10;
    }
}

