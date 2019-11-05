using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;

namespace Measurements2018.Models
{
    public class Measurement
    {
        public ObjectId Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public string StuffName { get; set; }
        public float Result { get; set; }
        public string Unit { get; set; }
        public string PlaceCode { get; set; }
        public string PlaceName { get; set; }
    }
}