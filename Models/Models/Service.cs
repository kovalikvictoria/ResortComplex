namespace Models.Models
{
    public class Service
    {
    //  create table Service
    //  (
    //       service_id bigserial PRIMARY KEY,
    //       name varchar(50),
    //	     description text,
    //       duration decimal,
    //	     price money
    //  );

        public long service_id;
        public string name;
        public string description;
        public double price;

        public Service(long service_id = 0, string name = "", string description = "",
                       double price = 0.0)
        {
            this.service_id = service_id;
            this.name = name;
            this.description = description;
            this.price = price;
        }
    }
}
