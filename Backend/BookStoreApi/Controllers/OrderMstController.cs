using BookStoreModels.NewFolder;
using BookStoreModels.ViewModels;
using BookStoreRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BookStoreApi.Controllers
{
    [ApiController]
    [Route("api/OrderMst")]
    public class OrderMstController : ControllerBase
    {
        OrdermstRepository _repository = new OrdermstRepository();

        [Route("{id}")]
        [HttpGet]
        [ProducesResponseType(typeof(OrdermstModel), (int)HttpStatusCode.OK)]
        public IActionResult GetOrderdtl(int id)
        {
            var order = _repository.GetOrderMst(id);
            OrdermstModel orderdtlModel = new OrdermstModel(order);

            return Ok(order);
        }

        [Route("add")]
        [HttpPost]
        [ProducesResponseType(typeof(OrderdtlModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), (int)HttpStatusCode.BadRequest)]
        public IActionResult AddOrdermst(OrdermstModel model)
        {
            Ordermst order = new Ordermst()
            {
                Id = model.Id,
                Userid = model.Userid,
                Orderdate = model.Orderdate,
                Totalprice = model.Totalprice
            };
            var response = _repository.AddOrderMsts(order);
            OrdermstModel orderdtlModel = new OrdermstModel(response);

            return Ok(orderdtlModel);
        }


        [Route("delete/{id}")]
        [HttpDelete]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), (int)HttpStatusCode.BadRequest)]
        public IActionResult DeleteOrdermst(int id)
        {
            if (id == 0)
                return BadRequest("id is null");

            var response = _repository.DeleteOrderMst(id);
            return Ok(response);
        }
    }
}
