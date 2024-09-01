using Microsoft.AspNetCore.Mvc;
using PrimeiraAPP.Data;
using PrimeiraAPP.Models;

namespace PrimeiraAPP.Controllers
{
    public class TesteEFController : Controller
    {
        private readonly AppDbContext Db;
        public TesteEFController(AppDbContext db)
        {
            Db = db;    
        }

        public IActionResult Index()
        {
            var aluno = new Aluno
            {
                Nome = "Renan",
                Email = "hello@renan.com",
                DataNascimento = new DateTime(1999, 12, 4),
                Ativo = true,
                Avaliacao = 5
            };

            Db.Alunos.Add(aluno);
            Db.SaveChanges();

            return Content("");
        }
    }
}
