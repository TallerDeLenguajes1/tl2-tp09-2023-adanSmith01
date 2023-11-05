using Microsoft.AspNetCore.Mvc;
namespace tl2_tp09_2023_adanSmith01.Controllers;

[ApiController]
[Route("[controller]")]
public class TareaController : ControllerBase
{
    private readonly ILogger<TareaController> _logger;
    private TareaRepository tareaRepo;
    public TareaController(ILogger<TareaController> logger)
    {
        _logger = logger;
        tareaRepo = new TareaRepository();
    }

    [HttpGet]
    [Route("/api/tarea/usuario/{id}")]
    public ActionResult<IEnumerable<Tarea>> GetTareasPorUsuario(int id){
        var tareasUsuario = tareaRepo.GetTareasDeUsuario(id);
        if(tareasUsuario.Count != 0){
            return Ok(tareasUsuario);
        }else{
            return Ok("La lista de tareas del usuario especificado se encuentra vacia"); //Consultar
        }
    }

    [HttpGet]
    [Route("/api/tarea/tablero/{id}")]
    public ActionResult<IEnumerable<Tarea>> GetTareasPorTablero(int id){
        var tareasTablero = tareaRepo.GetTareasDeTablero(id);
        if(tareasTablero.Count != 0){
            return Ok(tareasTablero);
        }else{
            return Ok("La lista de tareas del tablero especificado se encuentra vacia"); //Consultar
        }
    }

    [HttpPost("/api/tarea")]
    public ActionResult<string> CrearTareaNueva(Tarea nuevaTarea){
        if(nuevaTarea != null){
            tareaRepo.CrearTarea(nuevaTarea);
            return Ok("Se ha creado la tarea correctamente");
        }else{
            return BadRequest("ERROR. No pudo crear la tarea correctamente");
        }
    }

    [HttpDelete("/api/tarea/{id}")]
    public ActionResult<string> EliminarTareaPorId(int id){
        tareaRepo.EliminarTarea(id);
        return Ok("La tarea especificada fue borrada exitosamente");
    }
} 