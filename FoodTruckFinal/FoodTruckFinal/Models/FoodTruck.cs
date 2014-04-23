using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodTruckFinal.Models
{
    public class FoodTruck
    {
        private int iD;
        private string truckName;
        private string location;
        private DateTime startTime;
        private DateTime endTime;

        public int ID { get { return iD; } set { iD = value;} }
        public string TruckName { get { return truckName; } set { truckName = value; } }
        public string Location { get { return location; } set { location = value; } }
        public DateTime StartTime { get { return startTime; } set { startTime = value;} }
        public DateTime EndTime { get { return endTime; } set { endTime = value;} }

    }
}