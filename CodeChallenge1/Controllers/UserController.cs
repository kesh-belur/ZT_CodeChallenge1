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

       
        [HttpGet("{id}")]
        public ActionResult<UserDto> GetUser(int id)
        {
            // Find user
            var user = UsersDataStore.Current.Users
                .FirstOrDefault(c => c.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

       
    }
}
