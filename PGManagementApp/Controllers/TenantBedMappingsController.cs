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
    public class TenantBedMappingsController : Controller
    {
        private readonly ITenantBedMappingRepository _bedMappingRepository;
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IRoomBedRepository _roomBedRepository;
        private readonly ITenantRepository _tenantRepository;
        public TenantBedMappingsController(ITenantBedMappingRepository bedMappingRepository, IUserProfileRepository userProfileRepository, IRoomBedRepository roomBedRepository, ITenantRepository tenantRepository)
        {
            _bedMappingRepository = bedMappingRepository;
            _roomBedRepository = roomBedRepository;
            _userProfileRepository = userProfileRepository;
            _tenantRepository = tenantRepository;
        }

        // GET: TenantBedMappings
        public async Task<IActionResult> Index()
        {
            //var hostelDBContext = _context.TenantBedMappings.Include(t => t.Fkbed).Include(t => t.FkcreatedbyNavigation).Include(t => t.FkmodifiedByNavigation).Include(t => t.Fktenant);
            var result = _bedMappingRepository.GetAll();
            return View(result);
        }

        // GET: TenantBedMappings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var tenantBedMapping = _bedMappingRepository.GetTenantBedMappingById(id.Value);
            //var tenantBedMapping = await _context.TenantBedMappings
            //    .Include(t => t.Fkbed)
            //    .Include(t => t.FkcreatedbyNavigation)
            //    .Include(t => t.FkmodifiedByNavigation)
            //    .Include(t => t.Fktenant)
            //    .FirstOrDefaultAsync(m => m.PktenantBedId == id);
            if (tenantBedMapping == null)
            {
                return NotFound();
            }

            return View(tenantBedMapping);
        }

        // GET: TenantBedMappings/Create
        public async Task<IActionResult> Create()
        {
            ViewData["FkbedId"] = new SelectList(await _roomBedRepository.GetAll(), "PkbedId", "BedName");
            ViewData["Fkcreatedby"] = new SelectList(await _userProfileRepository.GetAll(), "PkuserId", "UserName");
            ViewData["FkmodifiedBy"] = new SelectList(await _userProfileRepository.GetAll(), "PkuserId", "UserName");
            ViewData["FktenantId"] = new SelectList(await _tenantRepository.GetAll(), "PktenantId", "Address");
            return View();
        }

        // POST: TenantBedMappings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PktenantBedId,FkbedId,FktenantId,IsActive,Created,Modified,Fkcreatedby,FkmodifiedBy")] TenantBedMapping tenantBedMapping)
        {
            if (ModelState.IsValid)
            {
                _bedMappingRepository.AddTenantBedMapping(tenantBedMapping);
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkbedId"] = new SelectList(await _roomBedRepository.GetAll(), "PkbedId", "BedName");
            ViewData["Fkcreatedby"] = new SelectList(await _userProfileRepository.GetAll(), "PkuserId", "UserName");
            ViewData["FkmodifiedBy"] = new SelectList(await _userProfileRepository.GetAll(), "PkuserId", "UserName");
            ViewData["FktenantId"] = new SelectList(await _tenantRepository.GetAll(), "PktenantId", "Address");
            return View(tenantBedMapping);
        }

        // GET: TenantBedMappings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tenantBedMapping = await _bedMappingRepository.GetTenantBedMappingById(id.Value);
            if (tenantBedMapping == null)
            {
                return NotFound();
            }
            ViewData["FkbedId"] = new SelectList(await _roomBedRepository.GetAll(), "PkbedId", "BedName");
            ViewData["Fkcreatedby"] = new SelectList(await _userProfileRepository.GetAll(), "PkuserId", "UserName");
            ViewData["FkmodifiedBy"] = new SelectList(await _userProfileRepository.GetAll(), "PkuserId", "UserName");
            ViewData["FktenantId"] = new SelectList(await _tenantRepository.GetAll(), "PktenantId", "Address");
            return View(tenantBedMapping);
        }

        // POST: TenantBedMappings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PktenantBedId,FkbedId,FktenantId,IsActive,Created,Modified,Fkcreatedby,FkmodifiedBy")] TenantBedMapping tenantBedMapping)
        {
            if (id != tenantBedMapping.PktenantBedId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _bedMappingRepository.UpdateTenantBedMapping(tenantBedMapping);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TenantBedMappingExists(tenantBedMapping.PktenantBedId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkbedId"] = new SelectList(await _roomBedRepository.GetAll(), "PkbedId", "BedName");
            ViewData["Fkcreatedby"] = new SelectList(await _userProfileRepository.GetAll(), "PkuserId", "UserName");
            ViewData["FkmodifiedBy"] = new SelectList(await _userProfileRepository.GetAll(), "PkuserId", "UserName");
            ViewData["FktenantId"] = new SelectList(await _tenantRepository.GetAll(), "PktenantId", "Address");
            return View(tenantBedMapping);
        }

        // GET: TenantBedMappings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var tenantBedMapping = _bedMappingRepository.GetTenantBedMappingById(id.Value);
            //var tenantBedMapping = await _context.TenantBedMappings
            //    .Include(t => t.Fkbed)
            //    .Include(t => t.FkcreatedbyNavigation)
            //    .Include(t => t.FkmodifiedByNavigation)
            //    .Include(t => t.Fktenant)
            //    .FirstOrDefaultAsync(m => m.PktenantBedId == id);
            if (tenantBedMapping == null)
            {
                return NotFound();
            }

            return View(tenantBedMapping);
        }

        // POST: TenantBedMappings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _bedMappingRepository.DeleteTenantBedMapping(id);
            return RedirectToAction(nameof(Index));
        }

        private bool TenantBedMappingExists(int id)
        {
            return _bedMappingRepository.TenantBedMappingExists(id);
        }
    }
}
