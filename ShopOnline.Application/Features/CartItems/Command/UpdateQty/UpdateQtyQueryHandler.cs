using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopOnline.Application.Dtos;
using ShopOnline.Application.Interfaces.Repositories;
using ShopOnline.Domain.Entities;

namespace ShopOnline.Application.Features.CartItems.Command.UpdateQty
{
	public record UpdateQtyQuery(int Id, CartItemQtyUpdateDto CartItemQtyUpdateDto) : IRequest<CartItemDto>;
	public class UpdateQtyQueryHandler : IRequestHandler<UpdateQtyQuery, CartItemDto>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public UpdateQtyQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<CartItemDto> Handle(UpdateQtyQuery request, CancellationToken cancellationToken)
		{
			var item = await _unitOfWork.Repository<CartItem>().Entities
				.Where(x => x.Id == request.Id)
				//.ProjectTo<CartItemDto>(_mapper.ConfigurationProvider)
				.FirstAsync(cancellationToken);
			if (item != null)
			{
				item.Qty = request.CartItemQtyUpdateDto.Qty;
				await _unitOfWork.Repository<CartItem>().UpdateAsync(item);
				await _unitOfWork.Save(cancellationToken);

				return await _unitOfWork.Repository<CartItem>().Entities
				.Where(x => x.Id == request.Id)
				.ProjectTo<CartItemDto>(_mapper.ConfigurationProvider)
				.FirstAsync(cancellationToken);
			}
			return null;
		}
	}
}
