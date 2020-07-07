using _2doParcial.BLL;
using _2doParcial.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace _2doParcial.UI.Registros
{
    /// <summary>
    /// Interaction logic for rProyectos.xaml
    /// </summary>
    public partial class rProyectos : Window
    {
        private Proyectos Proyecto = new Proyectos();
        Tareas tarea;

        public rProyectos()
        {
            InitializeComponent();
            this.DataContext = Proyecto;

            //ComboBox            
            TipoTareaComboBox.SelectedValuePath = "Tareas";
            TipoTareaComboBox.DisplayMemberPath = "TipoTarea";
            TipoTareaComboBox.ItemsSource = TareasBLL.GetTareas();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Proyecto = ProyectosBLL.Buscar(int.Parse(ProyectoIdTextBox.Text));
            Cargar();
        }

        private void AgregarButton_Click(object sender, RoutedEventArgs e)
        {
            var detalle = new ProyectosDetalle
            {
                ProyectoId = int.Parse(ProyectoIdTextBox.Text),
                TipoId = tarea.TareaId,
                Tarea = tarea,
                Requerimiento = RequerimientoTextBox.Text,
                TiempoMinutos = int.Parse(TiempoTextBox.Text)
            };

            Cargar();
            Proyecto.ProyectoDetalles.Add(detalle);
            TipoTareaComboBox.SelectedIndex = -1;
            RequerimientoTextBox.Clear();
            TiempoTextBox.Clear();
            RequerimientoTextBox.Focus();
        }

        private void RemoverButton_Click(object sender, RoutedEventArgs e)
        {
            if (DetalleDataGrid.SelectedIndex < 0)
                return;

            Proyecto.ProyectoDetalles.RemoveAt(DetalleDataGrid.SelectedIndex);

            Cargar();
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProyectosBLL.Guardar(Proyecto))
            {
                Limpiar();
                MessageBox.Show("Se ha guardado.", "Exito.", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No fue posible guardar.", "Error.", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProyectosBLL.Eliminar(int.Parse(ProyectoIdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Se ha eliminado.", "Exito.", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No fue posible eliminar.", "Error.", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TipoTareaComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tarea = ((Tareas)TipoTareaComboBox.SelectedItem);
        }

        public void Cargar()
        {
            this.DataContext = null;
            this.DataContext = Proyecto;
        }

        public void Limpiar()
        {
            this.Proyecto = new Proyectos();
            this.DataContext = Proyecto;

        }

        /*private bool Validar()
        {
            bool Validado = true;
            if (ProyectoIdTextBox.Text.Length == 0)
            {
                Validado = false;
                MessageBox.Show("Funcion Fallida", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            return Validado;
        }*/
    }
}
