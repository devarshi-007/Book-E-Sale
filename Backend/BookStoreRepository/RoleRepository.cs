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
    public class RoleRepository : BaseRepository
    {
        public ListResponse<Role> Roles()
        {

            var query = _context.Roles.AsQueryable();
            int totalReocrds = query.Count();
            IEnumerable<Role> categories = query;

            return new ListResponse<Role>()
            {
                Results = categories,
                TotalRecords = totalReocrds,
            };
        }
        public ListResponse<Role> GetRoles(int pageIndex, int pageSize, string keyword)
        {
            keyword = keyword?.ToLower()?.Trim();
            var query = _context.Roles.Where(c => keyword == null || c.Name.ToLower().Contains(keyword)).AsQueryable();
            int totalReocrds = query.Count();
            List<Role> categories = query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();

            return new ListResponse<Role>()
            {
                Results = categories,
                TotalRecords = totalReocrds,
            };
        }

        public Role GetRole(int id)
        {
            return _context.Roles.FirstOrDefault(c => c.Id == id);
        }

        public Role AddRole(Role role)
        {
            var entry = _context.Roles.Add(role);
            _context.SaveChanges();
            return entry.Entity;
        }

        public Role UpdateRole(Role role)
        {
            var entry = _context.Roles.Update(role);
            _context.SaveChanges();
            return entry.Entity;
        }

        public bool DeleteRole(int id)
        {
            var category = _context.Roles.FirstOrDefault(c => c.Id == id);
            if(category == null)
            {
                return false;
            }
            _context.Roles.Remove(category);
            _context.SaveChanges();
            return true;
        }
    }
}
