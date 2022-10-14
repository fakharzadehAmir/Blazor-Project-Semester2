using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace P8.Shared
{
    public class User
    {
        public int Id {get; set;}
        [Required]
        public string Username {get; set;}
        [Required]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z")]
        public string Email {get; set;}
        [Required]
        public string Password {get; set;}
        public override string ToString() =>
            $"{this.Username}, {this.Email}, {this.Id}";

        public override int GetHashCode() =>
            this.Id;

        public override bool Equals(object obj)
        {
            var other = obj as User;
            if(other==null) return false;
            return this.Username == other.Username && this.Password == other.Password;
        }
    }
}
