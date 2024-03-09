using EX2.DAL;

namespace EX2.BL
{
    public class Vacation
    {
        string userEmail;
        string flatId;
        DateTime startDate; //yy-mm-dd
        DateTime endDate; //yy-mm-dd
        static List<Vacation> ordersList = new List<Vacation>();

        public Vacation( string userEmail, string flatId, DateTime startDate, DateTime endDate)
        {
            UserEmail = userEmail;
            FlatId = flatId;
            StartDate = startDate;
            EndDate = endDate;
        }

        public Vacation() { }

        public string UserEmail { get => userEmail; set => userEmail = value; }
        public string FlatId { get => flatId; set => flatId = value; }
        public DateTime StartDate { get => startDate; set => startDate = value; }
        public DateTime EndDate { get => endDate; set => endDate = value; }

        public int InsertVacation()
        {
            DBservices dbs = new DBservices();
            try { 
            if (IsAvalible(this))
            {
                ordersList.Add(this);
                return dbs.InsertVacation(this) ;
            }
            else
            {
                return 0;
                throw new Exception();
            }
            }
            catch (Exception) {
                throw new Exception("Dates are taken. / ID exist.");
            }
        }

        public List<Vacation> ReadVacations()
        {
            DBservices dbs = new DBservices();
            return dbs.ReadVacations();
        }

        //public bool CheckOrderId(Vacation order)
        //{
        //    foreach (Vacation element in ordersList)
        //    { // Check if the flatId matches
        //        if (order.UserEmail == element.UserEmail)
        //        {
        //            return false;
        //        }
        //    }
        //    return true;
        //}

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
