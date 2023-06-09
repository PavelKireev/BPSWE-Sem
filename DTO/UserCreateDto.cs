﻿namespace ZdravotniSystem.DTO
{
    public class UserCreateDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? BirthDate { get; set; }
        public int InsuranceNumber { get; set; }
        public int OfficeNumber { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
