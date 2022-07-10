using BookStoreModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreModels.NewFolder
{
    public class GetOrderModel
    {
        public GetOrderModel()
        {

        }

        public GetOrderModel(GetOrder order)
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
        public List<GetSubOrder> subOrders { get; set; }
        public double Totalprice { get; set; }

        public GetOrder ToEntity()
        {
            return new GetOrder
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
