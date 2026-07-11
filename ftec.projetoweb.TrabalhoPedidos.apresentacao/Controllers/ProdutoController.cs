using Microsoft.AspNetCore.Mvc;
using ftec.projetoweb.TrabalhoPedidos.apresentacao.Models;
using System.Collections.Generic;
using ftec.projetoweb.TrabalhoPedidos.apresentacao.Facades;

namespace ftec.projetoweb.TrabalhoPedidos.apresentacao.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly APIFacade _apiFacade;
        private readonly APIFacade _apiFacadeCategoria;

        public ProdutoController(IConfiguration config)
        {
            var baseUrl = config["url_api_produto"];
            var baseUrlCategoria = config["url_api_categoria"];
            _apiFacade = new APIFacade(baseUrl);
            _apiFacadeCategoria = new APIFacade(baseUrlCategoria);
        }

        public IActionResult Index()
        {
            try
            {
                List<ProdutoModel> produtos = _apiFacade.ListarProdutos();

                foreach (ProdutoModel produto in produtos)
                {
                    if (produto.QuantidadeEstoque <= 0)
                    {
                        produto.Disponivel = false;
                    }
                    else
                    {
                        produto.Disponivel = true;
                    }
                }

                ProdutosListagemModel produtosListagem = new ProdutosListagemModel();
                produtosListagem.Produtos = produtos;

                return View(produtosListagem);
            }
            catch (Exception e)
            {
				return View(null);
			}
        }

        public IActionResult Edit(Guid id)
        {
            try
            {
                ProdutoModel produto = _apiFacade.BuscarProduto(id);
                ViewBag.categorias = _apiFacadeCategoria.GetCategorias();
                return View(produto);
            }
            catch (Exception e)
            {
                return RedirectToAction("Index");
            }
        }

        public IActionResult Create()
        {
            List<CategoriaModel> categorias = _apiFacadeCategoria.GetCategorias();
            return View(categorias);
        }

        public IActionResult Visualizar(Guid id)
        {
            try
            {
                ProdutoModel produto = _apiFacade.BuscarProduto(id);
                ViewBag.categoria = "sem categoria";

                if (produto.IdCategoria != null && produto.IdCategoria > 0)
                {
                    CategoriaModel categoria = _apiFacadeCategoria.GetCategorias().Where(a => a.Id == produto.IdCategoria).FirstOrDefault();

                    if (categoria != null)
                    {
                        ViewBag.categoria = categoria.Nome;
                    }
                }
                
                return View(produto);
            }
            catch (Exception e)
            {
				return RedirectToAction("Index");
			}
        }

        public IActionResult Delete(Guid id)
        {
            try
            {
                _apiFacade.DeletarProduto(id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
				return RedirectToAction("Index");
			}
        }

        public IActionResult Inserir(ProdutoModel produto)
        {
            try
            {
                if (produto.Id != null && produto.Id != Guid.Empty)
                {
                    //ProdutoModel aux = DadosTeste.ProdutosListagem.Produtos.Where(a => a.Id == produto.Id).FirstOrDefault();
                    //DadosTeste.ProdutosListagem.Produtos.Remove(aux);
                    //DadosTeste.ProdutosListagem.Produtos.Add(produto);

                    _apiFacade.AtualizarProduto(produto);
                }
                else
                {
                    produto.Id = Guid.NewGuid();
                    produto.Disponivel = true;
                    _apiFacade.CriarProduto(produto);
                    //DadosTeste.ProdutosListagem.Produtos.Add(produto);
                }

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
				return RedirectToAction("Index");
			}
        }
    }
}
