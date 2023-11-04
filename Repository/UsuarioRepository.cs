using System.Data.SQLite;
namespace tl2_tp09_2023_adanSmith01;

public class UsuarioRepository
{
    private string connectionString = @"Data Source = DB/kanban.sqlite;Initial Catalog=Northwind;" + "Integrated Security=true";


    public void CrearNuevoUsuario(Usuario nuevoUsuario){
        using(SQLiteConnection connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            
            string queryString = @"INSERT INTO Usuario (nombre_de_usuario) VALUES (@nombreUsuario)";
            var command = new SQLiteCommand(queryString, connection);

            command.Parameters.Add(new SQLiteParameter("@nombreUsuario", nuevoUsuario.NombreUsuario));
            command.ExecuteNonQuery();
            connection.Close();
        }
    }

    public List<Usuario> GetAllUsuarios(){
        List<Usuario> usuarios = new List<Usuario>();
        using(SQLiteConnection connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            string queryString = @"SELECT * FROM Usuario;";
            var command = new SQLiteCommand(queryString, connection);
            using(var reader = command.ExecuteReader())
            {
                while(reader.Read()){
                    var usuario = new Usuario();
                    usuario.Id = Convert.ToInt32(reader["id"]);
                    usuario.NombreUsuario = reader["nombre_de_usuario"].ToString();
                    usuarios.Add(usuario);
                }
            }
            connection.Close();
        }

        return usuarios;
    }
}