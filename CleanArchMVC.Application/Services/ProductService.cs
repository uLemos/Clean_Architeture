using CleanArchMVC.Application.DTOs;
using CleanArchMVC.Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMVC.Application.Services
{
    public class ProductService : IProductService
    {
        public Task Add(ProductDTO product)
        {
            throw new System.NotImplementedException();
        }

        public Task<ProductDTO> GetById(int? id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ProductDTO> GetProductCategory(int? id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<ProductDTO>> GetProducts()
        {
            throw new System.NotImplementedException();
        }

        public Task Remove(int? id)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(ProductDTO product)
        {
            throw new System.NotImplementedException();
        }
    }
}
