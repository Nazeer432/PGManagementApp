using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data.Models;
using Repositories;
using Microsoft.AspNetCore.Authorization;

namespace HostelManagementApp.Controllers
{
    [Authorize]
    public class RoomsController : Controller
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IBranchRepository _branchRepository;
        private readonly IHostelRepository _hostelRepository;


        public RoomsController(IRoomRepository roomRepository,IBranchRepository branchRepository,IHostelRepository hostelRepository)
        {
           _branchRepository= branchRepository;
            _roomRepository= roomRepository;
            _hostelRepository= hostelRepository;
        }

        // GET: Rooms
        public async Task<IActionResult> Index()
        {
           var result = await _roomRepository.GetAll();
            return View(result);
        }
        public async Task<IActionResult> GetGuestRooms()
        {
            var result = await _roomRepository.GetGuestRooms();
            return View(result);
        }

        // GET: Rooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var room = await _roomRepository.GetRoomById(id.Value);
            //var room = await _context.Rooms
            //    .Include(r => r.Fkbranch)
            //    .FirstOrDefaultAsync(m => m.PkroomId == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // GET: Rooms/Create
        public async Task<IActionResult> Create()
        {
            ViewData["FkbranchId"] = new SelectList(await _branchRepository.GetAll(), "PkbranchId", "BranchName");
            ViewData["FkhostelId"] = new SelectList(await _hostelRepository.GetAll(), "PkhostelId", "HostelName");
            return View();
        }

        // POST: Rooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Bind("PkroomId,RoomName,IsActive,FkbranchId,FkhostelId,Created,Modified,RoomType,NumberOfBeds")]
        public async Task<IActionResult> Create(Room room)
        {
            if (true)
            {                
              bool response =  _roomRepository.AddRoom(room);
                if (response)
                    ViewBag.Success = "Room Details Added/Updated successfully..!";
                else
                {
                    ViewBag.Error = "Room Details Add/Update Failed..!";
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkbranchId"] = new SelectList(await _branchRepository.GetAll(), "PkbranchId", "BranchName",room.FkbranchId);
            ViewData["FkhostelId"] = new SelectList(await _hostelRepository.GetAll(), "PkhostelId", "HostelName",room.FkhostelId);
            return View(room);
        }

        // GET: Rooms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _roomRepository.GetRoomById(id.Value);
            if (room == null)
            {
                return NotFound();
            }
            ViewData["FkbranchId"] = new SelectList(await _branchRepository.GetAll(), "PkbranchId", "BranchName", room.FkbranchId);
            ViewData["FkhostelId"] = new SelectList(await _hostelRepository.GetAll(), "PkhostelId", "HostelName",room.FkhostelId);

            return View(room);
        }

        // POST: Rooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Room room)
        {
            if (id != room.PkroomId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _roomRepository.UpdateRoom(room);
                   
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomExists(room.PkroomId))
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
            ViewData["FkbranchId"] = new SelectList(await _branchRepository.GetAll(), "PkbranchId", "BranchName", room.FkbranchId);
            ViewData["FkhostelId"] = new SelectList(await _hostelRepository.GetAll(), "PkhostelId", "HostelName",room.FkhostelId);

            return View(room);
        }

        // GET: Rooms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Room room = await _roomRepository.GetRoomById(id.Value);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {        
            _roomRepository.DeleteRoom(id);
            return RedirectToAction(nameof(Index));
        }

        private bool RoomExists(int id)
        {
            return _roomRepository.RoomExists(id);
        }
    }
}
