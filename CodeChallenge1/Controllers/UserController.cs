using CodeChallenge1.Models;
using Microsoft.AspNetCore.Mvc;

namespace UserInfo.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> GetUsers()
        {
            return Ok(UsersDataStore.Current.Users);
        }
    }
}
