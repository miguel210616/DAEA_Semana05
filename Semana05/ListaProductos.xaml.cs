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
    public partial class ListaProductos : Window
    {
        public ListaProductos()
        {
            InitializeComponent();
        }

        private void BtnConsultar_Click(object sender, RoutedEventArgs e)
        {
            Cargar();
        }

        private void Cargar()
        {
            BProducto bProducto = null;
            try
            {
                bProducto = new BProducto();
                dgvProducto.ItemsSource = bProducto.Listar(0);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Comunicarse con el Administrador !!!");
            }
            finally
            {
                bProducto = null;
            }
        }

        private void BtnNuevo_Click(object sender, RoutedEventArgs e)
        {
            ManProducto manProducto = new ManProducto(0);
            manProducto.ShowDialog();
            Cargar();
        }

        private void DgvCategoria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int idProducto;
            var item = (Producto)dgvProducto.SelectedItem;
            if (null == item) return;
            idProducto = Convert.ToInt32(item.IdProducto);
            ManProducto manProducto = new ManProducto(idProducto);
            manProducto.ShowDialog();
            Cargar();

        }
    }
}
