using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StalNoteM.Application
{
    public class AdvertisingWorker : IDisposable
    {
        private ApplicationDbContext context;
        private List<string> allNames = new List<string>();
        private int Counter = 0;
        private bool disposed;
        public AdvertisingWorker() 
        {
            disposed = false;
            context = new ApplicationDbContext();
            allNames = context.Advertisings.Select(x => x.NameCustomer).ToList();
        }
        public string TakeAdd()
        {
            if (Counter >= allNames.Count())
            {
                Counter = 0;
            }
            var Customer = context.Advertisings.Where(x => x.NameCustomer == allNames[Counter]).FirstOrDefault();
            Counter++;
            if (Customer.Count > 0)
            {
                Customer.Count--;
            }
            else if(Customer.Count == 0)
            {
                context.Advertisings.Remove(Customer);
            }
            if (Customer.End < DateTime.Now)
            {
                context.Advertisings.Remove(Customer);
            }
            return Customer.Context;
        }
        ~AdvertisingWorker()
        {
            context.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;
            if (disposing)
            {
                context.SaveChanges();
            }
            disposed = true;
        }
    }
}
