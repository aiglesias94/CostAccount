using CostAccount_BAL.Services.Interfaces;
using CostAccount_DAL.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace CostAccount.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IMarketService _marketService;

        [BindProperty]
        public List<SharesLotDTO> AvailableLots { get; set; }

        [BindProperty]
        public List<SaleDTO> Sales { get; set; }

        [BindProperty]
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Amount must be greater than 0")]
        public int Amount { get; set; }

        [BindProperty]
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }

        public string? Message { get; private set; }


        public IndexModel(ILogger<IndexModel> logger, IMarketService marketService)
        {
            _logger = logger;
            _marketService = marketService;
            AvailableLots = new List<SharesLotDTO>();
            Sales = new List<SaleDTO>();
        }

        public void OnGet()
        {
            LoadModel();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _marketService.Sell(Amount, Price);

            return RedirectToPage();
        }

        public IActionResult OnPostReset()
        {
            Amount = 0; Price = 0.0m;
            ModelState.Clear();
            Message = "Purchases Reset";
            _marketService.ResetLots();
            LoadModel();
            return Page();

        }

        private void LoadModel()
        {
            AvailableLots = _marketService.GetLots();
            Sales = _marketService.GetSales().OrderByDescending(n => n.Created).ToList();
        }
    }
}