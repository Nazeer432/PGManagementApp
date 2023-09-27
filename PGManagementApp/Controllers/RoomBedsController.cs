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
    public class RoomBedsController : Controller
    {
        private readonly IRoomBedRepository _roomBedRepository;
        private readonly IRoomRepository _roomRepository;

        public RoomBedsController(IRoomBedRepository roomBedRepository, IRoomRepository roomRepository)
        {
            _roomBedRepository = roomBedRepository;
            _roomRepository = roomRepository;
        }

        // GET: RoomBeds
        public async Task<IActionResult> Index()
        {
            var result = _roomBedRepository.GetAll();
            return View(result);
        }

        // GET: RoomBeds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var roomBed = _roomBedRepository.GetRoomBedById(id.Value);
            //var roomBed = await _context.RoomBeds
            //    .Include(r => r.Fkroom)
            //    .FirstOrDefaultAsync(m => m.PkbedId == id);
            if (roomBed == null)
            {
                return NotFound();
            }

            return View(roomBed);
        }

        // GET: RoomBeds/Create
        public async Task<IActionResult> Create()
        {
            ViewData["FkroomId"] = new SelectList(await _roomRepository.GetAll(), "PkroomId", "RoomName");
            return View();
        }

        // POST: RoomBeds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PkbedId,BedName,IsActive,FkroomId,Created,Modified,Fkcreatedby,FkmodifiedBy")] RoomBed roomBed)
        {
            if (ModelState.IsValid)
            {
                _roomBedRepository.AddRoomBed(roomBed);
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkroomId"] = new SelectList(await _roomRepository.GetAll(), "PkroomId", "RoomName");
            return View(roomBed);
        }

        // GET: RoomBeds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomBed = await _roomBedRepository.GetRoomBedById(id.Value);
            if (roomBed == null)
            {
                return NotFound();
            }
            ViewData["FkroomId"] = new SelectList(await _roomRepository.GetAll(), "PkroomId", "RoomName");
            return View(roomBed);
        }

        // POST: RoomBeds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PkbedId,BedName,IsActive,FkroomId,Created,Modified,Fkcreatedby,FkmodifiedBy")] RoomBed roomBed)
        {
            if (id != roomBed.PkbedId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _roomBedRepository.UpdateRoomBed(roomBed);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomBedExists(roomBed.PkbedId))
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
            ViewData["FkroomId"] = new SelectList(await _roomRepository.GetAll(), "PkroomId", "RoomName");
            return View(roomBed);
        }

        // GET: RoomBeds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var roomBed = await _roomBedRepository.GetRoomBedById(id.Value);
            //var roomBed = await _context.RoomBeds
            //    .Include(r => r.Fkroom)
            //    .FirstOrDefaultAsync(m => m.PkbedId == id);
            if (roomBed == null)
            {
                return NotFound();
            }

            return View(roomBed);
        }

        // POST: RoomBeds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _roomBedRepository.DeleteRoomBed(id);
            return RedirectToAction(nameof(Index));
        }

        private bool RoomBedExists(int id)
        {
            return _roomBedRepository.RoomBedExists(id);
        }
    }
}
