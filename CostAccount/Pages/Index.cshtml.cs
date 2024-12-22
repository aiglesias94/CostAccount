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

        public string? SuccessMessage { get; private set; }
        public string? ErrorMessage { get; private set; }


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
                LoadModel();
                return Page();
            }

            if (!_marketService.ValidPurchase(Amount, Price))
            {
                ErrorMessage = "Invalid Sale";
                LoadModel();
                return Page();
            }

            try
            {
                _marketService.Sell(Amount, Price);
            }
            catch (Exception ex)
            {
                string errorMessage = "Error selling stocks";
                _logger.LogError(ex, errorMessage);
                ErrorMessage = errorMessage;
                LoadModel();
                return Page();
            }

            return RedirectToPage();
        }

        public IActionResult OnPostReset()
        {
            Amount = 0; Price = 0.0m;
            ModelState.Clear();
            SuccessMessage = "Purchases Reset";
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