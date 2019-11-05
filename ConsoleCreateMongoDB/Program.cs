using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using MongoDB.Driver;

namespace ConsoleCreateMongoDB
{
    class Program
    {
        static void Main(string[] args)
        {
           // Xml2MongoDoc();
            //XmlMeasure2018MongoDoc();
            XmlMeasure2018MongoDoc_2();
        }

        private static void XmlMeasure2018MongoDoc_2()
        {
            MongoDataContext2 ctx = new MongoDataContext2();
            MeasurmentResaultF2019 AirDataResult = new MeasurmentResaultF2019();
            XmlReader lvsXmlReader = XmlReader.Create("../../XML_Measurements2019.xml");
            int i = 0;

            while (lvsXmlReader.Read())
            {
                if (lvsXmlReader.NodeType == XmlNodeType.Element)
                {
                    if (lvsXmlReader.Name == "datoMaerke")
                    {
                        AirDataResult.TimeStamp = lvsXmlReader.ReadElementContentAsDateTime();
                    }
                    if (lvsXmlReader.Name == "Resultat")
                    {
                        AirDataResult.Result = lvsXmlReader.ReadElementContentAsFloat();
                    }
                    if (lvsXmlReader.Name == "Unit")
                    {
                        AirDataResult.Unit = lvsXmlReader.ReadElementContentAsString();
                    }
                    if (lvsXmlReader.Name == "StofNavn")
                    {
                        AirDataResult.StuffName = lvsXmlReader.ReadElementContentAsString();
                    }
                    if (lvsXmlReader.Name == "kode")
                    {
                        AirDataResult.PlaceCode = lvsXmlReader.ReadElementContentAsString();
                    }
                    if (lvsXmlReader.Name == "Navn")
                    {
                        AirDataResult.PlaceName = lvsXmlReader.ReadElementContentAsString();
                        ctx.MeasurmentResultF2019s.InsertOne(AirDataResult);
                    }
                }

                i++;
                Console.WriteLine(i);
            }
            Console.WriteLine(i);
            Console.ReadLine();

        }

        private static void XmlMeasure2018MongoDoc()
        {
            MongoDataContext2 ctx = new MongoDataContext2();
            MeasurmentResaultF2019 AirDataResult = new MeasurmentResaultF2019();
            XmlReader lvsXmlReader = XmlReader.Create("../../XML_Measurements2019.xml");
            int i = 0;

            while (lvsXmlReader.Read())
            {
                if (lvsXmlReader.NodeType == XmlNodeType.Element)
                {
                    if (lvsXmlReader.Name == "datoMaerke")
                    {
                        AirDataResult.TimeStamp = lvsXmlReader.ReadElementContentAsDateTime();
                    }
                    if (lvsXmlReader.Name == "Resultat")
                    {
                        AirDataResult.Result = lvsXmlReader.ReadElementContentAsFloat();
                    }
                    if (lvsXmlReader.Name == "Unit")
                    {
                        AirDataResult.Unit = lvsXmlReader.ReadElementContentAsString();
                    }
                    if (lvsXmlReader.Name == "StofNavn")
                    {
                        AirDataResult.StuffName = lvsXmlReader.ReadElementContentAsString();
                    }
                    if (lvsXmlReader.Name == "kode")
                    {
                        AirDataResult.PlaceCode = lvsXmlReader.ReadElementContentAsString();
                    }
                    if (lvsXmlReader.Name == "Navn")
                    {
                        AirDataResult.PlaceName = lvsXmlReader.ReadElementContentAsString();
                        ctx.MeasurmentResultF2019s.InsertOne(AirDataResult);
                    }
                }

                i++;
                Console.WriteLine(i);
            }
            Console.WriteLine(i);
            Console.ReadLine();
        }



