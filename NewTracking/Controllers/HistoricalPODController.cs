using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewTracking.Models;
using System.Security.Cryptography;

namespace NewTracking.Controllers
{
    [CustomAction]

    public class HistoricalPODController : Controller
    {
        LogisureEntities1 context = new LogisureEntities1();
        // GET: APOD
        [PermissionFilter(Permission = "VIEW Historical TrackOrders POD")]

        public ActionResult Index(string OId)
        {
            try
            {
                if (!string.IsNullOrEmpty(OId))
                {
                    System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
                    System.Text.Decoder utf8Decode = encoder.GetDecoder();
                    byte[] todecode_byte = Convert.FromBase64String(OId.Replace("+", " "));
                    int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
                    char[] decoded_char = new char[charCount];
                    utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);

                    string result = new String(decoded_char);
                    Int32 OrderId = Convert.ToInt32(result);






                    //var Vehicles = context.DB_Vehicle_Tracking.Where(x => x.GPSno.Length > 10).Select(x => x.VehicleNo).ToList();
                    //ViewBag.vehicles = Vehicles;
                    ViewBag.OrderId = OrderId;
                }

                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public JsonResult GetOInfo(Int32 OrderId)
        {
            try
            {
                DateTime indianStd = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, "India Standard Time");
                string noIMageavailable = "http://tflappv10.logisureindia.com/upload/no_imageavailable.png";
                string noSignatureavailable = "http://tflappv10.logisureindia.com/upload/noSignatureavailable.png";
                string noSignaturerequested = "http://tflappv10.logisureindia.com/upload/noSignaturerequested.png";
                string noIMagerequested = "http://tflappv10.logisureindia.com/upload/noIMagerequested.png";
                var MainOrder = context.DB_mainOrders.Where(x => x.OrderId == OrderId).FirstOrDefault();
                var OrderDetails = context.DB_OrderDetails.Where(x => x.OrderId == OrderId && x.ActualCompletedAt != null).ToList().OrderBy(x => x.ActualCompletedAt);
                var pododet = context.DB_OrderDetails.Where(x => x.OrderId == OrderId);
                //var OrderDetails = context.DB_OrderDetails.Where(x => x.OrderId == OrderId ).ToList().OrderBy(x => x.ActualCompletedAt);

                List<PodSingledata> Podsd = new List<PodSingledata>();
                foreach (var od in OrderDetails)
                {

                    PodSingledata sdd = new PodSingledata();
                    sdd.Status = od.PickOrDelivery;
                    sdd.NameOfConsignornee = context.DB_DepotStation.Where(x => x.DepotStationId == od.DepotStationID).Select(x => x.Name).FirstOrDefault();
                    sdd.Address = od.ActualMAddress;
                    sdd.BiltyNumber = od.BiltyNumber;
                    sdd.Quantity = (od.EnteredQty == null) ? 0 : (double)od.EnteredQty;
                    sdd.Time = Convert.ToString(od.ActualCompletedAt);

                    sdd.isCancel = od.DB_mainOrders.IsCancelBy;
                    sdd.CDNNO = od.CDNnumber;
                    sdd.RDDCRemark = od.ReturnReason;
                    sdd.Latitude = (od.ActualMLatitude == null) ? 0 : (double)od.ActualMLatitude;
                    sdd.Longitude = (od.ActualMLongitude == null) ? 0 : (double)od.ActualMLongitude;
                    sdd.OId = od.ODetailId.ToString();



                    if (od.DB_mainOrders.DB_Client.IsPhotoAllowed == true)
                    {
                        #region /// Photo


                        if (od.PickOrDelivery == "PICKUP" || od.PickOrDelivery == "DELIVERY" || od.PickOrDelivery == "RETURN" || od.PickOrDelivery == "R-DDC" || od.PickOrDelivery == "FINISH")
                        {


                            string tflapp = "http://tflappv10.logisureindia.com/upload/" + od.PhotoGoods;
                            if (tflapp != null && od.PhotoGoods != null)
                                sdd.PhotoGoods = tflapp;
                            else
                                sdd.PhotoGoods = noIMageavailable;

                            tflapp = "http://tflappv10.logisureindia.com/upload/" + od.PhotoBilty;

                            if (tflapp != null && od.PhotoBilty != null)
                                sdd.PhotoGR = tflapp;
                            else
                                sdd.PhotoGR = noIMageavailable;

                            if (od.DB_mainOrders.DB_Client.IsSignatureRequired == true)
                            {
                                tflapp = "http://tflappv10.logisureindia.com/upload/" + od.Signature;

                                if (tflapp != null && od.Signature != null)
                                    sdd.Signature = tflapp;
                                else
                                    sdd.Signature = noSignatureavailable;
                            }
                            else
                            {
                                sdd.Signature = noSignaturerequested;
                            }

                        }
                    }

                    else
                    {


                        sdd.PhotoGoods = noIMagerequested + od.PhotoGoods;
                        sdd.PhotoGR = noIMagerequested + od.PhotoBilty;
                        sdd.Signature = noSignaturerequested + od.Signature;
                    }
                        #endregion

                    Podsd.Add(sdd);



                }

                //if enroute expenses is not null in main orders 
                //{
                //}

                if (MainOrder.EnrouteExpenses != null)
                {
                    var mainorderDetails = context.DB_mainOrderLog.Where(x => x.OrderId == OrderId && x.Status == "EE").ToList();

                    foreach (var od in mainorderDetails)
                    {

                        PodSingledata sdd = new PodSingledata();

                        sdd.NameOfConsignornee = od.DB_mainOrders.DB_DepotStation.Name;
                        sdd.CancelORemark = od.Remarks;
                        sdd.Time = Convert.ToString(od.CompletedDateTime);
                        sdd.Quantity = (double)od.DB_mainOrders.EnrouteExpenses;
                        sdd.Status = "ENROUTE EXPENSES";
                        string tflappee = "http://tflappv10.logisureindia.com/upload/" + od.PhotoGoods;
                        sdd.PhotoGR = noIMageavailable;
                        sdd.Signature = noIMageavailable;
                        sdd.Address = od.FullAddress;
                        sdd.PhotoGoods = tflappee;

                        Podsd.Add(sdd);

                    }

                }


                PodSingledata sd = new PodSingledata();

                sd.ClientName = MainOrder.DB_Client.ClientName;
                sd.CancelORemark = MainOrder.Remarks;
                sd.OrderId = MainOrder.CRNNumber;
                sd.VehicleNo = MainOrder.Vehicle;
                sd.NoOfDropPoints = pododet.Where(x => x.PickOrDelivery == "DELIVERY").Count();
                sd.NoOfPickupPoints = pododet.Where(x => x.PickOrDelivery == "PICKUP" && x.PickDelStatus == "C").Count();
                sd.NoOfReturnPoints = pododet.Where(x => x.PickOrDelivery == "RETURN" && x.PickDelStatus == "C").Count() + OrderDetails.Where(x => x.PickOrDelivery == "R-DDC" && x.PickDelStatus == "C").Count();
                sd.PICKUPcount = pododet.Where(c => c.PickOrDelivery == "PICKUP").Count();
                sd.DELIVERYcount = pododet.Where(c => c.PickOrDelivery == "DELIVERY" && c.PickDelStatus == "C").Count();
                sd.RDDCcount = pododet.Where(c => c.PickOrDelivery == "R-DDC").Count();
                sd.PICKUPquancount = pododet.Where(c => c.PickOrDelivery == "PICKUP").Sum(x => x.EnteredQty == null ? 0 : x.EnteredQty);
                sd.DELIVERYquancount = pododet.Where(c => c.PickOrDelivery == "DELIVERY").Sum(x => x.EnteredQty == null ? 0 : x.EnteredQty);
                sd.RDDCquancount = pododet.Where(c => c.PickOrDelivery == "R-DDC").Sum(x => x.EnteredQty == null ? 0 : x.EnteredQty);

                sd.AssignedAt = Convert.ToString(MainOrder.AssignedAt);
                sd.distanceAP = (MainOrder.distanceAP == null) ? 0 : (double)MainOrder.distanceAP;
                sd.distancePD = (MainOrder.OrderKm == null) ? 0 : (double)MainOrder.OrderKm;
                sd.TripTime = (MainOrder.TripTime == null) ? 0 : (double)MainOrder.TripTime * 60;
                sd.route = MainOrder.Route;



                return Json(new { data1 = Podsd, data2 = sd }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetStatus(string s)
        {
            switch (s)
            {
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
                case "C": return "Closed";
                default: return s;
            }
        }


        public ActionResult Map(string Longitude, string Latitude)
        {
            ViewBag.longiude = Longitude;
            ViewBag.latitude = Latitude;
            return View();
        }

        public ActionResult NMap(int orderid)
        {
            ViewBag.OrderId = orderid;
            ViewBag.order = context.DB_OrderDetails.Where(x => x.OrderId == orderid && x.ActualCompletedAt != null).OrderBy(x => x.ActualCompletedAt).ToList();
            return View();
        }
    }
}