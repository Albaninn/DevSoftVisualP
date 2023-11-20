using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]")]
public class MarcaController : ControllerBase
{
    private EstacionamentoDbContext _context;
    public MarcaController(EstacionamentoDbContext context)
    {
        _context = context;
    }
     //--------------------------------------------------------------------//

    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Marca>>> Listar()
    {
        if (_context is null) return BadRequest();
        if (_context.marca is null) return BadRequest();
        return await _context.marca.ToListAsync();
    }

     //--------------------------------------------------------------------//

    [HttpGet]
    [Route("buscar/{id}")]
    public async Task<ActionResult<Marca>> Buscar(int id)
    {
        if (_context is null) return BadRequest();
        if (_context.marca is null) return BadRequest();
        var marcaTemp = await _context.marca.FindAsync(id);
        if (marcaTemp is null) return BadRequest();
        return marcaTemp;
    }

    //--------------------------------------------------------------------//

    [HttpPost]
    [Route("cadastrar")]
    public async Task<ActionResult> Cadastrar(Marca marca)
    {
        if (_context is null) return BadRequest();
        await _context.AddAsync(marca);
        await _context.SaveChangesAsync();
        return Created("", marca);
    }

    //--------------------------------------------------------------------//
    
    [HttpPut()]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Marca marca)
    {
        if (_context is null) return BadRequest();
        if (_context.marca is null) return BadRequest();
        var marcaTemp = await _context.marca.FindAsync(marca.idMarca);
        if (marcaTemp is null) return BadRequest();
        marcaTemp.nomeMarca = marca.nomeMarca;
        await _context.SaveChangesAsync();
        return Ok();
    }

    //--------------------------------------------------------------------//

    [HttpDelete()]
    [Route("excluir/{id}")]
    public async Task<ActionResult> Excluir(int idMarca)
    {
        if (_context is null) return BadRequest();
        if (_context.marca is null) return BadRequest();
        var marcaTemp = await _context.marca.FindAsync(idMarca);
        if (marcaTemp is null) return BadRequest();
        _context.Remove(marcaTemp);
        await _context.SaveChangesAsync();
        return Ok();
    }

}