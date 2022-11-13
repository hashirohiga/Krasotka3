using System;
using System.Collections.Generic;

namespace Krasotka3.Entities
{
    public partial class Order
    {
        public Order()
        {
            OrderProducts = new HashSet<OrderProduct>();
        }

        public int OrderId { get; set; }
        public string OrderStatus { get; set; } = null!;
        public DateTime OrderDate { get; set; }
        public DateTime OrderDeliveryDate { get; set; }
        public string? OrderFio { get; set; }
        public string OrderCode { get; set; } = null!;
        public int OrderPickupPointId { get; set; }

        public virtual PickUpPoint OrderPickupPoint { get; set; } = null!;
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
