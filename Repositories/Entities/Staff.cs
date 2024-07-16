using System;
using System.Collections.Generic;

namespace Repositories.Entities;

public partial class Staff
{
    public int StaffId { get; set; }

    public string FullName { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Role { get; set; } = null!;

    public int Phone { get; set; }

    public string Email { get; set; } = null!;

    public DateOnly? Birthday { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
