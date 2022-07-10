using BookStoreModels.ViewModels;
using System.Collections.Generic;

namespace BookStoreModels.NewFolder
{
    public class ListResponse<T> where T : class
    {
        public IEnumerable<T> Results { get; set; }

        public int TotalRecords { get; set; }
    }
}
