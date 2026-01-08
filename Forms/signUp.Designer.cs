namespace foodDeliveryManagementSys.Forms
{
    partial class signUp
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
            label4 = new Label();
            label5 = new Label();
            printDialog1 = new PrintDialog();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            cmbRole = new ComboBox();
            button1 = new Button();
            label6 = new Label();
            textBox4 = new TextBox();
            pnlRestaurant = new Panel();
            txtResRating = new TextBox();
            txtResLocation = new TextBox();
            txtResName = new TextBox();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            pnlRestaurant.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.Info;
            label1.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(325, 23);
            label1.Name = "label1";
            label1.Size = new Size(115, 32);
            label1.TabIndex = 0;
            label1.Text = "SIGN UP";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(186, 97);
            label2.Name = "label2";
            label2.Size = new Size(113, 25);
            label2.TabIndex = 1;
            label2.Text = "Enter Name :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(186, 155);
            label3.Name = "label3";
            label3.Size = new Size(71, 25);
            label3.TabIndex = 2;
            label3.Text = "Phone :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(186, 275);
            label4.Name = "label4";
            label4.Size = new Size(96, 25);
            label4.TabIndex = 3;
            label4.Text = "Password :";
            label4.Click += label4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(186, 334);
            label5.Name = "label5";
            label5.Size = new Size(55, 25);
            label5.TabIndex = 4;
            label5.Text = "Role :";
            // 
            // printDialog1
            // 
            printDialog1.UseEXDialog = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(305, 97);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(276, 31);
            textBox1.TabIndex = 5;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(305, 155);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(276, 31);
            textBox2.TabIndex = 6;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(305, 215);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(276, 31);
            textBox3.TabIndex = 7;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // cmbRole
            // 
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.FormattingEnabled = true;
            cmbRole.Location = new Point(305, 334);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(276, 33);
            cmbRole.TabIndex = 8;
            cmbRole.SelectedIndexChanged += cmbRole_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.Info;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.ActiveCaptionText;
            button1.Location = new Point(265, 403);
            button1.Name = "button1";
            button1.Size = new Size(316, 44);
            button1.TabIndex = 9;
            button1.Text = "Sign up";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(186, 218);
            label6.Name = "label6";
            label6.Size = new Size(54, 25);
            label6.TabIndex = 10;
            label6.Text = "Email";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(305, 275);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(276, 31);
            textBox4.TabIndex = 11;
            // 
            // pnlRestaurant
            // 
            pnlRestaurant.Controls.Add(txtResRating);
            pnlRestaurant.Controls.Add(txtResLocation);
            pnlRestaurant.Controls.Add(txtResName);
            pnlRestaurant.Controls.Add(label10);
            pnlRestaurant.Controls.Add(label9);
            pnlRestaurant.Controls.Add(label8);
            pnlRestaurant.Controls.Add(label7);
            pnlRestaurant.Location = new Point(157, 58);
            pnlRestaurant.Name = "pnlRestaurant";
            pnlRestaurant.Size = new Size(463, 309);
            pnlRestaurant.TabIndex = 12;
            // 
            // txtResRating
            // 
            txtResRating.Location = new Point(187, 188);
            txtResRating.Name = "txtResRating";
            txtResRating.Size = new Size(241, 31);
            txtResRating.TabIndex = 6;
            // 
            // txtResLocation
            // 
            txtResLocation.Location = new Point(187, 142);
            txtResLocation.Name = "txtResLocation";
            txtResLocation.Size = new Size(241, 31);
            txtResLocation.TabIndex = 5;
            txtResLocation.TextChanged += textBox6_TextChanged;
            // 
            // txtResName
            // 
            txtResName.Location = new Point(190, 87);
            txtResName.Name = "txtResName";
            txtResName.Size = new Size(238, 31);
            txtResName.TabIndex = 4;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(87, 188);
            label10.Name = "label10";
            label10.Size = new Size(72, 25);
            label10.TabIndex = 3;
            label10.Text = "Rating: ";
            label10.Click += label10_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(71, 142);
            label9.Name = "label9";
            label9.Size = new Size(88, 25);
            label9.TabIndex = 2;
            label9.Text = "Location: ";
            label9.Click += label9_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(29, 90);
            label8.Name = "label8";
            label8.Size = new Size(156, 25);
            label8.TabIndex = 1;
            label8.Text = "Restaurant Name: ";
            label8.Click += label8_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = SystemColors.Info;
            label7.Location = new Point(29, 29);
            label7.Name = "label7";
            label7.Size = new Size(328, 25);
            label7.TabIndex = 0;
            label7.Text = "Extra information for restaurant Sign Up";
            // 
            // signUp
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(pnlRestaurant);
            Controls.Add(textBox4);
            Controls.Add(label6);
            Controls.Add(button1);
            Controls.Add(cmbRole);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "signUp";
            Text = "signUp";
            Load += signUp_Load;
            pnlRestaurant.ResumeLayout(false);
            pnlRestaurant.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private PrintDialog printDialog1;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private ComboBox cmbRole;
        private Button button1;
        private Label label6;
        private TextBox textBox4;
        private Panel pnlRestaurant;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private TextBox txtResRating;
        private TextBox txtResLocation;
        private TextBox txtResName;
    }
}