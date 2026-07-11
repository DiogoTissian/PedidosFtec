using ftec.projetoweb.TrabalhoPedidos.apresentacao.Facades;
using ftec.projetoweb.TrabalhoPedidos.apresentacao.Models;
using Microsoft.AspNetCore.Mvc;

namespace ftec.projetoweb.TrabalhoPedidos.apresentacao.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly APIFacade _apiFacade;

        public CategoriaController(IConfiguration config)
        {
            var baseUrl = config["url_api_categoria"];
            _apiFacade = new APIFacade(baseUrl);
        }

        public IActionResult Index()
        {
            try
            {
                List<CategoriaModel> categorias = _apiFacade.GetCategorias();
                return View(categorias);
                //return View(DadosTeste.categorias);
            }
            catch (Exception e)
            {
                return View(new List<CategoriaModel>());
            }
        }

        public IActionResult Inserir(CategoriaModel categoria)
        {
            try
            {
                if (categoria.Id == 0)
                {
                    //categoria.Id = DadosTeste.categorias.Count + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second;
                    //DadosTeste.categorias.Add(categoria);
                    _apiFacade.PostCriarCategoria(categoria);
                }
                else
                {
                    //CategoriaModel aux = DadosTeste.categorias.Where(a => a.Id == categoria.Id).FirstOrDefault();
                    //DadosTeste.categorias.Remove(aux);
                    //DadosTeste.categorias.Add(categoria);
                    _apiFacade.PutAtualizarCategoria(categoria);
                }

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index");
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            try
            {
                CategoriaModel categoria = _apiFacade.GetCategorias().Where(a => a.Id == id).FirstOrDefault();

                if (categoria == null)
                {
                    throw new ApplicationException();
                }

                return View(categoria);
            }
            catch (Exception e)
            {
                return RedirectToAction("Index");
            }
        }

        public IActionResult Excluir(int id)
        {
            try
            {
                /*
                CategoriaModel aux = DadosTeste.categorias.Where(a => a.Id == id).FirstOrDefault();
                DadosTeste.categorias.Remove(aux);
                */

                _apiFacade.DeleteCategoria(id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index");
            }
        }
    }
}
