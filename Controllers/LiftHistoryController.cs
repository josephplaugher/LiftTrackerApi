using LiftTrackerApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiftTrackerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LiftHistoryController : ControllerBase
    {
        private readonly ILogSql Sql;
        public LiftHistoryController(ILogSql sql)
        {
            this.Sql = sql;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Log>> Get()
        {
            return Ok(Sql.GetAllRecords());
        }

        [HttpGet("{Name}")]
        public ActionResult<IEnumerable<Log>> GetLiftsByName(string Name)
        {
            return Ok(Sql.GetLiftsByName(Name));
        }
    }
}
