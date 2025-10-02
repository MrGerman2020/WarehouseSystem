using System.Collections.Generic;
using System.Data.SQLite;
using WarehouseSystem.Models;

namespace WarehouseSystem.Repositories
{
    /// <summary>
    /// Manages data access for products using SQLite database.
    /// </summary>
    public class ProductRepository
    {
        private readonly string _connectionString = "Data Source=warehouse.db;Version=3;";

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductRepository"/> class and creates the database table if it does not exist.
        /// </summary>
        public ProductRepository()
        {
            InitializeDatabase();
        }

        /// <summary>
        /// Creates the Products table in the SQLite database.
        /// </summary>
        private void InitializeDatabase()
        {
            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();
            var command = new SQLiteCommand(
                "CREATE TABLE IF NOT EXISTS Products (Id INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT NOT NULL, Category TEXT NOT NULL, Price REAL NOT NULL)",
                connection);
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Adds a product to the database.
        /// </summary>
        /// <param name="product">The product to add.</param>
        public void AddProduct(Product product)
        {
            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();
            var command = new SQLiteCommand(
                "INSERT INTO Products (Name, Category, Price) VALUES (@name, @category, @price)",
                connection);
            command.Parameters.AddWithValue("@name", product.Name);
            command.Parameters.AddWithValue("@category", product.Category);
            command.Parameters.AddWithValue("@price", product.Price);
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Retrieves all products from the database.
        /// </summary>
        /// <returns>A list of all products.</returns>
        public List<Product> GetAllProducts()
        {
            var products = new List<Product>();
            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();
            var command = new SQLiteCommand("SELECT * FROM Products", connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                products.Add(new Product(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetDouble(3)
                ));
            }
            return products;
        }
    }
}
