using Microsoft.AspNetCore.Mvc;
namespace tl2_tp09_2023_adanSmith01.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly ILogger<UsuarioController> _logger;
    private UsuarioRepository usuarioRepo;
    public UsuarioController(ILogger<UsuarioController> logger)
    {
        _logger = logger;
        usuarioRepo = new UsuarioRepository();
    }

    [HttpGet("/api/usuario")]
    public ActionResult<IEnumerable<Usuario>> GetUsuarios(){
        return Ok(usuarioRepo.GetAllUsuarios());
    }
    // El controlador, por ahora, revisa que la informacion recibida desde el usuario sea valida
    [HttpPost("/api/usuario")]
    public ActionResult<string> CrearUsuario(Usuario nuevoUsuario){
        if(nuevoUsuario != null){
            usuarioRepo.CrearNuevoUsuario(nuevoUsuario);
            return Ok("Se creo el usuario correctamente.");
        } else{
            return BadRequest("ERROR. No se pudo crear un nuevo usuario.");
        }
    }
}
