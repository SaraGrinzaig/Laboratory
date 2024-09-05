using System;
using System.Collections.Generic;

namespace Service.DTOs;

public partial class DeviceDto
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
}
