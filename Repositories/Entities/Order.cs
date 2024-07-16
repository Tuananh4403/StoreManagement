using System;
using System.Collections.Generic;

namespace Repositories.Entities;

public partial class Order
{
    public int OrderId { get; set; }

    public DateOnly OrderDate { get; set; }

    public int? StaffId { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Staff? Staff { get; set; }
}
