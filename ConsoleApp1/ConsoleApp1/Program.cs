using MySql.Data.MySqlClient;

var conection = new MySqlConnection("Server=localhost;Port=3000;Database=bdvideoclub;Uid=root;");

conection.Open();

var command = new MySqlCommand("select * from clientes", conection);

var reader = command.ExecuteReader();

while (reader.Read())
{
    Console.WriteLine(reader.GetString("Nombre"));
}
