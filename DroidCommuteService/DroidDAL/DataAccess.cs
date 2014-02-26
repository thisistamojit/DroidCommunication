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
using System.Data.SqlClient;
using System.Data;
using DroidCommuteService.DroidUtilities;
using DroidModel;
using System.Net;
using Newtonsoft.Json;
using System.IO;

namespace DroidCommuteService.DroidDAL
{
    class DataAccess
    {
        public void AddData(List<BuildingInfoModel> lstinfo)
        {
            try
            {
                SqlConnection ocon = new SqlConnection("data source=mssql6.websitelive.net;initial catalog=devspace_DIRT;user id=devspace_dirtadmin;password=Whctdcp@2009;");
                ocon.Open();
                SqlCommand oCom = new SqlCommand();
                string SQL = string.Empty;
                oCom.Connection = ocon;
                oCom.CommandType = CommandType.Text;
                foreach (BuildingInfoModel model in lstinfo)
                {
                    SQL = "INSERT INTO DroidTracker (TotalNoofPassenger, NoofPassengerDeparted, NoofPassengerarrived, FromBuilding, ToBuilding, DateofJourney)" +
                        "VALUES (" + model.TolalNumberofPassengr + "," + model.NoofPassengerDeparting + "," + model.NoofPassengerArriving + ",'" + model.FromBuilding + "'," +
                        "'"+model.ToBuilding+"','"+model.DateofJourney+"')";
                    oCom.CommandText = SQL;
                    oCom.ExecuteNonQuery();
                }
                
                ocon.Close();
            }
            catch (Exception ex)
            {


            }

        }

        public void AddDataThroughebAPI(List<BuildingInfoModel> lstinfo)
        {
            try
            {
               
                foreach (BuildingInfoModel model in lstinfo)
                {
                    WebApiTest(model);
                }

                
            }
            catch (Exception ex)
            {


            }
        }
        private  void WebApiTest(BuildingInfoModel datamodel)
        {
            DetailModel model = new DetailModel();
            model.TotalNoofPassenger = datamodel.TolalNumberofPassengr;
            model.NoofPassengerarrived = datamodel.NoofPassengerArriving;
            model.NoofPassengerDeparted = datamodel.NoofPassengerDeparting;
            model.FromBuilding = datamodel.FromBuilding;
            model.ToBuilding = datamodel.ToBuilding;
            model.DateofJourney = datamodel.DateofJourney;
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
        //private DataTable MakeDataTable(List<BuildingInfoModel> lstinfo)
        //{
        //    DataTable dt = new DataTable();
        //}
    }
}