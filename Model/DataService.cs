using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Windows;
using System.Xml;

namespace ParserSbis.Model
{
    public class DataService : IDataService
    {
        public void GetDataRegion(Action<List<RegionItem>, Exception> callback)
        {
            List<RegionItem> region = new List<RegionItem>();
            string pathToFIle = @"Data/Location.json";
            string json = System.IO.File.ReadAllText(pathToFIle, System.Text.Encoding.UTF8);
            LocationResult model = JsonConvert.DeserializeObject<LocationResult>(json);
            var regionItem = model.result.d;


            //Получаем сериализованные объекты
            NetDataContractSerializer serializer = new NetDataContractSerializer();

            List<RegionItem> clonedActivity = null;
            if (File.Exists("region.xml"))
            {
                using (FileStream fs = File.OpenRead("region.xml"))
                {
                    clonedActivity = (List<RegionItem>)serializer.Deserialize(fs);
                }
            }

            List<string> code1Check = new List<string>();
            int count = 0;
            foreach (var item in regionItem)
            {
                if (count == 0)
                {
                    count++;
                    continue;
                }
                var found = region.FindAll(p => p.Code2 == item[3].ToString());
                if (found.Count != 0)
                {
                    continue;
                }


                bool check = false;
                if (clonedActivity != null)
                {
                    var isSelect = clonedActivity.FindAll(x => x.Name == item[1].ToString());
                    if (isSelect.Count != 0)
                    {
                        var isOneSelect = clonedActivity.Find(x => x.Name == item[1].ToString());
                        check = isOneSelect.Value;
                    }
                }

                RegionItem reg = new RegionItem(check, item[0].ToString(), item[1].ToString(), item[2].ToString(), item[3].ToString(), item[4].ToString(), item[5].ToString(), item[6].ToString());
                reg.Value = check;
                region.Add(reg);

                code1Check.Add(item[2].ToString());
                count++;
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

            List<string> code1Check = new List<string>();
            foreach (var item in regionItem)
            {
                region.Add(new RegionItem(false, item[0].ToString(), item[1].ToString(), item[2].ToString(), item[3].ToString(), item[4].ToString(), item[5].ToString(), item[6].ToString()));
                code1Check.Add(item[2].ToString());
            }

            callback(region, null);
        }
        /// <summary>
        /// Метод возращает список всех Деятельностей
        /// </summary>
        /// <param name="callback"></param>
        public void GetDataActivity(Action<List<ActivityItem>, Exception> callback)
        {
            List<ActivityItem> action = new List<ActivityItem>();
            string pathToFIle = @"Data/Activity.json";
            string json = System.IO.File.ReadAllText(pathToFIle, System.Text.Encoding.UTF8);
            LocationResult model = JsonConvert.DeserializeObject<LocationResult>(json);
            var actionItem = model.result.d;

            //Получаем сериализованные объекты
            NetDataContractSerializer serializer = new NetDataContractSerializer();

            List<ActivityItem> clonedActivity = null;
            if (File.Exists("activity.xml"))
            {
                using (FileStream fs = File.OpenRead("activity.xml"))
                {
                    clonedActivity = (List<ActivityItem>)serializer.Deserialize(fs);
                }
            }

            foreach (var item in actionItem)
            {
                bool check = false;
                if (clonedActivity != null)
                {
                    var isSelect = clonedActivity.FindAll(x => x.Name == item[1].ToString());
                    if (isSelect.Count != 0)
                    {
                        var isOneSelect = clonedActivity.Find(x => x.Name == item[1].ToString());
                        check = isOneSelect.Value;
                    }
                }
                
                ActivityItem activity = new ActivityItem(check, "", item[1].ToString(), item[2].ToString(), item[0].ToString(), item[4].ToString(), item[5].ToString(), null);
                activity.Value = check;
                action.Add(activity);
            }

            callback(action, null);
        }

        /// <summary>
        /// Получаем список всех ОКВЭД
        /// </summary>
        /// <param name="callback"></param>
        public void GetDataOKVD(Action<List<OKVDItem>, Exception> callback)
        {
            List<OKVDItem> action = new List<OKVDItem>();
            string pathToFIle = @"Data/list_okvd.xml";

            XmlDocument _doc = new XmlDocument();
            _doc.Load(pathToFIle);
            // получим корневой элемент
            XmlElement xRoot = _doc.DocumentElement;
            foreach (XmlNode xnode in xRoot)
            {
                string idOKVD = String.Empty;
                string kodOKVD = String.Empty;
                string nameOKVD = String.Empty;
                string fullcodeOKVD = String.Empty;

                // обходим все дочерние узлы элемента user

                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    if (childnode.Name == "idOKVD")
                    {
                        idOKVD = childnode.InnerText;
                    }

                    if (childnode.Name == "kodOKVD")
                    {
                        kodOKVD = childnode.InnerText;
                    }

                    if (childnode.Name == "nameOKVD")
                    {
                        nameOKVD = childnode.InnerText;
                    }

                    if (childnode.Name == "fullcodeOKVD")
                    {
                        fullcodeOKVD = childnode.InnerText;
                    }
                }

                action.Add(new OKVDItem(idOKVD, kodOKVD, nameOKVD, fullcodeOKVD));
            }


            callback(action, null);
        }

