namespace Models.Models
{
    public class Room
    {
    //    Create table Room
    //    (
    //        number integer PRIMARY KEY,
    //        description text,
    //        type varchar(20),
	//        places integer,
    //        price money,
	//        status varchar(10),
	//        assignedTo varchar(50)
    //    );

        public int number;
        public string description;
        public string type;
        public int places;
        public double price;
        public string status;
        public string assignedTo;

        public Room(int number = 0, string description = "", string type = "",
                    int places = 0, double price = 0.0, string status = "",
                    string assignedTo = "")
        {
            this.number = number;
            this.description = description;
            this.type = type;
            this.places = places;
            this.price = price;
            this.status = status;
            this.assignedTo = assignedTo;
        }
    }
}
