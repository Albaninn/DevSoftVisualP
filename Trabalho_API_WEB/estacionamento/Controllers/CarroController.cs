using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Tra_placa_estacionamento.Controllers;

[ApiController]
[Route("[controller]")]
public class CarroController : ControllerBase
{
    private EstacionamentoDbContext _context;
    public CarroController(EstacionamentoDbContext context)
    {
        _context = context;
    }

    [HttpGet()]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Carro>>> Listar()
    {
        if (_context.carro is null) return NotFound();
        return await _context.carro.ToListAsync();
    }

    [HttpGet()]
    [Route("buscar/{placa}")]
    public async Task<ActionResult<Carro>> Buscar([FromRoute] string placa)
    {
        if (_context.carro is null) return NotFound();
        var carro = await _context.carro.FindAsync(placa);
        return carro;
    }

    [HttpPost()]
    [Route("cadastrar")]
    public async Task<IActionResult> Cadastrar(Carro carro)
    {
        await _context.AddAsync(carro);
        await _context.SaveChangesAsync();
        return Created("", carro);
    }

    [HttpPut]
    [Route("alterar")]
    public async Task<IActionResult> Alterar(Carro carro)
    {
        _context.carro.Update(carro);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete]
    [Route("excluir/{placa}")]
    public async Task<IActionResult> excluir(string placa)
    {
        var carro = await _context.carro.FindAsync(placa);
        if (_context.carro is null) return NotFound();
        _context.carro.Remove(carro);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpPatch]
    [Route("modificardescricao/{placa}")]
    public async Task<IActionResult> ModificarDescricao(string placa, [FromForm] string Descricao)
    {
        var carro = await _context.carro.FindAsync(placa);
        if (_context.carro is null) return NotFound();
        carro.Descricao = Descricao;
        await _context.SaveChangesAsync();
        return Ok();
    }
}