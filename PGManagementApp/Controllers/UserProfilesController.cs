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
    public class UserProfilesController : Controller
    {
        // private readonly HostelDBContext _context;
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IRoleRepository _roleRepository;
        public UserProfilesController(IUserProfileRepository userProfileRepository, IRoleRepository roleRepository)
        {
            _userProfileRepository = userProfileRepository;
            _roleRepository = roleRepository;
        }

        // GET: UserProfiles 
                
        public async Task<IActionResult> Index()
        {
            var result = await _userProfileRepository.GetAll();
            return View(result);
        }

        // GET: UserProfiles/Details/5
        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var userProfile = _userProfileRepository.GetUserProfileById(id.Value);

            if (userProfile == null)
            {
                return NotFound();
            }

            return View(userProfile);
        }

        // GET: UserProfiles/Create
        public IActionResult Create()
        {
            ViewData["FkroleId"] = new SelectList(_roleRepository.GetAll(), "PkroleId", "RoleName");
            return View();
        }

        // POST: UserProfiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PkuserId,UserName,Password,IsActive,Created,Modified,FkroleId,Email")] UserProfile userProfile)
        {
            if (ModelState.IsValid)
            {
                _userProfileRepository.AddUserProfile(userProfile);

                return RedirectToAction(nameof(Index));
            }
            ViewData["FkroleId"] = new SelectList(_roleRepository.GetAll(), "PkroleId", "RoleName", userProfile.FkroleId);
            return View(userProfile);
        }

        // GET: UserProfiles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userProfile = await _userProfileRepository.GetUserProfileById(id.Value);
            if (userProfile == null)
            {
                return NotFound();
            }
            ViewData["FkroleId"] = new SelectList(_roleRepository.GetAll(), "PkroleId", "RoleName", userProfile.FkroleId);
            return View(userProfile);
        }

        // POST: UserProfiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PkuserId,UserName,Password,IsActive,Created,Modified,FkroleId,Email")] UserProfile userProfile)
        {
            if (id != userProfile.PkuserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _userProfileRepository.UpdateUserProfile(userProfile);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserProfileExists(userProfile.PkuserId))
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
            ViewData["FkroleId"] = new SelectList(_roleRepository.GetAll(), "PkroleId", "RoleName", userProfile.FkroleId);
            return View(userProfile);
        }

        // GET: UserProfiles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userProfile = await _userProfileRepository.GetUserProfileById(id.Value);
            if (userProfile == null)
            {
                return NotFound();
            }

            return View(userProfile);
        }

        // POST: UserProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _userProfileRepository.DeleteUserProfile(id);
            return RedirectToAction(nameof(Index));
        }

        private bool UserProfileExists(int id)
        {
            return _userProfileRepository.UserProfileExists(id);
        }
    }
}
