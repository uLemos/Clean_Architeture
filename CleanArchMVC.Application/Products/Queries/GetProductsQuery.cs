using CleanArchMVC.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace CleanArchMVC.Application.Products.Queries
{
    public class GetProductsQuery : IRequest<IEnumerable<Product>>
    {

    }
}
