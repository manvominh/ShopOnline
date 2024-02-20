using AutoMapper;
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

namespace ShopOnline.Application.Features.CartItems.Queries.GetAllCartItems
{
	public record GetCartItemsQuery(int UserId) : IRequest<IEnumerable<CartItemDto>>;
	public class GetCartItemsQueryHandler : IRequestHandler<GetCartItemsQuery, IEnumerable<CartItemDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public GetCartItemsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<IEnumerable<CartItemDto>> Handle(GetCartItemsQuery request, CancellationToken cancellationToken)
		{
			var carts = _unitOfWork.Repository<Cart>();
			var cartItems = _unitOfWork.Repository<CartItem>();
			var products = _unitOfWork.Repository<Product>().Entities;
			var cartItemsOfUser = await carts.Entities.Where(x => x.UserId == request.UserId).Join(cartItems.Entities, cart => cart.Id, cartItem => cartItem.CartId,
			   (cart, cartItem) => new CartItem
			   {
				   Id = cartItem.Id,
				   ProductId = cartItem.ProductId,
				   Qty = cartItem.Qty,
				   CartId = cartItem.CartId,
			   })
				//.ProjectTo<CartItemDto>(_mapper.ConfigurationProvider)
				.ToListAsync(cancellationToken);

			return (from cartItem in cartItemsOfUser
					join product in products
					on cartItem.ProductId equals product.Id
					select new CartItemDto
					{
						Id = cartItem.Id,
						ProductId = cartItem.ProductId,
						ProductName = product.Name,
						ProductDescription = product.Description,
						ProductImageURL = product.ImageURL,
						Price = product.Price,
						CartId = cartItem.CartId,
						Qty = cartItem.Qty,
						TotalPrice = product.Price * cartItem.Qty
					}).ToList();
			//var carts = await _unitOfWork.Repository<Cart>().Entities.Where(x => x.UserId == request.UserId).ToListAsync(cancellationToken).;
			//return await _unitOfWork.Repository<CartItem>().Entities.Where(x => x.CartId).ToListAsync(cancellationToken);
		}
	}
}
