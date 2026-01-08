namespace foodDeliveryManagementSys.Forms
{
    partial class MenuForm
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
            signupbutton = new Button();
            signinbutton = new Button();
            updateprofilebutton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ScrollBar;
            label1.Font = new Font("Broadway", 20F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 43);
            label1.Name = "label1";
            label1.Size = new Size(893, 46);
            label1.TabIndex = 0;
            label1.Text = "FOOD DELIVERY MANAGEMENT SYSTEM";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // signupbutton
            // 
            signupbutton.Anchor = AnchorStyles.None;
            signupbutton.Location = new Point(368, 120);
            signupbutton.Name = "signupbutton";
            signupbutton.Size = new Size(175, 63);
            signupbutton.TabIndex = 1;
            signupbutton.Text = "Sign Up";
            signupbutton.UseVisualStyleBackColor = true;
            signupbutton.Click += signupbutton_Click;
            // 
            // signinbutton
            // 
            signinbutton.Anchor = AnchorStyles.None;
            signinbutton.Location = new Point(368, 222);
            signinbutton.Name = "signinbutton";
            signinbutton.Size = new Size(175, 63);
            signinbutton.TabIndex = 2;
            signinbutton.Text = "Sign In";
            signinbutton.UseVisualStyleBackColor = true;
            signinbutton.Click += signinbutton_Click;
            // 
            // updateprofilebutton
            // 
            updateprofilebutton.Anchor = AnchorStyles.None;
            updateprofilebutton.Location = new Point(368, 324);
            updateprofilebutton.Name = "updateprofilebutton";
            updateprofilebutton.Size = new Size(175, 63);
            updateprofilebutton.TabIndex = 3;
            updateprofilebutton.Text = "Update Profile";
            updateprofilebutton.UseVisualStyleBackColor = true;
            updateprofilebutton.Click += updateprofilebutton_Click;
            // 
            // MenuForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(935, 450);
            Controls.Add(updateprofilebutton);
            Controls.Add(signinbutton);
            Controls.Add(signupbutton);
            Controls.Add(label1);
            Name = "MenuForm";
            Text = "MenuForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button signupbutton;
        private Button signinbutton;
        private Button updateprofilebutton;
    }
}