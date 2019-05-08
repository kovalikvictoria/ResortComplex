using Models.Filters;
using Models.Models;
using Repository.Concrete;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Concrete
{
    public class RoomServices :IRoomServices
    {
        public double MinPrice()
        {
            List<Room> rooms = new RoomRepository().Get(new RoomFilter());
            double minPrice = rooms[0].price;
            for (int i = 1; i < rooms.Count; i++)
                if (rooms[i].price < minPrice)
                    minPrice = rooms[i].price;
            return minPrice;
        }
        public double MaxPrice()
        {
            List<Room> rooms = new RoomRepository().Get(new RoomFilter());
            double maxPrice = rooms[0].price;
            for (int i = 1; i < rooms.Count; i++)
                if (rooms[i].price < maxPrice)
                    maxPrice = rooms[i].price;
            return maxPrice;
        }
    }
}
