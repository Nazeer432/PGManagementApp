using Data.Models;
using Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Repositories;
using static Data.ApplicationEnums;

namespace HostelManagementApp.Controllers
{
    public class TenantsController : Controller
    {
        private readonly ITenantRepository _tenantRepository;
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IRoomRepository _roomRepository;
        public TenantsController(ITenantRepository tenantRepository,IUserProfileRepository userProfileRepository, IRoomRepository roomRepository)
        {
            _tenantRepository = tenantRepository;
            _userProfileRepository = userProfileRepository;
            _roomRepository = roomRepository;
        }

        // GET: Tenants
        public async Task<IActionResult> Index()
        {
            //String message = HttpUtility.UrlEncode("Hi Murali, Welcome to AR STAY INN..!");
            //using (var wb = new WebClient())
            //{
            //    byte[] response = wb.UploadValues("https://api.textlocal.in/send/", new NameValueCollection()
            //    {
            //    {"apikey" , "MzI0MTM0NTA0YjY0MzE3NTY3NGQ2YzU0NjUzNTQ4NDg="},
            //    {"numbers" , "917989705831"},
            //    {"message" , message},
            //    {"sender" , "TXTLCL"}
            //    });
            //    string result1 = System.Text.Encoding.UTF8.GetString(response);
               
            //}
            var result =  _tenantRepository.GetAllTenantsByStatus();
            return View(result);
        }

        // GET: Tenants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var tenant =  _tenantRepository.GetTenantById(id.Value);
            //var tenant = await _context.Tenants
            //    .Include(t => t.FkcreatedbyNavigation)
            //    .Include(t => t.FkmodifiedByNavigation)
            //    .FirstOrDefaultAsync(m => m.PktenantId == id);
            if (tenant == null)
            {
                return NotFound();
            }

            return View(tenant);
        }

        // GET: Tenants/Create
        public async Task<IActionResult> Create()
        {
            ViewData["Fkcreatedby"] = new SelectList(await _userProfileRepository.GetAll(), "PkuserId", "UserName");
            ViewData["FkmodifiedBy"] = new SelectList(await _userProfileRepository.GetAll(), "PkuserId", "UserName");
            ViewData["FkRoomId"] = new SelectList( _roomRepository.GetRoomsByStatus((int)RoomStatus.Avaliable, false), "PkroomId", "RoomWithType");
            ViewData["PrimaryTenant"] = _tenantRepository.GetAllPrimaryTenants();

            return View();
        }

        // POST: Tenants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TenantsDb tenant)
        {
            if (true)
            {
                _tenantRepository.AddTenant(tenant);
                return RedirectToAction(nameof(Index));
            }
            ViewData["Fkcreatedby"] = new SelectList(await _userProfileRepository.GetAll(), "PkuserId", "UserName", tenant.Fkcreatedby);
            ViewData["FkmodifiedBy"] = new SelectList(await _userProfileRepository.GetAll(), "PkuserId", "UserName", tenant.FkmodifiedBy);
            return View(tenant);
        }

        // GET: Tenants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tenant = await _tenantRepository.GetTenantEditById(id.Value);

            if (tenant == null)
            {
                return NotFound();
            }
            ViewData["Fkcreatedby"] = new SelectList(await _userProfileRepository.GetAll(), "PkuserId", "UserName", tenant.Fkcreatedby);
            ViewData["FkmodifiedBy"] = new SelectList(await _userProfileRepository.GetAll(), "PkuserId", "UserName", tenant.FkmodifiedBy);
            ViewData["FkRoomId"] = new SelectList(_roomRepository.GetRoomsByStatus((int)RoomStatus.Avaliable, false), "PkroomId", "RoomWithType");
            return View(tenant);
        }

        // POST: Tenants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TenantsDb tenant)
        {
            if (id != tenant.PktenantId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                  _tenantRepository.UpdateTenant(tenant);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TenantExists(tenant.PktenantId))
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
            ViewData["Fkcreatedby"] = new SelectList(await _userProfileRepository.GetAll(), "PkuserId", "UserName", tenant.Fkcreatedby);
            ViewData["FkmodifiedBy"] = new SelectList(await _userProfileRepository.GetAll(), "PkuserId", "UserName", tenant.FkmodifiedBy);
            return View(tenant);
        }

        // GET: Tenants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Tenant tenant =  _tenantRepository.GetTenantById(id.Value);
            //var tenant = await _context.Tenants
            //    .Include(t => t.FkcreatedbyNavigation)
            //    .Include(t => t.FkmodifiedByNavigation)
            //    .FirstOrDefaultAsync(m => m.PktenantId == id);
            if (tenant == null)
            {
                return NotFound();
            }

            return View(tenant);
        }

        // POST: Tenants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _tenantRepository.DeleteTenant(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet, ActionName("Get")]
        public async Task<IActionResult> SetNoticePeriod(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tenant = await _tenantRepository.GetTenantEditById(id.Value);

            if (tenant == null)
            {
                return NotFound();
            }
            ViewData["Fkcreatedby"] = new SelectList(await _userProfileRepository.GetAll(), "PkuserId", "UserName", tenant.Fkcreatedby);
            ViewData["FkmodifiedBy"] = new SelectList(await _userProfileRepository.GetAll(), "PkuserId", "UserName", tenant.FkmodifiedBy);
            ViewData["FkRoomId"] = new SelectList(_roomRepository.GetRoomsByStatus((int)RoomStatus.Avaliable, false), "PkroomId", "RoomWithType");
            return View(tenant);
        }
        private bool TenantExists(int id)
        {
            return _tenantRepository.TenantExists(id);
        }
    }
}
