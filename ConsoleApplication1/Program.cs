using DroidDal.DroidTrackerRepo;
using DroidModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            WebApiTest();

            //APITest();
        }

        private static void WebApiTest()
        {
            DetailModel model = new DetailModel();
            model.TotalNoofPassenger = 5;
            model.NoofPassengerarrived = 10;
            model.NoofPassengerDeparted = 5;
            model.FromBuilding = "1";
            model.ToBuilding = "5";
            model.DateofJourney = "02/26/2014";
            var request = HttpWebRequest.Create(string.Format(@"http://localhost:3381/api/Values"));
            request.ContentType = "application/json";
            request.Method = "POST";
            request.ContentType = "application/json";
            string data = JsonConvert.SerializeObject(model);
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(data);
                streamWriter.Flush();
            }
            //request.r
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode == HttpStatusCode.Created)
                {
                    string strTest = "You are successful";
                }
            }
            //IDroidTracker tracker = new DroidTrackerDetails();
            //tracker.AddToDb(model);
        }

        private static void APITest()
        {
            var rxcui = "198440";
            var request = HttpWebRequest.Create(string.Format(@"http://localhost:56851/api/Values/0"));
            request.ContentType = "application/json";
            request.Method = "GET";
            //request.r
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    string strTest = "You are successful";
                }
            }
        }
    }
}
