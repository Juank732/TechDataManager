using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TechOilFront.Models;

namespace TechOilFront.Pages
{
	public class ProductsModel : PageModel
	{
		private readonly ILogger<ProductsModel> _logger;
		private readonly IHttpClientFactory _httpClientFactory;

		public List<ProductModel> Products { get;  set; }

		public ProductsModel(ILogger<ProductsModel> logger, IHttpClientFactory httpClientFactory)
		{
			_logger = logger;
			_httpClientFactory = httpClientFactory;

		}

		public async Task OnGet()
		{
			try
			{
				var client = _httpClientFactory.CreateClient("Api");
				var response = await client.GetAsync("/products");
				response.EnsureSuccessStatusCode();

				Products = await response.Content.ReadFromJsonAsync<List<ProductModel>>();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error al obtener datos de la API");

				Products = new List<ProductModel>();
			}
		}
	}
}
