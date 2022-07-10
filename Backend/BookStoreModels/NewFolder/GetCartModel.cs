using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreModels.NewFolder
{
    public class GetCartModel
    {
        public int Id { get; set; }
        public int Userid { get; set; }
        public BookModel Book { get; set; }
        public int Quantity { get; set; }
    }
}
