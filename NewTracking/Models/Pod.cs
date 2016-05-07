using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewTracking.Models
{
    public class PodSingledata
    {
        public string NameOfConsignornee { get; set; }
        public string Time { get; set; }
        public string Address { get; set; }
        public double? Quantity { get; set; }
        public string BiltyNumber { get; set; }
        public string Signature { get; set; }
        public string PhotoGoods { get; set; }
        public string PhotoGR { get; set; }
        public string Status { get; set; }
        public string OrderId { get; set; }

        public string OId { get; set; }
        public string ClientName { get; set; }
        public int NoOfPickupPoints { get; set; }
        public int NoOfReturnPoints { get; set; }
        public int NoOfDropPoints { get; set; }

        public int PICKUPcount { get; set; }
        public int DELIVERYcount { get; set; }

        public int RDDCcount { get; set; }
        public Nullable<int> PICKUPquancount { get; set; }
        public Nullable<int> DELIVERYquancount { get; set; }

        public Nullable<int> RDDCquancount { get; set; }

        public string VehicleNo { get; set; }

        public string AssignedAt { get; set; }
        public string route { get; set; }

        public double distanceAP { get; set; }

        public double distancePD { get; set; }

        public double TripTime { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public string HAWBNo { get; set; }

        public string CancelORemark { get; set; }
        public string CancelBy { get; set; }
        public string isCancel { get; set; }

        public string RDDCRemark {get;set;}
        public string CDNNO { get; set; }

    }

}