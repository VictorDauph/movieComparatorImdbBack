using movieComparatorImdbBack.dto;
using System;
using System.ComponentModel.DataAnnotations;

namespace movieComparatorImdbBack.models
{
    [Index(nameof(UserName), IsUnique = true)]
    public class User
    {
        public User() {
            this.UserName = "";
        }

        public User(NewUserDto dto)
        {
            this.UserName = dto.Username;
        }

        public int Id { get; set; }
      
        public string UserName { get; set; }
    }
}
