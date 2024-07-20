using System;
using System.Windows.Forms;

namespace UserSQL
{
    public partial class WelcomeForm : Form
    {
        public WelcomeForm(string userName)
        {
            InitializeComponent();
            lblWelcome.Text = "Welcome " + userName;
        }
    }
}
