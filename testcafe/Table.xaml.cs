using System.Windows;
using System.Data;
using System.Data.SqlClient;
using System;
using System.Linq;

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
                connection.Open();
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
                connection.Open();
                string query = "SELECT * FROM Products";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                productsDataGrid.ItemsSource = dataTable.DefaultView;
            }
        }
        //
        // Обработчик события нажатия кнопки "Добавить продукт" (во вкладке "Food")
        private void AddFoodButton_Click(object sender, RoutedEventArgs e)
        {
            string foodType = foodTypeTextBox.Text;
            AddFood(foodType);
            LoadFoodData(); // Обновление данных в таблице после добавления
        }


        // Обработчик события нажатия кнопки "Удалить продукт" (во вкладке "Food")
        private void DeleteFoodButton_Click(object sender, RoutedEventArgs e)
        {
            DataRowView selectedRow = (DataRowView)foodDataGrid.SelectedItem;
            if (selectedRow != null)
            {
                int foodId = (int)selectedRow["Id"];
                DeleteFood(foodId);
                LoadFoodData(); // Обновление данных в таблице после удаления
            }
            else
            {
                MessageBox.Show("Выберите продукт для удаления.");
            }
        }

        // Обработчик события нажатия кнопки "Добавить продукт" (во вкладке "Products")
        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            string name = productNameTextBox.Text;
            string foodType = productFoodTypeTextBox.Text;
            decimal price = decimal.Parse(productPriceTextBox.Text);
            AddProduct(name, foodType, price);
            LoadProductsData(); // Обновление данных в таблице после добавления
        }


        // Обработчик события нажатия кнопки "Удалить продукт" (во вкладке "Products")
        private void DeleteProductButton_Click(object sender, RoutedEventArgs e)
        {
            DataRowView selectedRow = (DataRowView)productsDataGrid.SelectedItem;
            if (selectedRow != null)
            {
                int productId = (int)selectedRow["Id"];
                DeleteProduct(productId);
                LoadProductsData(); // Обновление данных в таблице после удаления
            }
            else
            {
                MessageBox.Show("Выберите продукт для удаления.");
            }
        }

        private void AddFood(string foodType)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "INSERT INTO Food (Type) VALUES (@Type)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Type", foodType);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Продукт успешно добавлен.");
                }
                else
                {
                    MessageBox.Show("Не удалось добавить продукт.");
                }
            }
        }


        private void DeleteFood(int foodId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "DELETE FROM Food WHERE Id = @FoodId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FoodId", foodId);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Продукт успешно удален.");
                }
                else
                {
                    MessageBox.Show("Не удалось удалить продукт.");
                }
            }
        }

        private void AddProduct(string name, string foodType, decimal price)
        {
            int foodTypeId;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "SELECT Id FROM Food WHERE Type = @FoodType";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FoodType", foodType);

                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    foodTypeId = (int)result;
                }
                else
                {
                    MessageBox.Show("Неверный тип продукта.");
                    return; // Прерывание операции добавления продукта
                }
            }

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "INSERT INTO Products (Name, FoodType, Price) VALUES (@Name, @FoodType, @Price)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@FoodType", foodTypeId);
                command.Parameters.AddWithValue("@Price", price);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Продукт успешно добавлен.");
                }
                else
                {
                    MessageBox.Show("Не удалось добавить продукт.");
                }
            }
        }

        private void DeleteProduct(int productId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "DELETE FROM Products WHERE Id = @ProductId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductId", productId);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Продукт успешно удален.");
                }
                else
                {
                    MessageBox.Show("Не удалось удалить продукт.");
                }
            }
        }
    }
}