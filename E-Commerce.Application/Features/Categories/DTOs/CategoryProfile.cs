using AutoMapper;
using E_Commerce.Application.Features.Categories.Commands.CreateCategory;
using E_Commerce.Application.Features.Categories.Commands.UpdateCategory;
using E_Commerce.Application.Features.Categories.DTOs;
using E_Commerce.Domain.Entities;

namespace E_Commerce.Application.Features.Products.DTOs;
internal class CategoryProfile : Profile
{
	public CategoryProfile()
	{
		CreateMap<CreateCategoryCommand, Category>();
		CreateMap<UpdateCategoryCommand, Category>();

		CreateMap<Category, CategoryDto>();
	}

}
