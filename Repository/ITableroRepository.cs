namespace tl2_tp09_2023_adanSmith01;

public interface ITableroRepository
{
    void CrearTablero(Tablero nuevoTablero);
    void ModificarTablero(int idTablero, Tablero tableroModificar);
    List<Tablero> GetAllTableros();
    Tablero GetTablero(int idTablero);
    List<Tablero> GetTablerosDeUsuario(int idUsuario);
    void EliminarTablero(int idTablero);
}