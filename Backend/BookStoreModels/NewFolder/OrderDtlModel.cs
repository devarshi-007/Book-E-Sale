using BookStoreModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreModels.NewFolder
{
    public class OrderDtlModel
    {
        public OrderDtlModel()
        {

        }

        public OrderDtlModel(Orderdtl orderDtl)
        {
            this.Id = orderDtl.Id;
            this.Ordermstid = (int)orderDtl.Ordermstid;
            this.Bookid = (int)orderDtl.Bookid;
            this.Quantity = (int)orderDtl.Quantity;
            this.Price = (double)orderDtl.Price;
            this.Totalprice = (double)orderDtl.Totalprice;
        }
        public int Id { get; set; }
        public int Ordermstid { get; set; }
        public int Bookid { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Totalprice { get; set; }

        public SubOrder ToEntity()
        {
            return new SubOrder
            {
                Bookid = this.Bookid,
                Quantity = this.Quantity,
                Price = this.Price,
                Totalprice = this.Totalprice
            };
        }
    }
}
