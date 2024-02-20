using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopOnline.Application.Dtos;
using ShopOnline.Application.Interfaces.Repositories;
using ShopOnline.Domain.Entities;

namespace ShopOnline.Application.Features.ProductCategories.Queries.GetAllCategories
{
	public record GetAllCategoriesQuery : IRequest<IEnumerable<ProductCategoryDto>>;
	public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, IEnumerable<ProductCategoryDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public GetAllCategoriesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<IEnumerable<ProductCategoryDto>> Handle(GetAllCategoriesQuery query, CancellationToken cancellationToken)
		{
			return await _unitOfWork.Repository<ProductCategory>().Entities
				.ProjectTo<ProductCategoryDto>(_mapper.ConfigurationProvider)
				.ToListAsync(cancellationToken);
		}
	}
}