    private static void Xml2MongoDoc()
        {
            MongoDataContext ctx = new MongoDataContext();
            LvsMeasurmentResault lvsMeasurmentResault = new LvsMeasurmentResault();
            XmlReader lvsXmlReader = XmlReader.Create("../../LVS.xml");
            int i = 0;

            while (lvsXmlReader.Read())
            {
                if (lvsXmlReader.NodeType == XmlNodeType.Element)
                {
                    if (lvsXmlReader.Name == "MaalestedId")
                    {
                        lvsMeasurmentResault.PlaceId = lvsXmlReader.ReadElementContentAsString();
                    }
                    if (lvsXmlReader.Name == "Maalested")
                    {
                        lvsMeasurmentResault.Place = lvsXmlReader.ReadElementContentAsString();
                    }
                    if (lvsXmlReader.Name == "DatoMaerke")
                    {
                        lvsMeasurmentResault.TimeStamp = lvsXmlReader.ReadElementContentAsDateTime();
                    }
                    if (lvsXmlReader.Name == "StofId")
                    {
                        lvsMeasurmentResault.StuffId = lvsXmlReader.ReadElementContentAsString();
                    }
                    if (lvsXmlReader.Name == "StofNavn")
                    {
                        lvsMeasurmentResault.StuffName = lvsXmlReader.ReadElementContentAsString();
                    }
                    if (lvsXmlReader.Name == "EnhedId")
                    {
                        lvsMeasurmentResault.UnitId = lvsXmlReader.ReadElementContentAsString();
                    }
                    if (lvsXmlReader.Name == "Enhed")
                    {
                        lvsMeasurmentResault.UnitValue = lvsXmlReader.ReadElementContentAsString();
                    }
                    if (lvsXmlReader.Name == "Resultat")
                    {
                        lvsMeasurmentResault.Result = lvsXmlReader.ReadElementContentAsFloat();
                    }
                    if (lvsXmlReader.Name == "UdstyrId")
                    {
                        lvsMeasurmentResault.EquipmentId = lvsXmlReader.ReadElementContentAsString();
                    }
                    if (lvsXmlReader.Name == "Navn")
                    {
                        lvsMeasurmentResault.EquipmentName = lvsXmlReader.ReadElementContentAsString();
                        ctx.LvsMeasurmentResaults.InsertOne(lvsMeasurmentResault);
                    }
                }
               
                i++;
            }
            Console.WriteLine(i);
            Console.ReadLine();
        }
    }

 

    public class MongoDataContext
    {
        protected static IMongoDatabase MongoDb;


        public MongoDataContext()
        {
            var client = new MongoClient();
            MongoDb = client.GetDatabase("LvsData");
            var Collection = MongoDb.GetCollection<LvsMeasurmentResault>("LvsMeasurmentResaults");
        }

        public IMongoCollection<LvsMeasurmentResault> LvsMeasurmentResaults
        {
            get { return MongoDb.GetCollection<LvsMeasurmentResault>("LvsMeasurmentResault"); }
        }


    }

    public class MongoDataContext2
    {
        protected static IMongoDatabase MongoDb;


        public MongoDataContext2()
        {
            var client = new MongoClient();
            MongoDb = client.GetDatabase("AirData2018");
            var Collection = MongoDb.GetCollection<MeasurmentResaultF2019>("MeasurmentResultF2018s");
        }

        public IMongoCollection<MeasurmentResaultF2019> MeasurmentResultF2019s
        {
            get { return MongoDb.GetCollection<MeasurmentResaultF2019>("MeasurmentResultF2018"); }
        }


    }

    public class LvsMeasurmentResault
    {
        public string PlaceId { get; set; }
        public string Place { get; set; }
        public DateTime TimeStamp { get; set; }
        public string StuffId { get; set; }
        public string StuffName { get; set; }
        public string UnitId { get; set; }
        public string UnitValue { get; set; }
        public float Result { get; set; }
        public string EquipmentId { get; set; }
        public string EquipmentName { get; set; }


    }

    public class MeasurmentResaultF2019
    {
        public DateTime TimeStamp { get; set; }
        public string StuffName { get; set; }
        public float Result { get; set; }
        public string Unit { get; set; }
        public string PlaceCode { get; set; }
        public string PlaceName { get; set; }
    }

    public class Ozon_2018
    {
        public DateTime TimeStamp { get; set; }
        public string StuffName { get; set; }
        public float Result { get; set; }
        public string Unit { get; set; }
        public string PlaceCode { get; set; }
        public string PlaceName { get; set; }
    }
}
