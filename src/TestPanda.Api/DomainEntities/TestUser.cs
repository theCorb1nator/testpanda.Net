using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestPanda.Api.DomainEntities
{
    public class TestUser
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public Role Role { get; private set; }

        public TestUser(string name, 
            string email, Role role)
        {
            Name = name;
            Email = email;
            Role = role;
        }
    }
}