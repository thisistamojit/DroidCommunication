using DroidDal.DroidTrackerRepo;
using DroidModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DroidWebApi.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public HttpResponseMessage Post([FromBody]DetailModel model)
        {
            //Sample st = JsonConvert.DeserializeObject<Sample>(value);
            try
            {
                IDroidTracker trackerrepo = new DroidTrackerDetails();
                trackerrepo.AddToDb(model);
                //data.Add(st.Name);
                //data.Add()
                var msg = Request.CreateResponse(HttpStatusCode.Created);
                msg.Headers.Location = new Uri(Request.RequestUri + "/" + (1).ToString());
                return msg;
            }
            catch (Exception ex)
            {
                    
                throw ex;
            }

        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}