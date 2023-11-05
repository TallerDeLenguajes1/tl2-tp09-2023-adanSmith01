using Microsoft.AspNetCore.Mvc;
namespace tl2_tp09_2023_adanSmith01.Controllers;

[ApiController]
[Route("[controller]")]
public class TableroController : ControllerBase
{
    private readonly ILogger<TableroController> _logger;
    private TableroRepository tableroRepo;
    public TableroController(ILogger<TableroController> logger)
    {
        _logger = logger;
        tableroRepo = new TableroRepository();
    }

    [HttpGet("/api/tableros")]
    public ActionResult<IEnumerable<Tablero>> GetAll(){
        var tableros = tableroRepo.GetAllTableros();

        if(tableros.Count != 0){
            return Ok(tableros);
        } else{
            return BadRequest("No se registraron tableros de tareas de usuarios");
        }
    }

    [HttpPost("/api/tablero")]
    public ActionResult<string> CrearTablero(Tablero nuevoTablero){
        if(nuevoTablero != null){
            tableroRepo.CrearTablero(nuevoTablero);
            return Ok("Se ha creado un nuevo tablero correctamente");
        } else{
            return BadRequest("ERROR. No se ha creado el tablero correctamente");
        }
    }

    //Probando el GET y DELETE faltantes
    [HttpGet]
    [Route("/api/tablero/{idUsuario}")]
    public ActionResult<IEnumerable<Tablero>> GetTablerosPorIdUsuario(int idUsuario){
        var tablerosDeUsuario = tableroRepo.GetTablerosDeUsuario(idUsuario);

        if(tablerosDeUsuario.Count != 0){
            return Ok(tablerosDeUsuario);
        } else{
            return BadRequest("No hay tableros registrados del usuario indicado");
        }
    }

    [HttpDelete("/api/tablero/{id}")]
    public ActionResult<string> BorrarTablero(int id){
        tableroRepo.EliminarTablero(id);
        return Ok("La eliminacion del tablero se realizo correctamente");
    }
    
}