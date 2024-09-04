using System;
using System.Collections.Generic;

namespace Service.DTOs;

public partial class StatusTypeDto
{
    public int Id { get; set; }

    public string StatusName { get; set; } = null!;
}
