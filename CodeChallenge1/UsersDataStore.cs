using CodeChallenge1.Models;

namespace UserInfo.API
{ 
        public  class UsersDataStore
        {
            public List<UserDto> Users { get; set; }
           //public static UsersDataStore Current { get; } = new UsersDataStore();

            public UsersDataStore()
            {
                // Initialise Users Data
                Users = new List<UserDto>()
            {
                new UserDto()
                {
                     Id = 100,
                     FirstName = "Spider",
                     LastName = "Man",
                     Email = "spider@email",
                     DateOfBirth= new DateTime(1980,1,1)
                    
                },
               new UserDto()
                {
                     Id = 200,
                     FirstName = "Super",
                     LastName = "Man",
                     Email = "super@email.com",
                     DateOfBirth= new DateTime(1960,1,1)

                }
            };

            }

        }
    }



