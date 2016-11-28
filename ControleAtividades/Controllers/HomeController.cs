using System.Web.Mvc;
using ControleAtividades.Models;


namespace ControleAtividades.Controllers
{
    public class HomeController : Controller
    {
        private static Atividade _Atividade = new Atividade();
        public ActionResult Index()
        {
            return View(_Atividade.listarAtividades());
        }
    }
}