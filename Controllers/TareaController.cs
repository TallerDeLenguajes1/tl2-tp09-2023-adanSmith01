using Microsoft.AspNetCore.Mvc;
namespace tl2_tp09_2023_adanSmith01.Controllers;

[ApiController]
[Route("[controller]")]
public class TareaController : ControllerBase
{
    private readonly ILogger<TareaController> _logger;
    private ITareaRepository tareaRepo;
    public TareaController(ILogger<TareaController> logger)
    {
        _logger = logger;
        tareaRepo = new TareaRepository();
    }

    [HttpGet]
    [Route("/api/tarea/usuario/{id}")]
    public ActionResult<IEnumerable<Tarea>> GetTareasPorUsuario(int id){
        var tareasUsuario = tareaRepo.GetTareasDeUsuario(id);
        return Ok(tareasUsuario);
    }

    [HttpGet]
    [Route("/api/tarea/tablero/{id}")]
    public ActionResult<IEnumerable<Tarea>> GetTareasPorTablero(int id){
        var tareasTablero = tareaRepo.GetTareasDeTablero(id);
        return Ok(tareasTablero);
    }

    [HttpGet]
    [Route("/api/tarea/{estado}")] 
    public ActionResult<string> CantidadTareasPorEstado(EstadoTarea estado){
        var tareasEstado = tareaRepo.GetTareasPorEstado(estado);
        return Ok($"La cantidad de tareas de estado '{estado}' es {tareasEstado.Count}");
    }

    [HttpPost("/api/tarea")]
    public ActionResult<string> CrearTareaNueva(int idTablero, Tarea nuevaTarea){
        if(nuevaTarea != null){
            tareaRepo.CrearTarea(idTablero, nuevaTarea);
            return Ok("Se ha creado la tarea correctamente");
        }else{
            return BadRequest("ERROR. No se pudo crear la tarea correctamente");
        }
    }

    [HttpPut("/api/tarea/{idTarea}/nombre/{nombreNuevo}")]
    public ActionResult<string> ActualizarNombreTarea(int idTarea, string nombreNuevo, Tarea tareaAModificar){
        tareaAModificar.Nombre = nombreNuevo;
        tareaRepo.ModificarTarea(idTarea, tareaAModificar);
        return Ok("La tarea fue modificada exitosamente");
    }

    [HttpPut("/api/tarea/{idTarea}/nombre/{nombreNuevo}")]
    public ActionResult<string> ActualizarEstadoTarea(int idTarea, EstadoTarea estadoNuevo, Tarea tareaAModificar){
        tareaAModificar.Estado = estadoNuevo;
        tareaRepo.ModificarTarea(idTarea, tareaAModificar);
        return Ok("La tarea fue modificada exitosamente");
    }

    [HttpDelete("/api/tarea/{id}")]
    public ActionResult<string> EliminarTareaPorId(int id){
        tareaRepo.EliminarTarea(id);
        return Ok("La tarea especificada fue borrada exitosamente");
    }
} 