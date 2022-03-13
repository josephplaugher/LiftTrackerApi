using System.Collections.Generic;

namespace LiftTrackerApi.Data
{
    public interface ILogSql
    {
        IEnumerable<Log> GetAllRecords();
        IEnumerable<Log> GetLiftsByName(string Name);
        IEnumerable<LiftOption> GetLiftOptions();
        IEnumerable<Log> TrackASet(Log set);
        Log UpdateASet(Log set);
        IEnumerable<LiftOption> AddLiftOption(string lift);
        int Commit();
    }
}