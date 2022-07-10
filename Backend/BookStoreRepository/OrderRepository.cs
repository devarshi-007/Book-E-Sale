using BookStore.Repository;
using BookStoreModels.NewFolder;
using BookStoreModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreRepository
{
    public class OrderRepository : BaseRepository
    {
        public ListResponse<GetOrder> GetAll(int pageIndex, int pageSize, int userid)
        {
            GetOrder order = null;
            List<GetOrder> orders = new List<GetOrder>();
            List<GetSubOrder> subOrders = null;
            List<Ordermst> orderMsts = null;
            List<Orderdtl> orderDtls = null;
            ListResponse<GetOrder> result = new ListResponse<GetOrder>();
            
                orderMsts = _context.Ordermsts.Where(order => (order.Userid == userid)).Skip((pageIndex - 1) * pageSize).Take(pageSize).AsQueryable().ToList();

                foreach (Ordermst orderMst in orderMsts)
                {
                    order = new GetOrder();
                    order.Id = orderMst.Id;
                    order.Userid = (int)orderMst.Userid;
                    order.Orderdate = (DateTime)orderMst.Orderdate;
                    order.Totalprice = (double)orderMst.Totalprice;
                    orderDtls = _context.Orderdtls.AsQueryable().Where(o => o.Ordermstid == orderMst.Id).ToList();

                    subOrders = new List<GetSubOrder>();
                    foreach (Orderdtl orderDtl in orderDtls)
                    {
                        GetSubOrder getSubOrder = new GetSubOrder();
                        Book book = _context.Books.Where(b => b.Id == orderDtl.Bookid).FirstOrDefault();

                        getSubOrder.Book = new BookModel(book);
                        getSubOrder.Quantity = (int)orderDtl.Quantity;
                        getSubOrder.Price = (double)orderDtl.Price;
                        getSubOrder.Totalprice = (double)orderDtl.Totalprice;
                        subOrders.Add(getSubOrder);
                    }

                    order.subOrders = subOrders;
                    orders.Add(order);
                }
            int totalRecords = orders.Count();
            IEnumerable<GetOrder> getOrder = orders;
            return new ListResponse<GetOrder>
            {
                Results = getOrder,
                TotalRecords = totalRecords,
            };
        }

        public Order Add(Order order)
        {
            
                Ordermst orderMst = new Ordermst();
                orderMst.Userid = order.Userid;
                orderMst.Orderdate = order.Orderdate;
                orderMst.Totalprice = (decimal?)order.Totalprice;

                _context.Ordermsts.Add(orderMst);
                _context.SaveChanges();

                Orderdtl orderDtl = null;
                Book book = null;
                foreach (SubOrder subOrder in order.subOrders)
                {
                    book = _context.Books.Where(b => b.Id == subOrder.Bookid).FirstOrDefault();
                    orderDtl = new Orderdtl();
                    orderDtl.Ordermstid = orderMst.Id;
                    orderDtl.Bookid = subOrder.Bookid;
                    orderDtl.Quantity = subOrder.Quantity;
                    orderDtl.Price = (decimal?)subOrder.Price;
                    orderDtl.Totalprice = (decimal?)subOrder.Totalprice;
                    _context.Orderdtls.Add(orderDtl);
                    _context.SaveChanges();

                    book.Quantity = book.Quantity - orderDtl.Quantity;
                    _context.Books.Update(book);
                    _context.SaveChanges();
                }
                return order;
            
        }
    }
}

