using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParserSbis.Model
{
    public interface IDataService
    {
        void GetDataRegion(Action<List<RegionItem>, Exception> callback);
        void GetDataCity(Action<List<RegionItem>, Exception> callback);
        void GetDataActivity(Action<List<ActivityItem>, Exception> callback);
        void GetTask(Action<List<TaskObject>, Exception> callback);
        void GetDataOKVD(Action<List<OKVDItem>, Exception> callback);
    }
}