        public void GetTask(Action<List<TaskObject>, Exception> callback)
        {
            // Use this to connect to the actual data service
            //List<DataItem> item = new List<DataItem>();
            List<TaskObject> item = new List<TaskObject>();
            XmlDocument _doc = new XmlDocument();
            _doc.Load(@"Data/task_object.xml");
            // получим корневой элемент
            XmlElement xRoot = _doc.DocumentElement;
            foreach (XmlNode xnode in xRoot)
            {
                string id = String.Empty;
                string SelectedActivityName = String.Empty;
                string SelectedActivityCode1 = String.Empty;
                string SelectedActivityCode2 = String.Empty;
                string SelectedRegionCode1 = String.Empty;
                string kodeCity = String.Empty;
                string SelectedRegionIdRegion = String.Empty;
                string SelectedTypeKontragent = String.Empty;
                string SelectedStatus = String.Empty;
                string city = String.Empty;
                string pagin = String.Empty;
                string Time = String.Empty;
                string Interval = String.Empty;
                string Completed = String.Empty;
                string regionName = String.Empty;
                string revenueMin = String.Empty;
                string revenueMax = String.Empty;
                string revenueCheck = String.Empty;
                string idOKVD = String.Empty;
                string kodOKVD = String.Empty;
                string nameOKVD = String.Empty;
                string check_okvd = String.Empty;

                // обходим все дочерние узлы элемента user
                foreach (XmlNode childnode in xnode.ChildNodes)
                {

                    if (childnode.Name == "id")
                    {
                        id = childnode.InnerText;
                    }

                    if (childnode.Name == "SelectedActivityName")
                    {
                        SelectedActivityName = childnode.InnerText;
                    }

                    if (childnode.Name == "SelectedActivityCode1")
                    {
                        SelectedActivityCode1 = childnode.InnerText;
                    }

                    if (childnode.Name == "SelectedActivityCode2")
                    {
                        SelectedActivityCode2 = childnode.InnerText;
                    }

                    if (childnode.Name == "SelectedRegionCode1")
                    {
                        SelectedRegionCode1 = childnode.InnerText;
                    }

                    if (childnode.Name == "kodeCity")
                    {
                        kodeCity = childnode.InnerText;
                    }

                    if (childnode.Name == "SelectedRegionIdRegion")
                    {
                        SelectedRegionIdRegion = childnode.InnerText;
                    }

                    if (childnode.Name == "SelectedTypeKontragent")
                    {
                        SelectedTypeKontragent = childnode.InnerText;
                    }

                    if (childnode.Name == "SelectedStatus")
                    {
                        SelectedStatus = childnode.InnerText;
                    }

                    if (childnode.Name == "city")
                    {
                        city = childnode.InnerText;
                    }

                    if (childnode.Name == "pagin")
                    {
                        pagin = childnode.InnerText;
                    }

                    if (childnode.Name == "Time")
                    {
                        Time = childnode.InnerText;
                    }


                    if (childnode.Name == "Interval")
                    {
                        Interval = childnode.InnerText;
                    }

                    if (childnode.Name == "Completed")
                    {
                        Completed = childnode.InnerText;
                    }
                    ///
                    if (childnode.Name == "RegionName")
                    {
                        regionName = childnode.InnerText;
                    }

                    if (childnode.Name == "RevenueMin")
                    {
                        revenueMin = childnode.InnerText;
                    }


                    if (childnode.Name == "RevenueMax")
                    {
                        revenueMax = childnode.InnerText;
                    }

                    if (childnode.Name == "RevenueCheck")
                    {
                        revenueCheck = childnode.InnerText;
                    }

                    if (childnode.Name == "Check_okvd")
                    {
                        check_okvd = childnode.InnerText;
                    }

                    if (childnode.Name == "idOKVD")
                    {
                        idOKVD = childnode.InnerText;
                    }

                    if (childnode.Name == "KodOKVD")
                    {
                        kodOKVD = childnode.InnerText;
                    }

                    if (childnode.Name == "NameOKVD")
                    {
                        nameOKVD = childnode.InnerText;
                    }
                }

                item.Add(new TaskObject(id, SelectedActivityName, SelectedActivityCode1, SelectedActivityCode2, SelectedRegionCode1, kodeCity, SelectedRegionIdRegion,
                    SelectedTypeKontragent, SelectedStatus, city, pagin, Time, Interval, Completed, revenueMin, revenueMax, revenueCheck, regionName, check_okvd, idOKVD, kodOKVD, nameOKVD));
            }

            callback(item, null);
        }


    }
}