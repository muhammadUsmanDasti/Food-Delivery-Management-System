using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace foodDeliveryManagementSys.Forms
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {

        }

        private void signupbutton_Click(object sender, EventArgs e)
        {
            signUp signUpForm = new signUp();
            signUpForm.ShowDialog();
        }

        private void signinbutton_Click(object sender, EventArgs e)
        {
            signIn signIpForm = new signIn();
            signIpForm.ShowDialog();
        }

        private void updateprofilebutton_Click(object sender, EventArgs e)
        {
            updateProfile updateProfileForm = new updateProfile();
            updateProfileForm.ShowDialog();
        }
    }
}
