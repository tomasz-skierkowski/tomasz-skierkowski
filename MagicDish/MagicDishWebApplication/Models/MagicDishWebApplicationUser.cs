using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MagicDishWebApplication.Models;

// Add profile data for application users by adding properties to the MagicDishWebApplicationUser class
public class MagicDishWebApplicationUser : IdentityUser
{
    public int Id { get; set; }
    
    //public string Email {get; set; }
    //public string PasswordHash {get; set; }

}

