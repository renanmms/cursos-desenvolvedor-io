using Microsoft.AspNetCore.Mvc;
using PrimeiraAPP.Models;

namespace PrimeiraAPP.ViewComponents
{
    public class SaudacaoAlunoViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var aluno = new Aluno { Nome = "Renan", DataNascimento = new DateTime(1999, 12, 04)};

            return View(aluno);
        }
    }
}
