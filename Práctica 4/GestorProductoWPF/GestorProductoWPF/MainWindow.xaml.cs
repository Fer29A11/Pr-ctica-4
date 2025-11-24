using System.Collections;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GestorProductoWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GestorDeProducto gestor = new GestorDeProducto();
        public MainWindow()
        {
            InitializeComponent();
            CargarDatosIniciales();
            dataGridProductos.ItemsSource = gestor.ObtenerProductos();
            comboTipoBusqueda.Items.Add("ID");
            comboTipoBusqueda.Items.Add("Nombre");
            comboTipoBusqueda.SelectedIndex = 0;

            comboOrdenar.Items.Add("Precio");
            comboOrdenar.Items.Add("ID");
            comboOrdenar.Items.Add("Nombre");
            comboOrdenar.SelectedIndex = 0;
        }

        private void CargarDatosIniciales()
        {
            gestor.AgregarProducto(new Producto
            {
                Id = 1,
                Nombre = "Laptop",
                CodigoBarras = "123456",
                Categoria = "Electrónica",
                Precio = 1500.00m,
                Stock = 10
            });
            
            gestor.AgregarProducto(new Producto
            {
                Id = 2,
                Nombre = "Smartphone",
                CodigoBarras = "789012",
                Categoria = "Electrónica",
                Precio = 800.00m,
                Stock = 25
            });

            gestor.AgregarProducto(new Producto
            {
                Id = 3,
                Nombre = "Camiseta",
                CodigoBarras = "345678",
                Categoria = "Ropa",
                Precio = 20.00m,
                Stock = 100
            });

            gestor.AgregarProducto(new Producto
            {
                Id = 4,
                Nombre = "Pantalones",
                CodigoBarras = "901234",
                Categoria = "Ropa",
                Precio = 40.00m,
                Stock = 60
            });
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            string criterio = comboTipoBusqueda.SelectedItem.ToString();
            string valor = txtBusqueda.Text;

            //Mista ordenada
            List<Producto> listaOrdenada = new List<Producto>(gestor.ObtenerProductos());
            OrdenadorSimplificado.QuickSortPorId(listaOrdenada);

            switch (criterio)
            {
                case "ID":
                    if (int.TryParse(valor, out int id))
                    {
                        var (producto, iteraciones) = BuscadorSimplificado.BusquedaBinariaPorId(gestor.ObtenerProductos(), id);
                        MostrarResultado(producto, iteraciones);
                    }
                    break;
                case "Nombre":
                    var (productoNombre, iteracionesNombre) = BuscadorSimplificado.BusquedaSecuencialNombre(gestor.ObtenerProductos(), valor);
                    MostrarResultado(productoNombre, iteracionesNombre);
                    break;

            }
        }

        private void MostrarResultado (Producto producto, int iteraciones)
        {
            txtResultadoBusqueda.Text = producto?.ToString() ?? "Producto no encontrado.";
            progressIteraciones.Value = iteraciones*10;
        }
        private void btnOrdenar_Click(object sender, RoutedEventArgs e)
        {
            List<Producto> productos = new List<Producto>(gestor.ObtenerProductos());
            string criterio = comboOrdenar.SelectedItem.ToString();

            switch (criterio)
            {
                case "ID":
                    OrdenadorSimplificado.QuickSortPorId(productos);
                    break;
                case "Nombre":
                    productos = OrdenadorSimplificado.MergeSortPorNombre(productos);
                    break;
                case "Precio":
                    OrdenadorSimplificado.QuickSortPorPrecio(productos);
                    break;
            }
            listViewOrdenados.ItemsSource = productos;
            // Dibujar grafica de barras
            DibujarGraficaDeBarras(productos);
        }

        private void DibujarGraficaDeBarras(List<Producto> productos)
        {
            canvasGrafico.Children.Clear();
            double maxPrecio = (double)productos.Max(p => p.Precio);
            double escala = canvasGrafico.ActualHeight / maxPrecio;
            for (int i = 0; i < productos.Count; i++)
            {
                Rectangle barra = new Rectangle
                {
                    Width = 40,
                    Height = (double)productos[i].Precio * escala,
                    Fill = Brushes.Blue,
                    Margin = new Thickness(i*40, canvasGrafico.ActualHeight - ((double)productos[i].Precio * escala), 0, 0)
                };

                canvasGrafico.Children.Add(barra);

                TextBlock etiqueta = new TextBlock
                {
                    Text = productos[i].Nombre,
                    Width = 40,
                    TextAlignment = TextAlignment.Center,
                    Margin = new Thickness(i * 40, canvasGrafico.ActualHeight - ((double)productos[i].Precio * escala) - 20, 0, 0)
                };
                canvasGrafico.Children.Add(etiqueta);
            }
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            var ventanaAgregar = new AgregarProductoWindows();
            if ( ventanaAgregar.ShowDialog() == true )
            {
                Producto nuevoProducto = ventanaAgregar.Producto;
                try
                {
                    gestor.AgregarProducto(nuevoProducto);
                    dataGridProductos.ItemsSource = null;
                    dataGridProductos.ItemsSource = gestor.ObtenerProductos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error al agregar producto", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridProductos.SelectedItem is Producto productoSeleccionado)
            {
                bool eliminado = gestor.EliminarProducto(productoSeleccionado.CodigoBarras);
                if (eliminado)
                {
                    dataGridProductos.ItemsSource = null;
                    dataGridProductos.ItemsSource = gestor.ObtenerProductos();
                    MessageBox.Show("Producto eliminado correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Selecciona un producto a eliminar.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }
    }
}