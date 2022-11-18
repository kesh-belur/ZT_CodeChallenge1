﻿using CodeChallenge1.CustomAttributes;
using System.ComponentModel.DataAnnotations;

namespace CodeChallenge1.Models
{
    public class UserDto
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; } = string.Empty;

        public string? LastName { get; set; } = String.Empty;
        
        public string? Email { get; set; } = string.Empty;
       
        public DateTime DateOfBirth { get; set; }
    }
}
