using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace UserSQL
{
    public partial class SignUpForm : Page
    {
        public SignUpForm()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text;
            string surname = txtSurname.Text;
            if (!int.TryParse(txtAge.Text, out int age))
            {
                MessageBox.Show("Invalid age.");
                return;
            }
            string login = txtLogin.Text;
            string password = txtPassword.Password;
            string confirmPassword = txtConfirmPassword.Password;

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(@"Server=localhost;Database=Users;User Id=DANTES-PC;Integrated Security=True;")) 
            {
                conn.Open();
                string query = "INSERT INTO Users (Name, Surname, Age, Login, Password) VALUES (@name, @surname, @age, @login, @password)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@surname", surname);
                    cmd.Parameters.AddWithValue("@age", age);
                    cmd.Parameters.AddWithValue("@login", login);
                    cmd.Parameters.AddWithValue("@password", password);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("User registered successfully.");
                        NavigationService.Navigate(new LoginForm());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }
    }
}
