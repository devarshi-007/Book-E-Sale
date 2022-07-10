using BookStoreModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreModels.NewFolder
{
    public class OrderModel
    {
        public OrderModel()
        {

        }

        public OrderModel(Order order)
        {
            this.Id = order.Id;
            this.Userid = order.Userid;
            this.Orderdate = order.Orderdate;
            this.subOrders = order.subOrders;
            this.Totalprice = order.Totalprice;
        }

        public int Id { get; set; }
        public int Userid { get; set; }
        public DateTime Orderdate { get; set; }
        public List<SubOrder> subOrders { get; set; }
        public double Totalprice { get; set; }

        public Order ToEntity()
        {
            return new Order
            {
                Totalprice = this.Totalprice,
                subOrders = this.subOrders,
                Orderdate = this.Orderdate,
                Userid = this.Userid,
                Id = this.Id
            };
        }
    }
}
