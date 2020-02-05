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

            if (payload != null)
            {
                string user_id = payload.Subject;
                return Content($"你的 user_id: {user_id}");
            }

            return null;
        }
        private static GoogleJsonWebSignature.ValidationSettings GoogleValidationSetting => new GoogleJsonWebSignature.ValidationSettings()
        {
            Audience = new List<string>() { WebConfigurationManager.AppSettings["GoogleClientId"] }
        };
    }
}