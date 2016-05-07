using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewTracking.Models;
namespace NewTracking.Controllers
{
    public class TrackingController : Controller
    {
        LogisureEntities1 context = new LogisureEntities1();
        // GET: Tracking
        public ActionResult Index()
        {

            ViewBag.city = new SelectList(context.DB_City.Where(x => x.IsActive == true).ToList(), "CityId", "Name");
            var vehicle = (from a in context.DB_Vehicle_Tracking
                           select new
                           {
                               Value = a.VehicleId,
                               Text = a.DB_LSVehicle.VehicleNo,
                           }).ToList();

            ViewBag.Vehicle = new SelectList(vehicle, "Value", "Text");


            return View();
        }

        public JsonResult Getmap(string vehicle, string City)
        {
            if (vehicle != "" && City != "")
            {
                var veh = Convert.ToInt64(vehicle);
                var city = Convert.ToInt32(City);
                var order = (from a in context.DB_Vehicle_Tracking
                             where a.VehicleId == veh
                             select new
                             {
                                 status = a.State,
                                 Speed = a.Speed,
                                 Latitude = a.CurrentLatitude,
                                 Longitude = a.CurrentLongitude,
                                 VehicleNo = context.DB_LSVehicle.Where(x => x.LS_VehicleId == a.VehicleId).Select(x => x.VehicleNo).FirstOrDefault(),
                                 deliveryboy = context.DB_Helper.Where(x => x.HelperId == a.HelperId).Select(x => x.Name).FirstOrDefault(),
                                 BoyPhone = context.DB_PhoneInfo.Where(x => x.PhoneId == a.MobileId).Select(x => x.PhoneNo).FirstOrDefault(),
                                 LastUpdated = a.Datetime.ToString(),
                             }).ToList();
                return Json(new { order = order }, JsonRequestBehavior.AllowGet);

            }
            else if (City != "")
            {

                var city = Convert.ToInt32(City);
                var order = (from a in context.DB_Vehicle_Tracking
                             where a.DB_LSVehicle.CityId == city
                             select new
                             {
                                 status = a.State,
                                 Speed = a.Speed,
                                 Latitude = a.CurrentLatitude,
                                 Longitude = a.CurrentLongitude,
                                 VehicleNo = context.DB_LSVehicle.Where(x => x.LS_VehicleId == a.VehicleId).Select(x => x.VehicleNo).FirstOrDefault(),
                                 deliveryboy = context.DB_Helper.Where(x => x.HelperId == a.HelperId).Select(x => x.Name).FirstOrDefault(),
                                 BoyPhone = context.DB_PhoneInfo.Where(x => x.PhoneId == a.MobileId).Select(x => x.PhoneNo).FirstOrDefault(),
                                 LastUpdated = a.Datetime.ToString(),
                             }).ToList();


                return Json(new { order = order }, JsonRequestBehavior.AllowGet);
            }

            else
            {
                var order = (from a in context.DB_Vehicle_Tracking
                             select new
                             {
                                 status = a.State,
                                 Speed = a.Speed,
                                 Latitude = a.CurrentLatitude,
                                 Longitude = a.CurrentLongitude,
                                 VehicleNo = context.DB_LSVehicle.Where(x => x.LS_VehicleId == a.VehicleId).Select(x => x.VehicleNo).FirstOrDefault(),
                                 deliveryboy = context.DB_Helper.Where(x => x.HelperId == a.HelperId).Select(x => x.Name).FirstOrDefault(),
                                 BoyPhone = context.DB_PhoneInfo.Where(x => x.PhoneId == a.MobileId).Select(x => x.PhoneNo).FirstOrDefault(),
                                 LastUpdated = a.Datetime.ToString(),

                             }).ToList();
                return Json(new { order = order }, JsonRequestBehavior.AllowGet);
            }


        }

        public JsonResult GetVehicles(int CityId)
        {
            context.Configuration.ProxyCreationEnabled = false;
            var vehicle = (from a in context.DB_Vehicle_Tracking
                           where a.DB_LSVehicle.CityId == CityId
                           select new
                           {
                               Value = a.VehicleId,
                               Text = a.DB_LSVehicle.VehicleNo,
                           }).ToList();

            var order = new SelectList(vehicle, "Value", "Text");

            return Json(new { order = order, d = "success" }, JsonRequestBehavior.AllowGet);
        }


    }
}