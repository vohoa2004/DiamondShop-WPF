﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace DiamondShop.Data.Models;

public partial class Promotion
{
    public string PromotionId { get; set; }

    public decimal Amount { get; set; }

    public DateTime ValidFrom { get; set; }

    public DateTime ValidTo { get; set; }

    public string Description { get; set; }

    public string Code { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}