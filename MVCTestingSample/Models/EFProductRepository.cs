using Microsoft.EntityFrameworkCore;
using MVCTestingSample.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCTestingSample.Models
{
    public class EFProductRepository : IProductRepository
    {
        private readonly ProductDbContext _context;

        public EFProductRepository(ProductDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a Product to the data store
        /// </summary>
        /// <param name="p">The Product</param>
        /// <returns></returns>
        public Task AddProductAsync(Product p)
        {
            _context.Add(p);
            return _context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes a Product from the data store
        /// </summary>
        /// <param name="p">The Product</param>
        /// <returns></returns>
        public Task DeleteProductAsync(Product p)
        {
            _context.Remove(p);
            return _context.SaveChangesAsync();
        }

        /// <summary>
        /// Returns all Products from the data store
        /// </summary>
        /// <returns>List of Products</returns>
        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _context.Products.OrderBy(p => p.Name).ToListAsync();
        }

        /// <summary>
        /// Returns the Product by the id,
        /// or null if no product matches
        /// </summary>
        /// <param name="id">Product id</param>
        /// <returns>Product</returns>
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products
                           .Where(p => p.ProductId == id)
                           .SingleOrDefaultAsync();
        }

        public Task UpdateProductAsync(Product p)
        {
            _context.Entry(p).State = EntityState.Modified;
            return _context.SaveChangesAsync();
        }
    }
}
