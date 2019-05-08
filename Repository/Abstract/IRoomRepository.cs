using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Models;
using Models.Filters;

namespace Repository.Abstract
{
    public interface IRoomRepository
    {
        void Add(Room room);
        void Delete(RoomFilter filter);
        void Update(Room room, RoomFilter filter);
        void Select(RoomFilter filter);
    }
}
