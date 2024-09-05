using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Order
{
    public int Id { get; set; }

    public int DeviceId { get; set; }

    public DateTime? OrderDate { get; set; }

    public string? Notes { get; set; }

    public virtual Device Device { get; set; } = null!;
}
