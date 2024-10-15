using Microsoft.AspNetCore.Mvc;
using PrimeiraAPP.Data;
using PrimeiraAPP.Models;

namespace PrimeiraAPP.Controllers
{
    public class AlunosController : Controller
    {
        private readonly AppDbContext _context;
        public AlunosController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Alunos.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,DataNascimento,Email,EmailConfirmacao,Avaliacao,Ativo")] Aluno aluno)
        {
            if(ModelState.IsValid)
            {
                _context.Alunos.Add(aluno);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(aluno);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);

            return View(aluno);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,DataNascimento,Email,EmailConfirmacao,Avaliacao,Ativo")] Aluno aluno)
        {
            if(id != aluno.Id)
            {
                return NotFound();
            }

            ModelState.Remove("EmailConfirmacao");

            if(ModelState.IsValid)
            {
                _context.Update(aluno);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(aluno);
        }

        public async Task<IActionResult> Details(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);

            return View(aluno);
        }
    }
}