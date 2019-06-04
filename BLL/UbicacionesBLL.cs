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
    public class UbicacionesBLL
    {
        public static bool Guardar(Ubicaciones ubicacion)
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

        public static bool Modificar(Ubicaciones ubicacion)
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
                Ubicaciones ubicacion = contexto.Ubicaciones.Find(id);

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

        public static Ubicaciones Buscar(int id)
        {
            Contexto db = new Contexto();
            Ubicaciones ubicacion = new Ubicaciones();
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
        public static List<Ubicaciones> GetList(Expression<Func<Ubicaciones, bool>> ubicacion)
        {
            List<Ubicaciones> Lista = new List<Ubicaciones>();
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
