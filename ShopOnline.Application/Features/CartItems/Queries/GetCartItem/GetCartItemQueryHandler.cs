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

namespace ShopOnline.Application.Features.CartItems.Queries.GetCartItem
{
	public record GetCartItemQuery(int Id) : IRequest<CartItemDto>;
	public class GetCartItemQueryHandler : IRequestHandler<GetCartItemQuery, CartItemDto>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public GetCartItemQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<CartItemDto> Handle(GetCartItemQuery request, CancellationToken cancellationToken)
		{
			return await _unitOfWork.Repository<CartItem>().Entities
				.Where(x => x.CartId == request.Id)
				.ProjectTo<CartItemDto>(_mapper.ConfigurationProvider)
				.FirstAsync(cancellationToken);
		}
	}
}
