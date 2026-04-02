namespace Trabajo_Dylan_Andres
{
    using System.IO;
    using System.Diagnostics;
    public partial class Form1 : Form
    {
        int dni;
        string nombre;
        string nombrepelicula;
        int precio;
        int dnialquilar;
        int codigodepelicula;
        int dias;
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // aca dylan agregar a la base de datos, los nombres de los txtbox son txtdni y txtnombre
            MessageBox.Show("Usuario registrado con extito!", "aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dni = int.Parse(txtdni.Text);
            nombre = txtnombre.Text;

        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            //primero tiene que verificar si el cliente posee alguna deuda
            //, los nombres de los txt son txtdnialquilar y txtcodigo
            MessageBox.Show("Pelicula Alquilada, que la disfrute!", "aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            nombrepelicula = txtnamepeli.Text;
            precio = int.Parse(txtprecio.Text);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            dnialquilar = int.Parse(txtdnialquilar.Text);
            codigodepelicula = int.Parse(txtcodigo.Text);
            dias = int.Parse(txtdias.Text);


            // 1. Definimos dónde se va a guardar el archivo (en este caso, en el Escritorio)
            string rutaEscritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string rutaArchivo = Path.Combine(rutaEscritorio, "Reporte_Semanal.txt");

            // 2. Empezamos a armar el texto del reporte
            string contenidoReporte = "========================================\n";
            contenidoReporte += "      REPORTE SEMANAL DE ALQUILERES     \n";
            contenidoReporte += "========================================\n";
            contenidoReporte += $"Fecha de emisión: {DateTime.Now.ToString("dd/MM/yyyy HH:mm")}\n\n";

            // -------------------------------------------------------------------------
            // ZONA DE BASE DE DATOS (PARA CUANDO TU COMPAÑERO TERMINE)
            // -------------------------------------------------------------------------
            /*
             * Aquí es donde tendrán que conectar a la base de datos. El código será 
             * algo parecido a esto (dependiendo de si usan SQL Server, MySQL, etc.):
             * * SqlConnection conexion = new SqlConnection("TU_CADENA_DE_CONEXION_AQUI");
             * conexion.Open();
             * * // Hacen una consulta para traer lo de la última semana
             * string query = "SELECT NombrePelicula, DniCliente, Fecha FROM Alquileres WHERE Fecha >= FechaInicioSemana";
             * SqlCommand comando = new SqlCommand(query, conexion);
             * SqlDataReader lector = comando.ExecuteReader();
             * * while (lector.Read()) 
             * {
             * // Por cada fila que encuentren, la suman al texto:
             * contenidoReporte += $"- Película: {lector["NombrePelicula"]} | DNI: {lector["DniCliente"]}\n";
             * }
             * * conexion.Close();
             */
            // -------------------------------------------------------------------------


            // 3. DATOS SIMULADOS (Mietras tanto, usamos esto para probar que el .txt funciona)
            contenidoReporte += ">> DATOS DE PRUEBA (Falta conectar BD):\n\n";
            contenidoReporte += "- Película: El Señor de los Anillos | DNI: 12345678 | Fecha: 01/04/2026\n";
            contenidoReporte += "- Película: Matrix                  | DNI: 87654321 | Fecha: 02/04/2026\n";
            contenidoReporte += "- Película: Shrek 2                 | DNI: 11223344 | Fecha: 03/04/2026\n";
            contenidoReporte += "\n========================================\n";
            contenidoReporte += "Fin del reporte.";

            try
            {
                // 4. Creamos el archivo de texto y le metemos todo el string que armamos
                File.WriteAllText(rutaArchivo, contenidoReporte);

                // 5. Abrimos el bloc de notas apuntando a ese archivo
                Process.Start("notepad.exe", rutaArchivo);
            }
            catch (Exception ex)
            {
                // Por si llega a haber un error (ej. permisos de Windows)
                MessageBox.Show("Hubo un error al generar el reporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Pelicula Agregada con exito!", "aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}