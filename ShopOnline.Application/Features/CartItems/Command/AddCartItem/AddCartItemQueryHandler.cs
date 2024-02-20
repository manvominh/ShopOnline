using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopOnline.Application.Dtos;
using ShopOnline.Application.Interfaces.Repositories;
using ShopOnline.Domain.Entities;

namespace ShopOnline.Application.Features.CartItems.Command.AddCartItem
{
	public record AddCartItemQuery(CartItemToAddDto CartItemToAddDto) : IRequest<CartItemDto>;
	public class AddCartItemQueryHandler : IRequestHandler<AddCartItemQuery, CartItemDto>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public AddCartItemQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<CartItemDto> Handle(AddCartItemQuery request, CancellationToken cancellationToken)
		{
			if (await CartItemExists(request.CartItemToAddDto.CartId, request.CartItemToAddDto.ProductId) == false)
			{
				var product = await _unitOfWork.Repository<Product>().Entities.Where(x => x.Id == request.CartItemToAddDto.ProductId).FirstAsync(cancellationToken);

				var cartItem = new CartItem()
				{
					CartId = request.CartItemToAddDto.CartId,
					ProductId = product.Id,
					Qty = request.CartItemToAddDto.Qty,
				};
				if (cartItem != null)
				{
					var result = await _unitOfWork.Repository<CartItem>().AddAsync(cartItem);
					await _unitOfWork.Save(cancellationToken);

					//var cartItemDto = await _unitOfWork.Repository<CartItem>().Entities
					//    .Where(x => x.Id == result.Id)
					//    .ProjectTo<CartItemDto>(_mapper.ConfigurationProvider)
					//    .FirstAsync(cancellationToken);

					var cartItemDto = new CartItemDto
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
					};
					return cartItemDto;
				}
			}

			return null;
		}
		private async Task<bool> CartItemExists(int cartId, int productId)
		{
			return await _unitOfWork.Repository<CartItem>().Entities.AnyAsync(x => x.CartId == cartId && x.ProductId == productId);
		}
	}
}
