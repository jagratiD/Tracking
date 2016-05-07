using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewTracking.Models
{
    public class Class1
    {
        public string vehicleno { get; set; }
        public string fromplace { get; set; }
        public string toplace { get; set; }
        public string DriverName { get; set; }
        public string DriverNumber { get; set; }
        public string photourl { get; set; }
        public string CRN { get; set; }
       public List<double?> fromlat { get; set; }

       public List<double?> fromlong { get; set; }

       public List<double?> tolat { get; set; }

       public List<double?> tolong { get; set; }

       public int countpick { get; set; }
       public int countdel { get; set; }
       public int counttotal { get; set; }
        
  
        public string currentlocation { get; set; }
        public string driverdetails { get; set; }
        public string Pickdel { get; set; }

        public string PlaceName { get; set; }
        public Nullable<DateTime> EstimatedArrivalTime { get; set; }
        
       public DB_mainOrders mainorder { get; set; }

    }


  
}