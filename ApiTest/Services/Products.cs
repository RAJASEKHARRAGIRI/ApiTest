using ApiTest.Contracts;
using ApiTest.Entity;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace ApiTest.Services
{
    public class Products : IProducts
    {
        private readonly AppDBContext _context;

        public Products(AppDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllProducts(string productName = "", string category = "")
        {
            if (productName.Length > 0 || category.Length > 0)
            {
                var p =  await _context.Products.ToListAsync();
                return p.Where(x => (x.Name.Contains(productName) || x.Category.Contains(category)));
            }

            var products = await _context.Products.ToListAsync();
            return products;
        }

        public async Task<Product> GetProductById(int id)
        {
            var result = await _context.Products.Where(x => x.Id == id).FirstOrDefaultAsync();
            return result;
        }

        public async Task<Product> CreateProduct(Product request)
        {
            var res = CheckProductExistsOrNot(request.Id);
            if (res)
            {
                return null;
            }

            await _context.AddAsync(new Product() { 
                Id = request.Id, 
                Name = request.Name, 
                Cost = request.Cost,
                Brand = request.Brand,
                Category = request.Category
            });
            _context.SaveChanges();
            return request;
        }

        public async Task<Product> UpdateProduct(int productId, Product product)
        {
            var res = CheckProductExistsOrNot(productId);
            if (!res)
            {
                return null;
            }
            var request = new Product() 
                            { Name = product.Name, 
                                Cost = product.Cost, 
                                Brand = product.Brand, 
                                Category = product.Category,
                                UpdatedDate = new DateTime(),
                            };
            _context.Entry(request).State = EntityState.Modified;
            await _context.SaveChangesAsync();
           
            return product;
        }

        private bool CheckProductExistsOrNot(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
