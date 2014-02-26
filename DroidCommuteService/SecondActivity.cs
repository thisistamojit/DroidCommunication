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
using System.Data;
using System.Data.SqlClient;
using DroidCommuteService.DroidUtilities;
using DroidCommuteService.DroidDAL;

namespace DroidCommuteService
{
    [Activity(Label = "Droid Commute Service", Icon = "@drawable/icon")]
    public class SecondActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.secondactivity);
            //Button btnNavigate = FindViewById<Button>(Resource.Id.btnNavigate);
            InitializeContext();
            //CreateAlertDialog

            // Create your application here
        }

        private void InitializeContext()
        {
            TextView txtTotal = FindViewById<TextView>(Resource.Id.txtTotal);
            TextView txtFromTo = FindViewById<TextView>(Resource.Id.txtFromTo);
            TextView txtDate = FindViewById<TextView>(Resource.Id.txtDate);
            txtDate.Text = DateTime.Now.ToShortDateString();
            txtTotal.Text = string.Empty;
            ImageButton imgbtnone = FindViewById<ImageButton>(Resource.Id.imgbtnone);
            ImageButton imgbtntwo = FindViewById<ImageButton>(Resource.Id.imgbtntwo);
            ImageButton imgbtnthree = FindViewById<ImageButton>(Resource.Id.imgbtnthree);
            ImageButton imgbtnfour = FindViewById<ImageButton>(Resource.Id.imgbtnnfour);
            Button btndepurture = FindViewById<Button>(Resource.Id.btnDeparture);
            Button btnarrival = FindViewById<Button>(Resource.Id.btnarrival);
            Button btnupload = FindViewById<Button>(Resource.Id.btnUpload);
    
            int itotalpassengerarrived = 0;
            int itotalpassengerdeparted = 0;
            string strJourneyInfo = string.Empty;
            //imgbtnone.Focusable = true;
            BuildingInfoModel buildingModel = null;
            List<BuildingInfoModel> lstinfo = new List<BuildingInfoModel>();
            bool fromFlag = true;
            imgbtnone.Click += (sender, e) =>
            {
                if (fromFlag)
                {
                    if (buildingModel != null && buildingModel.ToBuilding!=string.Empty) { lstinfo.Add(buildingModel); itotalpassengerdeparted = 0; itotalpassengerarrived = 0; }
                    buildingModel = new BuildingInfoModel();
                    strJourneyInfo = string.Empty;
                    //txtFromTo.Text = string.Format("From Building1");
                    buildingModel.FromBuilding = "1";
                    strJourneyInfo = string.Format("From Building 1");
                    buildingModel.DateofJourney = DateTime.Now.ToString();
                    txtFromTo.Text = strJourneyInfo;
                    fromFlag = false;
                    //buildingModel.FromBuilding
                }
                else
                {
                    if (buildingModel != null)
                    {
                        if (buildingModel.FromBuilding != "1")
                        {
                            buildingModel.ToBuilding = "1";
                            strJourneyInfo = strJourneyInfo + string.Format("To Building 1");
                            txtFromTo.Text = strJourneyInfo;
                            lstinfo.Add(buildingModel); itotalpassengerdeparted = 0; itotalpassengerarrived = 0;
                            fromFlag = true;
                        }
                        else
                        {
                            Toast.MakeText(this, "please select a different destination", ToastLength.Long).Show();
                            txtFromTo.Text = string.Empty;
                            fromFlag = true;
                            buildingModel = null;
                        }
                    }
                }

                //imgbtnone.FocusableInTouchMode = true;
                //Toast.MakeText(this, "you are successful", ToastLength.Long).Show();
                //SampleInsertData();
                //DroidDal.MyTestEntity test = new DroidDal.MyTestEntity();
                //test.SampleInsertData();


                //Dialog();

            };
            imgbtntwo.Click += (sender, e) =>
            {
                if (fromFlag)
                {
                    if (buildingModel != null && buildingModel.ToBuilding != string.Empty) { lstinfo.Add(buildingModel); itotalpassengerdeparted = 0; itotalpassengerarrived = 0; }
                    buildingModel = new BuildingInfoModel();
                    strJourneyInfo = string.Empty;
                    //txtFromTo.Text = string.Format("From Building1");
                    buildingModel.FromBuilding = "2";
                    strJourneyInfo = string.Format("From Building 2");
                    buildingModel.DateofJourney = DateTime.Now.ToString();
                    txtFromTo.Text = strJourneyInfo;
                    fromFlag = false;
                    //buildingModel.FromBuilding
                }
                else
                {
                    if (buildingModel != null)
                    {
                        if (buildingModel.FromBuilding != "2")
                        {
                            buildingModel.ToBuilding = "2";
                            strJourneyInfo = strJourneyInfo + string.Format("To Building 2");
                            txtFromTo.Text = strJourneyInfo;
                            fromFlag = true; ;
                            lstinfo.Add(buildingModel); itotalpassengerdeparted = 0; itotalpassengerarrived = 0;
                        }
                        else
                        {
                            Toast.MakeText(this, "please select a different destination", ToastLength.Long).Show();
                            txtFromTo.Text = string.Empty;
                            buildingModel = null;
                            fromFlag = true;
                        }
                    }
                }

                //imgbtnone.FocusableInTouchMode = true;
                //Toast.MakeText(this, "you are successful", ToastLength.Long).Show();
                //SampleInsertData();
                //DroidDal.MyTestEntity test = new DroidDal.MyTestEntity();
                //test.SampleInsertData();


                //Dialog();

            };
            imgbtnthree.Click += (sender, e) =>
            {
                if (fromFlag)
                {
                    if (buildingModel != null && buildingModel.ToBuilding != string.Empty) { lstinfo.Add(buildingModel); itotalpassengerdeparted = 0; itotalpassengerarrived = 0; }
                    buildingModel = new BuildingInfoModel();
                    strJourneyInfo = string.Empty;
                    //txtFromTo.Text = string.Format("From Building1");
                    buildingModel.FromBuilding = "3";
                    strJourneyInfo = string.Format("From Building 3");
                    buildingModel.DateofJourney = DateTime.Now.ToString();
                    txtFromTo.Text = strJourneyInfo;
                    fromFlag = false;
                    //buildingModel.FromBuilding
                }
                else
                {
                    if (buildingModel != null)
                    {
                        if (buildingModel.FromBuilding != "3")
                        {
                            buildingModel.ToBuilding = "3";
                            strJourneyInfo = strJourneyInfo + string.Format("To Building 3");
                            txtFromTo.Text = strJourneyInfo;
                            lstinfo.Add(buildingModel); itotalpassengerdeparted = 0; itotalpassengerarrived = 0;
                            fromFlag = true;

                        }
                        else
                        {
                            Toast.MakeText(this, "please select a different destination", ToastLength.Long).Show();
                            txtFromTo.Text = string.Empty;
                            buildingModel = null;
                            fromFlag = true;
                        }
                    }
                }

                //imgbtnone.FocusableInTouchMode = true;
                //Toast.MakeText(this, "you are successful", ToastLength.Long).Show();
                //SampleInsertData();
                //DroidDal.MyTestEntity test = new DroidDal.MyTestEntity();
                //test.SampleInsertData();


                //Dialog();

            };
            imgbtnfour.Click += (sender, e) =>
            {
                if (fromFlag)
                {
                    if (buildingModel != null && buildingModel.ToBuilding != string.Empty) { lstinfo.Add(buildingModel); itotalpassengerdeparted = 0; itotalpassengerarrived = 0; }
                    buildingModel = new BuildingInfoModel();
                    strJourneyInfo = string.Empty;
                    //txtFromTo.Text = string.Format("From Building1");
                    buildingModel.FromBuilding = "4";
                    strJourneyInfo = string.Format("From Building 4");
                    buildingModel.DateofJourney = DateTime.Now.ToString();
                    txtFromTo.Text = strJourneyInfo;
                    fromFlag = false;
                    //buildingModel.FromBuilding
                }
                else
                {
                    if (buildingModel != null)
                    {
                        if (buildingModel.FromBuilding != "4")
                        {
                            buildingModel.ToBuilding = "4";
                            strJourneyInfo = strJourneyInfo + string.Format("To Building 4");
                            txtFromTo.Text = strJourneyInfo;
                            lstinfo.Add(buildingModel); itotalpassengerdeparted = 0; itotalpassengerarrived = 0;
                            fromFlag = true;
                        }
                        else
                        {
                            Toast.MakeText(this, "please select a different destination", ToastLength.Long).Show();
                            txtFromTo.Text = string.Empty;
                            buildingModel = null;
                            fromFlag = true;
                        }
                    }
                }

                //imgbtnone.FocusableInTouchMode = true;
                //Toast.MakeText(this, "you are successful", ToastLength.Long).Show();
                //SampleInsertData();
                //DroidDal.MyTestEntity test = new DroidDal.MyTestEntity();
                //test.SampleInsertData();


                //Dialog();

            };
            btndepurture.Click += (sender, e) =>
            {

                if (buildingModel != null && buildingModel.FromBuilding != string.Empty && buildingModel.ToBuilding != null)
                {
                    int TotalPassenger = txtTotal.Text != string.Empty ? Convert.ToInt32(txtTotal.Text) : 0;
                    TotalPassenger = TotalPassenger > 0 ? TotalPassenger - 1 : 0;
                    itotalpassengerdeparted++;
                    buildingModel.NoofPassengerDeparting = itotalpassengerdeparted;
                    buildingModel.TolalNumberofPassengr = TotalPassenger;
                    //TotalPassenger++;
                    //TotalPassenger = TotalPassenger + iCount;
                    
                    txtTotal.Text = TotalPassenger.ToString();
                }
                else
                {
                    Toast.MakeText(this, "Please select valid journey route", ToastLength.Long).Show();
                }

                //Toast.MakeText(this, "you are successful", ToastLength.Long).Show();
            };

            btnarrival.Click += (sender, e) =>
            {
                if (buildingModel != null && buildingModel.FromBuilding != string.Empty &&  buildingModel.ToBuilding!=null)
                {
                    int TotalPassenger = txtTotal.Text != string.Empty ? Convert.ToInt32(txtTotal.Text) : 0;
                    
                    TotalPassenger++;
                    itotalpassengerarrived++;
                    //TotalPassenger = TotalPassenger + iCount;
                    buildingModel.NoofPassengerArriving = itotalpassengerarrived;
                    buildingModel.TolalNumberofPassengr = TotalPassenger;
                    txtTotal.Text = TotalPassenger.ToString();
                }
                else
                {
                    Toast.MakeText(this, "Please select valid journey route", ToastLength.Long).Show();
                }

                //Toast.MakeText(this, "you are successful", ToastLength.Long).Show();
            };

            btnupload.Click += (sender, e) => {

                if (lstinfo!=null &&lstinfo.Count > 0)
                {
                    Dialog(lstinfo);
                    lstinfo = null;
                }
                else
                {
                    Toast.MakeText(this, "There is no data to upload", ToastLength.Long).Show();
                }
            
            };

        }

        private void Dialog(List<BuildingInfoModel> lstinfo)
        {
            var builder = new AlertDialog.Builder(this);
            builder.SetMessage("Are you sure that you want to upload the data?");
            builder.SetPositiveButton("OK", (s, e1) => { /* do something on OK click */
                DataAccess da = new DataAccess();
                Toast.MakeText(this, "Please wait while data is being transferred to the remote server", ToastLength.Long).Show();
                da.AddDataThroughebAPI(lstinfo);
                Toast.MakeText(this, "Transaction Successful", ToastLength.Long).Show();
            
            
            });
            builder.SetNegativeButton("Cancel", (s, e2) => { /* do something on Cancel click */ });
            builder.Create().Show();
        }

        private void SampleInsertData()
        {
            try
            {
                SqlConnection ocon = new SqlConnection("data source=mssql6.websitelive.net;initial catalog=devspace_DIRT;user id=devspace_dirtadmin;password=Whctdcp@2009;");
                ocon.Open();
                SqlCommand oCom = new SqlCommand();
                oCom.Connection = ocon;
                oCom.CommandType = CommandType.Text;
                oCom.CommandText = "INSERT INTO  DroidTracker  (Dataval) VALUES ('sample1')";
                oCom.ExecuteNonQuery();
                ocon.Close();
            }
            catch (Exception ex)
            {


            }

        }
    }
}