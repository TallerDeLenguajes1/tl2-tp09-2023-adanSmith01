using Microsoft.AspNetCore.Mvc;
namespace tl2_tp09_2023_adanSmith01.Controllers;

[ApiController]
[Route("[controller]")]
public class TableroController : ControllerBase
{
    private readonly ILogger<TableroController> _logger;
    private ITableroRepository tableroRepo;
    public TableroController(ILogger<TableroController> logger)
    {
        _logger = logger;
        tableroRepo = new TableroRepository();
    }

    [HttpGet("/api/tableros")]
    public ActionResult<IEnumerable<Tablero>> GetAll(){
        var tableros = tableroRepo.GetAllTableros();
        return Ok(tableros);
    }

    [HttpPost("/api/tablero")]
    public ActionResult<string> Crear(Tablero nuevoTablero){
        if(nuevoTablero != null){
            tableroRepo.CrearTablero(nuevoTablero);
            return Ok("Se ha creado un nuevo tablero correctamente");
        } else{
            return BadRequest("ERROR. No se ha creado el tablero correctamente");
        }
    }
    
}