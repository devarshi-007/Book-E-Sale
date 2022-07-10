using BookStoreModels.NewFolder;
using BookStoreModels.ViewModels;
using BookStoreRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApi.Controllers
{
    [Route("api/Order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
            [HttpGet]
            [Route("list")]
            public ListResponse<GetOrderModel> GetOrders(int pageIndex = 1, int pageSize = 10, int userid = 0)
            {
                OrderRepository repo = new OrderRepository();
                ListResponse<GetOrder> order = repo.GetAll(pageIndex, pageSize, userid);
                return new ListResponse<GetOrderModel> { TotalRecords = order.TotalRecords, Results = order.Results.Select(record => new GetOrderModel(record)).ToList() };
            }

            [HttpPost]
            [Route("Add")]
            public OrderModel AddOrder(OrderModel order)
            {
                OrderRepository repo = new OrderRepository();
                return new OrderModel(repo.Add(order.ToEntity()));
            }
        
    }
}
