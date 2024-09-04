using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Status
{
    public int Id { get; set; }

    public int DeviceId { get; set; }

    public int StatusId { get; set; }

    public DateTime? StatusChangeDate { get; set; }

    public virtual Device Device { get; set; } = null!;

    public virtual StatusType StatusNavigation { get; set; } = null!;
}
