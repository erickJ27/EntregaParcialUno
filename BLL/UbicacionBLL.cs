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
    public class UbicacionBLL
    {
        public static bool Guardar(Ubicacion ubicacion)
        {
            bool paso = false;

            Contexto db = new Contexto();
            try
            {
                if (db.Ubicaciones.Add(ubicacion) != null)
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

        public static bool Modificar(Ubicacion ubicacion)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(ubicacion).State = EntityState.Modified;
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
            Contexto contexto = new Contexto();
            try
            {
                Ubicacion ubicacion = contexto.Ubicaciones.Find(id);

                contexto.Ubicaciones.Remove(ubicacion);

                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public static Ubicacion Buscar(int id)
        {
            Contexto db = new Contexto();
            Ubicacion ubicacion = new Ubicacion();
            try
            {
                ubicacion = db.Ubicaciones.Find(id);
            }
            catch
            {
                throw;

            }
            finally
            {
                db.Dispose();
            }
            return ubicacion;
        }
        public static List<Ubicacion> GetList(Expression<Func<Ubicacion, bool>> ubicacion)
        {
            List<Ubicacion> Lista = new List<Ubicacion>();
            Contexto db = new Contexto();

            try
            {
                Lista = db.Ubicaciones.Where(ubicacion).ToList();
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
