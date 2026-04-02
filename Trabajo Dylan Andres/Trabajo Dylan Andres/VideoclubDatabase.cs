using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Trabajo_Dylan_Andres
{
    public class VideoclubDatabase
    {
        private MySqlConnection _connection;

        public VideoclubDatabase()
        {
            var conection = new MySqlConnection("Server=localhost;Port=3000;Database=bdvideoclub;Uid=root;");
        }

        public Result AgregarCliente(string nombre, int dni)
        {

            this._connection.Open();

            try
            {
                var command = new MySqlCommand($"insert into clientes (nombre, dni) VALUES({nombre}, {dni})", _connection);

                var filasInsertadas = command.ExecuteNonQuery();

                if (filasInsertadas > 1)
                {

                    var getClienteCommand = new MySqlCommand($"select * from clientes where dni={dni}", _connection);

                    var reader = getClienteCommand.ExecuteReader();

                    var id = reader.GetInt32("cliente_id");

                    var result = new Result()
                    {
                        Success = true,
                        Message = $"Se ha ingresado al cliente con exito.\nId de cliente: {id}"
                    };
                    _connection.Close();
                    return result;
                }
                else
                {
                    throw new Exception("Hubo un error interno en el ingreso del cliente.");
                }
            }
            catch (Exception ex)
            {
                var result = new Result()
                {
                    Success = false,
                    Message = ex.Message
                };
                _connection.Close();
                return result;
            }

        }

        public Result AlquilarPelicula(int dni, int pelicula_id, int cantidadDias)
        {
            this._connection.Open();

            try
            {
                var getPeliculaCommand = new MySqlCommand($"select * from peliculas where pelicula_id={pelicula_id}", _connection);

                var reader = getPeliculaCommand.ExecuteReader();

                var precio = reader.GetInt32("precio");

                var monto = precio * cantidadDias;

                var readerCliente = getCliente(dni);

                var cliente_id = readerCliente.GetInt32("id");

                var fechaActual = DateTime.Now;

                var fechaVencimientoString = fechaActual.AddDays(cantidadDias).ToString("dd/MM/yyyy");

                var fechaActualString = fechaActual.ToString("dd/MM/yyyy");


                var alquilerCommand = new MySqlCommand($"insert into alquileres (pelicula_id, cliente_id, monto, fecha_alquiler, fecha_vencimiento) values ({pelicula_id}, {cliente_id}, {monto}, {fechaActualString}, {fechaVencimientoString})", _connection);

                var filasAfectadas = alquilerCommand.ExecuteNonQuery();

                if (filasAfectadas > 1)
                {
                    var result = new Result()
                    {
                        Success = true,
                        Message = "Se registro el alquiler con exito"
                    };
                    return result;
                }
                else throw new Exception("Hubo un error interno en el registro del alquiler");
            }
               
            catch (Exception ex)
            {
                var result = new Result()
                {
                    Success = false,
                    Message = ex.Message
                };
                _connection.Close();
                return result;
            }

        }

        public Result AgregarPelicula(string nombre, int precio)
        {

            this._connection.Open();

            try
            {
                var command = new MySqlCommand($"insert into peliculas (nombre, precio) VALUES({nombre}, {precio})", _connection);

                var filasInsertadas = command.ExecuteNonQuery();

                if (filasInsertadas > 1)
                {

                    var getPeliculaCommand = new MySqlCommand($"select * from peliculas where nombre={nombre}", _connection);

                    var reader = getPeliculaCommand.ExecuteReader();

                    var id = reader.GetInt32("pelicula_id");



                    var result = new Result()
                    {
                        Success = true,
                        Message = $"Se ha creado la pelicula con exito.\nId de Pelicula: {id}"
                    };
                    _connection.Close();
                    return result;
                }
                else
                {
                    throw new Exception("Hubo un error interno en el ingreso de la pelicula.");
                }
            }
            catch (Exception ex)
            {
                var result = new Result()
                {
                    Success = false,
                    Message = ex.Message
                };
                _connection.Close();
                return result;
            }

        }

        public bool tieneDeudas(int dni)
        {
            var command = new MySqlCommand($"select * from clientes where dni=${dni}");

            var reader = command.ExecuteReader();

            var value = reader.GetInt32("deuda");

            Result result = new Result();

            if (value == 0)
            {
                return false;
            }
            else return true;
        }

        private MySqlDataReader getCliente(int dni)
        {
            _connection.Open();

            var getClienteCommand = new MySqlCommand($"select * from clientes where dni={dni}", _connection);

            _connection.Close();

            return getClienteCommand.ExecuteReader();
        }
    }
}
