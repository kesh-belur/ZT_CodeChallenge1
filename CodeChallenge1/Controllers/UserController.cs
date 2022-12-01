using CodeChallenge1.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace UserInfo.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController :Controller
    {

        private readonly ILogger<UserController> _logger;

        public  UserController(ILogger<UserController> logger)
        {
          _logger=logger?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet(Name = "GetUsers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
         public ActionResult<IEnumerable<UserDto>> GetUsers()

        {
            return Ok(UsersDataStore.Current.Users);
           // return UsersDataStore.Current.Users;
        }


        [HttpGet("{id}", Name = "GetUser")] //Helps after a new user has been created and can be called into.. See CreateUser method on how thi is used
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<UserDto> GetUser(int id)
        {
            try
            {
                throw new Exception("Testing Exception handling ");
                // Find user
                var user = UsersDataStore.Current.Users
                .FirstOrDefault(c => c.Id == id);
                if (user == null)
                {
                    _logger.LogInformation($"User with ID {id} was not found");
                    return NotFound();
                }
                return Ok(user);
                // return user != null ? user :NotFound();
            }
            catch (Exception ex)
            {

                _logger.LogCritical($"Exception while getting user with id {id}",ex);
                return StatusCode(500, "A problem occured while handling your request.Contact your api provider");
            }


            
            
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
       [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //Implemented properly this will have an Entity class. At this stage, the Entity/Dto is assumed to be the same for simplicity sake
        public ActionResult<UserDto> CreateUser([FromBody] UserCreationDto user) //the body will contain data for creation which will be de-serialized used by UserCreationDTO

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
        [HttpPut("{userId}")]
        public ActionResult UpdateUser(int userId,UserUpdateDto user)
        {
            var userFromStore = UsersDataStore.Current.Users.FirstOrDefault(u => u.Id==userId);

            if (userFromStore==null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            userFromStore.DateOfBirth = user.DateOfBirth;
            userFromStore.Email = user.Email;
            userFromStore.FirstName = user.FirstName;
            userFromStore.LastName = user.LastName;

            return NoContent();
        }

        [HttpDelete("{userId}")]
        public ActionResult DeleteUser(int userId)
        {
            var userFromStore = UsersDataStore.Current.Users.FirstOrDefault(u => u.Id == userId);

            if (userFromStore == null)
            {
                return NotFound();
            }

            UsersDataStore.Current.Users.Remove(userFromStore);

            return NoContent();
        }

        [HttpPatch("{userId}")]
        public ActionResult PartiallyUpdateUser(int userId,JsonPatchDocument<UserUpdateDto> patchDocument)
        {
            var userFromStore=UsersDataStore.Current.Users.FirstOrDefault(u=>u.Id==userId);

            if (userFromStore==null)
            {
                return NotFound();
            }

            
            var userToPatch = new UserUpdateDto() { Email = userFromStore.Email, FirstName = userFromStore.FirstName };
            patchDocument.ApplyTo(userToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(userToPatch))
            {
                return BadRequest(ModelState);
            }

            userFromStore.FirstName=userToPatch.FirstName;
            userFromStore.Email = userToPatch.Email;

                return NoContent();
        }
    }
}
