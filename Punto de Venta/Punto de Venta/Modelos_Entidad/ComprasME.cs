using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace Punto_de_Venta.Modelos_Entidad
{
    public class ComprasME
    {
        [BsonIgnoreIfNull]
        [BsonIgnoreIfDefault]
        public ObjectId _id { get; set; }

        [BsonIgnoreIfNull]
        [BsonIgnoreIfDefault]
        public int codigo { get; set; }       

        [BsonIgnoreIfNull]
        [BsonIgnoreIfDefault]
        public double total { get; set; }

        [BsonIgnoreIfNull]
        [BsonIgnoreIfDefault]
        public DateTime fecha { get; set; }

        public ComprasME(int codigo, double total, DateTime fecha)
        {
            this.codigo = codigo;
            this.total = total;
            this.fecha = fecha;
        }
    }
}
