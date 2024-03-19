using CrudApiProject.Data;
using CrudApiProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudApiProject.Services
{
    public class product_service
    {
        private readonly api_demo_db_class _dbContext;

        public product_service(api_demo_db_class dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<product_view_model>> GetAllProducts()
        {
            var products = await _dbContext.products.ToListAsync();
            var productViewModels = products.Select(p => new product_view_model
            {
                id = p.id,
                name = p.name,
                description = p.description,
                actual_price = p.actual_price,
                selling_price = p.selling_price,
                available_quantity = p.available_quantity
            }).ToList();
            return productViewModels;
        }

        public async Task<product_view_model> GetProductById(int id)
        {
            var product = await _dbContext.products.FindAsync(id);
            if (product != null)
            {
                var productViewModel = new product_view_model
                {
                    id = product.id,
                    name = product.name,
                    description = product.description,
                    actual_price = product.actual_price,
                    selling_price = product.selling_price,
                    available_quantity = product.available_quantity
                };
                return productViewModel;
            }
            return null;
        }

        public async Task<product_view_model> CreateProduct(product_view_model productViewModel)
        {
            var product = new products
            {
                name = productViewModel.name,
                description = productViewModel.description,
                actual_price = productViewModel.actual_price,
                selling_price = productViewModel.selling_price,
                available_quantity = productViewModel.available_quantity
            };
            _dbContext.products.Add(product);
            await _dbContext.SaveChangesAsync();
            productViewModel.id = product.id;
            return productViewModel;
        }

        public async Task UpdateProduct(int id, product_view_model productViewModel)
        {
            var product = await _dbContext.products.FindAsync(id);
            if (product != null)
            {
                product.name = productViewModel.name;
                product.description = productViewModel.description;
                product.actual_price = productViewModel.actual_price;
                product.selling_price = productViewModel.selling_price;
                product.available_quantity = productViewModel.available_quantity;
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteProduct(int id)
        {
            var product = await _dbContext.products.FindAsync(id);
            if (product != null)
            {
                _dbContext.products.Remove(product);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
