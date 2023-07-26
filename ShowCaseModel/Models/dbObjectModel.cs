using EFCore_DBLibrary;
using EFCore_DBModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace ShowCaseModel.Models
{
    public class dbObjectModel : IdbObject
    {
        private DBFactory dBFactory;
        private int currentID;
        private dbObject? currentdBObject;

        public dbObjectModel()
        {
            dBFactory = new DBFactory();
            GetFirstEntry();
        }

        private void GetFirstEntry()
        {
            using (var context = dBFactory.GetDbContext())
            {
                currentdBObject = context.dbObjects.FirstOrDefault();
                if (currentdBObject != null)
                {
                    currentID = currentdBObject.Id;
                }
                else
                {
                    currentID = 0;
                }
            }
        }

        public bool AddEntry()
        {
            using (var context = dBFactory.GetDbContext())
            {
                currentdBObject = new dbObject { Name = "tempNew" };
                context.Add(currentdBObject);
                context.SaveChanges();
                return true;
            }
        }

        public bool DeleteEntry()
        {
            using (var context = dBFactory.GetDbContext())
            {
                context.Remove(currentdBObject);
                context.SaveChanges();
                GetFirstEntry();
                return true;
            }
        }

        public int GetiD()
        {
            return currentID;
        }

        public string GetName()
        {
            if (currentdBObject is not null)
            {
                return currentdBObject.Name;
            }
            else
            {
                return "NULL";
            }
        }

        public bool NextEntry()
        {
            using (var context = dBFactory.GetDbContext())
            {
                var nextList = context.dbObjects.Where(t => t.Id > currentID).ToList();
                dbObject next;
                if (nextList.Count > 1)
                {
                    next = nextList.OrderBy( x => x.Id).Take(1).Single();
                }
                else if (nextList.Count == 1) 
                {
                    next = nextList.Single();
                }
                else
                {
                    next = null;
                }

                if (next is not null)
                {
                    currentdBObject = next;
                    currentID = next.Id;
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }

        public bool PrevEntry()
        {
            using (var context = dBFactory.GetDbContext())
            {
                var nextList = context.dbObjects.Where(t => t.Id < currentID).ToList();
                dbObject next;
                if (nextList.Count > 1)
                {
                    next = nextList.OrderByDescending(x => x.Id).Take(1).Single();
                }
                else if (nextList.Count == 1) 
                {
                    next = nextList.Single();
                }
                else
                {
                    next = null;
                }

                if (next is not null)
                {
                    currentdBObject = next;
                    currentID = next.Id;
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }

        public bool SaveEntry()
        {
            using (var context = dBFactory.GetDbContext())
            {
                if (currentdBObject != null)
                {
                    context.Update(currentdBObject);
                }
                context.SaveChanges();
                return true;
            }
        }

        public void SetName(string name)
        {
            if (currentdBObject is not null)
            {
                currentdBObject.Name = name;
                return;
            }
            else
            {
                return;
            }
        }
    }
}
