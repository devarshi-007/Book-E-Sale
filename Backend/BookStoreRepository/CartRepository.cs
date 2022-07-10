using BookStore.Repository;
using BookStoreModels;
using BookStoreModels.NewFolder;
using BookStoreModels.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreRepository
{
    public class CartRepository : BaseRepository
    {
        public BaseList<GetCartModel> GetCartItems(int pageIndex, int pageSize, int UserId)
        {
               var query = _context.Carts.AsQueryable();
                BaseList<GetCartModel> result = new BaseList<GetCartModel>();
                List<GetCartModel> getCartModels = new List<GetCartModel>();

                if (pageSize != 0)
                {
                    query = query.Where(cart => (cart.Userid == UserId)).Skip((pageIndex - 1) * pageSize).Take(pageSize);

                    foreach (Cart cart in query.ToList())
                    {
                        GetCartModel getCartModel = new GetCartModel();
                        getCartModel.Id = cart.Id;
                        getCartModel.Userid = cart.Userid;

                        Book book = _context.Books.Where(b => b.Id == cart.Bookid).FirstOrDefault();
                        BookModel bookModel = new BookModel(book);
                        getCartModel.Book = bookModel;
                        getCartModel.Quantity = cart.Quantity;
                        getCartModels.Add(getCartModel);
                    }
                }
                result.TotalRecords = getCartModels.Count();
                result.Records = getCartModels;
                return result;
            }


        public Cart GetCart(int id)
        {
            return _context.Carts.FirstOrDefault(c => c.Id == id);
        }

        public Cart AddCart(Cart category)
        {
            var entry = _context.Carts.Add(category);
            _context.SaveChanges();
            return entry.Entity;
        }

        public Cart UpdateCart(Cart category)
        {
            var entry = _context.Carts.Update(category);
            _context.SaveChanges();
            return entry.Entity;
        }

        public bool DeleteCart(int id)
        {
            var cart = _context.Carts.FirstOrDefault(c => c.Id == id);
            if (cart == null)
            {
                return false;
            }
            _context.Carts.Remove(cart);
            _context.SaveChanges();
            return true;
        }

    }
}
