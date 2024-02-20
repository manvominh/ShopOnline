using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopOnline.Application.Dtos;
using ShopOnline.Application.Interfaces.Repositories;
using ShopOnline.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Application.Features.Products.Queries.GetProductsByCategory
{
	public record GetProductsByCategoryQuery(int Id) : IRequest<IEnumerable<ProductDto>>;
	public class GetProductsByCategoryQueryHandler : IRequestHandler<GetProductsByCategoryQuery, IEnumerable<ProductDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		public GetProductsByCategoryQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<IEnumerable<ProductDto>> Handle(GetProductsByCategoryQuery request, CancellationToken cancellationToken)
		{
			return await _unitOfWork.Repository<Product>().Entities
				.ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
				.Where(x => x.CategoryId == request.Id)
				.ToListAsync(cancellationToken);
		}
	}
}
