namespace EX2.BL
{
    public class Vacation
    {
        string id;
        string userId;
        string flatId;
        DateTime startDate; //yy-mm-dd
        DateTime endDate; //yy-mm-dd
        static List<Vacation> ordersList = new List<Vacation>();

        public Vacation(string id, string userId, string flatId, DateTime startDate, DateTime endDate)
        {
            Id = id;
            UserId = userId;
            FlatId = flatId;
            StartDate = startDate;
            EndDate = endDate;
        }

        public Vacation() { }

        public string Id { get => id; set => id = value; }
        public string UserId { get => userId; set => userId = value; }
        public string FlatId { get => flatId; set => flatId = value; }
        public DateTime StartDate { get => startDate; set => startDate = value; }
        public DateTime EndDate { get => endDate; set => endDate = value; }

        public int Insert()
        {
            if (CheckOrderId(this) && IsAvalible(this))
            {
                ordersList.Add(this);
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public List<Vacation> Read()
        {
            return ordersList;
        }

        public bool CheckOrderId(Vacation order)
        {
            foreach (Vacation element in ordersList)
            { // Check if the flatId matches
                if (order.Id == element.Id)
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsAvalible(Vacation order)
        {
            foreach (Vacation existingOrder in ordersList)
            {
                // Check if the flatId matches
                if (order.flatId == existingOrder.flatId)
                {
                    // Check for date overlap
                    if (IsDateRangeOverlap(order.startDate, order.endDate, existingOrder.startDate, existingOrder.endDate))
                    {
                        // There is an overlap, so the flat is not available
                        return false;
                    }
                }

            }
            return true;
        }
        static bool IsDateRangeOverlap(DateTime start1, DateTime end1, DateTime start2, DateTime end2)
        {
            return start1 <= end2 && end1 >= start2;
        }


        public static IEnumerable<Vacation> getOrdersByDates(DateTime startDate, DateTime endDate)
        {
            List<Vacation> tempList = new List<Vacation>();
            foreach (Vacation existingOrder in ordersList)
            {
                if (existingOrder.startDate >= startDate && existingOrder.endDate <= endDate)
                {
                    tempList.Add(existingOrder);
                }
            }
            return tempList;
        }



    }
}
