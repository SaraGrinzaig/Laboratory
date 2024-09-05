using System;
using System.Collections.Generic;

namespace Service.DTOs;

public partial class StatusDto
{
    public int Id { get; set; }

    public int DeviceId { get; set; }

    public int StatusId { get; set; }

    public DateTime? StatusChangeDate { get; set; }
}
