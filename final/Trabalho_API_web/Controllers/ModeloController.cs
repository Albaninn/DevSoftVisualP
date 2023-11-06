
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


[ApiController]
[Route("[controller]")]
public class ModeloController : ControllerBase
{
    private EstacionamentoDbContext _dbContext;
    public ModeloController(EstacionamentoDbContext dbContext)
    {
        _context = context;
    }
    //--------------------------------------------------------------------//

    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Modelo>>> Listar()
    {
        if(_context is null) return BadRequest();
        if(_context.modelo is null) return BadRequest();
        return await _context.modelo.ToListAsync();
    }

    //--------------------------------------------------------------------//

    [HttpGet]
    [Route("buscar/{id}")]

    public async Task<ActionResult<Modelo>> Buscar(int id)
    {
        if(_context is null) return BadRequest();
        if(_context.modelo is null) return BadRequest();
        var modeloTemp = await _context.modelo.FindAsync(id);
        if(modeloTemp is null) return BadRequest();
        return modeloTemp;
    }

    //--------------------------------------------------------------------//

    [HttpPost]
    [Route("cadastrar")]
    public async Task<ActionResult> Cadastrar(Modelo modelo)
    {
        if(_context is null) return BadRequest();
        await _context.AddAsync(modelo);
        await _context.SaveChangesAsync();
        return Created("", modelo);
    }

    //--------------------------------------------------------------------//

    [HttpPut()]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Modelo modelo)
    {
        if(_context is null) return BadRequest();
        if(_context.modelo is null) return BadRequest();
        var modeloTemp = await _context.modelo.FindAsync(modelo._idMarca);
        if(modeloTemp is null) return BadRequest();
        modeloTemp._nomeModelo = modelo._nomeModelo;
        await _context.SaveChangesAsync();
        return Ok();
    }

    //--------------------------------------------------------------------//
    
    [HttpDelete()]
    [Route("excluir/{id}")]
    public async Task<ActionResult> Excluir(int id)
    {
        if(_context is null) return BadRequest();
        if(_context.modelo is null) return BadRequest();
        var modeloTemp = await _context.modelo.FindAsync(id);
        if(modeloTemp is null) return BadRequest();
        _context.Remove(modeloTemp);
        await _context.SaveChangesAsync();
        return Ok();
    }

}