namespace foodDeliveryManagementSys.Forms
{
    partial class RiderDashboard
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
            dataGridViewAvailableOrders = new DataGridView();
            panel1 = new Panel();
            button4 = new Button();
            textBox1 = new TextBox();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAvailableOrders).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            button3.Location = new Point(21, 319);
            button3.Name = "button3";
            button3.Size = new Size(216, 59);
            button3.TabIndex = 8;
            button3.Text = "Log Out";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            button2.Location = new Point(21, 223);
            button2.Name = "button2";
            button2.Size = new Size(299, 59);
            button2.TabIndex = 7;
            button2.Text = "Mark Order as Delivered";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(21, 126);
            button1.Name = "button1";
            button1.Size = new Size(299, 54);
            button1.TabIndex = 6;
            button1.Text = "View Available Orders";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.Info;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(220, 26);
            label1.Name = "label1";
            label1.Size = new Size(320, 45);
            label1.TabIndex = 5;
            label1.Text = "RIDER DASHBOARD";
            // 
            // dataGridViewAvailableOrders
            // 
            dataGridViewAvailableOrders.AllowUserToAddRows = false;
            dataGridViewAvailableOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewAvailableOrders.BackgroundColor = SystemColors.HighlightText;
            dataGridViewAvailableOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAvailableOrders.Location = new Point(345, 149);
            dataGridViewAvailableOrders.Name = "dataGridViewAvailableOrders";
            dataGridViewAvailableOrders.ReadOnly = true;
            dataGridViewAvailableOrders.RowHeadersWidth = 62;
            dataGridViewAvailableOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewAvailableOrders.Size = new Size(568, 312);
            dataGridViewAvailableOrders.TabIndex = 10;
            dataGridViewAvailableOrders.Enabled = true;
            dataGridViewAvailableOrders.CellDoubleClick += dataGridViewAvailableOrders_CellDoubleClick;



            // 
            // panel1
            // 
            panel1.Controls.Add(button4);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(51, 466);
            panel1.Name = "panel1";
            panel1.Size = new Size(702, 196);
            panel1.TabIndex = 11;
            // 
            // button4
            // 
            button4.BackColor = SystemColors.Info;
            button4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            button4.Location = new Point(210, 124);
            button4.Name = "button4";
            button4.Size = new Size(259, 42);
            button4.TabIndex = 2;
            button4.Text = "Mark as Delivered";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(428, 35);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(150, 31);
            textBox1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(12, 32);
            label2.Name = "label2";
            label2.Size = new Size(410, 32);
            label2.TabIndex = 0;
            label2.Text = "Enter Order ID to Mark As Delivered: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(345, 113);
            label3.Name = "label3";
            label3.Size = new Size(470, 32);
            label3.TabIndex = 12;
            label3.Text = "Double Click on the Order to Accept Order";
            label3.Click += label3_Click;
            // 
            // RiderDashboard
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(925, 671);
            Controls.Add(label3);
            Controls.Add(panel1);
            Controls.Add(dataGridViewAvailableOrders);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "RiderDashboard";
            Text = "RiderDashboard";
            Load += RiderDashboard_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewAvailableOrders).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button3;
        private Button button2;
        private Button button1;
        private Label label1;
        private DataGridView dataGridViewAvailableOrders;
        private Panel panel1;
        private Button button4;
        private TextBox textBox1;
        private Label label2;
        private Label label3;
    }
}