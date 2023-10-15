using AutoMapper;
using CleanArchMVC.Application.DTOs;
using CleanArchMVC.Application.Products.Commands;

namespace CleanArchMVC.Application.Mappings
{
    public class DTOToCommandMappingProfile : Profile
    {
        public DTOToCommandMappingProfile()
        {
            CreateMap<ProductDTO, ProductCreateCommand>();
            CreateMap<ProductDTO, ProductUpdateCommand>();
        }
    }
}
