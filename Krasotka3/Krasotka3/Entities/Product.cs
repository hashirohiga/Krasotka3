using System;
using System.Collections.Generic;

namespace Krasotka3.Entities
{
    public partial class Product
    {
        private string? _productPhoto;
        public Product()
        {
            OrderProducts = new HashSet<OrderProduct>();
        }

        public string ProductArticleNumber { get; set; } = null!;
        public string ProductName { get; set; } = null!;
        public string ProductDescription { get; set; } = null!;
        public string ProductCategory { get; set; } = null!;
        public string? ProductPhoto 
        {
            get => (_productPhoto == null || _productPhoto == string.Empty)
                ? $"..\\Resources\\picture.png"
                : $"..\\Resources\\products\\{_productPhoto}";
            set => _productPhoto = value;
        }
        public string ProductManufacturer { get; set; } = null!;
        public decimal ProductCost { get; set; }
        public byte? ProductDiscountAmount { get; set; }
        public int ProductQuantityInStock { get; set; }

        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
