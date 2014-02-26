using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace DroidCommuteService.DroidUtilities
{
   internal class BuildingInfoModel
    {
       public string DateofJourney { get; set; }
       public int TolalNumberofPassengr { get; set; }
       public int NoofPassengerArriving{ get; set; }
       public int NoofPassengerDeparting { get; set; }
       public string ToBuilding { get; set; }
       public string FromBuilding { get; set; }
       

    }
}