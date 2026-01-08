namespace foodDeliveryManagementSys.Forms
{
    partial class updateProfile
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox4 = new TextBox();
            label8 = new Label();
            label7 = new Label();
            label4 = new Label();
            label5 = new Label();
            textBox6 = new TextBox();
            textBox5 = new TextBox();
            textBox3 = new TextBox();
            cmbRole = new ComboBox();
            label6 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.Info;
            label1.Font = new Font("Segoe UI Black", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(249, 25);
            label1.Name = "label1";
            label1.Size = new Size(290, 45);
            label1.TabIndex = 0;
            label1.Text = "UPDATE PROFILE";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(91, 94);
            label2.Name = "label2";
            label2.Size = new Size(137, 32);
            label2.TabIndex = 1;
            label2.Text = "Your Email: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(51, 151);
            label3.Name = "label3";
            label3.Size = new Size(177, 32);
            label3.TabIndex = 2;
            label3.Text = "Your Password: ";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(222, 97);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(317, 31);
            textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(222, 154);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(317, 31);
            textBox2.TabIndex = 5;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(241, 398);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(276, 31);
            textBox4.TabIndex = 22;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(132, 226);
            label8.Name = "label8";
            label8.Size = new Size(108, 25);
            label8.TabIndex = 13;
            label8.Text = "New Name :";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(124, 284);
            label7.Name = "label7";
            label7.Size = new Size(111, 25);
            label7.TabIndex = 14;
            label7.Text = "New Phone :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(111, 398);
            label4.Name = "label4";
            label4.Size = new Size(136, 25);
            label4.TabIndex = 15;
            label4.Text = "New Password :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(156, 460);
            label5.Name = "label5";
            label5.Size = new Size(95, 25);
            label5.TabIndex = 16;
            label5.Text = "New Role :";
            // 
            // textBox6
            // 
            textBox6.Location = new Point(241, 220);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(276, 31);
            textBox6.TabIndex = 17;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(241, 278);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(276, 31);
            textBox5.TabIndex = 18;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(241, 338);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(276, 31);
            textBox3.TabIndex = 19;
            // 
            // cmbRole
            // 
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.FormattingEnabled = true;
            cmbRole.Location = new Point(241, 457);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(276, 33);
            cmbRole.TabIndex = 20;
            cmbRole.SelectedIndexChanged += cmbRole_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(132, 344);
            label6.Name = "label6";
            label6.Size = new Size(103, 25);
            label6.TabIndex = 21;
            label6.Text = "New Email: ";
            // 
            // button1
            // 
            button1.BackColor = SystemColors.Info;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(266, 511);
            button1.Name = "button1";
            button1.Size = new Size(226, 52);
            button1.TabIndex = 23;
            button1.Text = "Update Profile";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // updateProfile
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(839, 575);
            Controls.Add(button1);
            Controls.Add(textBox4);
            Controls.Add(label6);
            Controls.Add(cmbRole);
            Controls.Add(textBox3);
            Controls.Add(textBox5);
            Controls.Add(textBox6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label7);
            Controls.Add(label8);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "updateProfile";
            Text = "updateProfile";
            Load += updateProfile_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox4;
        private Label label8;
        private Label label7;
        private Label label4;
        private Label label5;
        private TextBox textBox6;
        private TextBox textBox5;
        private TextBox textBox3;
        private ComboBox cmbRole;
        private Label label6;
        private Button button1;
    }
}