﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopOnline.Application.Dtos;
using ShopOnline.Application.Interfaces.Repositories;
using ShopOnline.Domain.Entities;


namespace ShopOnline.Application.Features.Products.Queries.GetProduct
{
	public record GetProductQuery(int Id) : IRequest<ProductDto>;
	public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductDto>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public GetProductQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<ProductDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
		{
			return await _unitOfWork.Repository<Product>().Entities
						.ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
						.Where(x => x.Id == request.Id)
						.FirstAsync(cancellationToken);
		}
	}
}
