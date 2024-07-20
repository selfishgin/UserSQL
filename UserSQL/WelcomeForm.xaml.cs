using System.Windows.Controls;

namespace UserSQL
{
    public partial class WelcomeForm : Page
    {
        public WelcomeForm(string userName)
        {
            InitializeComponent();
            lblWelcome.Content = "Welcome " + userName;
        }
    }
}
