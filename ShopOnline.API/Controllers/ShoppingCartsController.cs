using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.Application.Dtos;
using ShopOnline.Application.Features.CartItems.Command.AddCartItem;
using ShopOnline.Application.Features.CartItems.Command.DeleteCartItem;
using ShopOnline.Application.Features.CartItems.Command.UpdateQty;
using ShopOnline.Application.Features.CartItems.Queries.GetAllCartItems;
using ShopOnline.Application.Features.CartItems.Queries.GetCartItem;

namespace ShopOnline.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ShoppingCartsController : ControllerBase
	{
		private readonly IMediator mediator;

		public ShoppingCartsController(IMediator _mediator)
		{
			mediator = _mediator;
		}
		[HttpGet]
		[Route("{userId}/GetItems")]
		public async Task<IActionResult> GetCartItems(int userId)
		{
			return Ok(await mediator.Send(new GetCartItemsQuery(userId)));
		}
		[HttpGet("{id:int}")]
		public async Task<IActionResult> GetCartItem(int id)
		{
			return Ok(await mediator.Send(new GetCartItemQuery(id)));
		}
		[HttpPost]
		public async Task<IActionResult> AddItem([FromBody] CartItemToAddDto cartItemToAddDto)
		{
			return Ok(await mediator.Send(new AddCartItemQuery(cartItemToAddDto)));
		}
		[HttpDelete("{id:int}")]
		public async Task<IActionResult> DeleteItem(int id)
		{
			return Ok(await mediator.Send(new DeleteCartItemQuery(id)));
		}
		[HttpPatch("{id:int}")]
		public async Task<IActionResult> UpdateQty(int id, CartItemQtyUpdateDto cartItemQtyUpdateDto) // modify to parameters because only contain 3 params
		{
			return Ok(await mediator.Send(new UpdateQtyQuery(id, cartItemQtyUpdateDto)));
		}
	}
}
