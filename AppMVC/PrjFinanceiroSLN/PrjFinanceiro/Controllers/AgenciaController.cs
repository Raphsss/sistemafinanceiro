using Microsoft.AspNetCore.Mvc;
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

    }
}
