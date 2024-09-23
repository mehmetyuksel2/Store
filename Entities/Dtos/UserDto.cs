﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public record UserDto
    {
        [DataType(DataType.Text)]
        [Required(ErrorMessage ="UserName is required")]
        public string? UserName { get; init; }//initi unutmuyoruz

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; init; }//initi unutmuyoruz

        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; init; }//initi unutmuyoruz

        public HashSet<String> Roles { get; set; } = new HashSet<string>();//yazma okuma açık
        
    }
}
