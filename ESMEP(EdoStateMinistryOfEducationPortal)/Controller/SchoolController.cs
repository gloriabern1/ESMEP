using ESMEP_EdoStateMinistryOfEducationPortal_.Infrastructure.Managers;
using ESMEP_EdoStateMinistryOfEducationPortal_.Services;
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
        //DropDownManager dropDownManager = new DropDownManager();
        InspectorServices inspectorServices = new InspectorServices();

        // GET api/<controller>
        [Route("api/StudentPersonalDatas/GetAllSchool")]
        [HttpGet]
        public IHttpActionResult GetAllSchool(int? id)
        {
            return Ok(DropDownManager.GetAllSchools());
        }

        // GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}
        [Route("api/School/AllInspector")]
        [HttpGet]
        public IHttpActionResult AllInspector()
        {
            return Ok(inspectorServices.GetLgaInspector());
        }

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