namespace tl2_tp09_2023_adanSmith01;

public interface ITareaRepository
{
    void CrearTarea(Tarea nuevaTarea);
    void ModificarTarea(int idTarea, Tarea tareaModificar);
    void AsignarUsuarioATarea(int idUsuario, int idTarea);
    Tarea GetTarea(int idTarea);
    List<Tarea> GetTareasDeUsuario(int idUsuario);
    List<Tarea> GetTareasDeTablero(int idTablero);
    void EliminarTarea(int idTarea);
}