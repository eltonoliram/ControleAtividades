using System.Web.Mvc;
using ControleAtividades.Models;

namespace ControleAtividades.Controllers
{
    public class AtividadeController : Controller
    {
        private static Atividade _Atividade = new Atividade();
        // GET: Atividade
        public ActionResult Index()
        {
            return View(_Atividade.listarAtividades());
        }
        
    }
}