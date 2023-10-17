using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Tra_placa_estacionamento.Controllers;

[ApiController]
[Route("[controller]")]
public class ClienteController : ControllerBase
{
    private EstacionamentoDbContext _context;
    public ClienteController(EstacionamentoDbContext context)
    {
        _context = context;
    }

    [HttpGet()]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Cliente>>> Listar()
    {
        if (_context.cliente is null) return NotFound();
        return await _context.cliente.ToListAsync();
    }

    [HttpGet()]
    [Route("buscar/{cpf}")]
    public async Task<ActionResult<Cliente>> Buscar([FromRoute] string Cpf)
    {
        if (_context.cliente is null) return NotFound();
        var cliente = await _context.cliente.FindAsync(Cpf);
        return cliente;
    }

    [HttpPost()]
    [Route("cadastrar")]
    public async Task<IActionResult> Cadastrar(Cliente cliente)
    {
        await _context.AddAsync(cliente);
        await _context.SaveChangesAsync();
        return Created("", cliente);
    }

    [HttpPut]
    [Route("alterar")]
    public async Task<IActionResult> Alterar(Cliente cliente)
    {
        _context.cliente.Update(cliente);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete]
    [Route("excluir/{cpf}")]
    public async Task<IActionResult> excluir(int Id)
    {
        var cliente = await _context.cliente.FindAsync(Id);
        if (_context.cliente is null) return NotFound();
        _context.cliente.Remove(cliente);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpPatch]
    [Route("modificaremail/{cpf}")]
    public async Task<IActionResult> ModificarEmail(string Cpf, [FromForm] string Email)
    {
        var cliente = await _context.cliente.FindAsync(Cpf);
        if (_context.cliente is null) return NotFound();
        cliente.Email = Email;
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpPost]
    [Route("adicionarveiculo/{cpf}")]
    public async Task<IActionResult> AdicionarVeiculo([FromRoute] string cpf, [FromBody] Veiculo veiculo)
    {
        var cliente = await _context.cliente.FindAsync(cpf);
        if (cliente == null) return NotFound("Cliente não encontrado.");

        if (cliente.Veiculos == null)
        {
            cliente.Veiculos = new List<Veiculo>();
        }
        cliente.Veiculos.Add(veiculo);
        await _context.SaveChangesAsync();
        return Created("", veiculo);
    }


    [HttpPost]
    [Route("associarveiculo/{cpf}")]
    public async Task<IActionResult> AssociarVeiculo([FromRoute] string cpf, [FromBody] string placa)
    {
        var cliente = await _context.cliente.FindAsync(cpf);
        if (cliente == null) return NotFound("Cliente não encontrado.");

        var veiculo = await _context.veiculo.FirstOrDefaultAsync(v => v.Placa == placa);
        if (veiculo == null) return NotFound("Veículo não encontrado.");

        /*if (veiculo.Cliente != null) return BadRequest("O veículo já está associado a um cliente.");*/
        
        // Adicione o veículo à lista de veículos do cliente
        cliente.Veiculos.Add(veiculo);
        
        // Associe o veículo ao cliente
        /*veiculo.Cliente = cliente;*/

        await _context.SaveChangesAsync();
        return Ok();
    }
}