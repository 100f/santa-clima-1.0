using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantaClima
{
    [BsonIgnoreExtraElements]
    class WeatherStationModel
    {
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        [BsonElement("createdAt")]
        public DateTime DataDeCriacao { get; set; }
        public double DirecaoDoVento { get; set; }
        public double VelocidadeDoVento { get; set; }
        public double Precipitacao { get; set; }
        public double Temperatura { get; set; }
        public double Umidade { get; set; }
        public double PressaoAtmosferica { get; set; }
    }
}
