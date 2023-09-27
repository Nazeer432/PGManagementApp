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
    public class HostelsController : Controller
    {
        private readonly IHostelRepository _hostelRepository;
        private readonly IUserProfileRepository _userProfileRepository;

        public HostelsController(IHostelRepository hostelRepository, IUserProfileRepository userProfileRepository)
        {
            _hostelRepository = hostelRepository;
            _userProfileRepository = userProfileRepository;
        }

        // GET: Hostels
        public async Task<IActionResult> Index()
        {
            var result = await _hostelRepository.GetAll();
            return View(result);
        }

        // GET: Hostels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var hostel = await _hostelRepository.GetHostelById(id.Value);
            //var hostel = await _context.Hostels
            //    .Include(h => h.FkcreatedByNavigation)
            //    .FirstOrDefaultAsync(m => m.PkhostelId == id);
            if (hostel == null)
            {
                return NotFound();
            }

            return View(hostel);
        }

        // GET: Hostels/Create
        public async Task<IActionResult> Create()
        {
             ViewData["FkcreatedBy"] = new SelectList(await _userProfileRepository.GetAll(), "PkuserId", "UserName");
            return View();
        }

        // POST: Hostels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PkhostelId,HostelName,IsActive,Created,Modified,FkcreatedBy")] Hostel hostel)
        {
            if (ModelState.IsValid)
            {
                _hostelRepository.AddHostel(hostel);
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkcreatedBy"] = new SelectList(await _userProfileRepository.GetAll(), "PkuserId", "UserName");
            return View(hostel);
        }

        // GET: Hostels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hostel = await _hostelRepository.GetHostelById(id.Value);
            if (hostel == null)
            {
                return NotFound();
            }
            ViewData["FkcreatedBy"] = new SelectList(await _userProfileRepository.GetAll(), "PkuserId", "UserName");
            return View(hostel);
        }

        // POST: Hostels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PkhostelId,HostelName,IsActive,Created,Modified,FkcreatedBy")] Hostel hostel)
        {
            if (id != hostel.PkhostelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _hostelRepository.UpdateHostel(hostel);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HostelExists(hostel.PkhostelId))
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
            ViewData["FkcreatedBy"] = new SelectList(await _userProfileRepository.GetAll(), "PkuserId", "UserName");
            return View(hostel);
        }

        // GET: Hostels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var hostel = await _hostelRepository.GetHostelById(id.Value);
            //var hostel = await _context.Hostels
            //    .Include(h => h.FkcreatedByNavigation)
            //    .FirstOrDefaultAsync(m => m.PkhostelId == id);
            if (hostel == null)
            {
                return NotFound();
            }

            return View(hostel);
        }

        // POST: Hostels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _hostelRepository.DeleteHostel(id);
            return RedirectToAction(nameof(Index));
        }
        private bool HostelExists(int id)
        {
            return _hostelRepository.HostelExists(id);
        }
    }
}
