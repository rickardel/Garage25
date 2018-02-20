using GoaGaraget.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoaGaraget.Functionalities
{
    public class DoIt
    {
        public void Park()
        {
        }
        public IEnumerable<ParkingSpace> GetEmptyParkingSpaces(int size)
        {
            return new List<ParkingSpace>();
        }
        public bool HasEmptyNeighbour(ParkingSpace ps)
        {
            return ps.ParkingSpaces.FirstOrDefault(p => p.IsEmpty == true) != null;
        }
        public IEnumerable<ParkingSpace> GetEmptyNeighbouringParkingSpace(ParkingSpace ps)
        {
            return ps.ParkingSpaces.Where(p => p.IsEmpty == true);
        }

        internal List<ParkingSpace> GetAvailableParkingSpaces(int size, ParkingSpace[] parkingSpaces)
        {
            var res = new List<ParkingSpace>();
            bool innerRes = true;
            int j = 0;
            for (int i = 0; i < parkingSpaces.Length; i++)
            {
                for (j = 0; j < size; j++)
                {
                    if (i + j >= parkingSpaces.Length || !parkingSpaces[i + j].IsEmpty) innerRes = false;
                }
                if (innerRes) res.Add(parkingSpaces[i]);
                innerRes = true;
            }

            return res;
        }

        public void CheckoutParkedVehicle(ParkedVehicle parkedVehicle)
        {
        }
        

        public int GetMaxSpace()
        {
            return 1;
        }


    }
}