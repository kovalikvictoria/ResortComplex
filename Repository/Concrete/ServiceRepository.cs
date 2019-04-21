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
            ExecuteNonQuery(string.Format(
                "INSERT INTO Service (Name, Description, Duration, Price)" +
                "VALUES ('{0}', '{1}', {2}, {3})",
                service.name, service.description, service.duration, service.price));
        }
        public void Delete(ServiceFilter filter)
        {
            string cmd = "Delete from Service ";
            List<string> wcmd = new List<string>();

            if (!String.IsNullOrEmpty(filter.Name))
            {
                wcmd.Add("Name = " + filter.Name);
            }

            if (!String.IsNullOrEmpty(filter.NameStartWith))
            {
                wcmd.Add("Name LIKE %" + filter.NameStartWith + "%");
            }

            if (!String.IsNullOrEmpty(filter.Description))
            {
                wcmd.Add("Description LIKE %" + filter.Description + "%");
            }

            if (filter.Duration.HasValue)
            {
                wcmd.Add("Duration = " + filter.Duration);
            }

            if (filter.DurationLowerThan.HasValue)
            {
                wcmd.Add("Duration < " + filter.DurationLowerThan);
            }

            if (filter.DurationUpperThan.HasValue)
            {
                wcmd.Add("Duration > " + filter.DurationUpperThan);
            }

            if (filter.Price.HasValue)
            {
                wcmd.Add("Price = " + filter.Price);
            }

            if (filter.PriceLowerThan.HasValue)
            {
                wcmd.Add("Price < " + filter.PriceLowerThan);
            }

            if (filter.PriceUpperThan.HasValue)
            {
                wcmd.Add("Price > " + filter.PriceUpperThan);
            }

            if (wcmd.Count() > 0)
            {
                cmd += "where " + string.Join(" AND ", wcmd.ToArray());
            }

            ExecuteNonQuery(cmd);
        }
        public void Update(Service service, ServiceFilter filter)
        {
            string cmd = string.Format("Update Service set " +
                "Name = '{0}', Description = '{1}', Duration = {2}, Price = {3} ",
                service.name, service.description, service.duration, service.price);
            List<string> wcmd = new List<string>();

            if (!String.IsNullOrEmpty(filter.Name))
            {
                wcmd.Add("Name = " + filter.Name);
            }

            if (!String.IsNullOrEmpty(filter.NameStartWith))
            {
                wcmd.Add("Name LIKE %" + filter.NameStartWith + "%");
            }

            if (!String.IsNullOrEmpty(filter.Description))
            {
                wcmd.Add("Description LIKE %" + filter.Description + "%");
            }

            if (filter.Duration.HasValue)
            {
                wcmd.Add("Duration = " + filter.Duration);
            }

            if (filter.DurationLowerThan.HasValue)
            {
                wcmd.Add("Duration < " + filter.DurationLowerThan);
            }

            if (filter.DurationUpperThan.HasValue)
            {
                wcmd.Add("Duration > " + filter.DurationUpperThan);
            }

            if (filter.Price.HasValue)
            {
                wcmd.Add("Price = " + filter.Price);
            }

            if (filter.PriceLowerThan.HasValue)
            {
                wcmd.Add("Price < " + filter.PriceLowerThan);
            }

            if (filter.PriceUpperThan.HasValue)
            {
                wcmd.Add("Price > " + filter.PriceUpperThan);
            }

            if (wcmd.Count() > 0)
            {
                cmd += "where " + string.Join(" AND ", wcmd.ToArray());
            }

            ExecuteNonQuery(cmd);
        }

        public List<Service> Get(ServiceFilter filter)
        {
            string cmd = "Select * from Service ";
            List<string> wcmd = new List<string>();

            if (!String.IsNullOrEmpty(filter.Name))
            {
                wcmd.Add("Name = " + filter.Name);
            }

            if (!String.IsNullOrEmpty(filter.NameStartWith))
            {
                wcmd.Add("Name LIKE %" + filter.NameStartWith + "%");
            }

            if (!String.IsNullOrEmpty(filter.Description))
            {
                wcmd.Add("Description LIKE %" + filter.Description + "%");
            }

            if (filter.Duration.HasValue)
            {
                wcmd.Add("Duration = " + filter.Duration);
            }

            if (filter.DurationLowerThan.HasValue)
            {
                wcmd.Add("Duration < " + filter.DurationLowerThan);
            }

            if (filter.DurationUpperThan.HasValue)
            {
                wcmd.Add("Duration > " + filter.DurationUpperThan);
            }

            if (filter.Price.HasValue)
            {
                wcmd.Add("Price = " + filter.Price);
            }

            if (filter.PriceLowerThan.HasValue)
            {
                wcmd.Add("Price < " + filter.PriceLowerThan);
            }

            if (filter.PriceUpperThan.HasValue)
            {
                wcmd.Add("Price > " + filter.PriceUpperThan);
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
                service.name = (string)reader["Name"];
                service.description = (string)reader["Description"];
                service.duration = (double)reader["Duration"];
                service.price = (double)reader["Price"];
                
                serviceList.Add(service);
            }
            RefreshDataReader();

            return serviceList;
        }
    }
}
