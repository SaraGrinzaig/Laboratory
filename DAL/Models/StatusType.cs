using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class StatusType
{
    public int Id { get; set; }

    public string StatusName { get; set; } = null!;

    public virtual ICollection<Status> Statuses { get; set; } = new List<Status>();
}
