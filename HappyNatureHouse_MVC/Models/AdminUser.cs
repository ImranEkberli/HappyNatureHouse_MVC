﻿namespace HappyNatureHouse_MVC.Models
{
    public class AdminUser
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
