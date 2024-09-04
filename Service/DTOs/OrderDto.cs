using System;
using System.Collections.Generic;

namespace Service.DTOs;

public partial class OrderDto
{
    public int Id { get; set; }

    public int DeviceId { get; set; }

    public DateTime? OrderDate { get; set; }

    public string? Notes { get; set; }
}
