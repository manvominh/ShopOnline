using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.Application.Features.Products.Queries.GetAllProducts;
using ShopOnline.Application.Features.Products.Queries.GetProduct;
using ShopOnline.Application.Features.Products.Queries.GetProductsByCategory;

namespace ShopOnline.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public ProductsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<ActionResult> GetAllProducts()
		{
			return Ok(await _mediator.Send(new GetAllProductsQuery()));
		}
		[HttpGet("{id:int}")]
		public async Task<ActionResult> GetProduct(int id)
		{
			return Ok(await _mediator.Send(new GetProductQuery(id)));
		}
		[HttpGet]
		[Route("{categoryId}/GetItemsByCategory")]
		public async Task<ActionResult> GetItemsByCategory(int categoryId)
		{
			return Ok(await _mediator.Send(new GetProductsByCategoryQuery(categoryId)));
		}
	}
}
