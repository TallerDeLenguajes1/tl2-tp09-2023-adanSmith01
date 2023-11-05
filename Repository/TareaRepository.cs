using System.Data.SQLite;
namespace tl2_tp09_2023_adanSmith01;

public class TareaRepository
{
    private string connectionString = @"Data Source = DB/kanban.sqlite;Initial Catalog=Northwind;" + "Integrated Security=true";

    public void CrearTarea(Tarea nuevaTarea){
        using(var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            
            string queryString = @"
            INSERT INTO Tarea (id_tablero, nombre, estado, descripcion, color, id_usuario_asignado) 
            VALUES (@idTablero, @nombreTarea, @estadoTarea, @descripcionTarea, @colorTarea, @idUsuarioAsignado);
            ";
            var command = new SQLiteCommand(queryString, connection);

            command.Parameters.Add(new SQLiteParameter("@idTablero", nuevaTarea.IdTablero));
            command.Parameters.Add(new SQLiteParameter("@nombreTarea", nuevaTarea.Nombre));
            command.Parameters.Add(new SQLiteParameter("@estadoTarea", Convert.ToInt32(nuevaTarea.Estado)));
            command.Parameters.Add(new SQLiteParameter("@descripcionTarea", nuevaTarea.Descripcion));
            command.Parameters.Add(new SQLiteParameter("@colorTarea", nuevaTarea.Color));
            command.Parameters.Add(new SQLiteParameter("@idUsuarioAsignado", nuevaTarea.IdUsuarioAsignado));

            command.ExecuteNonQuery();
            connection.Close();
        }
    }

    public void AsignarUsuarioATarea(int idUsuario, int idTarea){
        using(var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            string queryString = @"UPDATE Tarea SET id_usuario_asignado = @idUsuario WHERE id = @idTarea;";
            var command = new SQLiteCommand(queryString, connection);

            command.Parameters.Add(new SQLiteParameter("@idUsuario", idUsuario));
            command.Parameters.Add(new SQLiteParameter("@idTarea", idTarea));

            command.ExecuteNonQuery();
            connection.Close();
        }
    }

    public Tarea GetTarea(int idTarea){
        Tarea tareaEncontrada = new Tarea();
        using(var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            string queryString = @"SELECT * FROM Tarea WHERE id = @idTarea;";
            
            var command = new SQLiteCommand(queryString, connection);
            command.Parameters.Add(new SQLiteParameter("@idTarea", idTarea));
            using(var reader = command.ExecuteReader())
            {
                if(reader.Read()){
                    tareaEncontrada.Id = Convert.ToInt32(reader["id"]);
                    tareaEncontrada.IdTablero = Convert.ToInt32(reader["id_tablero"]);
                    tareaEncontrada.Nombre = reader["nombre"].ToString();
                    tareaEncontrada.Estado = (EstadoTarea) Convert.ToInt32(reader["estado"]);
                    tareaEncontrada.Descripcion = reader["descripcion"].ToString();
                    tareaEncontrada.Color = reader["color"].ToString();
                    tareaEncontrada.IdUsuarioAsignado = reader["id_usuario_asignado"] as int?;
                }
            }

            connection.Close();
        }

        return tareaEncontrada;
    }

    public List<Tarea> GetTareasDeUsuario(int idUsuario){
        List<Tarea> tareasUsuario = new List<Tarea>();
        using(var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            string queryString = @"SELECT * FROM Tarea WHERE id_usuario_asignado = @idUsuarioAsignado";
            var command = new SQLiteCommand(queryString, connection);
            command.Parameters.Add(new SQLiteParameter("@idUsuarioAsignado", idUsuario));

            using(var reader = command.ExecuteReader())
            {
                while(reader.Read()){
                    Tarea tarea = new Tarea();
                    tarea.Id = Convert.ToInt32(reader["id"]);
                    tarea.IdTablero = Convert.ToInt32(reader["id_tablero"]);
                    tarea.Nombre = reader["nombre"].ToString();
                    tarea.Estado = (EstadoTarea) Convert.ToInt32(reader["estado"]);
                    tarea.Descripcion = reader["descripcion"].ToString();
                    tarea.Color = reader["color"].ToString();
                    tarea.IdUsuarioAsignado = reader["id_usuario_asignado"] as int?; 
                    tareasUsuario.Add(tarea);
                }
            }
            connection.Close();
        }

        return tareasUsuario;
    }

    public List<Tarea> GetTareasDeTablero(int idTablero){
        List<Tarea> tareasTablero = new List<Tarea>();
        using(var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            string queryString = @"SELECT * FROM Tarea WHERE id_tablero = @idTablero";
            var command = new SQLiteCommand(queryString, connection);
            command.Parameters.Add(new SQLiteParameter("@idTablero", idTablero));

            using(var reader = command.ExecuteReader())
            {
                while(reader.Read()){
                    Tarea tarea = new Tarea();
                    tarea.Id = Convert.ToInt32(reader["id"]);
                    tarea.IdTablero = Convert.ToInt32(reader["id_tablero"]);
                    tarea.Nombre = reader["nombre"].ToString();
                    tarea.Estado = (EstadoTarea) Convert.ToInt32(reader["estado"]);
                    tarea.Descripcion = reader["descripcion"].ToString();
                    tarea.Color = reader["color"].ToString();
                    tarea.IdUsuarioAsignado = reader["id_usuario_asignado"] as int?; 
                    tareasTablero.Add(tarea);
                }
            }
            connection.Close();
        }

        return tareasTablero;
    }

    public void EliminarTarea(int idTarea){
        using(var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            string queryString = @"DELETE FROM Tarea WHERE id = @idTarea;";
            var command = new SQLiteCommand(queryString, connection);
            command.Parameters.Add(new SQLiteParameter("@idTarea", idTarea));

            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}