﻿namespace ECommerceBookStore.Domain.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public long Pincode { get; set; }

        public long PhoneNumber { get; set; }
        public bool IsCustomer { get; set; }

    }
}
