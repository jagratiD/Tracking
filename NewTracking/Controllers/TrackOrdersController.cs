using NewTracking.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Globalization;

namespace NewTracking.Controllers
{
    [CustomAction]

    public class TrackOrdersController : Controller
    {
        LogisureEntities1 context = new LogisureEntities1();
        public DateTime indianStd = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, "India Standard Time");
        // GET: TrackOrders

        [PermissionFilter(Permission = "TrackOrders GRID")]
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, string OrderStatus, string OrderDate, string OrderEDate, int? page, int PageSize = 5)
        {
            string str = string.Empty;
            string Status = string.Empty;
            string oDate = string.Empty;
            string oEDate = string.Empty;
            ActionResult action;
            if (!string.IsNullOrEmpty(searchString))
                Session["search"] = searchString;
            if (searchString == "")
                Session["search"] = null;
            str = searchString;
            if (Session["search"] != null)
                str = Session["search"].ToString();


            if (!string.IsNullOrEmpty(OrderStatus))
                Session["OrderStatus"] = OrderStatus;
            if (OrderStatus == "")
                Session["OrderStatus"] = null;
            Status = OrderStatus;
            if (Session["OrderStatus"] != null)
                Status = Session["OrderStatus"].ToString();

            if (!string.IsNullOrEmpty(OrderDate))
                Session["OrderDate"] = OrderDate;
            if (OrderDate == "")
                Session["OrderDate"] = null;
            oDate = OrderDate;
            if (Session["OrderDate"] != null)
                oDate = Session["OrderDate"].ToString();

            if (!string.IsNullOrEmpty(OrderEDate))
                Session["OrderEDate"] = OrderEDate;
            if (OrderEDate == "")
                Session["OrderEDate"] = null;
            oEDate = OrderEDate;
            if (Session["OrderEDate"] != null)
                oEDate = Session["OrderEDate"].ToString();


            var pagesizea = HttpContext.Request.Cookies["PageSize"];
            Int16 Paga = 10;
            if (pagesizea != null)
            {
                Paga = Convert.ToInt16(HttpContext.Request.Cookies["PageSize"].Value);
            }

            ViewBag.Psize = Paga;

            var City = HttpContext.Request.Cookies["City"].Value;
            int userid= Convert.ToInt32( HttpContext.Request.Cookies["UserId"].Value);

            var cityies= CommonFunction.GetUserCity(userid);

            var allowedcity = cityies.TrimEnd(',').Split(',').Select(x => int.Parse(x)).ToList(); 

            Int32 CityIda = 368;
           if (City != null && City!="")
            {
                CityIda = Convert.ToInt16(HttpContext.Request.Cookies["City"].Value);
                if(allowedcity.Contains(CityIda))
                {
                    CityIda = Convert.ToInt16(HttpContext.Request.Cookies["City"].Value);

                }
                else
                {
                    CityIda = allowedcity[0];

                }
            }

            ViewBag.CityList = new SelectList(context.DB_City.Where(x => x.IsActive == true && allowedcity.Contains(x.CityId)).ToList(), "CityId", "Name", CityIda);

            try
            {

                DateTime beforetwodays = indianStd.AddDays(-2);
                List<DB_mainOrders> mainorders = new List<DB_mainOrders>();

                var clientid = HttpContext.Request.Cookies["ClientId"];
                Int16 clientida = 0;
                if (clientid.Value != "")
                {
                    clientida = Convert.ToInt16(HttpContext.Request.Cookies["ClientId"].Value);
                    mainorders = context.DB_mainOrders.Where(x => x.DB_Client.DB_Address.CityId == CityIda && x.EstimatedPickupTime > beforetwodays && x.ClientId == clientida).ToList();

                }
                else
                {
                    mainorders = context.DB_mainOrders.Where(x => x.DB_Client.DB_Address.CityId == CityIda && x.EstimatedPickupTime > beforetwodays).Take(10).ToList();
                }







                ViewBag.OrderDetails = mainorders;


                List<OrderDetailModel> modellist = new List<OrderDetailModel>();
                List<string> oidserr = new List<string>();
                foreach (var od in mainorders)
                {
                    try
                    {
                        OrderDetailModel odd = new OrderDetailModel();
                        odd.ClientName = od.DB_Client.ClientName;
                        odd.CRNNo = od.CRNNumber;
                        odd.Consignor = od.DB_DepotStation.Name;
                        odd.Waypoints = context.DB_OrderDetails.Where(x => x.OrderId == od.OrderId).Select(x => x.DB_DepotStation.Name).ToList();
                        odd.EstimatedPickupTime = od.EstimatedPickupTime;
                  //      odd.PickUpTime = context.DB_OrderDetails.Where(x => x.OrderId == od.OrderId).FirstOrDefault();
                        odd.VehicleAssignTime = od.AssignedAt;
                        odd.CreatedOn = od.CreatedAt;
                        odd.Status = GetStatusmeaning(od.Status);
                        odd.Vehicle = od.Vehicle;
                        odd.OrderId = od.OrderId;
                        odd.Route = od.Route;
                        odd.oddetails = context.DB_OrderDetails.Where(x => x.OrderId == od.OrderId).ToList();
                        modellist.Add(odd);

                    }
                    catch (Exception ex)
                    {
                        oidserr.Add(od.CRNNumber);
                        string crnlist = string.Join(",", oidserr);

                        return Json(new { data = crnlist }, JsonRequestBehavior.AllowGet);
                    }
                }


                //var modellist = (from a in context.DB_mainOrders
                //                 where
                //                 a.DB_Client.DB_Address.CityId == CityIda 
                //                 //context.DB_OrderDetails.Where(b => b.OrderId == a.OrderId).FirstOrDefault() != null
                //                 select new OrderDetailModel
                //                 {
                //                     OrderId = a.OrderId,
                //                     CRNNo = a.CRNNumber,
                //                     ClientName = a.DB_Client.ClientName,
                //                     CreatedOn = context.DB_mainOrders.Where(x => x.OrderId == a.OrderId).Select(x => x.CreatedAt).FirstOrDefault(),
                //                     Consignor = a.DB_DepotStation.Name,
                //                     Waypoints = context.DB_OrderDetails.Where(x => x.OrderId == a.OrderId).Select(x => x.DB_DepotStation.Name).ToList(),
                //                     EstimatedPickupTime = a.EstimatedPickupTime,
                //                     VehicleAssignTime = a.AssignedAt,
                //                     //PickUpTime = context.DB_OrderDetails.Where(x => x.OrderId == a.OrderId).FirstOrDefault(),
                //                     Status = a.Status,
                //                     Vehicle = a.Vehicle,

                //                 }).ToList().OrderByDescending(x => x.OrderId).Take(6000);




                if (Status != "All" && Status != null)
                {
                    modellist = (from a in modellist where a.Status == Status select a).ToList();
                }

                if (!string.IsNullOrEmpty(oDate) && !string.IsNullOrEmpty(oEDate))
                {
                    DateTime dt = DateTime.ParseExact(oDate, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    DateTime dt1 = DateTime.ParseExact(oEDate, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture).AddDays(1);

                    modellist = (from a in modellist
                                 where a.CreatedOn >= dt && a.CreatedOn <= dt1
                                 select a).ToList();
                }

                ViewBag.CurrentSort = sortOrder;
                ViewBag.OrderIdsort = (string.IsNullOrEmpty(sortOrder) ? "" : "OrderIdSort");
                string name = HttpContext.User.Identity.Name;
                //string[] rolesForUser = Roles.GetRolesForUser(name);
                //ViewBag.Role = rolesForUser[0];




                if (!string.IsNullOrEmpty(str))
                {
                    modellist =
                       (from s in modellist

                        where (s.CRNNo.ToUpper().Contains(str.ToUpper())) || (s.Consignor.ToUpper().Contains(str.ToUpper())) || ((s.Consignee != null) && (s.Consignee.ToUpper().Contains(str.ToLower())))
 || ((s.Vehicle != null) && (s.Vehicle.ToLower().Contains(str.ToLower()))) || (s.CDN != null && s.CDN.Contains(str))
                        select s).ToList();
                }
                if (str == null || str == "")
                {
                    str = currentFilter;
                    if (page == 0)
                        page = new int?(10);
                }
                else
                {
                    //page = new int?(1);
                }

                ViewBag.CurrentFilter = str;
                //modellist = (sortOrder != "OrderIdSort" ?
                //    from x in modellist
                //    orderby x.OrderId descending
                //    select x :
                //    from x in modellist
                //    orderby x.OrderId
                //    select x).ToList();

                modellist = modellist.OrderByDescending(x => x.OrderId).ToList();


                int num1 = Paga;
                int? nullable = page;
                int num2 = (nullable.HasValue ? nullable.GetValueOrDefault() : 1);


                OrderPage model = new OrderPage();


                if (string.IsNullOrEmpty(Status))
                    model.OrderStatus = "All";
                else
                    model.OrderStatus = Status;
                if (!string.IsNullOrEmpty(oDate))
                {
                    
                    model.OrderDate = DateTime.ParseExact(oDate, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                }
                if (!string.IsNullOrEmpty(oEDate))
                {
                    model.OrderEDate = DateTime.ParseExact(oEDate, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                }

                model.list = modellist.ToPagedList(num2, num1);
                var user = HttpContext.Request.Cookies["UserName"].Value;
                var permissionlist = context.DB_CustomUserProfile.Where(x => x.UserName == user).Select(x => x.Permissions).FirstOrDefault();
                ViewBag.Permlist = permissionlist;

                return View(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public JsonResult Encrypt(string OrderId)
        {
            byte[] bytes = new byte[OrderId.Length];
            bytes = Encoding.UTF8.GetBytes(OrderId);
            string base64String = Convert.ToBase64String(bytes);
            int oid = int.Parse(OrderId);
            var Orderdetails = context.DB_mainOrders.Where(x => x.OrderId == oid).FirstOrDefault();
            DateTime dt = new DateTime();
            dt = Convert.ToDateTime("2014-11-24");
            if (Orderdetails.EstimatedPickupTime > dt)
            {
                return base.Json(new { Oid = base64String, Status = "New" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return base.Json(new { Oid = base64String, Status = "Old" }, JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult GetOrderInfo(int id)
        {
            JsonResult jsonResult;
            context.Configuration.ProxyCreationEnabled = false;


            var order = from a in context.DB_mainOrders

                        where a.OrderId == id
                        select new
                        {
                            a.DB_Client.ClientName,
                            a.DB_DepotStation.Name,
                            a.OrderType,
                            a.CRNNumber,
                            a.OrderKm,
                            a.Vehicle,
                            a.DB_Client.Email_Id,
                            a.DB_Client.DB_Address.FullAddress,
                            vehicletype = a.DB_VehicleType.Name,


                        };

            var orderList = order.ToList();


            var order1 = (from a in context.DB_OrderDetails
                          where a.OrderId == id
                          select new
                         {
                             a.CDNnumber,
                             a.PickOrDelivery,
                             a.DB_DepotStation.Name,


                             ActualCompletedAt = a.ActualCompletedAt.ToString(),
                             a.EnteredQty,
                             a.PickDelStatus,
                             a.Quantity,
                             a.ContactNumber,
                             a.FloorNumber

                         }).ToList();


        

            jsonResult = base.Json(new { order = orderList, order1 = order1 }, JsonRequestBehavior.AllowGet);


            return jsonResult;


            //return Json(order, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetVehicleInfo(string id)
        {
            JsonResult jsonResult;
            context.Configuration.ProxyCreationEnabled = false;



            var order1 = (from a in context.DB_Vehicle_Tracking
                          where a.DB_LSVehicle.VehicleNo == id
                          select new
                          {
                              a.DB_Driver.DriverName,
                              a.DB_Driver.PhoneNumber,
                              a.CurrentLatitude,
                              a.CurrentLongitude,
                              DateTime = a.Datetime.ToString(),

                          }).FirstOrDefault();




            jsonResult = base.Json(new { order1 = order1 }, JsonRequestBehavior.AllowGet);


            return jsonResult;


            //return Json(order, JsonRequestBehavior.AllowGet);

        }

        public ActionResult DownloadFeed()
        {
            var list = (from a in context.DB_mainOrders where a.Status == "A" || a.Status == "P" || a.Status == "NA" select a).ToList();

            StringBuilder sb = new StringBuilder();
            sb.Append("<table border=`" + "1px" + "`b>");
            //code section for creating header column
            sb.Append("<tr>");
            sb.Append("<td><b><font face=Arial size=2>Order Id</font></b></td>");
            sb.Append("<td><b><font face=Arial size=2>Punit Name</font></b></td>");
            sb.Append("<td><b><font face=Arial size=2>Dunit Name</font></b></td>");
            sb.Append("<td><b><font face=Arial size=2>Order Date</font></b></td>");
            sb.Append("<td><b><font face=Arial size=2>Status</font></b></td>");
            sb.Append("<td><b><font face=Arial size=2>Vehicle</font></b></td>");

            sb.Append("</tr>");

            //code for creating excel data
            if (list.Count > 0)
            {
                foreach (var item in list)
                {
                    sb.Append("<tr>");
                    sb.Append("<td><font face=Arial size=" + "14px" + ">" + item.OrderId + "</font></td>");
                    sb.Append("<td><font face=Arial size=" + "14px" + ">" + item.DB_DepotStation.Name + "</font></td>");
                    sb.Append("<td><font face=Arial size=" + "14px" + ">" + item.DB_DepotStation.Name + "</font></td>");
                    sb.Append("<td><font face=Arial size=" + "14px" + ">" + item.EstimatedPickupTime + "</font></td>");
                    if (item.Status == "A")
                        sb.Append("<td><font face=Arial size=" + "14px" + ">Assigned</font></td>");
                    else if (item.Status == "P")
                        sb.Append("<td><font face=Arial size=" + "14px" + ">Picked-up</font></td>");
                    else
                        sb.Append("<td><font face=Arial size=" + "14px" + ">Not Assigned</font></td>");
                    sb.Append("<td><font face=Arial size=" + "14px" + ">" + item.Vehicle + "</font></td>");
                    sb.Append("</tr>");
                }
            }
            sb.Append("</table>");
            HttpContext.Response.AddHeader("content-disposition", "attachment; filename=PendingOrder.xls");
            this.Response.ContentType = "application/vnd.ms-excel";
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(sb.ToString());
            return File(buffer, "application/vnd.ms-excel");
        }



        public ActionResult tracker(string Vehicle = null, string CRNNo = null)
        {

            var order = context.DB_mainOrders.Where(x => x.CRNNumber == CRNNo).Select(x => x.OrderId).FirstOrDefault();
            var vehicle = context.DB_mainOrderLog.Where(x => x.OrderId == order).Select(x => x.Vehicle).FirstOrDefault();


            var driver = context.DB_Vehicle_Tracking.Where(x => x.DB_LSVehicle.VehicleNo == vehicle).Select(x => x.DB_Driver.DriverName).FirstOrDefault();
            var driverpic = context.DB_Vehicle_Tracking.Where(x => x.DB_LSVehicle.VehicleNo == vehicle).Select(x => x.DB_Driver.PhotoUrl).FirstOrDefault();

            var orderdetails = (from a in context.DB_OrderDetails
                                 where a.DB_mainOrders.CRNNumber==CRNNo
                                 select new Class1
                                 {
                                     CRN = a.DB_mainOrders.CRNNumber,
                                     PlaceName=a.DB_DepotStation.DB_Address.FullAddress,
                                  EstimatedArrivalTime=  a.ExpectedTimeOfArrival,
                                   Pickdel=a.PickOrDelivery
                                  
                                 }).ToList();
            ViewBag.ordertemp = orderdetails;
            var drivnumber = context.DB_Vehicle_Tracking.Where(x => x.DB_LSVehicle.VehicleNo == vehicle).Select(x => x.DB_Driver.PhoneNumber).FirstOrDefault();
            Class1 model = new Class1();
            model.vehicleno = Vehicle;
            model.DriverName = driver;
         
            model.DriverNumber = drivnumber;
            model.photourl = driverpic;
            model.driverdetails = driver + " " + "," + drivnumber;
            model.fromplace = context.DB_OrderDetails.Where(x => x.OrderId == order && x.PickOrDelivery == "PICKUP").Select(x => x.ActualMAddress).FirstOrDefault();
            model.toplace = context.DB_OrderDetails.Where(x => x.OrderId == order && x.PickOrDelivery == "DELIVERY").Select(x => x.ActualMAddress).FirstOrDefault();
            model.CRN = CRNNo;
            model.fromlat = context.DB_OrderDetails.Where(x => x.OrderId == order && x.PickOrDelivery == "PICKUP").Select(x => x.ActualMLatitude).ToList();
            model.fromlong = context.DB_OrderDetails.Where(x => x.OrderId == order && x.PickOrDelivery == "PICKUP").Select(x => x.ActualMLongitude).ToList();
            model.tolong = context.DB_OrderDetails.Where(x => x.OrderId == order && x.PickOrDelivery == "DELIVERY").Select(x => x.ActualMLongitude).ToList();
            model.tolat = context.DB_OrderDetails.Where(x => x.OrderId == order && x.PickOrDelivery == "DELIVERY").Select(x => x.ActualMLatitude).ToList();

            model.countpick = context.DB_OrderDetails.Where(x => x.OrderId == order && x.PickOrDelivery == "PICKUP").Count();
            model.countdel = context.DB_OrderDetails.Where(x => x.OrderId == order && x.PickOrDelivery == "DELIVERY").Count();
            model.counttotal = model.countpick + model.countdel;
            return View(model);
        }

        public JsonResult Getlocation(string id, string CRN)
        {

            context.Configuration.ProxyCreationEnabled = false;

            var order1 = (from a in context.DB_Vehicle_Tracking
                          where a.DB_LSVehicle.VehicleNo == id
                          select new
                          {
                              a.CurrentLatitude,
                              a.CurrentLongitude,
                              
                          }).FirstOrDefault();


            var order = context.DB_mainOrders.Where(x => x.CRNNumber == CRN).Select(x => x.OrderId).FirstOrDefault();

            var fromlatlng = (from x in context.DB_OrderDetails
                              where x.OrderId == order && x.PickOrDelivery!="FINISH" 
                              select new
                                  {
                                      Latitude = x.ActualMLatitude == null ? (x.DB_DepotStation.DB_Address.Latitude == null ? 0 : x.DB_DepotStation.DB_Address.Latitude) : x.ActualMLatitude,
                                      Longitude = x.ActualMLongitude == null ? (x.DB_DepotStation.DB_Address.Longitude == null ? 0 : x.DB_DepotStation.DB_Address.Longitude) : x.ActualMLongitude,
                                 DepotStaionName=x.DB_DepotStation.Name,
                                 ContactNumber=x.ContactNumber,
                                 Status=x.PickDelStatus,
                                 Pickordel=x.PickOrDelivery,
                                 Address=x.DB_DepotStation.DB_Address.FullAddress,
                                 ContactNo=x.ContactNumber

                                  }).ToList();

            var tolatlong = context.DB_OrderDetails.Where(x => x.OrderId == order && x.PickOrDelivery == "DELIVERY").Select(x => new { x.ActualMLongitude, x.ActualMLatitude }).ToList();



            return Json(new { order1 = order1, flat = fromlatlng, flat4 = tolatlong }, JsonRequestBehavior.AllowGet);


            //return Json(order, JsonRequestBehavior.AllowGet);

        }




          public string GetStatusmeaning(string s) {
                   
                    switch (s) {

                        case "NA": return "Not Assigned";
                        case "TA": return "Temp Assigned";
                        case "TAD": return "Temp Assigned Declined";
                        case "A": return "Assigned";
                        case "P": return "Pickup";
                        case "RAtP": return "Reached At Pickup";
                        case "PDC": return "Declined At Pickup";
                        case "RAtD": return "Reached At Delivery";
                        case "D": return "Delivery";
                        case "DDC": return "Declined At Delivery";
                        case "C": return "Completed";
                        case "CAN": return "Cancelled";
                        default: return s;
                    }
                 
                    }




        //public ActionResult getdetails(string Id)
        //{
        //    JsonResult jsonResult;
        //    context.Configuration.ProxyCreationEnabled = false;

        //    long id = Convert.ToInt64(Id) ;

        //    var order1 = (from a in context.DB_OrderDetails
        //                  where a.OrderId == id && a.PickOrDelivery == "PICKUP"

        //                  select new
        //                  {
        //                      a.ActualMLatitude,
        //                      a.ActualMLongitude,

        //                  }).FirstOrDefault();

        //    var order2 = (from a in context.DB_OrderDetails
        //                  where a.OrderId == id && a.PickOrDelivery == "DELIVERY"

        //                         select new
        //                         {
        //                             a.ActualMLongitude,
        //                             a.ActualMLatitude,

        //                         }).FirstOrDefault();

        //    var order3 = (from a in context.DB_OrderDetails
        //                  where a.OrderId == id
        //                  select from b in context.DB_Vehicle_Tracking
        //                         where b.DB_LSVehicle.VehicleNo ==
        //                         select new
        //                         {
        //                             b.CurrentLatitude,
        //                             b.CurrentLongitude,
        //                         }).FirstOrDefault();






        //    jsonResult = base.Json(new { order1 = order1,order2=order2}, JsonRequestBehavior.AllowGet);


        //    return jsonResult;


        //    return Json(order, JsonRequestBehavior.AllowGet);

        //}





    }




}