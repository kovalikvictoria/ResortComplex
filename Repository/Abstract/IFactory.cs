using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Configuration;
using Models;
using Repository.Abstract;

namespace Repository
{
    interface IFactory
    {
        IRoomRepository GetRoomRepository();
        IEmployeeRepository GetEmployeeRepository();
        IServiceRepository GetServiceRepository();
    }   
}
