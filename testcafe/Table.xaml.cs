using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace Wpf_cafe
{
    public partial class TableWindow : Window
    {
        private const string ConnectionString = "Server=DESKTOP-PGFL9BA\\SQLEXPRESS;Database=master;Encrypt=False;Trusted_Connection=True";

        public TableWindow()
        {
            InitializeComponent();
            LoadFoodData();
            LoadProductsData();
        }

        private void LoadFoodData()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string query = "SELECT * FROM Food";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                foodDataGrid.ItemsSource = dataTable.DefaultView;
            }
        }

        private void LoadProductsData()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string query = "SELECT * FROM Products";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                productsDataGrid.ItemsSource = dataTable.DefaultView;
            }
        }
    }
}