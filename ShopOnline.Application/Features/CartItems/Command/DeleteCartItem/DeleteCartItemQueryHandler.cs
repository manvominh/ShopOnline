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

namespace ShopOnline.Application.Features.CartItems.Command.DeleteCartItem
{
	public record DeleteCartItemQuery(int Id) : IRequest<CartItemDto>;
	public class DeleteCartItemQueryHandler : IRequestHandler<DeleteCartItemQuery, CartItemDto>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public DeleteCartItemQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<CartItemDto> Handle(DeleteCartItemQuery request, CancellationToken cancellationToken)
		{
			var deletedItem = await _unitOfWork.Repository<CartItem>().Entities.Where(x => x.Id == request.Id).FirstAsync(cancellationToken);
			var returnItem = await _unitOfWork.Repository<CartItem>().Entities.Where(x => x.Id == request.Id).ProjectTo<CartItemDto>(_mapper.ConfigurationProvider).FirstAsync(cancellationToken);

			await _unitOfWork.Repository<CartItem>().DeleteAsync(deletedItem);
			await _unitOfWork.Save(cancellationToken);
			return returnItem;
		}
	}
}
