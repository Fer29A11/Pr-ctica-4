

public class OrdenadorSimplificado

{
    // Método QuickSort
    public static void QuickSortPorId(List<Producto> productos)
    {
        if (productos == null || productos.Count <= 1)
            return;


        //1. Elegir pivote (último elemento)
        Producto pivote = productos[productos.Count - 1];

        //2. Reorganizar la lista con elementos menores a la izquierda y mayores a la derecha
        var menores = new List<Producto>();
        var mayores = new List<Producto>();
        for (int i = 0; i < productos.Count - 1; i++)
        {
            if (productos[i].Id <= pivote.Id)
                menores.Add(productos[i]);
            else
                mayores.Add(productos[i]);
        }

        //3. Ordenar recursivamente las sublistas
        QuickSortPorId(menores);
        QuickSortPorId(mayores);


        //4. Combinar las listas ordenadas
        productos.Clear();
        productos.AddRange(menores);
        productos.Add(pivote);
        productos.AddRange(mayores);
    }



    public static void QuickSortPorPrecio(List<Producto> productos)
    {
        if (productos == null || productos.Count <= 1)
            return;


        //1. Elegir pivote (último elemento)
        Producto pivote = productos[productos.Count - 1];

        //2. Reorganizar la lista con elementos menores a la izquierda y mayores a la derecha
        var menores = new List<Producto>();
        var mayores = new List<Producto>();
        for (int i = 0; i < productos.Count - 1; i++)
        {
            if (productos[i].Precio <= pivote.Precio)
                menores.Add(productos[i]);
            else
                mayores.Add(productos[i]);
        }

        //3. Ordenar recursivamente las sublistas
        QuickSortPorPrecio(menores);
        QuickSortPorPrecio(mayores);


        //4. Combinar las listas ordenadas
        productos.Clear();
        productos.AddRange(menores);
        productos.Add(pivote);
        productos.AddRange(mayores);
    }

    // Método merge sort

    public static List<Producto> MergeSortPorNombre(List<Producto> productos)
    {
        if ( productos.Count <= 1)
            return productos;

        // 1. Dividir la lista en dos mitades
        int mid = productos.Count / 2;
        var izquierda = productos.GetRange(0, mid);
        var derecha = productos.GetRange(mid, productos.Count - mid);

        // 2. Ordenar recursivamente ambas mitades
        izquierda = MergeSortPorNombre(izquierda);
        derecha = MergeSortPorNombre(derecha);

        // 3. Combinar las dos mitades ordenadas
        return Mezclar(izquierda, derecha);
    }

    private static List<Producto> Mezclar(List<Producto> izquierda, List<Producto> derecha)
    {
        var resultado = new List<Producto>();
        int i = 0, j = 0;
        while (i < izquierda.Count && j < derecha.Count)
        {
            if (string.Compare(izquierda[i].Nombre, derecha[j].Nombre) <= 0)
            {
                resultado.Add(izquierda[i]);
                i++;
            }
            else
            {
                resultado.Add(derecha[j]);
                j++;
            }
        }
        // Agregar los elementos restantes
        while (i < izquierda.Count)
        {
            resultado.Add(izquierda[i]);
            i++;
        }
        while (j < derecha.Count)
        {
            resultado.Add(derecha[j]);
            j++;
        }
        return resultado;
    }
}


