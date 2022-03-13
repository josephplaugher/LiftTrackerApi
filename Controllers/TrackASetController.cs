using LiftTrackerApi.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiftTrackerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrackASetController : ControllerBase
    {
        private readonly ILogSql Sql;
        public TrackASetController(ILogSql sql)
        {
            this.Sql = sql;
        }
        [HttpPost]
        public ActionResult<IEnumerable<Log>> Index([FromForm] Log set)
        {
            return Ok(Sql.TrackASet(set));
        }

        [HttpPut]
        public ActionResult UpdateASet([FromForm] Log set)
        {
            return Ok(Sql.UpdateASet(set));
        }
    }
}
