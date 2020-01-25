using KBCsv;
using ParserSbis.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;

namespace ParserSbis.Utils
{
    public class XmlExecute
    {
        public bool WriteXmlDetailCompany(DataParsingItem company)
        {
            XmlDocument _doc = new XmlDocument();
            _doc.Load(@"Data/cache.xml");

            XmlNode find_idsp = _doc.SelectSingleNode(String.Format("id_sp[id='{0}']", company.IdSp));

            if (find_idsp == null)
            {
                XmlElement newCompany = _doc.CreateElement("CompanyTable");

                XmlElement id_sp = _doc.CreateElement("id_sp");
                id_sp.InnerText = company.IdSp ?? "-";
                newCompany.AppendChild(id_sp);

                XmlElement companyName = _doc.CreateElement("companyName");
                companyName.InnerText = company.CompanyName ?? "-";
                newCompany.AppendChild(companyName);

                XmlElement kindofactivity = _doc.CreateElement("kindofactivity");
                kindofactivity.InnerText = company.Kindofactivity ?? "-";
                newCompany.AppendChild(kindofactivity);

                XmlElement okevd = _doc.CreateElement("okevd");
                okevd.InnerText = company.Okevd ?? "-";
                newCompany.AppendChild(okevd);

                XmlElement all_okvd = _doc.CreateElement("all_okvd");
                all_okvd.InnerText = company.AllOkevd ?? "-";
                newCompany.AppendChild(all_okvd);

                XmlElement amountWorker = _doc.CreateElement("amountWorker");
                amountWorker.InnerText = company.AmountWorker ?? "-";
                newCompany.AppendChild(amountWorker);

                XmlElement city = _doc.CreateElement("city");
                city.InnerText = company.City ?? "-";
                newCompany.AppendChild(city);

                XmlElement adress = _doc.CreateElement("adress");
                adress.InnerText = company.Adress ?? "-";
                newCompany.AppendChild(adress);

                XmlElement index = _doc.CreateElement("index");
                index.InnerText = company.Index ?? "-";
                newCompany.AppendChild(index);

                XmlElement phone = _doc.CreateElement("phone");
                phone.InnerText = company.Phone ?? "-";
                newCompany.AppendChild(phone);

                XmlElement mail = _doc.CreateElement("mail");
                mail.InnerText = company.Mail ?? "-";
                newCompany.AppendChild(mail);

                XmlElement site = _doc.CreateElement("site");
                site.InnerText = company.Site ?? "-";
                newCompany.AppendChild(site);

                XmlElement revenue = _doc.CreateElement("revenue");
                revenue.InnerText = company.Revenue ?? "-";
                newCompany.AppendChild(revenue);

                XmlElement reliability = _doc.CreateElement("reliability");
                reliability.InnerText = company.Reliability ?? "-";
                newCompany.AppendChild(reliability);

                XmlElement inn = _doc.CreateElement("inn");
                inn.InnerText = company.Inn ?? "-";
                newCompany.AppendChild(inn);

                XmlElement kpp = _doc.CreateElement("kpp");
                kpp.InnerText = company.Kpp ?? "-";
                newCompany.AppendChild(kpp);

                XmlElement financial_analysis = _doc.CreateElement("financial_analysis");
                financial_analysis.InnerText = company.Financial_analysis ?? "-";
                newCompany.AppendChild(financial_analysis);

                XmlElement description = _doc.CreateElement("description");
                description.InnerText = company.Description ?? "-";
                newCompany.AppendChild(description);

                XmlElement dataRegistration = _doc.CreateElement("dataRegistration");
                dataRegistration.InnerText = company.DataRegistration ?? "-";
                newCompany.AppendChild(dataRegistration);

                XmlElement bik = _doc.CreateElement("bik");
                bik.InnerText = company.Bik ?? "-";
                newCompany.AppendChild(bik);

                XmlElement ogrn = _doc.CreateElement("ogrn");
                ogrn.InnerText = company.Ogrn ?? "-";
                newCompany.AppendChild(ogrn);

                XmlElement okpo = _doc.CreateElement("okpo");
                okpo.InnerText = company.Okpo ?? "-";
                newCompany.AppendChild(okpo);

                XmlElement bank = _doc.CreateElement("bank");
                bank.InnerText = company.Bank ?? "-";
                newCompany.AppendChild(bank);

                XmlElement property = _doc.CreateElement("property");
                property.InnerText = company.Property ?? "-";
                newCompany.AppendChild(property);

                XmlElement fax = _doc.CreateElement("fax");
                fax.InnerText = company.Fax ?? "-";
                newCompany.AppendChild(fax);

                XmlElement region = _doc.CreateElement("region");
                region.InnerText = company.Region ?? "-";
                newCompany.AppendChild(region);

                XmlElement genDirector = _doc.CreateElement("genDirector");
                genDirector.InnerText = company.GenDirector ?? "-";
                newCompany.AppendChild(genDirector);

                XmlElement founders = _doc.CreateElement("founders");
                founders.InnerText = company.Founders ?? "-";
                newCompany.AppendChild(founders);

                XmlElement certificate = _doc.CreateElement("certificate");
                certificate.InnerText = company.Certificate ?? "-";
                newCompany.AppendChild(certificate);

                _doc.DocumentElement.AppendChild(newCompany);
                _doc.Save(@"Data/cache.xml");

                return true;
            }

            return false;
        }

