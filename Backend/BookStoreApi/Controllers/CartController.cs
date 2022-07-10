using BookStoreModels;
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
    [ApiController]
    [Route("api/cart")]
    public class CartController : ControllerBase
    {
        CartRepository _bookRepository = new CartRepository();

        private readonly CartRepository _cartRepository = new CartRepository();

        [HttpGet]
        [Route("list")]
        public BaseList<GetCartModel> GetCartItems(int pageIndex = 1, int pageSize = 10, int UserId = 0)
        {
            CartRepository repo = new CartRepository();
            BaseList<GetCartModel> cart = repo.GetCartItems(pageIndex, pageSize, UserId);
            return cart;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetCart(int id)
        {
            Cart carts = _cartRepository.GetCart(id);
            return Ok(carts);
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddCart(CartModel model)
        {
            if (model == null)
                return BadRequest();

            Cart cart = new Cart()
            {
                Id = model.Id,
                Quantity = model.Quantity,
                Bookid = model.Bookid,
                Userid = model.Userid
            };
            cart = _cartRepository.AddCart(cart);

            return Ok(new CartModel(cart));
        }

        [HttpPut]
        [Route("update")]
        public IActionResult UpdateCart(CartModel model)
        {
            if (model == null)
                return BadRequest();

            Cart cart = new Cart()
            {
                Id = model.Id,
                Quantity = model.Quantity,
                Bookid = model.Bookid,
                Userid = model.Userid
            };
            cart = _cartRepository.UpdateCart(cart);

            return Ok(new CartModel(cart));
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult DeleteCart(int id)
        {
            if (id == 0)
                return BadRequest();

            bool response = _cartRepository.DeleteCart(id);
            return Ok(response);
        }

    }
}
