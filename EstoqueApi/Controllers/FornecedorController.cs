using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EstoqueData.Data;
using EstoqueData.Models;
using Microsoft.AspNetCore.Cors;

namespace EstoqueApi.Controllers
{
    [EnableCors("MyAppPolicy")]
    [Produces("application/json")]
    [Route("api/Fornecedor")]
    public class FornecedorController : Controller
    {
        private readonly EstoqueContext _context;

        public FornecedorController(EstoqueContext context)
        {
            _context = context;
        }

        // GET: api/Fornecedor
        [HttpGet]
        public IEnumerable<Fornecedor> GetFornecedores()
        {
            return _context.Fornecedores;
        }

        // GET: api/Fornecedor/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFornecedor([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fornecedor = await _context.Fornecedores.SingleOrDefaultAsync(m => m.FornecedorID == id);

            if (fornecedor == null)
            {
                return NotFound();
            }

            return Ok(fornecedor);
        }

        // PUT: api/Fornecedor/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFornecedor([FromRoute] int id, [FromBody] Fornecedor fornecedor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fornecedor.FornecedorID)
            {
                return BadRequest();
            }

            _context.Entry(fornecedor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FornecedorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Fornecedor
        [HttpPost]
        public async Task<IActionResult> PostFornecedor([FromBody] Fornecedor fornecedor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Fornecedores.Add(fornecedor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFornecedor", new { id = fornecedor.FornecedorID }, fornecedor);
        }

        // DELETE: api/Fornecedor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFornecedor([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fornecedor = await _context.Fornecedores.SingleOrDefaultAsync(m => m.FornecedorID == id);
            if (fornecedor == null)
            {
                return NotFound();
            }

            _context.Fornecedores.Remove(fornecedor);
            await _context.SaveChangesAsync();

            return Ok(fornecedor);
        }

        private bool FornecedorExists(int id)
        {
            return _context.Fornecedores.Any(e => e.FornecedorID == id);
        }
    }
}