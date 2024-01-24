namespace EX2.BL
{
    public class Flat
    {
        string id;
        string city;
        string address;
        double price; // in USD
        double numOfRooms;
        static List<Flat> flatsList = new List<Flat>();


        // standart constractor
        public Flat(string id, string city, string address, double price, int numOfRooms)
        {
            Id = id;
            City = city;
            Address = address;
            NumOfRooms = numOfRooms;
            Price = price;
        }

        // empty constractor
        public Flat()
        {
        }

        public string Id { get => id; set => id = value; }
        public string City { get => city; set => city = value; }
        public string Address { get => address; set => address = value; }
        public double NumOfRooms { get => numOfRooms; set => numOfRooms = value; }
        public double Price { get => price; set => price = Discount(value, numOfRooms); }

        public int Insert()
        {
            if (CheckFlatId(this))
            {
                flatsList.Add(this);
                return 1;
            }
            else
            {
                return 0;
            }
        }

        // checking flat parmameters
        public bool CheckFlatId(Flat flat)
        {
            foreach (Flat exFlat in flatsList)
            {
                if (exFlat.Id == flat.Id)
                {
                    return false;
                }
            }
            return true;
        }

        public List<Flat> Read()
        {
            return flatsList;
        }

        public double Discount(double price, double rooms)
        {
            if (rooms > 1 && price > 100)
            {
                return price * 0.9;
            }
            else
            {
                return price;
            }
        }

        static public IEnumerable<Flat> GetFlatMaxPriceByCity(double price, string city)
        {// checks what flats have an equal or lower price than a given price
            List<Flat> tempList = new List<Flat>();
            foreach(Flat flat in flatsList)
            {
                if ((flat.price <= price)&&(flat.city == city))
                {
                    tempList.Add(flat);
                }
            }
            return tempList;
        }
    }
}
