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
    [Route("api/orderdtl")]
    public class OrderdtlController : ControllerBase
    {
        OrderdtlRepository _repository = new OrderdtlRepository();

        [Route("{id}")]
        [HttpGet]
        [ProducesResponseType(typeof(OrderdtlModel), (int)HttpStatusCode.OK)]
        public IActionResult GetOrderdtl(int id)
        {
            var order = _repository.GetOrderdtl(id);
            OrderdtlModel orderdtlModel = new OrderdtlModel(order);

            return Ok(order);
        }

        [Route("add")]
        [HttpPost]
        [ProducesResponseType(typeof(OrderdtlModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), (int)HttpStatusCode.BadRequest)]
        public IActionResult AddOrderdtl(OrderdtlModel model)
        {
            Orderdtl order = new Orderdtl()
            {
                Quantity = model.Quantity,
                Ordermstid = model.Ordermstid,
                Price = model.Price,
                Totalprice = model.Totalprice
            };
            var response = _repository.AddOrderdtl(order);
            OrderdtlModel orderdtlModel= new OrderdtlModel(response);

            return Ok(orderdtlModel);
        }

        
        [Route("delete/{id}")]
        [HttpDelete]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), (int)HttpStatusCode.BadRequest)]
        public IActionResult DeleteOrderdtl(int id)
        {
            if (id == 0)
                return BadRequest("id is null");

            var response = _repository.DeleteOrderdtl(id);
            return Ok(response);
        }
    }
}
