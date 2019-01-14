using _2NETProjetBDClient.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2NETProjetBDClient.DAL
{
    public class ClientDAO : IManager<Client>
    {
        public Client Add(Client obj)
        {
            using (var db = new ManagerContext())
            {
                db.clients.Add(obj);
                db.SaveChanges();
            }
            return obj;
        }

        public Client Edit(Client obj)
        {
            using (var db = new ManagerContext())
            {
                db.Entry(obj).State = 
                    System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return obj;
        }

        public IEnumerable<Client> FindAll(string search = null)
        {
            List<Client> clients = null;
            using (var db = new ManagerContext())
            {
                search = search ?? "";
                clients = db.clients?.Where(f => f.Fullname.ToUpper().Trim().
                Contains(search.ToUpper().Trim())).ToList();

            }
            return clients;
        }

        public Client FindById(int Id)
        {
           Client client = null;
            using (var db = new ManagerContext())
            {
                client = db.clients?.FirstOrDefault(f => f.Id == Id);
            }
            return client;
        }

        public void Remove(Client obj)
        {
            using (var db = new ManagerContext())
            {
                db.clients.Remove(obj);
                db.SaveChanges();
            }
        }
    }
}
