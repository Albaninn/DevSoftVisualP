using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Tra_placa_estacionamento.Controllers;

[ApiController]
[Route("[controller]")]
public class NotaController : ControllerBase
{
    private readonly EstacionamentoDbContext _context;

    public NotaController(EstacionamentoDbContext context)
    {
        _context = context;
    }

    [HttpGet()]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<NotaFiscal>>> Listar()
    {
        if (_context.notasFiscais is null) return NotFound();
        return await _context.notasFiscais.ToListAsync();
    }

    [HttpGet()]
    [Route("buscar/{numeroNota}")]
    public async Task<ActionResult<NotaFiscal>> Buscar([FromRoute] string NumeroNota)
    {
        if (_context.notasFiscais is null) return NotFound();
        var notaFiscal = await _context.notasFiscais.FindAsync(NumeroNota);
        return notaFiscal;
    }

    [HttpPost()]
    [Route("cadastrar")]
    public async Task<IActionResult> Cadastrar(NotaFiscal notaFiscal)
    {
        await _context.AddAsync(notaFiscal);
        await _context.SaveChangesAsync();
        return Created("", notaFiscal);
    }

    [HttpPut]
    [Route("alterar")]
    public async Task<IActionResult> Alterar(NotaFiscal notaFiscal)
    {
        _context.notasFiscais.Update(notaFiscal);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete]
    [Route("excluir/{numeroNota}")]
    public async Task<IActionResult> Excluir(string NumeroNota)
    {
        var notaFiscal = await _context.notasFiscais.FindAsync(NumeroNota);
        if (_context.notasFiscais is null) return NotFound();
        _context.notasFiscais.Remove(notaFiscal);
        await _context.SaveChangesAsync();
        return Ok();
    }
}

