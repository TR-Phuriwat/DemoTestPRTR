using DemoTestPRTR.DBContext;
using DemoTestPRTR.Models;
using DemoTestPRTR.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Newtonsoft.Json;

namespace DemoTestPRTR.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDBContext _dbcontext;
        private readonly Calculator _calculator;

        public HomeController(ILogger<HomeController> logger,ApplicationDBContext dbcontext,Calculator calculator)
		{
			_logger = logger;
            _dbcontext = dbcontext;
            _calculator = calculator;

        }

		public IActionResult Index()
		{
            var productVariantsWithProductName = _dbcontext.ProductVariant
            .Include(pv => pv.Product)
            .Select(pv => new ProductVariantViewModel
            {
                VariantID = pv.VariantID,
                ProductID = pv.ProductID,
                ProductName = pv.Product.ProductName,
				ProductVariantName = pv.ProductVariantName,
                Image = pv.Image,
                SalePrice = pv.SalePrice,
                DiscountPrice = pv.DiscountPrice,
                SKU = pv.SKU,
                Stock = pv.Stock,
                Location = pv.Location,
                Rating = _calculator.calRating(pv.ViewCount)
            })
            .ToList();

            return View(productVariantsWithProductName);
        }

		public IActionResult Privacy()
		{
			return View();
		}
        public string GetProductById(int variantId) {

			var productVariantsWithProductName = _dbcontext.ProductVariant
			.Include(pv => pv.Product).Where(pv => pv.VariantID.Equals(variantId))
			.Select(pv => new ProductVariantViewModel
			{
				VariantID = pv.VariantID,
				ProductID = pv.ProductID,
				ProductName = pv.Product.ProductName,
				ProductVariantName = pv.ProductVariantName,
				Image = pv.Image,
				SalePrice = pv.SalePrice,
				DiscountPrice = pv.DiscountPrice,
				SKU = pv.SKU,
				Stock = pv.Stock,
				Location = pv.Location,
				Rating = _calculator.calRating(pv.ViewCount)
			}).FirstOrDefault();

			return JsonConvert.SerializeObject(productVariantsWithProductName);
        }

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
