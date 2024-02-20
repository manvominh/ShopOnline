using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.Application.Features.ProductCategories.Queries.GetAllCategories;
using ShopOnline.Application.Features.ProductCategories.Queries.GetCategory;

namespace ShopOnline.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductCategoriesController : ControllerBase
	{
		private readonly IMediator mediator;

		public ProductCategoriesController(IMediator _mediator)
		{
			mediator = _mediator;
		}

		[HttpGet]
		public async Task<ActionResult> GetCategories()
		{
			return Ok(await mediator.Send(new GetAllCategoriesQuery()));
		}
		[HttpGet("{id:int}")]
		public async Task<ActionResult> GetCategoryById(int id)
		{
			return Ok(await mediator.Send(new GetCategoryQuery(id)));
		}
	}
}
