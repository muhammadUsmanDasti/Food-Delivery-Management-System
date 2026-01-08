using FoodDeliveryManagementSystem.Users;

namespace foodDeliveryManagementSys.Forms
{
    partial class AdminDashboard
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
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            label1 = new Label();
            dataGridViewUsers = new DataGridView();
            panelDeleteUser = new Panel();
            buttonConfirmDelete = new Button();
            textBox1 = new TextBox();
            label2 = new Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsers).BeginInit();
            panelDeleteUser.SuspendLayout();
            SuspendLayout();
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            button3.Location = new Point(23, 299);
            button3.Name = "button3";
            button3.Size = new Size(193, 59);
            button3.TabIndex = 8;
            button3.Text = "Log Out";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            button2.Location = new Point(23, 206);
            button2.Name = "button2";
            button2.Size = new Size(193, 59);
            button2.TabIndex = 7;
            button2.Text = "Delete User";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(23, 97);
            button1.Name = "button1";
            button1.Size = new Size(193, 59);
            button1.TabIndex = 6;
            button1.Text = "View All Users";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.Info;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(249, 9);
            label1.Name = "label1";
            label1.Size = new Size(340, 45);
            label1.TabIndex = 5;
            label1.Text = "ADMIN DASHBOARD";
            label1.Click += label1_Click;
            // 
            // dataGridViewUsers
            // 
            dataGridViewUsers.AllowUserToAddRows = false;
            dataGridViewUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewUsers.BackgroundColor = SystemColors.HighlightText;
            dataGridViewUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewUsers.Location = new Point(303, 97);
            dataGridViewUsers.Name = "dataGridViewUsers";
            dataGridViewUsers.ReadOnly = true;
            dataGridViewUsers.RowHeadersWidth = 62;
            dataGridViewUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewUsers.Size = new Size(568, 322);
            dataGridViewUsers.TabIndex = 9;
            // 
            // panelDeleteUser
            // 
            panelDeleteUser.Controls.Add(buttonConfirmDelete);
            panelDeleteUser.Controls.Add(textBox1);
            panelDeleteUser.Controls.Add(label2);
            panelDeleteUser.Location = new Point(86, 451);
            panelDeleteUser.Name = "panelDeleteUser";
            panelDeleteUser.Size = new Size(503, 183);
            panelDeleteUser.TabIndex = 10;
            panelDeleteUser.Paint += panelDeleteUser_Paint;
            // 
            // buttonConfirmDelete
            // 
            buttonConfirmDelete.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonConfirmDelete.Location = new Point(152, 116);
            buttonConfirmDelete.Name = "buttonConfirmDelete";
            buttonConfirmDelete.Size = new Size(141, 50);
            buttonConfirmDelete.TabIndex = 2;
            buttonConfirmDelete.Text = "Delete";
            buttonConfirmDelete.UseVisualStyleBackColor = true;
            buttonConfirmDelete.Click += buttonConfirmDelete_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(260, 31);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(231, 31);
            textBox1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(0, 28);
            label2.Name = "label2";
            label2.Size = new Size(271, 32);
            label2.TabIndex = 0;
            label2.Text = "Enter User ID to Delete: ";
            // 
            // AdminDashboard
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(908, 664);
            Controls.Add(panelDeleteUser);
            Controls.Add(dataGridViewUsers);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "AdminDashboard";
            Text = "AdminDashboard";
            Load += AdminDashboard_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsers).EndInit();
            panelDeleteUser.ResumeLayout(false);
            panelDeleteUser.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button3;
        private Button button2;
        private Button button1;
        private Label label1;
        private DataGridView dataGridViewUsers;
        private Panel panelDeleteUser;
        private Button buttonConfirmDelete;
        private TextBox textBox1;
        private Label label2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}