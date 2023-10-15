using CleanArchMVC.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMVC.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(int? id);

        //Task<Product> GetProductCategoryAsync(int? id);

        Task<Product> CreateAsync(Product product);
        Task<Product> UpdateAsync(Product product);
        Task<Product> RemoveAsync(Product product);
    }
}
