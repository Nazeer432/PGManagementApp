using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace HostelManagementApp.Controllers
{
    public class TestController : Controller
    {
        // private readonly HostelDBContext _context;
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IRoleRepository _roleRepository;
        public TestController(IUserProfileRepository userProfileRepository, IRoleRepository roleRepository)
        {
            _userProfileRepository = userProfileRepository;
            _roleRepository = roleRepository;
        }

        // GET: UserProfiles


        [Authorize(Roles = "1")]
        public async Task<IActionResult> Index()
        {
            var result = await _userProfileRepository.GetAll();
            return View(result);
        }
    }
}
