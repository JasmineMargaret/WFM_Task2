using JasmineTask_Wfm.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JasmineTask_Wfm.Controllers
{
    public class LoginController : Controller
    {
        private readonly Jasmine_DBContext _context;

        public LoginController(Jasmine_DBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("UserName,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

    }
}
