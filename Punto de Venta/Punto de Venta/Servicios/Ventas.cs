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
using System.Data;
using Punto_de_Venta.Servicios;
using Punto_de_Venta.Modelos_Entidad;
using System.Globalization;

namespace Punto_de_Venta.Servicios
{
    public class Ventas
    {
        public conexion con = new conexion();
        public Productos prod;
        public ventasME venta;
        public ComprasME compra;

        public IMongoCollection<Productos> GetProductos()
        {
            IMongoDatabase db = con.mongod.GetDatabase(con.dbName);
            IMongoCollection<Productos> col = db.GetCollection<Productos>("productos");
            return col;
        }
        public IMongoCollection<ComprasME> GetCompras()
        {
            IMongoDatabase db = con.mongod.GetDatabase(con.dbName);
            IMongoCollection<ComprasME> col = db.GetCollection<ComprasME>("compras");
            return col;
        }
        public IMongoCollection<ventasME> GetVentas()
        {
            IMongoDatabase db = con.mongod.GetDatabase(con.dbName);
            IMongoCollection<ventasME> col = db.GetCollection<ventasME>("ventas");
            return col;
        }        
    }

    public class VentasServices : Ventas
    {
        public object[,] BuscarProducto(int codigo)
        {
            var collection = GetProductos();
            var query = from document in collection.AsQueryable<Productos>()
                        where document.codigo == codigo
                        select document;
            object[,] producto = new object[query.Count(),3];
            int i = 0;
            foreach (Productos pro in query)
            {                
                producto[i,0] = pro.codigo;
                producto[i,1] = pro.tipo;
                producto[i,2] = pro.precio;
                
                i++;
            }
            return producto;
        }
        public object[,] Productos()
        {
            var collection = GetProductos();
            var query = from document in collection.AsQueryable<Productos>()                        
                        select document;
            object[,] producto = new object[query.Count(), 3];
            int i = 0;
            foreach (Productos pro in query)
            {
                producto[i, 0] = pro.codigo;
                producto[i, 1] = pro.tipo;
                producto[i, 2] = pro.precio;

                i++;
            }
            return producto;
        }
        public bool GuardarCompra(int codigo,double total,DateTime fecha)
        {
            bool done = true;
            try
            {
                compra = new ComprasME(codigo, total, fecha);
                var collection = GetCompras();
                collection.InsertOne(compra);
            }
            catch
            {
                done = false;
            }
            return done;
        }
        public int NumeroCompra()
        {

            var collection = GetCompras();
            var query = (from document in collection.AsQueryable<ComprasME>()
                        orderby document.codigo descending
                        select document).Take(1);
            int num=1;            
            foreach (ComprasME com in query)
            {
                num = com.codigo+1;

            }                
            return num;
                                   
        }
        public bool GuardarVenta(int codigo, double total, DateTime fecha)
        {
            bool done = true;
            try
            {
                venta = new ventasME(codigo, total, fecha);
                var collection = GetVentas();
                collection.InsertOne(venta);
            }
            catch
            {
                done = false;
            }
            return done;
        }
        public int NumeroVenta()
        {

            var collection = GetVentas();
            var query = (from document in collection.AsQueryable<ventasME>()
                         orderby document.codigo descending
                         select document).Take(1);
            int num = 1;
            foreach (ventasME ven in query)
            {
                num = ven.codigo + 1;

            }
            return num;

        }
        public object[,] BuscarVentas()
        {
            var collection =GetVentas();
            var query = from document in collection.AsQueryable<ventasME>()
                        orderby document.codigo descending
                        select document;
            object[,] obj = new object[query.Count(),3];
            int i = 0;
            foreach(ventasME ob in query)
            {
                obj[0,0] = ob.codigo;
                obj[1,1] = ob.total;
                obj[2,2] = ob.fecha;
                i++;
            }
            return obj;
        }
        /*public object[] AgregarProducto(int codigo,string nombre,string unidad,double precio)
        {
            
            try
            {
                prod = new Productos(codigo, nombre, unidad, precio);
                var collection = GetProductos();
                collection.InsertOne(prod);
            }
            catch
            {
                
            }            
        }*/
    }
}
