using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data.Models;
using Repositories;

namespace HostelManagementApp.Controllers
{
    public class FeeDetailsController : Controller
    {
        private readonly IFeeDetailsRepository _feeDetailsRepository;
        private readonly ITenantRepository _tenantRepository;
        private readonly IUserProfileRepository _userProfileRepository;

        public FeeDetailsController(IFeeDetailsRepository feeDetailsRepository, ITenantRepository tenantRepository, IUserProfileRepository userProfileRepository)
        {
            _feeDetailsRepository = feeDetailsRepository;
            _tenantRepository = tenantRepository;
            _userProfileRepository = userProfileRepository;
        }

        // GET: FeeDetails
        public async Task<IActionResult> Index(int id)
        {
            var result = await _feeDetailsRepository.GetFeeDetailsByTenId(id);
            //var hostelDBContext = _context.FeeDetails.Include(f => f.FkcreatedbyNavigation).Include(f => f.FkmodifiedByNavigation).Include(f => f.Fktenant);
            return View(result);
        }
        public async Task<IActionResult> GetFeeDetailsById(int id)
        {
            var result = await _feeDetailsRepository.GetFeeDetailsById(id);
            //var hostelDBContext = _context.FeeDetails.Include(f => f.FkcreatedbyNavigation).Include(f => f.FkmodifiedByNavigation).Include(f => f.Fktenant);
            return View(result);
        }

        // GET: FeeDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var feeDetail = _feeDetailsRepository.GetFeeDetailsById(id.Value);
            //var feeDetail = await _context.FeeDetails
            //    .Include(f => f.FkcreatedbyNavigation)
            //    .Include(f => f.FkmodifiedByNavigation)
            //    .Include(f => f.Fktenant)
            //    .FirstOrDefaultAsync(m => m.PkfeeDetailsId == id);
            if (feeDetail == null)
            {
                return NotFound();
            }

            return View(feeDetail);
        }

        // GET: FeeDetails/Create
        public async Task<IActionResult> Create()
        {
            ViewData["Fkcreatedby"] = new SelectList(await _userProfileRepository.GetAll(), "PkuserId", "UserName");
            ViewData["FkmodifiedBy"] = new SelectList(await _userProfileRepository.GetAll(), "PkuserId", "UserName");
            ViewData["FktenantId"] = new SelectList(await _tenantRepository.GetAll(), "PktenantId", "Address");
            return View();
        }

        // POST: FeeDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PkfeeDetailsId,FeeAmount,DueAmount,FeeDate,FeeMode,TransactionId,TransactionType,FktenantId,IsActive,Created,Modified,Fkcreatedby,FkmodifiedBy")] FeeDetail feeDetail)
        {
            if (ModelState.IsValid)
            {
                _feeDetailsRepository.AddFeeDetails(feeDetail);
                return RedirectToAction(nameof(Index));
            }
            ViewData["Fkcreatedby"] = new SelectList(await _userProfileRepository.GetAll(), "PkuserId", "UserName");
            ViewData["FkmodifiedBy"] = new SelectList(await _userProfileRepository.GetAll(), "PkuserId", "UserName");
            ViewData["FktenantId"] = new SelectList(await _tenantRepository.GetAll(), "PktenantId", "Address");
            return View(feeDetail);
        }

        // GET: FeeDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feeDetail = await _feeDetailsRepository.GetFeeDetailsById(id.Value);
            if (feeDetail == null)
            {
                return NotFound();
            }
            ViewData["Fkcreatedby"] = new SelectList(await _userProfileRepository.GetAll(), "PkuserId", "UserName");
            ViewData["FkmodifiedBy"] = new SelectList(await _userProfileRepository.GetAll(), "PkuserId", "UserName");
            ViewData["FktenantId"] = new SelectList(await _tenantRepository.GetAll(), "PktenantId", "Address");
            return View(feeDetail);
        }

        // POST: FeeDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  FeeDetail feeDetail)
        {
            if (id != feeDetail.PkfeeDetailsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _feeDetailsRepository.UpdateFeeDetails(feeDetail);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeeDetailExists(feeDetail.PkfeeDetailsId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { id = feeDetail.FktenantId });
            }
            ViewData["Fkcreatedby"] = new SelectList(await _userProfileRepository.GetAll(), "PkuserId", "UserName");
            ViewData["FkmodifiedBy"] = new SelectList(await _userProfileRepository.GetAll(), "PkuserId", "UserName");
            ViewData["FktenantId"] = new SelectList(await _tenantRepository.GetAll(), "PktenantId", "Address");
            return View(feeDetail);
        }

        // GET: FeeDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var feeDetail = _feeDetailsRepository.GetFeeDetailsById(id.Value);
            //var feeDetail = await _context.FeeDetails
            //    .Include(f => f.FkcreatedbyNavigation)
            //    .Include(f => f.FkmodifiedByNavigation)
            //    .Include(f => f.Fktenant)
            //    .FirstOrDefaultAsync(m => m.PkfeeDetailsId == id);
            if (feeDetail == null)
            {
                return NotFound();
            }

            return View(feeDetail);
        }

        // POST: FeeDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _feeDetailsRepository.DeleteFeeDetails(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet, ActionName("Payment")]
        public async Task<IActionResult> Payment(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feeDetail = await _feeDetailsRepository.GetFeeDetailsById(id.Value);
            if (feeDetail == null)
            {
                return NotFound();
            }
            ViewData["Fkcreatedby"] = new SelectList(await _userProfileRepository.GetAll(), "PkuserId", "UserName");
            ViewData["FkmodifiedBy"] = new SelectList(await _userProfileRepository.GetAll(), "PkuserId", "UserName");
            return View("Payment", feeDetail);
        }
        [HttpPost, ActionName("Payment")]
        public async Task<IActionResult> Payment(FeeDetail feeDetail)
        {
            ViewBag.ResponseMessage = _feeDetailsRepository.AcceptPayment(feeDetail);
            if (feeDetail == null)
                ViewData["Fkcreatedby"] = new SelectList(await _userProfileRepository.GetAll(), "PkuserId", "UserName");
            ViewData["FkmodifiedBy"] = new SelectList(await _userProfileRepository.GetAll(), "PkuserId", "UserName");
            return RedirectToAction(nameof(Index), new { id = feeDetail.FktenantId });
        }
        private bool FeeDetailExists(int id)
        {
            return _feeDetailsRepository.FeeDetailsExists(id);
        }
    }
}