        public void DeleteIdSpXml(string id)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"Data/id_sp.xml");
            XmlNode root = doc.DocumentElement;
            XmlNode node = root.SelectSingleNode(
                String.Format("IdSpTable[id='{0}']",
                id));
            XmlNode outer = node.ParentNode;
            outer.RemoveChild(node);
            doc.Save(@"Data/id_sp.xml");
        }

        public void SaveXmlToCsv()
        {
            List<DataParsingItem> listObject = new List<DataParsingItem>();

            // Use this to connect to the actual data service
            //List<DataItem> item = new List<DataItem>();
            List<TaskObject> item = new List<TaskObject>();
            XmlDocument _doc = new XmlDocument();
            _doc.Load(@"Data/cache.xml");
            // получим корневой элемент
            XmlElement xRoot = _doc.DocumentElement;
            foreach (XmlNode xnode in xRoot)
            {
                string phone = String.Empty;
                string revenue = String.Empty;
                string founders = String.Empty;
                string reliability = String.Empty;
                string financial_analysis = String.Empty;
                string city = String.Empty;
                string companyName = String.Empty;
                string mail = String.Empty;
                string site = String.Empty;
                string reabilty = String.Empty;
                string inn = String.Empty;
                string amountWorker = String.Empty;//Количество работников
                string kpp = String.Empty;
                string dataRegistration = String.Empty;
                string adress = String.Empty;//Юридический Адрес
                string okvd = String.Empty;
                string all_okvd = String.Empty;//Все ОКВД
                string kindofactivity = String.Empty;
                string description = String.Empty;
                string revenues = String.Empty;//Выручка
                string index = String.Empty;
                string citys = String.Empty;
                string bik = String.Empty;
                string ogrn = String.Empty;
                string okpo = String.Empty;
                string bank = "-";
                string property = String.Empty;
                string fax = String.Empty;
                string region = String.Empty;
                string genDirector = String.Empty;
                string founderscsv = String.Empty;
                string certificatecsv = String.Empty;

                // обходим все дочерние узлы элемента user
                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    if (childnode.Name == "companyName")
                    {
                        companyName = childnode.InnerText;
                    }

                    if (childnode.Name == "kindofactivity")
                    {
                        kindofactivity = childnode.InnerText;
                    }

                    if (childnode.Name == "okevd")
                    {
                        okvd = childnode.InnerText;
                    }

                    if (childnode.Name == "all_okvd")
                    {
                        all_okvd = childnode.InnerText;
                    }

                    if (childnode.Name == "amountWorker")
                    {
                        amountWorker = childnode.InnerText;
                    }

                    if (childnode.Name == "city")
                    {
                        city = childnode.InnerText;
                    }

                    if (childnode.Name == "adress")
                    {
                        adress = childnode.InnerText;
                    }

                    if (childnode.Name == "index")
                    {
                        index = childnode.InnerText;
                    }

                    if (childnode.Name == "phone")
                    {
                        phone = childnode.InnerText;
                    }

                    if (childnode.Name == "mail")
                    {
                        mail = childnode.InnerText;
                    }

                    if (childnode.Name == "site")
                    {
                        site = childnode.InnerText;
                    }

                    if (childnode.Name == "revenue")
                    {
                        revenue = childnode.InnerText;
                    }


                    if (childnode.Name == "reliability")
                    {
                        reliability = childnode.InnerText;
                    }

                    if (childnode.Name == "inn")
                    {
                        inn = childnode.InnerText;
                    }
                    ///
                    if (childnode.Name == "kpp")
                    {
                        kpp = childnode.InnerText;
                    }

                    if (childnode.Name == "financial_analysis")
                    {
                        financial_analysis = childnode.InnerText;
                    }


                    if (childnode.Name == "dataRegistration")
                    {
                        dataRegistration = childnode.InnerText;
                    }

                    if (childnode.Name == "bik")
                    {
                        bik = childnode.InnerText;
                    }

                    if (childnode.Name == "ogrn")
                    {
                        ogrn = childnode.InnerText;
                    }

                    if (childnode.Name == "okpo")
                    {
                        okpo = childnode.InnerText;
                    }

                    if (childnode.Name == "bank")
                    {
                        bank = childnode.InnerText;
                    }

                    if (childnode.Name == "property")
                    {
                        property = childnode.InnerText;
                    }

                    if (childnode.Name == "fax")
                    {
                        fax = childnode.InnerText;
                    }
                    if (childnode.Name == "region")
                    {
                        region = childnode.InnerText;
                    }

                    if (childnode.Name == "genDirector")
                    {
                        genDirector = childnode.InnerText;
                    }

                    if (childnode.Name == "founders")
                    {
                        founderscsv = childnode.InnerText;
                    }

                    if (childnode.Name == "certificate")
                    {
                        certificatecsv = childnode.InnerText;
                    }
                }

                listObject.Add(new DataParsingItem("", companyName, kindofactivity, okvd, all_okvd, amountWorker, city, adress, index, phone, mail, site,
revenue.ToString(), reliability, inn, kpp, "Финансовый анализ", description, dataRegistration, bik, ogrn, okpo, bank, property, fax, region, genDirector, founderscsv, certificatecsv));

            }

            using (var streamWriter = new StreamWriter(@"Out/out.csv"))
            using (var writer = new CsvWriter(streamWriter))
            {
                writer.ForceDelimit = true;
                writer.ValueSeparator = ';';

                writer.WriteRecord("Наименование", "Вид деятельности", "Форма собственности", "ОГРН", "ОКПО", "Банк", "БИК", "Факс", "ОКЭВД", "Регион", "Город", "Численнность сотрудников",
                    "Ген. Директор", "Учредители", "Все ОКВЭД", "Адрес", "Индекс", "Телефон", "E-mail", "Сайт", "Выручка", "Надежность",
                    "ИНН", "КПП", "Дата регистраций", "Сертификаты");
                foreach (DataParsingItem items in listObject)
                {
                    writer.WriteRecord(items.CompanyName, items.Kindofactivity, items.Property, items.Ogrn, items.Okpo, items.Bank, items.Bik, items.Fax, items.Okevd, items.Region, items.City,
                            items.AmountWorker, items.GenDirector, items.Founders, items.AllOkevd, items.Adress, items.Index, items.Phone, items.Mail, items.Site, items.Revenue, items.Reliability,
                            items.Inn, items.Kpp, items.DataRegistration, items.Certificate);
                }
            }
            MessageBox.Show("Файл успешно записан");
        }
    }
}
