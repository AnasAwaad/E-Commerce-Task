using AutoMapper;
using E_Commerce.Application.Features.Products.Commands.CreateProduct;
using E_Commerce.Domain.Entities;

namespace E_Commerce.Application.Features.Products.DTOs;
internal class ProductProfile : Profile
{
	public ProductProfile()
	{
		CreateMap<CreateProductCommand, Product>();

		CreateMap<Product, ProductDto>()
			.ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
	}

}
