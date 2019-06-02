using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntregaParcialUno.DAL;
using EntregaParcialUno.Entidades;
using System.Data.Entity;
using System.Linq.Expressions;

namespace EntregaParcialUno.BLL
{
    public class ProductosBLL
    {
        public static bool Guardar(productos producto)
        {
            bool paso = false;

            Contexto db = new Contexto();
            try
            {
                if (db.Producto.Add(producto) != null)
                    paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }
    }
}
