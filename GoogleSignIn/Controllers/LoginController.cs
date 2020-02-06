using Google.Apis.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace GoogleSignIn.Controllers
{
    public class LoginController : Controller
    {
        private DbEntities _dbContext;
        public LoginController()
        {
            _dbContext = new DbEntities();
        }
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GoogleLogin()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> GoogleLogin(string id_token)
        {
            GoogleJsonWebSignature.Payload payload = null;
            try
            {
                payload = await GoogleJsonWebSignature.ValidateAsync(id_token, GoogleValidationSetting);
            }
            catch (Google.Apis.Auth.InvalidJwtException ex)
            {
                return Content($"Google.Apis.Auth.InvalidJwtException: { ex.Message}");
            }
            catch (Newtonsoft.Json.JsonReaderException ex)
            {
                return Content($"Newtonsoft.Json.JsonReaderException: {ex.Message}");
            }
            catch (Exception ex)
            {
                return Content($"Exception: {ex.Message}");
            }

            if (payload == null)
            {
                return null;

            }

            string email = payload.Email;
            if (_dbContext.Users.Where(u => u.Email == email).Any()) // if 使用者已存在
                return Content(Url.Action("Index", "Users"));

            return Content(Url.Action("Register", routeValues: new { email = email }));
        }

        private static GoogleJsonWebSignature.ValidationSettings GoogleValidationSetting => new GoogleJsonWebSignature.ValidationSettings()
        {
            Audience = new List<string>() { WebConfigurationManager.AppSettings["GoogleClientId"] }
        };

        public ActionResult Register(string email)
        {
            var viewModel = new RegisterViewModel()
            {
                Gmail = email,
                Roles = _dbContext.Roles.ToList(),
                User = new User()
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = email
                }
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            var isUserExists = _dbContext.Users.Where(u => u.Email == user.Email).Any();
            if (isUserExists)
            {
                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();
            }

            return RedirectToAction("Index", "Users");
        }
    }
}