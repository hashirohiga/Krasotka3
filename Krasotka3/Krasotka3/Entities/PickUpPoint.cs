using System;
using System.Collections.Generic;

namespace Krasotka3.Entities
{
    public partial class PickUpPoint
    {
        public PickUpPoint()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string PickupPointName { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
    }
}
