using Microsoft.AspNetCore.Mvc;
using PrjFinanceiro.Data;
using PrjFinanceiro.Models;
using System.Linq;

namespace PrjFinanceiro.Controllers
{

    public class FuncionarioController : Controller
    {
        private readonly AppDbContext _context;

        public FuncionarioController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var Funcionarios = _context.Funcionario.ToList();
            ViewBag.nomesenai = "SENAI";


            return View(Funcionarios); // Passa a lista para a View
        }

        // GET: Funcionario/Details/x
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Funcionario = _context.Funcionario.FirstOrDefault(Funcionario => Funcionario.Codigo == id);

            if (Funcionario == null)
            {
                return NotFound();
            }

            return View(Funcionario);
        }

        // GET: Funcionario/Create
        public IActionResult Create()
        {
            return View(); // Views/Aluno/Create.cshtml, retorna este caminho por convernção
        }

        // POST: Funcionario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Funcionario Funcionario)
        {
            if (!ModelState.IsValid)
            {
                return View(Funcionario);
            }

            _context.Funcionario.Add(Funcionario);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: Funcionario/Edit/x
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Funcionario = _context.Funcionario.FirstOrDefault(Funcionario => Funcionario.Codigo == id);

            if (Funcionario == null)
            {
                return NotFound();
            }

            return View(Funcionario);
        }

        // POST: Funcionario/Edit/x
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Funcionario Funcionario)
        {
            if (!ModelState.IsValid)
            {
                return View(Funcionario);
            }

            _context.Funcionario.Update(Funcionario);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: Funcionario/Delete/x
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Funcionario = _context.Funcionario.FirstOrDefault(Funcionario => Funcionario.Codigo == id);
            if (Funcionario == null)
            {
                return NotFound();
            }
            return View(Funcionario);
        }

        // POST: Funcionario/Delete/x
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var Funcionario = _context.Funcionario.FirstOrDefault(Funcionario => Funcionario.Codigo == id);
            if (Funcionario == null)
            {
                return NotFound();
            }

            _context.Funcionario.Remove(Funcionario);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

