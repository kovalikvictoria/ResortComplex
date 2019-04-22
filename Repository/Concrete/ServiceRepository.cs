using Models.Filters;
using Models.Models;
using Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace Repository.Concrete
{
    public class ServiceRepository : ConnectionManager, IServiceRepository
    {
        public void Add(Service service)
        {
            ExecuteNonQuery(string.Format(
                "INSERT INTO Service (service_id, name, description, duration, price)" +
                "VALUES ({0}, '{1}', '{2}', {3}, {4})",
                service.service_id, service.name, service.description, service.duration, service.price));
        }

        public void Delete(ServiceFilter filter)
        {
            string cmd = "Delete from Service ";
            List<string> wcmd = new List<string>();

            if (!String.IsNullOrEmpty(filter.Name))
            {
                wcmd.Add("name = " + filter.Name);
            }

            if (!String.IsNullOrEmpty(filter.NameStartWith))
            {
                wcmd.Add("name LIKE %" + filter.NameStartWith + "%");
            }

            if (!String.IsNullOrEmpty(filter.Description))
            {
                wcmd.Add("description LIKE %" + filter.Description + "%");
            }

            if (filter.Duration.HasValue)
            {
                wcmd.Add("duration = " + filter.Duration);
            }

            if (filter.DurationLowerThan.HasValue)
            {
                wcmd.Add("duration < " + filter.DurationLowerThan);
            }

            if (filter.DurationUpperThan.HasValue)
            {
                wcmd.Add("duration > " + filter.DurationUpperThan);
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

            if (wcmd.Count() > 0)
            {
                cmd += "where " + string.Join(" and ", wcmd.ToArray());
            }
            Console.WriteLine(cmd);

            ExecuteNonQuery(cmd);
        }

        public void Update(Service service, ServiceFilter filter)
        {
            string cmd = string.Format("Update Service set " +
                "service_id = {0}, name = '{1}', description = '{2}', duration = {3}, price = {4} ",
                 service.service_id, service.name, service.description, service.duration, service.price);
            List<string> wcmd = new List<string>();

            if (!String.IsNullOrEmpty(filter.Name))
            {
                wcmd.Add("name = " + filter.Name);
            }

            if (!String.IsNullOrEmpty(filter.NameStartWith))
            {
                wcmd.Add("name LIKE %" + filter.NameStartWith + "%");
            }

            if (!String.IsNullOrEmpty(filter.Description))
            {
                wcmd.Add("description LIKE %" + filter.Description + "%");
            }

            if (filter.Duration.HasValue)
            {
                wcmd.Add("duration = " + filter.Duration);
            }

            if (filter.DurationLowerThan.HasValue)
            {
                wcmd.Add("duration < " + filter.DurationLowerThan);
            }

            if (filter.DurationUpperThan.HasValue)
            {
                wcmd.Add("duration > " + filter.DurationUpperThan);
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

            if (wcmd.Count() > 0)
            {
                cmd += "where " + string.Join(" AND ", wcmd.ToArray());
            }

            ExecuteNonQuery(cmd);
        }

        public void ShowAll()
        {
            string cmd = "select * from Service";
            
            DbDataReader reader = ExecuteReader(cmd);

            Console.WriteLine("Table: Service");
            while (reader.Read())
            {
                Console.WriteLine(string.Format("Id: {0}\tName: {1}\tDescription: {2}\tDuration: {3} min\tPrice: {4} uah",
                   Convert.ToInt64(reader["service_id"].ToString()), reader["name"].ToString(), reader["description"].ToString(), 
                   Convert.ToDouble(reader["duration"].ToString()), Convert.ToDouble(reader["price"].ToString())));
            }
        }

        public List<Service> Get(ServiceFilter filter)
        {
            string cmd = "Select * from Service ";
            List<string> wcmd = new List<string>();

            if (!String.IsNullOrEmpty(filter.Name))
            {
                wcmd.Add("name = " + filter.Name);
            }

            if (!String.IsNullOrEmpty(filter.NameStartWith))
            {
                wcmd.Add("name LIKE %" + filter.NameStartWith + "%");
            }

            if (!String.IsNullOrEmpty(filter.Description))
            {
                wcmd.Add("description LIKE %" + filter.Description + "%");
            }

            if (filter.Duration.HasValue)
            {
                wcmd.Add("duration = " + filter.Duration);
            }

            if (filter.DurationLowerThan.HasValue)
            {
                wcmd.Add("duration < " + filter.DurationLowerThan);
            }

            if (filter.DurationUpperThan.HasValue)
            {
                wcmd.Add("duration > " + filter.DurationUpperThan);
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
                service.duration = (double)reader["duration"];
                service.price = (double)reader["price"];

                serviceList.Add(service);
            }

            return serviceList;
        }
    }
}
