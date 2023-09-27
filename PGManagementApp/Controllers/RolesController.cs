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
    public class DailyWagesController : Controller
    {
        // private readonly HostelDBContext _context;
        private readonly IRoleRepository _roleRepository;

        public DailyWagesController(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        // GET: Roles
        public IActionResult Index()
        {
            var lstRoles = _roleRepository.GetAll();
            return View(lstRoles);
        }

        // GET: Roles/Details/5
        public IActionResult Details(int? id)
        {
            var role = _roleRepository.GetRoleById(id.Value);
            if (role == null)
            {
                return NotFound();
            }

            return View(role);
        }

        // GET: Roles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PkroleId,RoleName,IsActive,Created,Modified")] Role role)
        {
            if (ModelState.IsValid)
            {
                _roleRepository.AddRole(role);
                return RedirectToAction(nameof(Index));
            }
            return View(role);
        }

        // GET: Roles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var role = _roleRepository.GetRoleById(id.Value);
            if (role == null)
            {
                return NotFound();
            }
            return View(role);
        }

        // POST: Roles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PkroleId,RoleName,IsActive,Created,Modified")] Role role)
        {
            if (id != role.PkroleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _roleRepository.UpdateRole(role);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoleExists(id))
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
            return View(role);
        }

        // GET: Roles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            //if (id == null || _context.Roles == null)
            //{
            //    return NotFound();
            //}

            var role = new Role();
            //var role = await _context.Roles
            //    .FirstOrDefaultAsync(m => m.PkroleId == id);
            if (role == null)
            {
                return NotFound();
            }

            return View(role);
        }

        // POST: Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _roleRepository.DeleteRole(id);
            return RedirectToAction(nameof(Index));
        }

        private bool RoleExists(int id)
        {
            Role role = _roleRepository.GetRoleById(id);
            if(role == null)
            {
                return false;
            }
            return true;
        }
    }
}
