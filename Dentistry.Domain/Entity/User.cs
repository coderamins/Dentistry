using System;
using System.ComponentModel.DataAnnotations;

namespace Dentistry.Domain.Entity
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
