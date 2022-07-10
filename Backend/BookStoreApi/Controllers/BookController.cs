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
    [Route("api/book")]
    public class BookController : ControllerBase
    {
        BookRepository _bookRepository = new BookRepository();

        [Route("list")]
        [HttpGet]
        public IActionResult GetBooks(int pageIndex = 1, int pageSize = 10, string keyword = "")
        {
            var books = _bookRepository.GetBooks(pageIndex, pageSize, keyword);

            ListResponse<BookModel> listResponse = new ListResponse<BookModel>()
            {
                Results = books.Results.Select(c => new BookModel(c)),
                TotalRecords = books.TotalRecords,
            };

            return Ok(listResponse);
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult GetBook(int id)
        {
            var book = _bookRepository.GetBook(id);
            BookModel bookModel = new BookModel(book);
            if (book == null)
                return NotFound();
            return Ok(bookModel);
        }

        [Route("add")]
        [HttpPost]
        [ProducesResponseType(typeof(BookModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), (int)HttpStatusCode.BadRequest)]
        public IActionResult AddBook(BookModel model)
        {
            if (model == null)
                return BadRequest("Model is null");

            Book book = new Book()
            {
                Id = model.Id,
                Name = model.Name,
                Price = model.Price,
                Description = model.Description,
                Base64image = model.Base64image,
                Categoryid = model.Categoryid,
                Publisherid = model.Publisherid,
                Quantity = model.Quantity,
            };
            var response = _bookRepository.AddBook(book);
            BookModel bookModel = new BookModel(response);

            return Ok(bookModel);
        }

        [Route("update")]
        [HttpPut]
        [ProducesResponseType(typeof(BookModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), (int)HttpStatusCode.BadRequest)]
        public IActionResult UpdateBook(BookModel model)
        {
            if (model == null)
                return BadRequest("Model is null");

            Book book = new Book()
            {
                Id = model.Id,
                Name = model.Name,
                Price = model.Price,
                Description = model.Description,
                Base64image = model.Base64image,
                Categoryid = model.Categoryid,
                Publisherid = model.Publisherid,
                Quantity = model.Quantity,
            };
            var response = _bookRepository.UpdateBook(book);
            BookModel bookModel = new BookModel(response);

            return Ok(bookModel);
        }


        [Route("delete/{id}")]
        [HttpDelete]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), (int)HttpStatusCode.BadRequest)]
        public IActionResult DeleteBook(int id)
        {
            if (id == 0)
                return BadRequest("id is null");

            var response = _bookRepository.DeleteBook(id);
            return Ok(response);
        }

    }
}
