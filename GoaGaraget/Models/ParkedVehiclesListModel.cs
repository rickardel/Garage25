using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoaGaraget.Models
{
    public class ParkedVehiclesListModel
    {
        ICollection<ParkedVehicleListModel> ParkedVehicles { get; set; }
        public ParkedVehiclesListModel()
        {
            ParkedVehicles = new List<ParkedVehicleListModel>();
        }
        public ParkedVehiclesListModel(ICollection<ParkedVehicle> parkedVehicles)
        {
            List<ParkedVehicleListModel> ParkedVehicles = new List<ParkedVehicleListModel>();
            foreach (var pv in parkedVehicles)
            {
                ParkedVehicles.Add(new ParkedVehicleListModel(pv.Member, pv.VehicleType, pv.RegNumber, pv.CheckinDate));
            }
        }

        public List<ParkedVehicleListModel> Simplify(ICollection<ParkedVehicle> parkedVehicles)
        {
            List<ParkedVehicleListModel> ParkedVehicles = new List<ParkedVehicleListModel>();
            foreach (var pv in parkedVehicles)
            {
                ParkedVehicles.Add(new ParkedVehicleListModel(pv.Member, pv.VehicleType, pv.RegNumber, pv.CheckinDate));
            }
            return ParkedVehicles;
        }
    }
}