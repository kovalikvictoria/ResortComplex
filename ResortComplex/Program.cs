using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Configuration;
using Npgsql;
using Repository;
using Models.Models;
using Repository.Abstract;
using Repository.Concrete;
using Models.Filters;

namespace ResortComplex
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionManager conn = new ConnectionManager();
            Menu menu = new Menu();
            menu.ChooseTable();
        }
    }
}
