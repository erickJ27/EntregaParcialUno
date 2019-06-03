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
                if (db.ValorInventario.Add(valorinventario) != null)
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
        public static bool Modificar(ValorInventario valorinvetario)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(valorinvetario).State = EntityState.Modified;
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
      
        public static ValorInventario Buscar(int id)
        {
            Contexto db = new Contexto();
            ValorInventario valorinvetario = new ValorInventario();
            try
            {
                valorinvetario = db.ValorInventario.Find(id);
            }
            catch
            {
                throw;

            }
            finally
            {
                db.Dispose();
            }
            return valorinvetario;
        }
    }
}