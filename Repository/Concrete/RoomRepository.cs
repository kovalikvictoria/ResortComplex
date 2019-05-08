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
            try
            {
                ExecuteNonQuery(string.Format(
                    "INSERT INTO Room (number, description, type, places, price, status, assignedTo)" +
                    "VALUES ({0}, '{1}', '{2}', {3}, {4}, '{5}', '{6}')",
                    room.number, room.description, room.type, room.places, room.price, room.status, room.assignedTo));
            }
            catch(Exception e)
            {
                Console.WriteLine("Error " + e.ToString());
                Console.ReadKey();
            }
        }
        public void Delete(RoomFilter filter)
        {
            try
            {
                string cmd = "Delete from Room ";

                List<string> wcmd = new List<string>();
                if (filter.Number.HasValue)
                {
                    wcmd.Add("number = " + filter.Number);
                }
                if (!String.IsNullOrEmpty(filter.Description))
                {
                    wcmd.Add("description LIKE '" + filter.Description + "%'");
                }
                if (!String.IsNullOrEmpty(filter.Type))
                {
                    wcmd.Add("type LIKE '" + filter.Type + "%'");
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
                    wcmd.Add("status LIKE '" + filter.Status + "%'");
                }
                if (!String.IsNullOrEmpty(filter.AssignedTo))
                {
                    wcmd.Add("assignedTo LIKE '" + filter.AssignedTo + "%'");
                }
                if (wcmd.Count() > 0)
                {
                    cmd += "where " + string.Join(" AND ", wcmd.ToArray());
                }

                ExecuteNonQuery(cmd);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e.ToString());
                Console.ReadKey();
            }
        }
        public void Update(Room room, RoomFilter filter)
        {
            try
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
                    wcmd.Add("description LIKE '" + filter.Description + "%'");
                }
                if (!String.IsNullOrEmpty(filter.Type))
                {
                    wcmd.Add("type LIKE '" + filter.Type + "%'");
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
                    wcmd.Add("status LIKE '" + filter.Status + "%'");
                }
                if (!String.IsNullOrEmpty(filter.AssignedTo))
                {
                    wcmd.Add("assignedTo LIKE '" + filter.AssignedTo + "%'");
                }
                if (wcmd.Count() > 0)
                {
                    cmd += "where " + string.Join(" AND ", wcmd.ToArray());
                }

                ExecuteNonQuery(cmd);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e.ToString());
                Console.ReadKey();
            }
        }
        public void Select(RoomFilter filter)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Repository: ROOM\n\n");

                string cmd = "Select * from Room ";

                List<string> wcmd = new List<string>();
                if (filter.Number.HasValue)
                {
                    wcmd.Add("number = " + filter.Number);
                }
                if (!String.IsNullOrEmpty(filter.Description))
                {
                    wcmd.Add("description LIKE '" + filter.Description + "%'");
                }
                if (!String.IsNullOrEmpty(filter.Type))
                {
                    wcmd.Add("type LIKE '" + filter.Type + "%'");
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
                    wcmd.Add("status LIKE '" + filter.Status + "%'");
                }
                if (!String.IsNullOrEmpty(filter.AssignedTo))
                {
                    wcmd.Add("assignedTo LIKE '" + filter.AssignedTo + "%'");
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

                Console.WriteLine("You can choose columns: number, description," +
                    " type, places, price, status, assignedTo");
                Helper h = new Helper();
                int n = h.AmountOfColumns();
                List<string> columns = h.NamesOfColumns(n);
                WriteTable(n, roomList, columns);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e.ToString());
                Console.ReadKey();
            }
        }
        
        public List<Room> Get(RoomFilter filter)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Repository: ROOM\n\n");

                string cmd = "Select * from Room ";

                List<string> wcmd = new List<string>();
                if (filter.Number.HasValue)
                {
                    wcmd.Add("number = " + filter.Number);
                }
                if (!String.IsNullOrEmpty(filter.Description))
                {
                    wcmd.Add("description LIKE '" + filter.Description + "%'");
                }
                if (!String.IsNullOrEmpty(filter.Type))
                {
                    wcmd.Add("type LIKE '" + filter.Type + "%'");
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
                    wcmd.Add("status LIKE '" + filter.Status + "%'");
                }
                if (!String.IsNullOrEmpty(filter.AssignedTo))
                {
                    wcmd.Add("assignedTo LIKE '" + filter.AssignedTo + "%'");
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
                return roomList;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e.ToString());
                Console.ReadKey();
                return new List<Room>();
            }
        }
        public Room CreateModel()
        {
            Console.Clear();
            Console.WriteLine("Repository: ROOM\n\n");
            Console.WriteLine("SET\n");

            Room room = new Room();

            Console.WriteLine("NUMBER: ");
            room.number = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("DESCRIPTION: ");
            room.description = Console.ReadLine();

            Console.WriteLine("TYPE: ");
            room.type = Console.ReadLine();

            Console.WriteLine("PLACES: ");
            room.places = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("PRICE: ");
            room.price = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("STATUS: ");
            room.status = Console.ReadLine();

            Console.WriteLine("ASSIGNED TO: ");
            room.assignedTo = Console.ReadLine();

            return room;
        }
        public RoomFilter CreateFilter()
        {
            Console.Clear();
            Console.WriteLine("Repository: ROOM\n\n");
            Console.WriteLine("Creating conditions for rows\n" +
                 "You can skip some conditions\n" +
                 "(select ... , where): ");

            RoomFilter filter = new RoomFilter();

            Console.WriteLine("NUMBER: ");
            string a1 = Console.ReadLine();
            if (a1 != "") filter.Number = Convert.ToInt32(a1);

            Console.WriteLine("DESCRIPTION: ");
            filter.Description = Console.ReadLine();

            Console.WriteLine("TYPE: ");
            filter.Type = Console.ReadLine();

            Console.WriteLine("PLACES: ");
            string a2 = Console.ReadLine();
            if (a2 != "") filter.Number = Convert.ToInt32(a2);

            Console.WriteLine("PRICE: ");
            string a = Console.ReadLine();
            if (a != "") filter.Price = Convert.ToDouble(a);

            Console.WriteLine("PRICE lower than: ");
            string b = Console.ReadLine();
            if (b != "") filter.PriceLowerThan = Convert.ToDouble(b);

            Console.WriteLine("PRICE upper than: ");
            string c = Console.ReadLine();
            if (c != "") filter.PriceUpperThan = Convert.ToDouble(c);

            Console.WriteLine("STATUS: ");
            filter.Status = Console.ReadLine();

            Console.WriteLine("ASSiGNED TO: ");
            filter.AssignedTo = Console.ReadLine();

            return filter;
        }
        public void WriteTable(int n, List<Room> list, List<string> columns)
        {
            Console.Clear();
            Console.WriteLine("Repository: EMPLOYEE\n\n");

            for (int k = 0; k < list.Count(); k++)
            {
                for (int i = 0; i < n; i++)
                {
                    if (columns[i] == "NUMBER")
                    {
                        Console.WriteLine(string.Format("{0}: {1}", columns[i], list[k].number));
                    }
                    else if (columns[i] == "DESCRIPTION")
                    {
                        Console.WriteLine(string.Format("{0}: {1}", columns[i], list[k].description));
                    }
                    else if (columns[i] == "TYPE")
                    {
                        Console.WriteLine(string.Format("{0}: {1}", columns[i], list[k].type));
                    }
                    else if (columns[i] == "PLACES")
                    {
                        Console.WriteLine(string.Format("{0}: {1}", columns[i], list[k].places));
                    }
                    else if (columns[i] == "PRICE")
                    {
                        if (list[k].price == 0)
                        {
                            Console.WriteLine(string.Format("{0}: {1}", columns[i], "Free"));
                        }
                        else
                        {
                            Console.WriteLine(string.Format("{0}: {1} UAH", columns[i], list[k].price));
                        }
                    }
                    else if (columns[i] == "STATUS")
                    {
                        Console.WriteLine(string.Format("{0}: {1}", columns[i], list[k].status));
                    }
                    else if (columns[i] == "ASSIGNEDTO")
                    {
                        Console.WriteLine(string.Format("ASSIGNED TO: {0}", list[k].assignedTo));
                    }
                }
                Console.WriteLine("\n");
            }
            Console.ReadKey();
        }
    }
}
