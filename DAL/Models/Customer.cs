using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Device> Devices { get; set; } = new List<Device>();
}
