﻿namespace Domain.Models
{
    public class User : DomainObject
    {
        public string UserId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
    }
}