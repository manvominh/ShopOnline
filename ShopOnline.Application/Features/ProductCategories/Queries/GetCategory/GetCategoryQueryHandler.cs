using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopOnline.Application.Dtos;
using ShopOnline.Application.Interfaces.Repositories;
using ShopOnline.Domain.Entities;

namespace ShopOnline.Application.Features.ProductCategories.Queries.GetCategory
{
	public record GetCategoryQuery(int Id) : IRequest<ProductCategoryDto>;
	public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, ProductCategoryDto>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public GetCategoryQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<ProductCategoryDto> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
		{
			return await _unitOfWork.Repository<ProductCategory>().Entities
				.ProjectTo<ProductCategoryDto>(_mapper.ConfigurationProvider)
				.Where(x => x.Id == request.Id).FirstAsync(cancellationToken);
		}
	}
}
