using _2NETProjetBDClient.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2NETProjetBDClient.DAL
{
    public class WishDAO : IManager<Wish>
    {
        public Wish Add(Wish obj)
        {
            using (var db = new ManagerContext())
            {
                db.wishs.Add(obj);
                db.SaveChanges();
            }
            return obj;
        }

        public Wish Edit(Wish obj)
        {
            using (var db = new ManagerContext())
            {
                db.Entry(obj).State =
                    System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return obj;
        }

        public IEnumerable<Wish> FindAll(string search = null)
        {
            List<Wish> Wishs = null;
            using (var db = new ManagerContext())
            {
                search = search ?? "";
                Wishs = db.wishs?.Where(f => f.Title.ToUpper().Trim().
                Contains(search.ToUpper().Trim())).ToList();

            }
            return Wishs;
        }

        public Wish FindById(int Id)
        {
            Wish Wish = null;
            using (var db = new ManagerContext())
            {
                Wish = db.wishs?.FirstOrDefault(f => f.Id == Id);
            }
            return Wish;
        }

        public void Remove(Wish obj)
        {
            using (var db = new ManagerContext())
            {
                db.wishs.Remove(obj);
                db.SaveChanges();
            }
        }
    }
}

