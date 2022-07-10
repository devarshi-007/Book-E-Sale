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
    public class CartControllers : ControllerBase
    {
        CartRepository _bookRepository = new CartRepository();

        private readonly CartRepository _cartRepository = new CartRepository();

        [HttpGet]
        [Route("list")]
        public IActionResult GetCartItems(string keyword)
        {
            List<Cart> carts = _cartRepository.GetCartItems(keyword);
            IEnumerable<CartModel> cartModels = carts.Select(c => new CartModel(c));
            return Ok(cartModels);
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
                Bookid = model.BookId,
                Userid = model.UserId
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
                Bookid = model.BookId,
                Userid = model.UserId
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
