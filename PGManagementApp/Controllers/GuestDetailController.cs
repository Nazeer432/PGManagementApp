using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data.Models;
using Repositories;
using static Data.ApplicationEnums;

namespace HostelManagementApp.Controllers
{
    public class GuestDetailController : Controller
    {
        private readonly IBranchRepository _branchRepository;
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IHostelRepository _hostelRepository;
        private readonly IRoomRepository _roomRepository;

        public GuestDetailController(IBranchRepository branchRepository, IUserProfileRepository userProfileRepository, IHostelRepository hostelRepository, IRoomRepository roomRepository)
        {
            _branchRepository = branchRepository;
            _userProfileRepository = userProfileRepository;
            _hostelRepository = hostelRepository;
            _roomRepository = roomRepository;
        }

        // GET: Branches
        public async Task<IActionResult> Index()
        {
            var result = await _branchRepository.GetAll();
            return View(result);
        }

        // GET: Branches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var branch = _branchRepository.GetBranchById(id.Value);

            if (branch == null)
            {
                return NotFound();
            }

            return View(branch);
        }

        // GET: Branches/Create
        public async Task<IActionResult> Create()
        {
            ViewData["FkcreatedBy"] = new SelectList(await _userProfileRepository.GetAll(), "PkuserId", "UserName");
            ViewData["FkhostelId"] = new SelectList(await _hostelRepository.GetAll(), "PkhostelId", "HostelName");
            ViewData["FkRoomId"] = new SelectList(_roomRepository.GetRoomsByStatus((int)RoomStatus.Avaliable, true, false), "PkroomId", "RoomWithType");
            GuestDetail guestDetail = new GuestDetail();
            guestDetail.CheckIn = DateTime.Now;
            return View(guestDetail);
        }

        // POST: Branches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GuestDetail guestDetail)
        {
            try
            {
                ViewData["FkcreatedBy"] = new SelectList(await _userProfileRepository.GetAll(), "PkuserId", "UserName");
                ViewData["FkhostelId"] = new SelectList(await _hostelRepository.GetAll(), "PkhostelId", "HostelName");
                ViewData["FkRoomId"] = new SelectList(_roomRepository.GetRoomsByStatus((int)RoomStatus.Avaliable, true, false), "PkroomId", "RoomWithType");
                guestDetail.CheckIn = DateTime.Now;
            }
            catch (Exception ex)
            {

                throw;
            }
            
            return View(guestDetail);
        }

        // GET: Branches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var branch = await _branchRepository.GetBranchById(id.Value);
            if (branch == null)
            {
                return NotFound();
            }
            ViewData["FkcreatedBy"] = new SelectList(await _userProfileRepository.GetAll(), "PkuserId", "UserName", branch.FkcreatedBy);
            ViewData["FkhostelId"] = new SelectList(await _hostelRepository.GetAll(), "PkhostelId", "HostelName");

            return View(branch);
        }

        // POST: Branches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PkbranchId,BranchName,IsActive,Location,FkcreatedBy,FkhostelId,Created,Modified")] Branch branch)
        {
            if (id != branch.PkbranchId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _branchRepository.UpdateBranch(branch);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BranchExists(branch.PkbranchId))
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
            ViewData["FkcreatedBy"] = new SelectList(await _userProfileRepository.GetAll(), "PkuserId", "UserName", branch.FkcreatedBy);
            ViewData["FkhostelId"] = new SelectList(await _hostelRepository.GetAll(), "PkhostelId", "HostelName");
            return View(branch);
        }

        // GET: Branches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Branch branch = await _branchRepository.GetBranchById(id.Value);
            //var branch = await _context.Branches
            //    .Include(b => b.FkcreatedByNavigation)
            //    .Include(b => b.Fkhostel)
            //    .FirstOrDefaultAsync(m => m.PkbranchId == id);
            if (branch == null)
            {
                return NotFound();
            }

            return View(branch);
        }

        // POST: Branches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _branchRepository.DeleteBranch(id);
            return RedirectToAction(nameof(Index));
        }

        private bool BranchExists(int id)
        {
            return _branchRepository.BranchExists(id);
        }
    }
}
