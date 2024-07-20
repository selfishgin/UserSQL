using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace UserSQL
{
    public partial class LoginForm : Page
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            string login = txtLogin.Text;
            string password = txtPassword.Password;

            using (SqlConnection conn = new SqlConnection(@"Server=localhost;Database=Users;User Id=DANTES-PC;Integrated Security=True;"))
            {
                conn.Open();
                string query = "SELECT Name FROM Users WHERE Login = @login AND Password = @password";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@login", login);
                    cmd.Parameters.AddWithValue("@password", password);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        string name = reader["Name"].ToString();
                        WelcomeForm welcomeForm = new WelcomeForm(name);
                        NavigationService.Navigate(welcomeForm);
                    }
                    else
                    {
                        MessageBox.Show("Invalid login or password.");
                    }
                }
            }
        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            SignUpForm signUpForm = new SignUpForm();
            NavigationService.Navigate(signUpForm);
        }
    }
}
