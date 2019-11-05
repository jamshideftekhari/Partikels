using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;

namespace Measurements2018.Models
{
    public class AirData2018Context
    {
        public IMongoDatabase MongoDB;

        public AirData2018Context()
        {
            var Client = new MongoClient();
            MongoDB = Client.GetDatabase("AirData2018");
            var Collection = MongoDB.GetCollection<Measurement>("MeasurmentResultF2018");

        }
        public IMongoCollection<Measurement> Measurements
        {
            get { return MongoDB.GetCollection<Measurement>("MeasurmentResultF2018"); }
        }
    }
}