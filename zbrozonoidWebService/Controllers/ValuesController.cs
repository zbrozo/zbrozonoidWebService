using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace zbrozonoidWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public class PadMovement
        {
            public int playerId { get; set; }
            public int movement { get; set; }
        }

        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();

        private static readonly IDictionary<int, PadMovement> clientData = new Dictionary<int, PadMovement>();

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<PadMovement> Get(int id)
        {
            if (!clientData.Keys.Contains(id))
            {
                Logger.Info($"Error - key {id} not found");
                return new PadMovement();
            }

            Logger.Info("Get " + id);
            return clientData[id];
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
            
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] PadMovement value)
        {
            Logger.Info("Put " + id);

            if (!clientData.Keys.Contains(id))
            {
                clientData.Add(id, value);
            }
            else
            {
                clientData[id] = value;
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
