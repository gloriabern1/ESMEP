using ESMEP_EdoStateMinistryOfEducationPortal_.Infrastructure.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ESMEP_EdoStateMinistryOfEducationPortal_.Controller
{
    public class SubjectController : ApiController
    {
        DropDownManager dropDownManager = new DropDownManager();

        // GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        [Route("api/subject/GetAllSubject")]
        [HttpGet]
        public IHttpActionResult GetAllSubject(int? id)
        {
            return Ok(dropDownManager.GetAllSubject());
        }

        // GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}