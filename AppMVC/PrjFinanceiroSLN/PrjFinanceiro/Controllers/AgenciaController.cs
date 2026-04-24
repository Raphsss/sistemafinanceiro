using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrjFinanceiro.Data;
using PrjFinanceiro.Models;
using System.Linq;
using System.Threading.Tasks;

namespace PrjFinanceiro.Controllers
{
    public class AgenciaController : Controller
    {
        private readonly AppDbContext _context;

        public AgenciaController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var agencias = await _context.Agencia.ToListAsync();
            ViewBag.nomesenai = "SENAI";


            return View(agencias); // Passa a lista para a View
        }

        // GET: Agencia/Details/x
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agencia = await _context.Agencia.FirstOrDefaultAsync(agencia => agencia.Codigo == id);

            if (agencia == null)
            {
                return NotFound();
            }

            return View(agencia);
        }

        // GET: Agencia/Create
        public IActionResult Create()
        {
            return View(); // Views/Aluno/Create.cshtml, retorna este caminho por convernção
        }

        // POST: Agencia/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Agencia agencia)
        {
            if (!ModelState.IsValid)
            {
                return View(agencia);
            }

            await _context.Agencia.AddAsync(agencia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Agencia/Edit/x
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agencia = await _context.Agencia
                .FirstOrDefaultAsync(a => a.Codigo == id);

            if (agencia == null)
            {
                return NotFound();
            }

            return View(agencia);
        }

        // POST: Agencia/Edit/x
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Agencia agenciaForm)
        {
            if (id != agenciaForm.Codigo)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(agenciaForm);
            }

            var agenciaEntity = await _context.Agencia
                .FirstOrDefaultAsync(a => a.Codigo == id);

            if (agenciaEntity == null)
            {
                return NotFound();
            }

            agenciaEntity.Nome = agenciaForm.Nome;
            agenciaEntity.Cidade = agenciaForm.Cidade;
            agenciaEntity.EstadoUF = agenciaForm.EstadoUF;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Agencia/Delete/x
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var agencia = await _context.Agencia
                .FirstOrDefaultAsync(agencia => agencia.Codigo == id);
            if (agencia == null)
            {
                return NotFound();
            }
            return View(agencia);
        }

        // POST: Agencia/Delete/x
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var agencia = await _context.Agencia
                .FirstOrDefaultAsync(agencia => agencia.Codigo == id);
            if (agencia == null)
            {
                return NotFound();
            }

            _context.Agencia.Remove(agencia);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}