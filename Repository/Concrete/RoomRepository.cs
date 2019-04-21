using System;
using System.Data.Common;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Abstract;
using Models.Filters;
using Models.Models;

namespace Repository.Concrete
{
    public class RoomRepository : ConnectionManager, IRoomRepository
    {
        public void Add(Room room)
        {
            ExecuteNonQuery(string.Format(
                "INSERT INTO Room (number, description, type, places, price, status, assignedTo)" +
                "VALUES ({0}, '{1}', '{2}', {3}, {4}, '{5}', {6})",
                room.number, room.description, room.type, room.places, room.price, room.status, room.assignedTo));
        }

        public void Delete(RoomFilter filter)
        {
            string cmd = "Delete from Room ";
            List<string> wcmd = new List<string>();

            if (filter.Number.HasValue)
            {
                wcmd.Add("number = " + filter.Number);
            }

            if (!String.IsNullOrEmpty(filter.Description))
            {
                wcmd.Add("description LIKE %" + filter.Description + "%");
            }

            if (!String.IsNullOrEmpty(filter.Type))
            {
                wcmd.Add("type = " + filter.Type);
            }

            if (filter.Places.HasValue)
            {
                wcmd.Add("places = " + filter.Places);
            }

            if (filter.Price.HasValue)
            {
                wcmd.Add("price = " + filter.Price);
            }

            if (filter.PriceLowerThan.HasValue)
            {
                wcmd.Add("price < " + filter.PriceLowerThan);
            }

            if (filter.PriceUpperThan.HasValue)
            {
                wcmd.Add("price > " + filter.PriceUpperThan);
            }

            if (!String.IsNullOrEmpty(filter.Status))
            {
                wcmd.Add("status = " + filter.Status);
            }

            if (!String.IsNullOrEmpty(filter.AssignedTo))
            {
                wcmd.Add("assignedTo = " + filter.AssignedTo);
            }

            if (wcmd.Count() > 0)
            {
                cmd += "where " + string.Join(" AND ", wcmd.ToArray());
            }

            ExecuteNonQuery(cmd);
        }

        public void Update(Room room, RoomFilter filter)
        {
            string cmd = string.Format("Update Room set " +
                "number = {0}, description = '{1}', type = '{2}', places = {3}, price = {4}, status = '{5}', assignedTo = '{6}' ",
                room.number, room.description, room.type, room.places, room.price, room.status, room.assignedTo);
            List<string> wcmd = new List<string>();

            if (filter.Number.HasValue)
            {
                wcmd.Add("number = " + filter.Number);
            }

            if (!String.IsNullOrEmpty(filter.Description))
            {
                wcmd.Add("description LIKE %" + filter.Description + "%");
            }

            if (!String.IsNullOrEmpty(filter.Type))
            {
                wcmd.Add("type = " + filter.Type);
            }

            if (filter.Places.HasValue)
            {
                wcmd.Add("places = " + filter.Places);
            }

            if (filter.Price.HasValue)
            {
                wcmd.Add("price = " + filter.Price);
            }

            if (filter.PriceLowerThan.HasValue)
            {
                wcmd.Add("price < " + filter.PriceLowerThan);
            }

            if (filter.PriceUpperThan.HasValue)
            {
                wcmd.Add("price > " + filter.PriceUpperThan);
            }

            if (!String.IsNullOrEmpty(filter.Status))
            {
                wcmd.Add("status = " + filter.Status);
            }

            if (!String.IsNullOrEmpty(filter.AssignedTo))
            {
                wcmd.Add("assignedTo = " + filter.AssignedTo);
            }

            if (wcmd.Count() > 0)
            {
                cmd += "where " + string.Join(" AND ", wcmd.ToArray());
            }

            ExecuteNonQuery(cmd);
        }

        public List<Room> Get(RoomFilter filter)
        {
            string cmd = "Select * from Room ";
            List<string> wcmd = new List<string>();

            if (filter.Number.HasValue)
            {
                wcmd.Add("number = " + filter.Number);
            }

            if (!String.IsNullOrEmpty(filter.Description))
            {
                wcmd.Add("description LIKE %" + filter.Description + "%");
            }

            if (!String.IsNullOrEmpty(filter.Type))
            {
                wcmd.Add("type = " + filter.Type);
            }

            if (filter.Places.HasValue)
            {
                wcmd.Add("places = " + filter.Places);
            }

            if (filter.Price.HasValue)
            {
                wcmd.Add("price = " + filter.Price);
            }

            if (filter.PriceLowerThan.HasValue)
            {
                wcmd.Add("price < " + filter.PriceLowerThan);
            }

            if (filter.PriceUpperThan.HasValue)
            {
                wcmd.Add("price > " + filter.PriceUpperThan);
            }

            if (!String.IsNullOrEmpty(filter.Status))
            {
                wcmd.Add("status = " + filter.Status);
            }

            if (!String.IsNullOrEmpty(filter.AssignedTo))
            {
                wcmd.Add("assignedTo = " + filter.AssignedTo);
            }

            if (wcmd.Count() > 0)
            {
                cmd += "where " + string.Join(" AND ", wcmd.ToArray());
            }

            List<Room> roomList = new List<Room>();
            DbDataReader reader = ExecuteReader(cmd);
            while (reader.Read())
            {
                Room room = new Room();
                room.number = (int)reader["number"];
                room.description = (string)reader["description"];
                room.type = (string)reader["type"];
                room.places = (int)reader["places"];
                room.price = (double)reader["price"];
                room.status = (string)reader["status"];
                room.assignedTo = (string)reader["assignedTo"];

                roomList.Add(room);
            }
            RefreshDataReader();

            return roomList;
        }
    }
}
