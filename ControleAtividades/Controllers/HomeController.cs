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

        public ActionResult AdicionaAtividade()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdicionaAtividade(Atividade_mdl _Atividade_mdl)
        {
            _Atividade.criaAtividade(_Atividade_mdl);
            return View();
        }


        public ViewResult DeletaUsuario(Atividade_mdl _Atividade_mdl)
        {
            return View(_Atividade.apagaAtividade(_Atividade_mdl));

        }

        [HttpPost]
        public RedirectToRouteResult DeletaUsuario(Atividade_mdl _Atividade_mdl, FormCollection collection)
        {
            _Atividade.apagaAtividade(_Atividade_mdl);
            return RedirectToAction("Index");
        }
    }
}