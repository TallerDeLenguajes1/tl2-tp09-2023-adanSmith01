namespace tl2_tp09_2023_adanSmith01;

public interface IUsuarioRepository
{
    void CrearUsuario(Usuario nuevoUsuario);
    void ModificarUsuario(int idUsuario, Usuario usuarioModificar);
    List<Usuario> GetAllUsuarios();
    Usuario GetUsuario(int idUsuario);
    void EliminarUsuario(int idUsuario);
}