﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace DiamondShop.Data.Models;

public partial class Customer
{
    public string CustomerId { get; set; }

    public string Email { get; set; }

    public string LastName { get; set; }

    public string FirstName { get; set; }

    public string Address { get; set; }

    public string PhoneNumber { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public string Gender { get; set; }

    public bool? IsActive { get; set; }

    public string Country { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}