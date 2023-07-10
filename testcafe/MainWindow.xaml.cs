using System.Data.SqlClient;
using System.Windows;

namespace Wpf_cafe
{
    public partial class MainWindow : Window
    {
        private const string ConnectionString = "Server=DESKTOP-PGFL9BA\\SQLEXPRESS;Database=master;Encrypt=False;Trusted_Connection=True";
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
                MessageBox.Show("Login successful!");
                TableWindow tableWindow = new TableWindow();
                tableWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }

        private bool AuthenticateUser(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }

    }
}
