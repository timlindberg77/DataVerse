using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
namespace DataVerse_Manager.Classes
{ 
        // Beskriver vilken sorts arbete ett yrke är
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum WorkType
        {
            Physical,    // fysiska yrken, till exempel lagerarbetare
            NonPhysical, // icke fysiska yrken, till exempel systemutvecklare
            Mixed        // blandade yrken, till exempel lärare
        }
}
