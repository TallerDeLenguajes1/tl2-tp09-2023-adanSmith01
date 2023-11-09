using Microsoft.AspNetCore.Mvc;
namespace tl2_tp09_2023_adanSmith01.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly ILogger<UsuarioController> _logger;
    private IUsuarioRepository usuarioRepo;
    public UsuarioController(ILogger<UsuarioController> logger)
    {
        _logger = logger;
        usuarioRepo = new UsuarioRepository();
    }

    [HttpGet("/api/usuario")]
    public ActionResult<IEnumerable<Usuario>> GetUsuarios(){
        var usuarios = usuarioRepo.GetAllUsuarios();
        return Ok(usuarios);
    }

    [HttpGet]
    [Route("/api/usuario/{id}")]
    public ActionResult<Usuario> GetUsuarioPorId(int id){
        var usuarioEncontrado = usuarioRepo.GetUsuario(id);
        return Ok(usuarioEncontrado);
    }
    
    [HttpPost("/api/usuario")]
    public ActionResult<string> CrearUsuario(Usuario nuevoUsuario){
        if(nuevoUsuario != null){
            usuarioRepo.CrearUsuario(nuevoUsuario);
            return Ok("Se creo el usuario correctamente.");
        } else{
            return BadRequest("ERROR. No se pudo crear un nuevo usuario.");
        }
    }

    [HttpPut("/api/usuario/{id}")]
    public ActionResult<string> ActualizarUsuario(int id, Usuario usuarioModificar){
        if(usuarioModificar != null){
            usuarioRepo.ModificarUsuario(id, usuarioModificar);
            return Ok("Actualizacion de datos de usuario realizado correctamente");
        } else{
            return BadRequest("ERROR. La actualizacion no pudo completarse");
        }
    }
}
