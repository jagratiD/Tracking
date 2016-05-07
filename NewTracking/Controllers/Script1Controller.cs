using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewTracking.Models;

namespace NewTracking.Controllers
{
    public class Script1Controller : Controller
    {
        LogisureEntities1 context = new LogisureEntities1();
        public DateTime indianStd = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, "India Standard Time");

        // GET: Script1
        public ActionResult Script1()
        {
            try
            {
                DateTime dt = Convert.ToDateTime("2016-03-01");
                string ii = "";
                while (dt.Month == 3)
                {
                    updatevehicleClient(dt);
                    ii += dt.ToShortDateString() + " , ";
                    dt = dt.AddDays(1);
                }

                return Json(new { status = "done", msg = ii }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult Script2()
        {
            try
            {
                DateTime dt = Convert.ToDateTime("2016-02-01");
                string ii = "";
                while (dt.Month == 2)
                {
                    updatevehicleClient(dt);
                    ii += dt.ToShortDateString() + " , ";
                    dt = dt.AddDays(1);
                }

                return Json(new { status = "done2", msg = ii }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ActionResult Script3()
        {
            try
            {
                DateTime dt = Convert.ToDateTime("2016-02-01");
                string ii = "";
                while (dt.Month == 2)
                {
                    updatevehicleIncentive(dt);
                    ii += dt.ToShortDateString() + " , ";
                    dt = dt.AddDays(1);
                }

                return Json(new { status = "done", msg = ii }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void updatevehicle(DateTime datefor)
        {
            try
            {
                var checkveh = context.DB_LSVehicle.Where(x => x.DB_VehicleType.Name.Contains("Beetle")).ToList();

                foreach (var item in checkveh)
                {

                    int checkorde = context.DB_mainOrders.Where(x => x.Vehicle == item.VehicleNo && x.EstimatedPickupTime.Value.Day == datefor.Day && x.EstimatedPickupTime.Value.Month == datefor.Month && x.EstimatedPickupTime.Value.Year == datefor.Year).Select(x => x.OrderId).Count();
                    if (checkorde >= 1)
                    {
                        DB_ExtraCharge ince = new DB_ExtraCharge();
                        ince.Amount = 100;
                        ince.Remark = "3 wheeler helper incentive";
                        ince.CreatedBy = "incentive bot";
                        ince.Vehicleid = item.LS_VehicleId;
                        ince.IsVerify = true;
                        ince.EventDate = datefor;
                        ince.ChargableAt = "Hire Charges";
                        ince.CreatedOn = indianStd;
                        context.DB_ExtraCharge.Add(ince);
                        context.SaveChanges();

                    }


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void updatevehicleClient(DateTime datefor)
        {
            try
            {
                var checkveh = context.DB_LSVehicle.Where(x => x.LS_VehicleId == 30236 || x.LS_VehicleId == 30292).ToList();

                foreach (var item in checkveh)
                {

                    int checkorde = context.DB_mainOrders.Where(x => x.Vehicle == item.VehicleNo && x.EstimatedPickupTime.Value.Day == datefor.Day && x.EstimatedPickupTime.Value.Month == datefor.Month && x.EstimatedPickupTime.Value.Year == datefor.Year  && x.Status == "C").Select(x => x.OrderId).Count();
                    if (checkorde >= 1)
                    {
                        DB_ExtraCharge ince = new DB_ExtraCharge();
                        ince.Amount = 100;
                        ince.Remark = "Driver As Helper";
                        ince.CreatedBy = "incentive bot";
                        ince.Vehicleid = item.LS_VehicleId;
                        ince.IsVerify = true;
                        ince.EventDate = datefor;
                        ince.ReasonId = 13;
                        ince.CreatedOn = indianStd;
                        ince.ChargableAt = "Hire Charges";
                        context.DB_ExtraCharge.Add(ince);
                        context.SaveChanges();

                    }


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void updatevehicleIncentive(DateTime datefor)
        {
            try
            {
                var checkveh = context.DB_LSVehicle.Where(x => x.Active == true && (x.LeavingDate == null || x.LeavingDate > indianStd)).ToList();

                foreach (var item in checkveh)
                {

                    var dutytime = context.DB_VehicleDailyAttendance.Where(x => x.LS_VehicleId == item.LS_VehicleId && x.AttendanceType.ToLower().Contains("out") && x.DateTime.Value.Day == datefor.Day && x.DateTime.Value.Month == datefor.Month && x.DateTime.Value.Year == datefor.Year).Select(x => x.DutyTime).FirstOrDefault();

                    if (dutytime != null && dutytime >= 13)
                    {
                        var extrahour = (int)(dutytime - 12);

                        DB_ExtraCharge ince = new DB_ExtraCharge();
                        ince.Amount = extrahour * 75;
                        ince.Remark = "extra duty hours";
                        ince.CreatedBy = "incentive bot";
                        ince.Vehicleid = item.LS_VehicleId;
                        ince.IsVerify = false;
                        ince.EventDate = datefor;
                        ince.ChargableAt = "Hire Charges";
                        ince.CreatedOn = indianStd;
                        context.DB_ExtraCharge.Add(ince);
                        context.SaveChanges();

                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}