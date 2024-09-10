using Microsoft.AspNetCore.Mvc;
using WearHouse.Data;
using WearHouse.Models;

namespace WearHouse.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;
        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Login()
        {
            return View();
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string emailLogin, string passwordLogin)
        {
            if(emailLogin == null || passwordLogin == null)
            {
                return BadRequest("Email atau Password kosong");
            }
            

            var user= _db.Users.FirstOrDefault(u => u.Email == emailLogin && u.Password == passwordLogin);
            if (user == null)
            {
                return BadRequest("Email atau Password salah");
            }

            HttpContext.Session.SetString("name", user.Name);
            return RedirectToAction("Dashboard", "User");
        }

        [HttpPost]
        public IActionResult Register(string username, string emailRegister, 
            string passwordRegister, string ConfirmpasswordRegister)
        {
 
            var userCek = _db.Users.Any(u => u.Email == emailRegister);
            if(userCek)
            {
                return BadRequest("Email telah didaftar");
            }
            if(passwordRegister != ConfirmpasswordRegister)
            {
                return BadRequest("Password dan Confirm Password tidak cocok");
            }
            var newuser = new User
            {
                Name = username,
                Email = emailRegister,
                Password = passwordRegister
            };
            _db.Users.Add(newuser);
            _db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
        public IActionResult Dashboard()
        {
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View();
        }
    }

}
