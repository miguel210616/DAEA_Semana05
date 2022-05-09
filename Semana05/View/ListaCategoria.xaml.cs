﻿using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
using Semana05.ViewModel;

namespace Semana05.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ListaCategoria : Window
    {
        ListaCategoriaViewModel viewModel;
        public ListaCategoria()
        {
            InitializeComponent();
            viewModel = new ListaCategoriaViewModel();
            this.DataContext = viewModel;
        }

        private void BtnConsultar_Click(object sender, RoutedEventArgs e)
        {
            Cargar();
        }

        private void Cargar()
        {
            BCategoria Bcategoria = null;
            try
            {
                Bcategoria = new BCategoria();
                dgvCategoria.ItemsSource = Bcategoria.Listar(0);
            }
            catch(Exception)
            {
                MessageBox.Show("Comunicarse con el Administrador");
            }
            finally
            {
                Bcategoria = null;
            }
        }

        private void BtnNuevo_Click(object sender, RoutedEventArgs e)
        {
            ManCategoria manCategoria = new ManCategoria();
            manCategoria.ShowDialog();
            Cargar();
        }

        //private void DgvCategoria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    int idCategoria;
        //    var item = (Categoria)dgvCategoria.SelectedItem;
        //    if (null == item) return;
        //    idCategoria = Convert.ToInt32(item.IdCategoria);
        //    ManCategoria manCategoria = new ManCategoria();
        //    manCategoria.ShowDialog();
        //    Cargar();
        //}        //private void DgvCategoria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    int idCategoria;
        //    var item = (Categoria)dgvCategoria.SelectedItem;
        //    if (null == item) return;
        //    idCategoria = Convert.ToInt32(item.IdCategoria);
        //    ManCategoria manCategoria = new ManCategoria();
        //    manCategoria.ShowDialog();
        //    Cargar();
        //}
    }
}
