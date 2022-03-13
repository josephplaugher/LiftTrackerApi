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
    public class LiftOptionsController : ControllerBase
    {
        private readonly ILogSql Sql;

        public LiftOptionsController(ILogSql sql)
        {
            this.Sql = sql;
        }

        [HttpGet]
        public ActionResult<IEnumerable<LiftOption>> Get()
        {
            return Ok(Sql.GetLiftOptions());
        }

        [HttpPost]
        public ActionResult AddLiftOption([FromForm] string lift)
        {
            return Ok(Sql.AddLiftOption(lift));
        }
    }
}
