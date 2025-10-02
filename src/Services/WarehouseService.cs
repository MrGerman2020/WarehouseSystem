using System.Collections.Generic;
using WarehouseSystem.Models;
using WarehouseSystem.Repositories;

namespace WarehouseSystem.Services
{
    /// <summary>
    /// Provides business logic for managing products in the warehouse.
    /// </summary>
    public class WarehouseService
    {
        private readonly ProductRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="WarehouseService"/> class.
        /// </summary>
        /// <param name="repository">The product repository for data access.</param>
        public WarehouseService(ProductRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Adds a new product to the warehouse.
        /// </summary>
        /// <param name="name">The product name.</param>
        /// <param name="category">The product category.</param>
        /// <param name="price">The product price.</param>
        public void AddProduct(string name, string category, double price)
        {
            var product = new Product(0, name, category, price);
            _repository.AddProduct(product);
        }

        /// <summary>
        /// Retrieves all products in the warehouse.
        /// </summary>
        /// <returns>A list of all products.</returns>
        public List<Product> GetAllProducts()
        {
            return _repository.GetAllProducts();
        }
    }
}
