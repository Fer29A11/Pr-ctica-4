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
using System.Windows.Shapes;

namespace GestorProductoWPF
{
    /// <summary>
    /// Lógica de interacción para AgregarProductoWindows.xaml
    /// </summary>
    public partial class AgregarProductoWindows : Window
    {
        public Producto Producto { get; set; }
        public AgregarProductoWindows()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            Producto = new Producto
            {
                Id = int.Parse(txtID.Text),
                Nombre = txtNombre.Text,
                CodigoBarras = txtCodigoBarras.Text,
                Categoria = txtCategoria.Text,
                Precio = decimal.Parse(txtPrecio.Text),
                Stock = int.Parse(txtStock.Text)
            };
            this.DialogResult = true;
            this.Close();
        }

        private void txtStock_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            // Aquí puedes agregar la lógica que desees ejecutar cuando cambie el texto de txtStock.
        }

    }
}
