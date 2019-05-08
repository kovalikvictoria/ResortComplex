using Models.Filters;
using Models.Models;
using Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Concrete
{
    public class ServiceRepository : ConnectionManager, IServiceRepository
    {
        public void Add(Service service)
        {
            try
            {
                ExecuteNonQuery(string.Format(
                "INSERT INTO Service (service_id, name, description, price) " +
                "VALUES ({0}, '{1}', '{2}', {3})",
                service.service_id, service.name, service.description,
                Helper.ToMyString(service.price.ToString())));
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e.ToString());
                Console.ReadKey();
            }
        }
        public void Delete(ServiceFilter filter)
        {
            try
            {
                string cmd = "Delete from Service ";

                List<string> wcmd = new List<string>();
                if (!String.IsNullOrEmpty(filter.name))
                {
                    wcmd.Add("name LIKE '" + filter.name + "%'");
                }
                if (!String.IsNullOrEmpty(filter.description))
                {
                    wcmd.Add("description LIKE '" + filter.description + "%'");
                }
                if (filter.price.HasValue)
                {
                    wcmd.Add("price = " + Helper.ToMyString(filter.price.ToString()));
                }
                if (filter.priceLowerThan.HasValue)
                {
                    wcmd.Add("price < " + Helper.ToMyString(filter.priceLowerThan.ToString()));
                }
                if (filter.priceUpperThan.HasValue)
                {
                    wcmd.Add("price > " + Helper.ToMyString(filter.priceUpperThan.ToString()));
                }
                if (wcmd.Count() > 0)
                {
                    cmd += "where " + string.Join(" and ", wcmd.ToArray());
                }

                ExecuteNonQuery(cmd);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e.ToString());
                Console.ReadKey();
            }
        }
        public void Update(Service service, ServiceFilter filter)
        {
            try
            {
                string cmd = string.Format("Update Service set " +
                "service_id = {0}, name = '{1}', description = '{2}', price = {3} ",
                 service.service_id, service.name, service.description, service.price);

                List<string> wcmd = new List<string>();
                if (!String.IsNullOrEmpty(filter.name))
                {
                    wcmd.Add("name LIKE '" + filter.name + "%'");
                }
                if (!String.IsNullOrEmpty(filter.description))
                {
                    wcmd.Add("description LIKE '" + filter.description + "%'");
                }
                if (filter.price.HasValue)
                {
                    wcmd.Add("price = " + Helper.ToMyString(filter.price.ToString()));
                }
                if (filter.priceLowerThan.HasValue)
                {
                    wcmd.Add("price < " + Helper.ToMyString(filter.priceLowerThan.ToString()));
                }
                if (filter.priceUpperThan.HasValue)
                {
                    wcmd.Add("price > " + Helper.ToMyString(filter.priceUpperThan.ToString()));
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
        public void Select(ServiceFilter filter) 
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Repository: SERVICE\n\n");

                string cmd = "Select * from Service ";

                List<string> wcmd = new List<string>();
                if (!String.IsNullOrEmpty(filter.name))
                {
                    wcmd.Add("name LIKE '" + filter.name + "%'");
                }
                if (!String.IsNullOrEmpty(filter.description))
                {
                    wcmd.Add("description LIKE '" + filter.description + "%'");
                }
                if (filter.price.HasValue)
                {
                    wcmd.Add("price = " + Helper.ToMyString(filter.price.ToString()));
                }
                if (filter.priceLowerThan.HasValue)
                {
                    wcmd.Add("price < " + Helper.ToMyString(filter.priceLowerThan.ToString()));
                }
                if (filter.priceUpperThan.HasValue)
                {
                    wcmd.Add("price > " + Helper.ToMyString(filter.priceUpperThan.ToString()));
                }
                if (wcmd.Count() > 0)
                {
                    cmd += "where " + string.Join(" AND ", wcmd.ToArray());
                }

                List<Service> serviceList = new List<Service>();
                DbDataReader reader = ExecuteReader(cmd);
                while (reader.Read())
                {
                    Service service = new Service();
                    service.service_id = (long)reader["service_id"];
                    service.name = (string)reader["name"];
                    service.description = (string)reader["description"];
                    var p = reader["price"];
                    if (p != null) service.price = Convert.ToDouble(p);

                    serviceList.Add(service);
                }

                Console.WriteLine("You can choose columns: service_id, name, " +
                    "description, price");
                Helper h = new Helper();
                int n = h.AmountOfColumns();
                List<string> columns = h.NamesOfColumns(n);

                WriteTable(n, serviceList, columns);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e.ToString());
                Console.ReadKey();
            }
        }

        public List<Service> Get(ServiceFilter filter)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Repository: SERVICE\n\n");

                string cmd = "Select * from Service ";

                List<string> wcmd = new List<string>();
                if (!String.IsNullOrEmpty(filter.name))
                {
                    wcmd.Add("name LIKE '" + filter.name + "%'");
                }
                if (!String.IsNullOrEmpty(filter.description))
                {
                    wcmd.Add("description LIKE '" + filter.description + "%'");
                }
                if (filter.price.HasValue)
                {
                    wcmd.Add("price = " + Helper.ToMyString(filter.price.ToString()));
                }
                if (filter.priceLowerThan.HasValue)
                {
                    wcmd.Add("price < " + Helper.ToMyString(filter.priceLowerThan.ToString()));
                }
                if (filter.priceUpperThan.HasValue)
                {
                    wcmd.Add("price > " + Helper.ToMyString(filter.priceUpperThan.ToString()));
                }
                if (wcmd.Count() > 0)
                {
                    cmd += "where " + string.Join(" AND ", wcmd.ToArray());
                }

                List<Service> serviceList = new List<Service>();
                DbDataReader reader = ExecuteReader(cmd);
                while (reader.Read())
                {
                    Service service = new Service();
                    service.service_id = (long)reader["service_id"];
                    service.name = (string)reader["name"];
                    service.description = (string)reader["description"];
                    var p = reader["price"];
                    if (p != null) service.price = Convert.ToDouble(p);

                    serviceList.Add(service);
                }
                return serviceList;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e.ToString());
                Console.ReadKey();
                return new List<Service>();
            }
        }
        public Service CreateModel()
        {
            Console.Clear();
            Console.WriteLine("Repository: SERVICE\n\n");
            Console.WriteLine("SET\n");

            Service service = new Service();

            Console.WriteLine("ID: ");
            service.service_id = Convert.ToInt64(Console.ReadLine());

            Console.WriteLine("NAME: ");
            service.name = Console.ReadLine();

            Console.WriteLine("DESCRIPTION: ");
            service.description = Console.ReadLine();

            Console.WriteLine("PRICE: ");
            service.price = Convert.ToDouble(Console.ReadLine());

            return service;
        }
        public ServiceFilter CreateFilter()
        {
            Console.Clear();
            Console.WriteLine("Repository: SERVICE\n\n");
            Console.WriteLine("Creating conditions for rows\n" +
                "You can skip some conditions\n" +
                "(select ... , where): ");

            ServiceFilter filter = new ServiceFilter();

            Console.WriteLine("NAME: ");
            filter.name = Console.ReadLine();

            Console.WriteLine("DESCRIPTION: ");
            filter.description = Console.ReadLine();
            
            Console.WriteLine("PRICE: ");
            string a = Console.ReadLine();
            if (a != "") filter.price = Convert.ToDouble(a);

            Console.WriteLine("PRICE lower than: ");
            string b = Console.ReadLine();
            if (b != "") filter.priceLowerThan = Convert.ToDouble(b);

            Console.WriteLine("PRICE upper than: ");
            string c = Console.ReadLine();
            if (c != "") filter.priceUpperThan = Convert.ToDouble(c);

            return filter;
        }
        public void WriteTable(int n, List<Service> list, List<string> columns)
        {
            Console.Clear();
            Console.WriteLine("Repository: SERVICE\n\n");

            for (int k = 0; k < list.Count(); k++)
            {
                for (int i = 0; i < n; i++)
                {
                    if (columns[i] == "SERVICE_ID")
                    {
                        Console.WriteLine(string.Format("ID: {0}", list[k].service_id));
                    }
                    else if (columns[i] == "NAME")
                    {
                        Console.WriteLine(string.Format("{0}: {1}", columns[i], list[k].name));
                    }
                    else if (columns[i] == "DESCRIPTION")
                    {
                        Console.WriteLine(string.Format("{0}: {1}", columns[i], list[k].description));
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
                }
                Console.WriteLine("\n");
            }
            Console.ReadKey();
        }
    }
}
