﻿namespace Val
{
    partial class valForm1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(valForm1));
            this.label1 = new System.Windows.Forms.Label();
            this.buildValButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.diameterShaftUpDown1 = new Val.ParameterUpDown();
            this.lengthShaftUpDown1 = new Val.ParameterUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.diameterShaftUpDown2 = new Val.ParameterUpDown();
            this.lengthShaftUpDown2 = new Val.ParameterUpDown();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.diameterShaftUpDown3 = new Val.ParameterUpDown();
            this.lengthShaftUpDown3 = new Val.ParameterUpDown();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.diameterShaftUpDown4 = new Val.ParameterUpDown();
            this.lengthShaftUpDown4 = new Val.ParameterUpDown();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.diameterShaftUpDown5 = new Val.ParameterUpDown();
            this.lengthShaftUpDown5 = new Val.ParameterUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.pictureBoxVal = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVal)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(209, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(282, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Вал пятиступенчатый";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // buildValButton
            // 
            this.buildValButton.Location = new System.Drawing.Point(297, 435);
            this.buildValButton.Name = "buildValButton";
            this.buildValButton.Size = new System.Drawing.Size(109, 35);
            this.buildValButton.TabIndex = 26;
            this.buildValButton.Text = "Построить";
            this.buildValButton.UseVisualStyleBackColor = true;
            this.buildValButton.Click += new System.EventHandler(this.buildPiston_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.diameterShaftUpDown1);
            this.groupBox1.Controls.Add(this.lengthShaftUpDown1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(15, 203);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 71);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Размеры первой ступени вала";
            // 
            // diameterShaftUpDown1
            // 
            this.diameterShaftUpDown1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.diameterShaftUpDown1.Location = new System.Drawing.Point(88, 45);
            this.diameterShaftUpDown1.Name = "diameterShaftUpDown1";
            this.diameterShaftUpDown1.Parameter = null;
            this.diameterShaftUpDown1.Size = new System.Drawing.Size(106, 20);
            this.diameterShaftUpDown1.TabIndex = 3;
            // 
            // lengthShaftUpDown1
            // 
            this.lengthShaftUpDown1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.lengthShaftUpDown1.Location = new System.Drawing.Point(88, 19);
            this.lengthShaftUpDown1.Name = "lengthShaftUpDown1";
            this.lengthShaftUpDown1.Parameter = null;
            this.lengthShaftUpDown1.Size = new System.Drawing.Size(106, 20);
            this.lengthShaftUpDown1.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Диаметр";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Длина";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.diameterShaftUpDown2);
            this.groupBox2.Controls.Add(this.lengthShaftUpDown2);
            this.groupBox2.Location = new System.Drawing.Point(231, 203);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 71);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Размеры второй ступени вала";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Диаметр";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Длина";
            // 
            // diameterShaftUpDown2
            // 
            this.diameterShaftUpDown2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.diameterShaftUpDown2.Location = new System.Drawing.Point(88, 45);
            this.diameterShaftUpDown2.Name = "diameterShaftUpDown2";
            this.diameterShaftUpDown2.Parameter = null;
            this.diameterShaftUpDown2.Size = new System.Drawing.Size(106, 20);
            this.diameterShaftUpDown2.TabIndex = 1;
            // 
            // lengthShaftUpDown2
            // 
            this.lengthShaftUpDown2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.lengthShaftUpDown2.Location = new System.Drawing.Point(88, 19);
            this.lengthShaftUpDown2.Name = "lengthShaftUpDown2";
            this.lengthShaftUpDown2.Parameter = null;
            this.lengthShaftUpDown2.Size = new System.Drawing.Size(106, 20);
            this.lengthShaftUpDown2.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.diameterShaftUpDown3);
            this.groupBox3.Controls.Add(this.lengthShaftUpDown3);
            this.groupBox3.Location = new System.Drawing.Point(458, 203);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 71);
            this.groupBox3.TabIndex = 29;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Размеры третьей ступени вала";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Диаметр";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Длина";
            // 
            // diameterShaftUpDown3
            // 
            this.diameterShaftUpDown3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.diameterShaftUpDown3.Location = new System.Drawing.Point(88, 45);
            this.diameterShaftUpDown3.Name = "diameterShaftUpDown3";
            this.diameterShaftUpDown3.Parameter = null;
            this.diameterShaftUpDown3.Size = new System.Drawing.Size(106, 20);
            this.diameterShaftUpDown3.TabIndex = 1;
            // 
            // lengthShaftUpDown3
            // 
            this.lengthShaftUpDown3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.lengthShaftUpDown3.Location = new System.Drawing.Point(88, 19);
            this.lengthShaftUpDown3.Name = "lengthShaftUpDown3";
            this.lengthShaftUpDown3.Parameter = null;
            this.lengthShaftUpDown3.Size = new System.Drawing.Size(106, 20);
            this.lengthShaftUpDown3.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.diameterShaftUpDown4);
            this.groupBox4.Controls.Add(this.lengthShaftUpDown4);
            this.groupBox4.Location = new System.Drawing.Point(127, 298);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 71);
            this.groupBox4.TabIndex = 30;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Размеры четвертой ступени вала";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Диаметр";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Длина";
            // 
            // diameterShaftUpDown4
            // 
            this.diameterShaftUpDown4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.diameterShaftUpDown4.Location = new System.Drawing.Point(88, 45);
            this.diameterShaftUpDown4.Name = "diameterShaftUpDown4";
            this.diameterShaftUpDown4.Parameter = null;
            this.diameterShaftUpDown4.Size = new System.Drawing.Size(106, 20);
            this.diameterShaftUpDown4.TabIndex = 1;
            // 
            // lengthShaftUpDown4
            // 
            this.lengthShaftUpDown4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.lengthShaftUpDown4.Location = new System.Drawing.Point(88, 18);
            this.lengthShaftUpDown4.Name = "lengthShaftUpDown4";
            this.lengthShaftUpDown4.Parameter = null;
            this.lengthShaftUpDown4.Size = new System.Drawing.Size(106, 20);
            this.lengthShaftUpDown4.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.diameterShaftUpDown5);
            this.groupBox5.Controls.Add(this.lengthShaftUpDown5);
            this.groupBox5.Location = new System.Drawing.Point(377, 298);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(200, 71);
            this.groupBox5.TabIndex = 31;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Размеры пятой ступени вала";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 52);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 13);
            this.label11.TabIndex = 3;
            this.label11.Text = "Диаметр";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Длина";
            // 
            // diameterShaftUpDown5
            // 
            this.diameterShaftUpDown5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.diameterShaftUpDown5.Location = new System.Drawing.Point(88, 45);
            this.diameterShaftUpDown5.Name = "diameterShaftUpDown5";
            this.diameterShaftUpDown5.Parameter = null;
            this.diameterShaftUpDown5.Size = new System.Drawing.Size(106, 20);
            this.diameterShaftUpDown5.TabIndex = 1;
            // 
            // lengthShaftUpDown5
            // 
            this.lengthShaftUpDown5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.lengthShaftUpDown5.Location = new System.Drawing.Point(88, 19);
            this.lengthShaftUpDown5.Name = "lengthShaftUpDown5";
            this.lengthShaftUpDown5.Parameter = null;
            this.lengthShaftUpDown5.Size = new System.Drawing.Size(106, 20);
            this.lengthShaftUpDown5.TabIndex = 0;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(150, 399);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(389, 13);
            this.label12.TabIndex = 32;
            this.label12.Text = "Размеры шпоночного паза задаются в соответствии с диаметром ступени";
            // 
            // pictureBoxVal
            // 
            this.pictureBoxVal.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxVal.Image")));
            this.pictureBoxVal.Location = new System.Drawing.Point(80, 57);
            this.pictureBoxVal.Name = "pictureBoxVal";
            this.pictureBoxVal.Size = new System.Drawing.Size(510, 126);
            this.pictureBoxVal.TabIndex = 33;
            this.pictureBoxVal.TabStop = false;
            // 
            // valForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 522);
            this.Controls.Add(this.pictureBoxVal);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buildValButton);
            this.Controls.Add(this.label1);
            this.Name = "valForm1";
            this.Text = "Построение вала";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buildValButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private ParameterUpDown diameterShaftUpDown1;
        private ParameterUpDown lengthShaftUpDown1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private ParameterUpDown diameterShaftUpDown2;
        private ParameterUpDown lengthShaftUpDown2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private ParameterUpDown diameterShaftUpDown3;
        private ParameterUpDown lengthShaftUpDown3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private ParameterUpDown diameterShaftUpDown4;
        private ParameterUpDown lengthShaftUpDown4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private ParameterUpDown diameterShaftUpDown5;
        private ParameterUpDown lengthShaftUpDown5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox pictureBoxVal;

    }
}

