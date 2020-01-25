using Newtonsoft.Json;
using ParserSbis.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace ParserSbis.Utils
{
    public class api_sbis
    {

        public string Auth(string login, string password)
        {
            string id_session = null;

            var auth = new AuthRequest();
            auth.jsonrpc = "2.0";
            auth.method = "СБИС.Аутентифицировать";
            auth.@params = new AuthParams
            {
                Логин = login,
                Пароль = password
            };

            auth.id = 0;

            string jsonRequest = JsonConvert.SerializeObject(auth);
            //byte[] body = Encoding.UTF8.GetBytes(jsonRequest);

            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create("https://online.sbis.ru/auth/service/");
            req.UserAgent = "Mozilla/5.0 (Windows NT 6.1; rv:38.0) Gecko/20100101 Firefox/38.0";
            req.AllowAutoRedirect = false;
            req.ContentType = "application/json; charset=utf-8";
            req.Method = WebRequestMethods.Http.Post;

            //Debug Sniffing 
            //WebProxy myProxy = new WebProxy("http://127.0.0.1:8888/");
            //req.Proxy = myProxy;

            using (var streamWriter = new StreamWriter(req.GetRequestStream()))
            {
                streamWriter.Write(jsonRequest);
            }

            HttpWebResponse response = (HttpWebResponse)req.GetResponse();

            string json = String.Empty;

            using (StreamReader sr = new StreamReader(response.GetResponseStream()))
            {
                json = sr.ReadToEnd();
            }

            AuthResultObject m = JsonConvert.DeserializeObject<AuthResultObject>(json);
            id_session = m.result;

            if (m.result == null)
            {
                ErrorItem error = JsonConvert.DeserializeObject<ErrorItem>(json);
                id_session = null;
                MessageBox.Show(error.error.message);
            }
           
            return id_session;
        }

        /// <summary>
        /// Получаем список контрагентов по ОГРН
        /// </summary>
        /// <returns></returns>
        public ResultCompany GetListOGRNContragent()
        {
            ResultCompany listCompany = null;



            return listCompany;
        }



        public ResultCompany SearchListContragent(string key, string search_key, int pagin)
        {
            ResultCompany listCompany = new ResultCompany();

            //Фильтр
            List<S> listS = new List<S>();
            listS.Add(new S { n = "ИскатьВФилиалах", t = "Логическое" });
            listS.Add(new S { n = "Реквизиты", t = "Строка" });

            //Сортировка
            List<S2> listS2 = new List<S2>();
            listS2.Add(new S2 { n = "l", t = "Логическое" });
            listS2.Add(new S2 { n = "n", t = "Строка" });
            listS2.Add(new S2 { n = "o", t = "Логическое" });

            //Навигация
            List<S3> listS3 = new List<S3>();
            listS3.Add(new S3 { n = "Страница", t = "Число целое" });
            listS3.Add(new S3 { n = "РазмерСтраницы", t = "Число целое" });
            listS3.Add(new S3 { n = "ЕстьЕще", t = "Логическое" });

            var query = new SearchQuery();
            query.jsonrpc = "2.0";
            query.protocol = 4;
            query.method = "Контрагент.СписокОбщийИСПП";

            List<object> bufferFilter = new List<object>();

            bufferFilter.Add(true);
            bufferFilter.Add(search_key);

            var filter = new Фильтр
            {
                s = listS,
                d = bufferFilter
            };

            var nviagtion = new Навигация
            {
                s = listS3,
                d = new List<object> { pagin, 20, true }
            };
            var sort = new Сортировка
            {
                d = new List<object> { false, "Выручка", true },
                s = listS2
            };

            query.@params = new @params
            {
                ДопПоля = new List<object>(),
                Фильтр = filter,
                Сортировка = sort,
                Навигация = nviagtion
            };

            query.id = 1;

            string jsonRequest = JsonConvert.SerializeObject(query, Formatting.None, new JsonSerializerSettings { });
            jsonRequest = jsonRequest.Replace("[false,\"Выручка\",true]", "[[false,\"Выручка\",true]]");
            //Сырая строка запроса
            //string jsonRequest = "{\"jsonrpc\":\"2.0\",\"protocol\":4,\"method\":\"Контрагент.СписокОбщийИСПП\",\"params\":{\"ДопПоля\":[],\"Фильтр\":{\"d\":[\"607\",true,\"77\",\"1\",\"1\",\"Москва\",\"Банк\"],\"s\":[{\"n\":\"ИдРегион\",\"t\":\"Строка\"},{\"n\":\"ИскатьВФилиалах\",\"t\":\"Логическое\"},{\"n\":\"Регион\",\"t\":\"Строка\"},{\"n\":\"Состояние\",\"t\":\"Строка\"},{\"n\":\"СтатусКонтрагента\",\"t\":\"Строка\"},{\"n\":\"СтрокаРегион\",\"t\":\"Строка\"},{\"n\":\"ТипЛица\",\"t\":\"Строка\"}]},\"Сортировка\":{\"s\":[{\"n\":\"n\",\"t\":\"Строка\"},{\"n\":\"o\",\"t\":\"Логическое\"},{\"n\":\"l\",\"t\":\"Логическое\"}],\"d\":[[\"Выручка\",true,false]]},\"Навигация\":{\"s\":[{\"n\":\"Страница\",\"t\":\"Число целое\"},{\"n\":\"РазмерСтраницы\",\"t\":\"Число целое\"},{\"n\":\"ЕстьЕще\",\"t\":\"Логическое\"}],\"d\":[2,20,true]}},\"id\":1}";
            try
            {
                HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create("https://online.sbis.ru/service/");
                //req.Proxy = new WebProxy("212.1.227.182:80", false);

                req.ContentType = "application/json; charset=utf-8";
                req.Method = WebRequestMethods.Http.Post;
                req.Headers["X-SBISSessionID"] = key;

                using (var streamWriter = new StreamWriter(req.GetRequestStream()))
                {
                    streamWriter.Write(jsonRequest);
                }

                HttpWebResponse response = (HttpWebResponse)req.GetResponse();

                string json = String.Empty;

                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {
                    json = sr.ReadToEnd();
                }

                JsonSerializerSettings jsonSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, DateFormatHandling = DateFormatHandling.IsoDateFormat };
                jsonSettings.MissingMemberHandling = MissingMemberHandling.Ignore;

                listCompany = JsonConvert.DeserializeObject<ResultCompany>(json, jsonSettings);

                if (listCompany.result == null)
                {
                    ErrorItem erroMessage = JsonConvert.DeserializeObject<ErrorItem>(json, jsonSettings);
                    MessageBox.Show(erroMessage.error.message);
                }

                return listCompany;
            }

            catch (WebException ex)
            {
                listCompany = null;
                MessageBox.Show(ex.Message);
            }

            return listCompany;
        }
        /// <summary>
        /// Получаем список контрагентов по виду деятельности
        /// </summary>
        /// <param name="key"></param>
        public ResultCompany GetListContragent(string key, string typeActivity, string idActivity, string id_kind_name, string idRegion, string region, string kod, string typeKontragent, string status, string city, int pagin, bool check_okvd, 
            string IdOKVD, string kodOKVD, string NameOKVD)
        {
            ResultCompany listCompany;

            //Фильтр
            List<S> listS = new List<S>();
            listS.Add(new S { n = "activityKindName", t = "Строка" });

            if (!typeActivity.Equals("all") && !check_okvd)
            {
                listS.Add(new S { n = "ВидДеятельности", t = "Строка" });
                listS.Add(new S { n = "ИдВидДеятельности", t = "Строка" });
            }
            //Если выбран ОКЭВД
            if (check_okvd)
            {
                listS.Add(new S { n = "ИдОКВЭД", t = "Число целое" });
                listS.Add(new S { n = "ОКВЭД", t = "Строка" });
                listS.Add(new S { n = "ОКВЭДName", t = "Строка" });
            }
                        
            listS.Add(new S { n = "ИдРегион", t = "Строка" });
            listS.Add(new S { n = "ИскатьВФилиалах", t = "Логическое" });
            listS.Add(new S { n = "Регион", t = "Строка" });
            listS.Add(new S { n = "Состояние", t = "Строка" });
            listS.Add(new S { n = "СтатусКонтрагента" , t = "Строка" });

            if (city != null)
            {
                listS.Add(new S { n = "СтрокаРегион", t = "Строка" });
            }
            
            bool check_allKontragent = typeKontragent.Equals("Все контрагенты");
            if (!check_allKontragent)
            {
                listS.Add(new S { n = "ТипЛица", t = "Строка" });
            }
            
            //Сортировка
            List<S2> listS2 = new List<S2>();
            listS2.Add(new S2 { n = "l", t = "Логическое" });
            listS2.Add(new S2 { n = "n", t = "Строка" });
            listS2.Add(new S2 { n = "o", t = "Логическое" });
            
            //Навигация
            List<S3> listS3 = new List<S3>();
            listS3.Add(new S3 { n = "Страница", t = "Число целое" });
            listS3.Add(new S3 { n = "РазмерСтраницы", t = "Число целое" });
            listS3.Add(new S3 { n = "ЕстьЕще", t = "Логическое" });

            var query = new SearchQuery();
            query.jsonrpc = "2.0";
            query.protocol = 4;
            query.method = "Контрагент.СписокОбщийИСПП";

            List<object> bufferFilter = new List<object>();

            if (!typeActivity.Equals("all") && !check_okvd)
            {
                bufferFilter.Add(typeActivity.Trim());
                bufferFilter.Add(idActivity);
            }

            if (check_okvd)
            {
                bufferFilter.Add(id_kind_name);
                bufferFilter.Add(Convert.ToInt64(IdOKVD));
                bufferFilter.Add(kodOKVD);
                bufferFilter.Add(NameOKVD);
            }
            
            if (!check_okvd)
            {
                //Извлекаем из строки id вид деятельности
                id_kind_name = id_kind_name.Trim(new Char[] { '[', ']' });
                id_kind_name = id_kind_name.Trim();
                id_kind_name = Regex.Replace(id_kind_name, "[\r\n]+", "");
                bufferFilter.Add(id_kind_name);
            }

            kod = kod.Trim(new Char[] { '[', ']' });
            kod = kod.Trim();
            kod = Regex.Replace(kod, "[\r\n]+", "");

            if (city != null)
            {
                bufferFilter.Add(kod);
            }
            bufferFilter.Add(true);
            if (city != null)
            {
               
                if (city.Equals("Москва"))
                {
                    kod = "77";
                    bufferFilter.Add(kod);
                } 

                else if (city.Equals("Санкт-Петербург"))
                {
                    kod = "78";
                    bufferFilter.Add(kod);
                }
                else
                {
                    bufferFilter.Add(region);
                }
            }


            if (status.Equals("В любом статусе"))
            {
                bufferFilter.Add(null);
                bufferFilter.Add("2");
            }
            if (status.Equals("Только действующие"))
            {
                bufferFilter.Add("1");
                bufferFilter.Add("1");
            }

            if (status.Equals("Только ликвидированные"))
            {
                bufferFilter.Add("0");
                bufferFilter.Add("0");
            }

            if (city != null)
            {
                bufferFilter.Add(city);
            }

            //Если выбрано "Выбрать всех", то не добавляем этот фильтр 
            if (!check_allKontragent)
            {
                bufferFilter.Add(typeKontragent);
            }

            var filter = new Фильтр
            {
                s = listS,
                //d = new List<object> { typeActivity, "906000000", "1975", "607", true, "77", "1", "1", "Москва" }
                //d = new List<object> { typeActivity, idActivity, "1975", idRegion, true, region, "1", "1", city, typeKontragent }  // !<----------------Рабочий вариант. Делаем динамику на виды и Город
                d = bufferFilter
            };

            var nviagtion = new Навигация
            {
                s = listS3,
                d = new List<object> { pagin, 20, true }
            };
            var sort = new Сортировка
            {                
                d = new List<object> { false, "Выручка", true } ,
                s = listS2
            };

            query.@params = new @params
            {
                ДопПоля = new List<object>(),
                Фильтр = filter,
                Сортировка = sort,
                Навигация = nviagtion
            };

            query.id = 1;


            string jsonRequest = JsonConvert.SerializeObject(query, Formatting.None, new JsonSerializerSettings { });
            jsonRequest = jsonRequest.Replace("[false,\"Выручка\",true]", "[[false,\"Выручка\",true]]");
            //Сырая строка запроса
            //string jsonRequest = "{\"jsonrpc\":\"2.0\",\"protocol\":4,\"method\":\"Контрагент.СписокОбщийИСПП\",\"params\":{\"ДопПоля\":[],\"Фильтр\":{\"d\":[\"607\",true,\"77\",\"1\",\"1\",\"Москва\",\"Банк\"],\"s\":[{\"n\":\"ИдРегион\",\"t\":\"Строка\"},{\"n\":\"ИскатьВФилиалах\",\"t\":\"Логическое\"},{\"n\":\"Регион\",\"t\":\"Строка\"},{\"n\":\"Состояние\",\"t\":\"Строка\"},{\"n\":\"СтатусКонтрагента\",\"t\":\"Строка\"},{\"n\":\"СтрокаРегион\",\"t\":\"Строка\"},{\"n\":\"ТипЛица\",\"t\":\"Строка\"}]},\"Сортировка\":{\"s\":[{\"n\":\"n\",\"t\":\"Строка\"},{\"n\":\"o\",\"t\":\"Логическое\"},{\"n\":\"l\",\"t\":\"Логическое\"}],\"d\":[[\"Выручка\",true,false]]},\"Навигация\":{\"s\":[{\"n\":\"Страница\",\"t\":\"Число целое\"},{\"n\":\"РазмерСтраницы\",\"t\":\"Число целое\"},{\"n\":\"ЕстьЕще\",\"t\":\"Логическое\"}],\"d\":[2,20,true]}},\"id\":1}";
            try
            {
                HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create("https://online.sbis.ru/service/");
                //req.Proxy = new WebProxy("212.1.227.182:80", false);

                req.ContentType = "application/json; charset=utf-8";
                req.Method = WebRequestMethods.Http.Post;
                req.Headers["X-SBISSessionID"] = key;

                using (var streamWriter = new StreamWriter(req.GetRequestStream()))
                {
                    streamWriter.Write(jsonRequest);
                }

                HttpWebResponse response = (HttpWebResponse)req.GetResponse();

                string json = String.Empty;

                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {
                    json = sr.ReadToEnd();
                }

                JsonSerializerSettings jsonSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, DateFormatHandling = DateFormatHandling.IsoDateFormat };
                jsonSettings.MissingMemberHandling = MissingMemberHandling.Ignore;

                listCompany = JsonConvert.DeserializeObject<ResultCompany>(json, jsonSettings);

                if (listCompany.result == null)
                {
                    ErrorItem erroMessage = JsonConvert.DeserializeObject<ErrorItem>(json, jsonSettings);
                    MessageBox.Show(erroMessage.error.message);
                }
                return listCompany;
            }
            catch (WebException ex)
            {
                listCompany = null;
                MessageBox.Show(ex.Message);
            }

            return listCompany;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id_spp">ИдСПП </param>
        /// <param name="key"></param>
        /// <returns></returns>
        public ResultDetailCompany GetDetailContragent(int id_spp, string key)
        {
            string query = "{\"jsonrpc\":\"2.0\"," + 
                           "\"protocol\": 4, " +
                           "\"method\":\"Контрагент.ПрочитатьПолный\" " +
                           ",\"params\":{ \"ИдСПП\":" + id_spp + ",\"ИдЛок\":null,\"ИП\":null,\"Регламент\":null },\"id\":1}";

            //string jsonRequest = JsonConvert.SerializeObject(query, Formatting.Indented, new JsonSerializerSettings { });
            ResultDetailCompany m = new ResultDetailCompany();

            try
            {
                HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create("https://online.sbis.ru/service/?srv=1");
                req.ContentType = "application/json; charset=utf-8";
                req.Method = WebRequestMethods.Http.Post;
                req.Headers["X-SBISSessionID"] = key;

                using (var streamWriter = new StreamWriter(req.GetRequestStream()))
                {
                    streamWriter.Write(query);
                }

                HttpWebResponse response = (HttpWebResponse)req.GetResponse();

                string json = String.Empty;

                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {
                    json = sr.ReadToEnd();
                }

                m = JsonConvert.DeserializeObject<ResultDetailCompany>(json);

                return m;
            }
            catch (WebException ex)
            {
                m = null;
                MessageBox.Show(ex.Message);
                return m;               
            }
        }

        /// <summary>
        /// Метод получает сертификаты и лицензий компаний 
        /// </summary>
        public ResultCertificate GetCertificate(int id_spp, string key)
        {
            //string query = "{\"jsonrpc\":\"2.0\",\"protocol\":4,\"method\":\"+Лицензия.GroupedSamplesList\",\"params\":{ \"Фильтр\":{ \"s\":[{\"n\":\"id_spp\",\"t\":\"Число целое\"},{\"n\":\"samples_amount\",\"t\":\"Число целое\"},{\"n\":\"source\",\"t\":\"Число целое\"}],\"d\":[" + id_spp +",6,1],\"_type\":\"record\"},\"Сортировка\":null,\"Навигация\":{\"s\":[{\"n\":\"ЕстьЕще\",\"t\":\"Логическое\"},{\"n\":\"РазмерСтраницы\",\"t\":\"Число целое\"},{\"n\":\"Страница\",\"t\":\"Число целое\"}],\"d\":[true,20,2],\"_type\":\"record\"},\"ДопПоля\":[]},\"id\":1}";

            List<S> listS = new List<S>();
            listS.Add(new S { n = "id_spp", t = "Число целое" });
            listS.Add(new S { n = "samples_amount", t = "Число целое" });
            listS.Add(new S { n = "source", t = "Число целое" });

            var query = new SearchQuery();
            query.jsonrpc = "2.0";
            query.protocol = 4;
            query.method = "Лицензия.GroupedSamplesList";
            var filter = new Фильтр
            {
                d = new List<object> { id_spp, 6, 1 },
                s = listS
            };
            query.@params = new @params
            {
                ДопПоля = new List<object>(),
                Фильтр = filter,
                Сортировка = null,
                Навигация = null
            };
            query.id = 1;

            string jsonRequest = JsonConvert.SerializeObject(query, Formatting.Indented, new JsonSerializerSettings { });

            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create("https://online.sbis.ru/service/?srv=1");
            req.ContentType = "application/json; charset=utf-8";
            req.Method = WebRequestMethods.Http.Post;
            req.Headers["X-SBISSessionID"] = key;

            using (var streamWriter = new StreamWriter(req.GetRequestStream()))
            {
                streamWriter.Write(jsonRequest);
            }

            HttpWebResponse response = (HttpWebResponse)req.GetResponse();

            string json = String.Empty;

            using (StreamReader sr = new StreamReader(response.GetResponseStream()))
            {
                json = sr.ReadToEnd();
            }

            ResultCertificate listCertificate = JsonConvert.DeserializeObject<ResultCertificate>(json);

            return listCertificate;            
        }

        /// <summary>
        /// Метод обновляет спавочник локаций(Регион и город)
        /// </summary>
        /// <param name="key"></param>
        public void RefreshCatalog(string key)
        {
            List<S> listS = new List<S>();
            listS.Add(new S { n = "ВидДеятельности", t = "Строка" });
            listS.Add(new S { n = "ИскатьВФилиалах", t = "Логическое" });
            listS.Add(new S { n = "Состояние", t = "Строка" });

            var query = new SearchQuery();
            query.jsonrpc = "2.0";
            query.protocol = 4;
            query.method = "ГородРегиона.СписокРегионов";
            var filter = new Фильтр
            {
                d = new List<object> { "1700000000", true, "1" },
                s = listS
            };
            query.@params = new @params
            {
                ДопПоля = new List<object>(),
                Фильтр = filter,
                Сортировка = null,
                Навигация = null
            };
            query.id = 0;

            string jsonRequest = JsonConvert.SerializeObject(query, Formatting.Indented, new JsonSerializerSettings { });


            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create("https://online.sbis.ru/service/?srv=1");
            req.ContentType = "application/json; charset=utf-8";
            req.Method = WebRequestMethods.Http.Post;
            req.Headers["X-SBISSessionID"] = key;

            using (var streamWriter = new StreamWriter(req.GetRequestStream()))
            {
                streamWriter.Write(jsonRequest);
            }

            HttpWebResponse response = (HttpWebResponse)req.GetResponse();

            string json = String.Empty;

            using (StreamReader sr = new StreamReader(response.GetResponseStream()))
            {
                json = sr.ReadToEnd();
            }

            string path = "Data/Location.json";

            using (StreamWriter sw = new StreamWriter(path, false, Encoding.UTF8))
            {
                sw.WriteLine(json);
            }
        }


        /// <summary>
        /// Метод получает информцию об соучеридителях.
        /// </summary>
        public ResultFounder GetOverride(int id_spp, string key)
        {
            string query = "{\"jsonrpc\":\"2.0\",\"protocol\":4,\"method\":\"Контрагент.УчредительСписокСИсторией\",\"params\":{\"ДопПоля\":[],\"Фильтр\":{\"d\":[\"" + id_spp + "\",true],\"s\":[{\"n\":\"Лицо\",\"t\":\"Строка\"},{\"n\":\"УставныйКапитал\",\"t\":\"Логическое\"}]},\"Сортировка\":null,\"Навигация\":{\"s\":[{\"n\":\"Страница\",\"t\":\"Число целое\"},{\"n\":\"РазмерСтраницы\",\"t\":\"Число целое\"},{\"n\":\"ЕстьЕще\",\"t\":\"Логическое\"}],\"d\":[0,11,false]}},\"id\":1}";

            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create("https://online.sbis.ru/service/?srv=1");
            req.ContentType = "application/json; charset=utf-8";
            req.Method = WebRequestMethods.Http.Post;
            req.Headers["X-SBISSessionID"] = key;

            using (var streamWriter = new StreamWriter(req.GetRequestStream()))
            {
                streamWriter.Write(query);
            }

            HttpWebResponse response = (HttpWebResponse)req.GetResponse();

            string json = String.Empty;

            using (StreamReader sr = new StreamReader(response.GetResponseStream()))
            {
                json = sr.ReadToEnd();
            }

            ResultFounder listFounder = JsonConvert.DeserializeObject<ResultFounder>(json);

            return listFounder;
        }
        /// <summary>
        /// Метод обновляет список "Вид деятельности" 
        /// </summary>
        /// <param name="key"></param>
        public void RefreshActivity(string key)
        {
            List<S> listS = new List<S>();
            listS.Add(new S { n = "ВидДеятельности", t = "Строка" });
            listS.Add(new S { n = "ИскатьВФилиалах", t = "Логическое" });
            listS.Add(new S { n = "Состояние", t = "Строка" });

            var query = new SearchQuery();
            query.jsonrpc = "2.0";
            query.protocol = 4;
            query.method = "ВидДеятельности.СписокКоличество";
            var filter = new Фильтр
            {
                d = new List<object> { "1700000000", true, "1" },
                s = listS
            };
            query.@params = new @params
            {
                ДопПоля = new List<object>(),
                Фильтр = filter,
                Сортировка = null,
                Навигация = null
            };
            query.id = 0;

            string jsonRequest = JsonConvert.SerializeObject(query, Formatting.Indented, new JsonSerializerSettings { });

            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create("https://online.sbis.ru/service/?srv=1");
            req.ContentType = "application/json; charset=utf-8";
            req.Method = WebRequestMethods.Http.Post;
            req.Headers["X-SBISSessionID"] = key;

            using (var streamWriter = new StreamWriter(req.GetRequestStream()))
            {
                streamWriter.Write(jsonRequest);
            }

            HttpWebResponse response = (HttpWebResponse)req.GetResponse();

            string json = String.Empty;

            using (StreamReader sr = new StreamReader(response.GetResponseStream()))
            {
                json = sr.ReadToEnd();
            }

            string path = "Data/Activity.json";

            using (StreamWriter sw = new StreamWriter(path, false, Encoding.UTF8))
            {
                sw.WriteLine(json);
            }
        }
        public RootOKVDRasdel GetOKVDRasdel(string key)
        {
            List<S> listS = new List<S>();
            listS.Add(new S { n = "count", t = "Логическое" });


            var query = new SearchQuery();
            query.jsonrpc = "2.0";
            query.protocol = 4;
            query.method = "ОКВЭД.ListSelect";
            var filter = new Фильтр
            {
                d = new List<object> { true },
                s = listS
            };
            query.@params = new @params
            {
                ДопПоля = new List<object>(),
                Фильтр = filter,
                Сортировка = null,
                Навигация = null
            };
            query.id = 1;

            string jsonRequest = JsonConvert.SerializeObject(query, Formatting.Indented, new JsonSerializerSettings { });

            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create("https://online.sbis.ru/service/?srv=1");
            req.ContentType = "application/json; charset=utf-8";
            req.Method = WebRequestMethods.Http.Post;
            req.Headers["X-SBISSessionID"] = key;

            using (var streamWriter = new StreamWriter(req.GetRequestStream()))
            {
                streamWriter.Write(jsonRequest);
            }

            HttpWebResponse response = (HttpWebResponse)req.GetResponse();

            string json = String.Empty;

            using (StreamReader sr = new StreamReader(response.GetResponseStream()))
            {
                json = sr.ReadToEnd();
            }

            RootOKVDRasdel listOKVDRazdel = JsonConvert.DeserializeObject<RootOKVDRasdel>(json);

            return listOKVDRazdel;
        }

        public RootOKVDRasdel GetOKVD(string key, int rasdel)
        {
            List<S> listS = new List<S>();
            listS.Add(new S { n = "count", t = "Логическое" });
            listS.Add(new S { n = "Раздел", t = "Строка" });

            var query = new SearchQuery();
            query.jsonrpc = "2.0";
            query.protocol = 4;
            query.method = "ОКВЭД.ListSelect";
            var filter = new Фильтр
            {
                d = new List<object> { true, rasdel },
                s = listS
            };
            query.@params = new @params
            {
                ДопПоля = new List<object>(),
                Фильтр = filter,
                Сортировка = null,
                Навигация = null
            };
            query.id = 1;

            string jsonRequest = JsonConvert.SerializeObject(query, Formatting.Indented, new JsonSerializerSettings { });

            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create("https://online.sbis.ru/service/");
            req.ContentType = "application/json; charset=utf-8";
            req.Method = WebRequestMethods.Http.Post;
            req.Headers["X-SBISSessionID"] = key;

            using (var streamWriter = new StreamWriter(req.GetRequestStream()))
            {
                streamWriter.Write(jsonRequest);
            }

            HttpWebResponse response = (HttpWebResponse)req.GetResponse();

            string json = String.Empty;

            using (StreamReader sr = new StreamReader(response.GetResponseStream()))
            {
                json = sr.ReadToEnd();
            }

            RootOKVDRasdel listOKVD = JsonConvert.DeserializeObject<RootOKVDRasdel>(json);

            return listOKVD;
        }

    }

    public class AuthRequest
    {
        public string jsonrpc { get; set; }
        public string method { get; set; }
        public AuthParams @params { get; set; }
        public int id { get; set; }
    }

    public class AuthParams
    {
        public string Логин { get; set; }
        public string Пароль { get; set; }
    }


    public class AuthResultObject
    {
        public string jsonrpc { get; set; }
        public string result { get; set; }
        public int id { get; set; }
    }

    //Модели для полуения данных

    public class Фильтр
    {
        public List<object> d { get; set; }
        public List<S> s { get; set; }
    }

    public class @params
    {
        //public int ИдСПП { get; set; }
        //public string ИдЛок { get; set; }
        //public string ИП { get; set; }
        //public string Регламент { get; set; }

        public List<object> ДопПоля { get; set; }
        public Фильтр Фильтр { get; set; }
        public Сортировка Сортировка { get; set; }
        public Навигация Навигация { get; set; }      
    }

    public class SearchQuery
    {
        public string jsonrpc { get; set; }
        public int protocol { get; set; }
        public string method { get; set; }
        public @params @params { get; set; }
        public int id { get; set; }
    }
    public class S
    {
        public string n { get; set; }
        public string t { get; set; }
    }

    public class S2
    {
        public string n { get; set; }
        public string t { get; set; }
    }

    public class Сортировка
    {
        public List<S2> s { get; set; }
        public List<object> d { get; set; }
    }

    public class S3
    {
        public string n { get; set; }
        public string t { get; set; }
    }

    public class Навигация
    {
        public List<S3> s { get; set; }
        public List<object> d { get; set; }
    }



}
