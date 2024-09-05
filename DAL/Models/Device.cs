using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Device
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public string DeviceType { get; set; } = null!;

    public string DeviceModel { get; set; } = null!;

    public string IssueDescription { get; set; } = null!;

    public string? UnlockCode { get; set; }

    public decimal? EstimatedPrice { get; set; }

    public decimal? FinalPrice { get; set; }

    public string? Notes { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Status> Statuses { get; set; } = new List<Status>();
}
