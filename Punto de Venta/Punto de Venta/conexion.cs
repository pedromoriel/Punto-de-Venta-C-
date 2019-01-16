using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.Linq;


namespace Punto_de_Venta
{
    public class conexion
    {
        public string dbName = "nuecera";
        public MongoClient mongod = new MongoClient();
    }
}
