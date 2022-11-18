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

        [HttpGet(Name ="GetUsers")]
        public ActionResult<IEnumerable<UserDto>> GetUsers()
        {
            return Ok(UsersDataStore.Current.Users);
        }

       
        [HttpGet("{id}",Name ="GetUser")] //Helps after a new user has been created and can be called into.. See CreateUser method on how thi is used
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

        [HttpPost]
        //Implemented properly this will have an Entity class. At this stage, the Entity/Dto is assumed to be the same for simplicity sake
        public ActionResult<UserDto> CreateUser([FromBody]UserCreationDto user) //the body will contain data for creation which will be de-serialized used by UserCreationDTO
        {
            var newUserID = UsersDataStore.Current.Users.Max(u => u.Id) + 100;

            var newUser = new UserDto()
            {
                Id = newUserID,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DateOfBirth = user.DateOfBirth,
                Email = user.Email
            };
            UsersDataStore.Current.Users.Add(newUser);
            //go to the newly created user -returns 201 as well
            return CreatedAtRoute("GetUser", new { id = newUserID }, newUser);
            
        }
    }
}
