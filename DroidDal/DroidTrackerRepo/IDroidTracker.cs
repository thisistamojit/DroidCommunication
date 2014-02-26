using DroidDal.Entity;
using DroidModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroidDal.DroidTrackerRepo
{
   public interface IDroidTracker
    {
        bool AddToDb(DetailModel model);
    }
    public class DroidTrackerDetails : IDroidTracker
    {
        public bool AddToDb(DetailModel model)
        {
            try
            {
                devspace_DIRTEntities1 en = new devspace_DIRTEntities1();
                en.DroidTrackers.Add(InitModel(model));
                en.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            
        }

        private DroidTracker InitModel(DetailModel model)
        {
            DroidTracker tracker = new DroidTracker();
            tracker.TotalNoofPassenger = model.TotalNoofPassenger;
            tracker.NoofPassengerarrived = model.NoofPassengerarrived;
            tracker.NoofPassengerDeparted = model.NoofPassengerDeparted;
            tracker.FromBuilding = model.FromBuilding;
            tracker.ToBuilding = model.ToBuilding;
            tracker.DateofJourney = model.DateofJourney;
            return tracker;
        }
    }

}
