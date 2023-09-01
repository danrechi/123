using Npgsql;
using System;
using System.Windows;

namespace Wpf_cafe
{
    public partial class MainWindow : Window
    {
        private const string ConnectionString = "Host=localhost;Port=5432;Database=cafe;Username=postgres;Password=2104;";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordBox.Password;

            if (AuthenticateUser(username, password))
            {
                TableWindow tableWindow = new TableWindow();
                tableWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль.");
            }
        }

        private bool AuthenticateUser(string username, string password)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM admins WHERE Username = @Username AND Password = @Password";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                int count = Convert.ToInt32(command.ExecuteScalar());
                return count > 0;
            }
        }

    }
}
