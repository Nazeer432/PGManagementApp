using Data;
using Data.Models;
using HostelManagementApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repositories;
using System.Diagnostics;

namespace HostelManagementApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBranchRepository _branchRepository;
        private readonly IDailyWagesRepository _dailyWagesRepository;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IBranchRepository branchRepository,
            IDailyWagesRepository dailyWagesRepository, IConfiguration configuration)
        {
            _logger = logger;
            _branchRepository = branchRepository;
            _dailyWagesRepository = dailyWagesRepository;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetDailyWages()
        {
            ViewData["Months"] = new SelectList(Helper.GetMonths(), "MonthId", "Name", DateTime.Now.Month);
            ViewData["Years"] = new SelectList(Helper.GetYears(), "YearId", "Name", DateTime.Now.Year);
            ViewData["FkbranchId"] = new SelectList(await _branchRepository.GetAll(), "PkbranchId", "BranchName");
            var lstDailyWages = _dailyWagesRepository.GetAll();
            return View(lstDailyWages);
        }
        [HttpPost]
        public async Task<IActionResult> GetDailyWages(int MonthId = 0, int YearId = 0, int FkbranchId = 0)
        {
            ViewData["Months"] = new SelectList(Helper.GetMonths(), "MonthId", "Name", MonthId);
            ViewData["Years"] = new SelectList(Helper.GetYears(), "YearId", "Name", YearId);
            ViewData["FkbranchId"] = new SelectList(await _branchRepository.GetAll(), "PkbranchId", "BranchName");
            var lstDailyWages = _dailyWagesRepository.GetAll(MonthId, YearId, FkbranchId);
            return View(lstDailyWages);
        }
        [HttpGet]
        public async Task<IActionResult> DailyWages()
        {
            ViewData["FkbranchId"] = new SelectList(await _branchRepository.GetAll(), "PkbranchId", "BranchName");
            IConfigurationSection myArraySection = _configuration.GetSection("AdminGroup");
            var itemArray = myArraySection.AsEnumerable();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DailyWages(DailyWage dailyWage)
        {
            _dailyWagesRepository.AddDailyWage(dailyWage);
            return RedirectToAction(nameof(GetDailyWages));
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}