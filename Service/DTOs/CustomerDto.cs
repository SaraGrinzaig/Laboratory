using System;
using System.Collections.Generic;

namespace Service.DTOs;

public partial class CustomerDto
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;
}
