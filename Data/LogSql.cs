using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiftTrackerApi.Data
{
    public class LogSql : ILogSql
    {
        private readonly ApplicationDbContext db;

        public LogSql(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<Log> GetAllRecords()
        {
            var query = from row in db.log
                        select row;
            return query.Take(15);
        }

        public IEnumerable<Log> GetLiftsByName(string Name)
        {
            var query = from row in db.log
                        where row.lift.StartsWith(Name)
                        orderby row.date
                        select row;
            return query.Take(15);
        }

        public IEnumerable<LiftOption> GetLiftOptions()
        {
            var query = from row in db.liftoptions
                        select row;
            return query;
        }

        public IEnumerable<Log> TrackASet(Log set)
        {
            db.Add(set);
            Commit();
            return GetLiftsByName(set.lift);
        }

        public Log UpdateASet(Log set)
        {
            var entity = db.log.Attach(set);
            entity.State = EntityState.Modified;
            db.Update(set);
            return set;
        }

        public IEnumerable<LiftOption> AddLiftOption(string lift)
        {
            LiftOption option = new LiftOption();
            option.name = lift;
            db.Add(option);
            Commit();
            return GetLiftOptions();
        }

        public int Commit()
        {
            return db.SaveChanges();
        }
    }

}
