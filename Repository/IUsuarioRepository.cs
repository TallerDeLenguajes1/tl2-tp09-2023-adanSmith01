namespace tl2_tp09_2023_adanSmith01;

public interface IUsuarioRepository
{
    void CrearNuevoUsuario(Usuario nuevoUsuario);
    void ModificarUsuarioExistente(int idUsuario, Usuario usuarioModificar);
    List<Usuario> GetAllUsuarios();
    Usuario GetInfoUsuario(int idUsuario);
    void EliminarUsuario(int idUsuario);
}