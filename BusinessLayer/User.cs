using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer
{
    public class User
    {
        [Key]
        public int ID { get; private set; }

        [Required, MaxLength(20)]
        public string FirstName { get; set; }

        [Required, MaxLength(20)]
        public string FamilyName { get; set; }

        [Required, Range(10, 80)]
        public int Age { get; set; }

        [Required, MaxLength(20)]
        public string Username { get; set; }

        [Required, MaxLength(70)]
        public string Password { get; set; }

        [Required, MaxLength(20)]
        public string Email { get; set; }

        public List<User> Friends { get; set; }

        public IEnumerable<Game> Games{ get; set; }

        private User()
        {

        }

        public User(string firstName, string familyName, int age, string username, string password, string email)
        {
            FirstName = firstName;
            FamilyName = familyName;
            Age = age;
            Username = username;
            Password = password;
            Email = email;
        }
    }
}
