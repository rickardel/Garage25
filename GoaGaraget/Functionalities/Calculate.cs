using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoaGaraget.Functionalities
{
    public class Calculate
    {
        public int CalculateCost(int hourly, DateTime from, DateTime to)
        {
            TimeSpan ts = to - from;
            double cost = ts.TotalHours * hourly;
            return (int)Math.Round(cost);
        }
        public void UpdateReceipt(Models.Receipt r)
        {
            r.ParkedVehicleId = r.ParkedVehicle.Id;
            r.CheckinAt = r.ParkedVehicle.CheckinDate;
            r.CheckoutAt = DateTime.Now;
            r.Cost = CalculateCost(r.ParkedVehicle.Member.Price, r.CheckinAt, r.CheckoutAt);
        }
        public float TotalIncome()
        {
            return 1f;
        }
        public float WheelCount()
        {
            return 1f;
        }
    }
}