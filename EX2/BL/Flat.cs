using EX2.DAL;

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
        public Flat(string id, string city, string address, double numOfRooms, double price)
        {
            Id = id;
            City = city;
            Address = address;
            NumOfRooms = numOfRooms;
            Price = Discount(price, numOfRooms);
        }

        // empty constractor
        public Flat()
        {
        }

        public string Id { get => id; set => id = value; }
        public string City { get => city; set => city = value; }
        public string Address { get => address; set => address = value; }
        public double NumOfRooms { get => numOfRooms; set => numOfRooms = value; }
        public double Price { get => price; set => price = Discount(value, NumOfRooms); }

        public int InsertFlat()
        {
            DBservices dbs = new DBservices();
            try {
            if (CheckFlatId(this))
            {
                flatsList.Add(this);
                return dbs.InsertFlat(this);
            }
            else
            {
                    return 0;
                    throw new Exception(); 
            }
            }
            catch (Exception) {
                throw new Exception("Flat ID already exist.");
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

        public List<Flat> ReadFlats()
        {
            DBservices dbs = new DBservices();
            return dbs.ReadFlats();
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
