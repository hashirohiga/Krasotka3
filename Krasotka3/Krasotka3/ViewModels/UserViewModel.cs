using Krasotka3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krasotka3.ViewModels
{
    public class UserViewModel:ViewModelBase
    {
        private List<Product> _products;
        private List<Product> _displayingProduct;
        private string _searchValue;
        private int _displayingCount;
        private int _allCount;
        private string _sortValue;
        private string _filterValue;
        private User _user;

        public User User
        {
            get { return _user; }
            set { Set(ref _user, value, nameof(User)); }
        }

        public string FilterValue
        {
            get { return _filterValue; }
            set { Set(ref _filterValue,value,nameof(FilterValue));
                DisplayProduct();
            }
        }

        public string SortValue
        {
            get { return _sortValue; }
            set { Set(ref _sortValue,value,nameof(SortValue));
                DisplayProduct();
            }
        }





        public int AllCount
        {
            get { return _allCount; }
            set { Set(ref _allCount,value,nameof(AllCount)); }
        }

        public int DisplayingCount
        {
            get { return _displayingCount; }
            set { Set(ref _displayingCount,value,nameof(DisplayingCount)); }
        }


        public string SearchValue
        {
            get { return _searchValue; }
            set { Set(ref _searchValue,value,nameof(SearchValue));
                DisplayProduct();
            }
        }

        public List<Product> DisplayingProduct
        {
            get { return _displayingProduct; }
            set { Set(ref _displayingProduct, value, nameof(DisplayingProduct)); }
        }

        public List<Product> Products
        {
            get { return _products; }
            set { Set(ref _products, value, nameof(Products)); }
        }

        public UserViewModel(User user)
        {
            
            using(ApplicationDbContext context = new()) 
            {
                Products = context.Products.ToList();
            }
            DisplayProduct();
            SortValue = SortList[0];
            FilterValue = FilterList[0];
            User = user;
        }

        public List<string> SortList => new() 
        {
            "Без сортировки",
            "Стоимость возр.",
            "Стоимость уб."

        };

        public List<string> FilterList => new()
        {
            "Без фильтрации",
            "0% - 9.99%",
            "10% - 14.99%",
            "< 15%"

        };


        private void DisplayProduct()
        {
            DisplayingProduct = Sorting(Search(Filtering(_products)));
            DisplayingCount = DisplayingProduct.Count;
            AllCount = Products.Count;
        }
        //фильтрация
        private List<Product> Filtering(List<Product> products)
        {
            if (FilterValue == FilterList[1])
                return products.Where(pd => pd.ProductDiscountAmount < 10).ToList();
            else if (FilterValue == FilterList[2])
                return products.Where(pd => pd.ProductDiscountAmount >= 10 && pd.ProductDiscountAmount < 15).ToList();
            else if (FilterValue == FilterList[3])
                return products.Where(pd => pd.ProductDiscountAmount > 15).ToList();
            else
                return products;
        }
        //сортировка
        private List<Product> Sorting(List<Product> products)
        {
            if (SortValue == SortList[1])
                return products.OrderByDescending(pc => pc.ProductCost).ToList();
            else if (SortValue == SortList[2])
                return products.OrderBy(pc => pc.ProductCost).ToList();
            else
                return products;
        }
        //поиск
        private List<Product> Search(List<Product> products)
        {
            if (SearchValue == null || SearchValue == string.Empty)
                return products;
            else
            return products.Where(pm => pm.ProductName.ToLower().Contains(SearchValue.ToLower())).ToList();
            
        }
    }
}
