using System.Windows;
using System.Data;
using Npgsql;
using System;
using System.Linq;

namespace Wpf_cafe
{
    public partial class TableWindow : Window
    {
        private const string ConnectionString = "Host=localhost;Port=5432;Database=cafe;Username=postgres;Password=2104;";

        public TableWindow()
        {
            InitializeComponent();
            LoadFoodData();
            LoadProductsData();
        }

        private void LoadFoodData()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Food";
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                foodDataGrid.ItemsSource = dataTable.DefaultView;
            }
        }

        private void LoadProductsData()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Products";
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                productsDataGrid.ItemsSource = dataTable.DefaultView;
            }
        }
        //
        //Обработчик нажатия кнопки "Добавить продукт" во вкладке "Food"
        private void AddFoodButton_Click(object sender, RoutedEventArgs e)
        {
            string foodType = foodTypeTextBox.Text;
            AddFood(foodType);
            LoadFoodData(); //Чтобы данные обновились после изменения
        }


        //Обработчик нажатия кнопки "Удалить продукт" во вкладке "Food"
        private void DeleteFoodButton_Click(object sender, RoutedEventArgs e)
        {
            DataRowView selectedRow = (DataRowView)foodDataGrid.SelectedItem;
            if (selectedRow != null)
            {
                int foodId = (int)selectedRow["Id"];
                DeleteFood(foodId);
                LoadFoodData();
            }
            else
            {
                MessageBox.Show("Выберите продукт для удаления.");
            }
        }

        //Обработчик нажатия кнопки "Добавить продукт" во вкладке "Products"
        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            string name = productNameTextBox.Text;
            string foodType = productFoodTypeTextBox.Text;
            decimal price = decimal.Parse(productPriceTextBox.Text);
            AddProduct(name, foodType, price);
            LoadProductsData();
        }


        //Обработчик нажатия кнопки "Удалить продукт" во вкладке "Products"
        private void DeleteProductButton_Click(object sender, RoutedEventArgs e)
        {
            DataRowView selectedRow = (DataRowView)productsDataGrid.SelectedItem;
            if (selectedRow != null)
            {
                int productId = (int)selectedRow["Id"];
                DeleteProduct(productId);
                LoadProductsData();
            }
            else
            {
                MessageBox.Show("Выберите продукт для удаления.");
            }
        }

        private void AddFood(string foodType)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "INSERT INTO Food (Type) VALUES (@Type)";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
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
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "DELETE FROM Food WHERE Id = @FoodId";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
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
            if (int.TryParse(foodType, out foodTypeId))
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO Products (Name, FoodType, Price) VALUES (@Name, @FoodType, @Price)";
                    NpgsqlCommand command = new NpgsqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@FoodType", foodTypeId);
                    command.Parameters.AddWithValue("@Price", price);
                    try
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Продукт успешно добавлен.");
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Не удалось добавить продукт.");
                    }
                    
                }
            }
            else
            {
                MessageBox.Show("Неверный тип продукта.");
            }
        }

        private void DeleteProduct(int productId)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "DELETE FROM Products WHERE Id = @ProductId";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
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