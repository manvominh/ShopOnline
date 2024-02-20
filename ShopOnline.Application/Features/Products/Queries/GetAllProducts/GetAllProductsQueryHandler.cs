using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopOnline.Application.Dtos;
using ShopOnline.Application.Interfaces.Repositories;
using ShopOnline.Domain.Entities;

namespace ShopOnline.Application.Features.Products.Queries.GetAllProducts
{
	public record GetAllProductsQuery : IRequest<IEnumerable<ProductDto>>;
	public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		public GetAllProductsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<IEnumerable<ProductDto>> Handle(GetAllProductsQuery query, CancellationToken cancellationToken)
		{
			return await _unitOfWork.Repository<Product>().Entities
				.ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
				.ToListAsync(cancellationToken);
		}
	}
}
