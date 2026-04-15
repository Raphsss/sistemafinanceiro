using Microsoft.AspNetCore.Mvc;
using PrjFinanceiro.Data;
using PrjFinanceiro.Models;
using System.Linq;

namespace PrjFinanceiro.Controllers
{
    public class AgenciaController : Controller
    {
        private readonly AppDbContext _context;

        public AgenciaController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var agencias = _context.Agencia.ToList();
            ViewBag.nomesenai = "SENAI";


            return View(agencias); // Passa a lista para a View
        }

        // GET: Agencia/Details/x
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agencia = _context.Agencia.FirstOrDefault(agencia => agencia.Codigo == id);

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
        public IActionResult Create(Agencia agencia)
        {
            if (!ModelState.IsValid)
            {
                return View(agencia);
            }

            _context.Agencia.Add(agencia);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: Agencia/Edit/x
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var agencia = _context.Agencia.FirstOrDefault(agencia => agencia.Codigo == id);

            if (agencia == null)
            {
                return NotFound();
            }

            return View(agencia);
        }

        // POST: Agencia/Edit/x
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Agencia agencia)
        {
            if (!ModelState.IsValid)
            {
                return View(agencia);
            }

            _context.Agencia.Update(agencia);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}