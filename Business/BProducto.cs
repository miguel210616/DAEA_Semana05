using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Entity;

namespace Business
{
    public class BProducto
    {
        private DProducto dProducto = null;

        public List<Producto> Listar(int IdProducto)
        {
            List<Producto> productos = null;
            try
            {
                dProducto = new DProducto();
                productos = dProducto.Listar(new Producto { IdProducto = IdProducto });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
            return productos;
        }

        public bool Insertar(Producto producto)
        {
            bool result = true;
            try
            {
                dProducto = new DProducto();
                dProducto.Insertar(producto);
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

        public bool Actualizar(Producto producto)
        {
            bool result = true;
            try
            {
                dProducto = new DProducto();
                dProducto.Actualizar(producto);
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

        public bool Eliminar(int IdProducto)
        {
            bool result = true;
            try
            {
                dProducto = new DProducto();
                dProducto.Eliminar(IdProducto);
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }


    }
}
