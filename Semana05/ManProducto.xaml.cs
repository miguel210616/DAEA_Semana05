using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Business;
using Entity;

namespace Semana05
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ManProducto : Window
    {
        public int ID { get; set; }
        public ManProducto(int Id)
        {
            InitializeComponent();
            ID = Id;
            if (ID > 0)
            {
                BProducto bProducto = new BProducto();
                List<Producto> productos = new List<Producto>();
                productos = bProducto.Listar(ID);
                if (productos.Count > 0)
                {
                    txtId.Text = productos[0].IdCategoria.ToString();
                    txtNombreProducto.Text = productos[0].NombreProducto.ToString();
                    txtIdCategoria.Text = productos[0].IdCategoria.ToString();
                    txtIdProveedor.Text = productos[0].IdProveedor.ToString();
                    txtCantidadPorUnidad.Text = productos[0].CantidadPorUnidad.ToString();
                    txtPrecioUnidad.Text = productos[0].PrecioUnidad.ToString();
                    txtUnidadesEnExistencia.Text = productos[0].UnidadesEnExistencia.ToString();
                    txtUnidadesEnPedido.Text = productos[0].UnidadesEnPedido.ToString();
                    txtNivelNuevoPedido.Text = productos[0].NivelNuevoPedido.ToString();
                    txtSuspendido.Text = productos[0].Suspendido.ToString();
                    txtCategoriaProducto.Text = productos[0].CategoriaProducto.ToString();
                }
            }
        }

        private void BtnGrabar_Click(object sender, RoutedEventArgs e)
        {
            BProducto bProducto = null;
            bool result = true;
            try
            {
                bProducto = new BProducto();
                if (ID > 0)
                {
                    result = bProducto.Actualizar(new Producto { 
                        IdProducto = ID, 
                        NombreProducto = txtNombreProducto.Text, 
                        IdProveedor = Convert.ToInt32(txtIdProveedor.Text),
                        IdCategoria = Convert.ToInt32(txtIdCategoria.Text),
                        CantidadPorUnidad = txtCantidadPorUnidad.Text,
                        PrecioUnidad = Convert.ToInt32(txtPrecioUnidad.Text),
                        UnidadesEnExistencia = Convert.ToInt32(txtUnidadesEnExistencia.Text),
                        UnidadesEnPedido = Convert.ToInt32(txtUnidadesEnPedido.Text),
                        NivelNuevoPedido = Convert.ToInt32(txtNivelNuevoPedido.Text),
                        Suspendido = Convert.ToInt32(txtSuspendido.Text),
                        CategoriaProducto = txtCategoriaProducto.Text,
                    });
                }
                else
                    result = bProducto.Insertar(new Producto
                    {
                        IdProducto = ID,
                        NombreProducto = txtNombreProducto.Text,
                        IdProveedor = Convert.ToInt32(txtIdProveedor.Text),
                        IdCategoria = Convert.ToInt32(txtIdCategoria.Text),
                        CantidadPorUnidad = txtCantidadPorUnidad.Text,
                        PrecioUnidad = Convert.ToInt32(txtPrecioUnidad.Text),
                        UnidadesEnExistencia = Convert.ToInt32(txtUnidadesEnExistencia.Text),
                        UnidadesEnPedido = Convert.ToInt32(txtUnidadesEnPedido.Text),
                        NivelNuevoPedido = Convert.ToInt32(txtNivelNuevoPedido.Text),
                        Suspendido = Convert.ToInt32(txtSuspendido.Text),
                        CategoriaProducto = txtCategoriaProducto.Text,
                    });
                if (!result)
                {
                    MessageBox.Show("Comunicarse con el administrador  !");
                }
                Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Comunicarse con el administrador");
            }
            finally
            {
                bProducto = null;
            }
        }

        private void BtnCerrar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            BProducto bProducto = null;
            bool result = true;
            try
            {
                bProducto = new BProducto();
                if (ID > 0)
                {
                    result = bProducto.Eliminar(ID);
                }
                if (result)
                {
                    Close();
                }
                else
                {
                    MessageBox.Show("Comunicarse con el administrador -- problemas para eliminar");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Comunicarse con el administrador");
            }
        }
    }
}
