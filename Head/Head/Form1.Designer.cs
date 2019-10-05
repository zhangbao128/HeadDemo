namespace Head
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Txt_CanNum = new System.Windows.Forms.TextBox();
            this.Txt_CardNum = new System.Windows.Forms.TextBox();
            this.Btn_CanInit = new System.Windows.Forms.Button();
            this.Btn_CardInit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Btn_Home = new System.Windows.Forms.Button();
            this.Lab_Total = new System.Windows.Forms.Label();
            this.Lst_Msg = new System.Windows.Forms.ListBox();
            this.Btn_ServoOn = new System.Windows.Forms.Button();
            this.Btn_ServoOff = new System.Windows.Forms.Button();
            this.Btn_Test = new System.Windows.Forms.Button();
            this.Txt_TestDis = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Chk_Box6 = new System.Windows.Forms.CheckBox();
            this.Chk_R2 = new System.Windows.Forms.CheckBox();
            this.Chk_Box5 = new System.Windows.Forms.CheckBox();
            this.Chk_R1 = new System.Windows.Forms.CheckBox();
            this.Chk_Box4 = new System.Windows.Forms.CheckBox();
            this.Chk_Box3 = new System.Windows.Forms.CheckBox();
            this.Chk_Box2 = new System.Windows.Forms.CheckBox();
            this.Chk_Box1 = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Txt_RPf = new System.Windows.Forms.TextBox();
            this.Txt_RDelay = new System.Windows.Forms.TextBox();
            this.Txt_TestPf = new System.Windows.Forms.TextBox();
            this.Txt_DelayTime = new System.Windows.Forms.TextBox();
            this.Txt_RDis = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Lab_RTotal = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Txt_CanNum
            // 
            this.Txt_CanNum.Location = new System.Drawing.Point(71, 22);
            this.Txt_CanNum.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Txt_CanNum.Name = "Txt_CanNum";
            this.Txt_CanNum.Size = new System.Drawing.Size(25, 21);
            this.Txt_CanNum.TabIndex = 0;
            this.Txt_CanNum.Text = "0";
            // 
            // Txt_CardNum
            // 
            this.Txt_CardNum.Location = new System.Drawing.Point(71, 51);
            this.Txt_CardNum.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Txt_CardNum.Name = "Txt_CardNum";
            this.Txt_CardNum.Size = new System.Drawing.Size(25, 21);
            this.Txt_CardNum.TabIndex = 8;
            this.Txt_CardNum.Text = "0";
            // 
            // Btn_CanInit
            // 
            this.Btn_CanInit.Location = new System.Drawing.Point(114, 18);
            this.Btn_CanInit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Btn_CanInit.Name = "Btn_CanInit";
            this.Btn_CanInit.Size = new System.Drawing.Size(78, 25);
            this.Btn_CanInit.TabIndex = 9;
            this.Btn_CanInit.Text = "CAN初始化";
            this.Btn_CanInit.UseVisualStyleBackColor = true;
            // 
            // Btn_CardInit
            // 
            this.Btn_CardInit.Location = new System.Drawing.Point(114, 46);
            this.Btn_CardInit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Btn_CardInit.Name = "Btn_CardInit";
            this.Btn_CardInit.Size = new System.Drawing.Size(78, 25);
            this.Btn_CardInit.TabIndex = 10;
            this.Btn_CardInit.Text = "卡初始化";
            this.Btn_CardInit.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "CAN号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 51);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "卡号";
            // 
            // Btn_Home
            // 
            this.Btn_Home.Location = new System.Drawing.Point(114, 96);
            this.Btn_Home.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Btn_Home.Name = "Btn_Home";
            this.Btn_Home.Size = new System.Drawing.Size(78, 21);
            this.Btn_Home.TabIndex = 12;
            this.Btn_Home.Text = "回零";
            this.Btn_Home.UseVisualStyleBackColor = true;
            // 
            // Lab_Total
            // 
            this.Lab_Total.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Lab_Total.Font = new System.Drawing.Font("楷体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Lab_Total.Location = new System.Drawing.Point(256, 21);
            this.Lab_Total.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Lab_Total.Name = "Lab_Total";
            this.Lab_Total.Size = new System.Drawing.Size(322, 104);
            this.Lab_Total.TabIndex = 13;
            this.Lab_Total.Text = "0";
            // 
            // Lst_Msg
            // 
            this.Lst_Msg.FormattingEnabled = true;
            this.Lst_Msg.ItemHeight = 12;
            this.Lst_Msg.Location = new System.Drawing.Point(10, 364);
            this.Lst_Msg.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Lst_Msg.Name = "Lst_Msg";
            this.Lst_Msg.Size = new System.Drawing.Size(229, 64);
            this.Lst_Msg.TabIndex = 15;
            // 
            // Btn_ServoOn
            // 
            this.Btn_ServoOn.Location = new System.Drawing.Point(30, 77);
            this.Btn_ServoOn.Name = "Btn_ServoOn";
            this.Btn_ServoOn.Size = new System.Drawing.Size(66, 23);
            this.Btn_ServoOn.TabIndex = 16;
            this.Btn_ServoOn.Text = "ServoOn";
            this.Btn_ServoOn.UseVisualStyleBackColor = true;
            // 
            // Btn_ServoOff
            // 
            this.Btn_ServoOff.Location = new System.Drawing.Point(30, 117);
            this.Btn_ServoOff.Name = "Btn_ServoOff";
            this.Btn_ServoOff.Size = new System.Drawing.Size(66, 23);
            this.Btn_ServoOff.TabIndex = 16;
            this.Btn_ServoOff.Text = "ServoOff";
            this.Btn_ServoOff.UseVisualStyleBackColor = true;
            // 
            // Btn_Test
            // 
            this.Btn_Test.Location = new System.Drawing.Point(136, 147);
            this.Btn_Test.Name = "Btn_Test";
            this.Btn_Test.Size = new System.Drawing.Size(75, 23);
            this.Btn_Test.TabIndex = 17;
            this.Btn_Test.Text = "Test";
            this.Btn_Test.UseVisualStyleBackColor = true;
            this.Btn_Test.Click += new System.EventHandler(this.Btn_Test_Click);
            // 
            // Txt_TestDis
            // 
            this.Txt_TestDis.Location = new System.Drawing.Point(65, 20);
            this.Txt_TestDis.Name = "Txt_TestDis";
            this.Txt_TestDis.Size = new System.Drawing.Size(39, 21);
            this.Txt_TestDis.TabIndex = 18;
            this.Txt_TestDis.Text = "17";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 19;
            this.label3.Text = "测试距离";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Chk_Box6);
            this.groupBox1.Controls.Add(this.Chk_R2);
            this.groupBox1.Controls.Add(this.Chk_Box5);
            this.groupBox1.Controls.Add(this.Chk_R1);
            this.groupBox1.Controls.Add(this.Chk_Box4);
            this.groupBox1.Controls.Add(this.Chk_Box3);
            this.groupBox1.Controls.Add(this.Chk_Box2);
            this.groupBox1.Controls.Add(this.Chk_Box1);
            this.groupBox1.Controls.Add(this.Btn_Test);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.Txt_RPf);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.Txt_RDelay);
            this.groupBox1.Controls.Add(this.Txt_TestPf);
            this.groupBox1.Controls.Add(this.Txt_DelayTime);
            this.groupBox1.Controls.Add(this.Txt_RDis);
            this.groupBox1.Controls.Add(this.Txt_TestDis);
            this.groupBox1.Location = new System.Drawing.Point(10, 176);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(227, 175);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "来回测试";
            // 
            // Chk_Box6
            // 
            this.Chk_Box6.AutoSize = true;
            this.Chk_Box6.Checked = true;
            this.Chk_Box6.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Chk_Box6.Location = new System.Drawing.Point(146, 122);
            this.Chk_Box6.Name = "Chk_Box6";
            this.Chk_Box6.Size = new System.Drawing.Size(54, 16);
            this.Chk_Box6.TabIndex = 21;
            this.Chk_Box6.Text = "Head6";
            this.Chk_Box6.UseVisualStyleBackColor = true;
            // 
            // Chk_R2
            // 
            this.Chk_R2.AutoSize = true;
            this.Chk_R2.Checked = true;
            this.Chk_R2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Chk_R2.Location = new System.Drawing.Point(77, 142);
            this.Chk_R2.Name = "Chk_R2";
            this.Chk_R2.Size = new System.Drawing.Size(36, 16);
            this.Chk_R2.TabIndex = 21;
            this.Chk_R2.Text = "R2";
            this.Chk_R2.UseVisualStyleBackColor = true;
            // 
            // Chk_Box5
            // 
            this.Chk_Box5.AutoSize = true;
            this.Chk_Box5.Checked = true;
            this.Chk_Box5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Chk_Box5.Location = new System.Drawing.Point(77, 122);
            this.Chk_Box5.Name = "Chk_Box5";
            this.Chk_Box5.Size = new System.Drawing.Size(54, 16);
            this.Chk_Box5.TabIndex = 21;
            this.Chk_Box5.Text = "Head5";
            this.Chk_Box5.UseVisualStyleBackColor = true;
            // 
            // Chk_R1
            // 
            this.Chk_R1.AutoSize = true;
            this.Chk_R1.Checked = true;
            this.Chk_R1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Chk_R1.Location = new System.Drawing.Point(7, 142);
            this.Chk_R1.Name = "Chk_R1";
            this.Chk_R1.Size = new System.Drawing.Size(36, 16);
            this.Chk_R1.TabIndex = 21;
            this.Chk_R1.Text = "R1";
            this.Chk_R1.UseVisualStyleBackColor = true;
            // 
            // Chk_Box4
            // 
            this.Chk_Box4.AutoSize = true;
            this.Chk_Box4.Checked = true;
            this.Chk_Box4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Chk_Box4.Location = new System.Drawing.Point(7, 122);
            this.Chk_Box4.Name = "Chk_Box4";
            this.Chk_Box4.Size = new System.Drawing.Size(54, 16);
            this.Chk_Box4.TabIndex = 21;
            this.Chk_Box4.Text = "Head4";
            this.Chk_Box4.UseVisualStyleBackColor = true;
            // 
            // Chk_Box3
            // 
            this.Chk_Box3.AutoSize = true;
            this.Chk_Box3.Checked = true;
            this.Chk_Box3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Chk_Box3.Location = new System.Drawing.Point(146, 100);
            this.Chk_Box3.Name = "Chk_Box3";
            this.Chk_Box3.Size = new System.Drawing.Size(54, 16);
            this.Chk_Box3.TabIndex = 21;
            this.Chk_Box3.Text = "Head3";
            this.Chk_Box3.UseVisualStyleBackColor = true;
            // 
            // Chk_Box2
            // 
            this.Chk_Box2.AutoSize = true;
            this.Chk_Box2.Checked = true;
            this.Chk_Box2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Chk_Box2.Location = new System.Drawing.Point(77, 100);
            this.Chk_Box2.Name = "Chk_Box2";
            this.Chk_Box2.Size = new System.Drawing.Size(54, 16);
            this.Chk_Box2.TabIndex = 21;
            this.Chk_Box2.Text = "Head2";
            this.Chk_Box2.UseVisualStyleBackColor = true;
            // 
            // Chk_Box1
            // 
            this.Chk_Box1.AutoSize = true;
            this.Chk_Box1.Location = new System.Drawing.Point(7, 100);
            this.Chk_Box1.Name = "Chk_Box1";
            this.Chk_Box1.Size = new System.Drawing.Size(54, 16);
            this.Chk_Box1.TabIndex = 21;
            this.Chk_Box1.Text = "Head1";
            this.Chk_Box1.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(110, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 12);
            this.label8.TabIndex = 19;
            this.label8.Text = "R速度";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(110, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 12);
            this.label7.TabIndex = 19;
            this.label7.Text = "R延时";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 19;
            this.label5.Text = "测试速度";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 19;
            this.label4.Text = "来回延时";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(110, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 19;
            this.label6.Text = "角度";
            // 
            // Txt_RPf
            // 
            this.Txt_RPf.Location = new System.Drawing.Point(169, 64);
            this.Txt_RPf.Name = "Txt_RPf";
            this.Txt_RPf.Size = new System.Drawing.Size(39, 21);
            this.Txt_RPf.TabIndex = 18;
            this.Txt_RPf.Text = "0";
            // 
            // Txt_RDelay
            // 
            this.Txt_RDelay.Location = new System.Drawing.Point(169, 42);
            this.Txt_RDelay.Name = "Txt_RDelay";
            this.Txt_RDelay.Size = new System.Drawing.Size(39, 21);
            this.Txt_RDelay.TabIndex = 18;
            this.Txt_RDelay.Text = "100";
            // 
            // Txt_TestPf
            // 
            this.Txt_TestPf.Location = new System.Drawing.Point(65, 68);
            this.Txt_TestPf.Name = "Txt_TestPf";
            this.Txt_TestPf.Size = new System.Drawing.Size(39, 21);
            this.Txt_TestPf.TabIndex = 18;
            this.Txt_TestPf.Text = "3";
            // 
            // Txt_DelayTime
            // 
            this.Txt_DelayTime.Location = new System.Drawing.Point(65, 44);
            this.Txt_DelayTime.Name = "Txt_DelayTime";
            this.Txt_DelayTime.Size = new System.Drawing.Size(39, 21);
            this.Txt_DelayTime.TabIndex = 18;
            this.Txt_DelayTime.Text = "100";
            // 
            // Txt_RDis
            // 
            this.Txt_RDis.Location = new System.Drawing.Point(169, 20);
            this.Txt_RDis.Name = "Txt_RDis";
            this.Txt_RDis.Size = new System.Drawing.Size(39, 21);
            this.Txt_RDis.TabIndex = 18;
            this.Txt_RDis.Text = "5";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Btn_CardInit);
            this.groupBox2.Controls.Add(this.Txt_CanNum);
            this.groupBox2.Controls.Add(this.Btn_ServoOff);
            this.groupBox2.Controls.Add(this.Txt_CardNum);
            this.groupBox2.Controls.Add(this.Btn_ServoOn);
            this.groupBox2.Controls.Add(this.Btn_CanInit);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.Btn_Home);
            this.groupBox2.Location = new System.Drawing.Point(10, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(229, 156);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "初始化";
            // 
            // Lab_RTotal
            // 
            this.Lab_RTotal.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Lab_RTotal.Font = new System.Drawing.Font("楷体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Lab_RTotal.Location = new System.Drawing.Point(256, 145);
            this.Lab_RTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Lab_RTotal.Name = "Lab_RTotal";
            this.Lab_RTotal.Size = new System.Drawing.Size(322, 104);
            this.Lab_RTotal.TabIndex = 13;
            this.Lab_RTotal.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 436);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Lst_Msg);
            this.Controls.Add(this.Lab_RTotal);
            this.Controls.Add(this.Lab_Total);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox Txt_CanNum;
        private System.Windows.Forms.TextBox Txt_CardNum;
        private System.Windows.Forms.Button Btn_CanInit;
        private System.Windows.Forms.Button Btn_CardInit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Btn_Home;
        private System.Windows.Forms.Label Lab_Total;
        private System.Windows.Forms.ListBox Lst_Msg;
        private System.Windows.Forms.Button Btn_ServoOn;
        private System.Windows.Forms.Button Btn_ServoOff;
        private System.Windows.Forms.Button Btn_Test;
        private System.Windows.Forms.TextBox Txt_TestDis;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox Chk_Box1;
        private System.Windows.Forms.CheckBox Chk_Box6;
        private System.Windows.Forms.CheckBox Chk_Box5;
        private System.Windows.Forms.CheckBox Chk_Box4;
        private System.Windows.Forms.CheckBox Chk_Box3;
        private System.Windows.Forms.CheckBox Chk_Box2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Txt_TestPf;
        private System.Windows.Forms.TextBox Txt_DelayTime;
        private System.Windows.Forms.CheckBox Chk_R2;
        private System.Windows.Forms.CheckBox Chk_R1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Txt_RDis;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox Txt_RPf;
        private System.Windows.Forms.TextBox Txt_RDelay;
        private System.Windows.Forms.Label Lab_RTotal;
    }
}

