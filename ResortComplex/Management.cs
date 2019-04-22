using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Configuration;
using Npgsql;
//using Services;
using Repository;
using Models.Models;
//using Repository.Abstract;
using Repository.Concrete;
using Models.Filters;

namespace ResortComplex
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionManager conn = new ConnectionManager();
            ServiceRepository repository = new ServiceRepository();

            //Service service1 = new Service(95345447, "Swimming pool", "", 60, 220);
            //repository.Add(service1);

            //Service service2 = new Service(95004068, "Taxi call", "", 0, 25);
            //repository.Add(service2);

            ServiceFilter filter = new ServiceFilter();
            filter.DurationUpperThan = 60;
            filter.PriceUpperThan = 30;
            repository.Delete(filter);

            repository.ShowAll();

            
            Console.Read();
        }
    }
}
