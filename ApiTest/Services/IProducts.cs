using ApiTest.Contracts;

namespace ApiTest.Services
{
    public interface IProducts
    {
        Task<IEnumerable<Product>> GetAllProducts(string productName = "", string category = "");
        Task<Product> GetProductById(int id);
        Task<Product> CreateProduct(Product request);
        Task<Product> UpdateProduct(int productId, Product product);
    }
}
