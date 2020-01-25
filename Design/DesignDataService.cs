using System;
using ParserSbis.Model;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ParserSbis.Design
{
    public class DesignDataService : IDataService
    {
        public void GetDataRegion(Action<List<RegionItem>, Exception> callback)
        {
            List<RegionItem> region = new List<RegionItem>();
            string pathToFIle = @"Data/Location.json";
            string json = System.IO.File.ReadAllText(pathToFIle);
            LocationResult model = JsonConvert.DeserializeObject<LocationResult>(json);
            var regionItem = model.result.d;

            foreach (var item in regionItem)
            {
                region.Add(new RegionItem(false, "id_region", item[1].ToString(), item[2].ToString(), item[3].ToString(), item[4].ToString(), item[5].ToString(), item[6].ToString()));
            }

            callback(region, null);
        }

        public void GetDataCity(Action<List<RegionItem>, Exception> callback)
        {
            List<RegionItem> region = new List<RegionItem>();
            string pathToFIle = @"Data/Location.json";
            string json = System.IO.File.ReadAllText(pathToFIle, System.Text.Encoding.UTF8);
            LocationResult model = JsonConvert.DeserializeObject<LocationResult>(json);
            var regionItem = model.result.d;

            callback(region, null);
        }

        public void GetDataActivity(Action<List<ActivityItem>, Exception> callback)
        {
            List<ActivityItem> region = new List<ActivityItem>();
            string pathToFIle = @"Data/Activity.json";
            string json = System.IO.File.ReadAllText(pathToFIle, System.Text.Encoding.UTF8);
            LocationResult model = JsonConvert.DeserializeObject<LocationResult>(json);
            var regionItem = model.result.d;
        }

        public void GetTask(Action<List<TaskObject>, Exception> callback)
        {
            // Use this to connect to the actual data service
            //List<DataItem> item = new List<DataItem>();
            List<TaskObject> item = new List<TaskObject>();
 
            
            callback(item, null);
        }

        /// <summary>
        /// Получаем список всех ОКВЭД
        /// </summary>
        /// <param name="callback"></param>
        public void GetDataOKVD(Action<List<OKVDItem>, Exception> callback)
        {
            List<OKVDItem> action = new List<OKVDItem>();


            callback(action, null);
        }


    }
}