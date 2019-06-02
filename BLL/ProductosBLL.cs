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
        public static bool Guardar(Productos producto)
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

        public static bool Modificar(Productos producto)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(producto).State = EntityState.Modified;
                paso = (db.SaveChanges() > 0);
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
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                var eliminar = db.Producto.Find(id);

                paso = (db.SaveChanges() > 0);
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

        public static Productos Buscar(int id)
        {
            Contexto db = new Contexto();
            Productos producto = new Productos();
            try
            {
                producto = db.Producto.Find(id);
            }
            catch
            {
                throw;

            }
            finally
            {
                db.Dispose();
            }
            return producto;
        }
        public static List<Productos> GetList(Expression<Func<Productos, bool>> producto)
        {
            List<Productos> Lista = new List<Productos>();
            Contexto db = new Contexto();

            try
            {
                Lista = db.Producto.Where(producto).ToList();
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return Lista;
        }



    }
}
