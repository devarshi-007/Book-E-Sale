using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreModels.ViewModels
{
    public class Order
    {
        public int Id { get; set; }
        public int Userid { get; set; }
        public DateTime Orderdate { get; set; }
        public List<SubOrder> subOrders { get; set; }
        public double Totalprice { get; set; }
    }
}
