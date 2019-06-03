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
    public class ValorInventarioBLL
    {
        public static bool Guardar(ValorInventario valorinventario)
        {
            bool paso = false;

            Contexto db = new Contexto();
            try
            {
                if (db.ValorInventarioC.Add(valorinventario) != null)
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
        public static List<ValorInventario> GetList(Expression<Func<ValorInventario, bool>> valorinventario)
        {
            List<ValorInventario> Lista = new List<ValorInventario>();
            Contexto db = new Contexto();

            try
            {
                Lista = db.ValorInventarioC.Where(valorinventario).ToList();
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
