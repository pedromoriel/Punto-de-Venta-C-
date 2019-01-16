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
    public class Productos
    {
        [BsonIgnoreIfNull]
        [BsonIgnoreIfDefault]
        public ObjectId _id { get; set; }

        [BsonIgnoreIfNull]
        [BsonIgnoreIfDefault]
        public int codigo { get; set; }

        [BsonIgnoreIfNull]
        [BsonIgnoreIfDefault]
        public string tipo { get; set; }

        [BsonIgnoreIfNull]
        [BsonIgnoreIfDefault]
        public double precio { get; set; }

        [BsonIgnoreIfNull]
        [BsonIgnoreIfDefault]
        public double existencia { get; set; }

        public Productos(int codigo,string tipo,double precio, double existencia)
        {
            this.codigo = codigo;
            this.tipo = tipo;
            this.precio = precio;
            this.existencia = existencia;
        }
    }
}
