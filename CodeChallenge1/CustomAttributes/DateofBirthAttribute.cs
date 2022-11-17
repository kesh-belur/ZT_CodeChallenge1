using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CodeChallenge1.CustomAttributes
{
    public class DateOfBirthAttribute : ValidationAttribute
    {
        public int MinAge { get; set; }
      

        public override bool IsValid(object value)
        {
            if (value == null)
                return false;

            var val = (DateTime)value;

            //calculate age
            return (DateTime.Today.Year - val.Year)>=MinAge;            

           
        }
    }
}
