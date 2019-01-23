using ESMEP_EdoStateMinistryOfEducationPortal_.Infrastructure.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ESMEP_EdoStateMinistryOfEducationPortal_.Controller
{
    public class SchoolController : ApiController
    {
        DropDownManager dropDownManager = new DropDownManager();

        // GET api/<controller>
        [Route("api/StudentPersonalDatas/GetAllSchool")]
        [HttpGet]
        public IHttpActionResult GetAllSchool(int? id)
        {
            return Ok(dropDownManager.GetAllSchools());
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