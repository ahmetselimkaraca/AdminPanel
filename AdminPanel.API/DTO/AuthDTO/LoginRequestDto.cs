﻿using System.ComponentModel.DataAnnotations;

namespace AdminPanel.API.DTO.AuthDTO
{
    public class LoginRequestDto
    {
        [Required]
        [DataType(DataType.Text)]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }   
}
