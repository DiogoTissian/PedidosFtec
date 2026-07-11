using Microsoft.AspNetCore.Mvc;
using ftec.projetoweb.TrabalhoPedidos.apresentacao.Models;
using System.Collections.Generic;
using ftec.projetoweb.TrabalhoPedidos.apresentacao.Facades;

namespace ftec.projetoweb.TrabalhoPedidos.apresentacao.Controllers
{
    public class AvaliacaoController : Controller
    {
        private readonly APIFacade _apiFacade;

        public AvaliacaoController(IConfiguration config)
        {
            var baseUrl = config["url_api_avaliacao"];
            _apiFacade = new APIFacade(baseUrl);
        }

        public IActionResult AvaliacoesProduto(Guid produtoId)
        {
            try
            {
                ViewBag.produtoId = produtoId;

                //return View(DadosTeste.avaliacoes.Where(a => a.idProduto == produtoId).ToList());

                List<AvaliacaoModel> avaliacoes = _apiFacade.GetAvaliacoes(produtoId);

                return View(avaliacoes);
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
                AvaliacaoModel avaliacao = _apiFacade.GetAvaliacao(id);
                return View(avaliacao);
                //return View(DadosTeste.avaliacoes.Where(a => a.Id == id).FirstOrDefault());
            }
            catch (Exception e)
            {
                return RedirectToAction("AvaliacoesProduto");
            }
        }

        public IActionResult Create(Guid idProduto)
        {
            return View(new AvaliacaoModel()
            {
                idCliente = DadosTeste.usuarioLogado.id,
                idProduto = idProduto
            });
        }

        public IActionResult Inserir(AvaliacaoModel avaliacao)
        {
            try
            {
                if (avaliacao.Id != null && avaliacao.Id != Guid.Empty)
                {
                    //AvaliacaoModel aux = DadosTeste.avaliacoes.Where(a => a.Id == avaliacao.Id).FirstOrDefault();
                    //DadosTeste.avaliacoes.Remove(aux);
                    //DadosTeste.avaliacoes.Add(avaliacao);

                    _apiFacade.PutAtualizarAvaliacao(avaliacao);
                }
                else
                {
                    //avaliacao.Id = Guid.NewGuid();
                    //DadosTeste.avaliacoes.Add(avaliacao);

                    _apiFacade.PostCriarAvaliacao(avaliacao);
                }

                return RedirectToAction("AvaliacoesProduto", new { produtoId = avaliacao.idProduto });
            }
            catch (Exception e)
            {
				return RedirectToAction("AvaliacoesProduto", new { produtoId = avaliacao.idProduto });
			}
        }

        public IActionResult Remover(Guid id, Guid produtoId)
        {
            try
            {
                //AvaliacaoModel aux = DadosTeste.avaliacoes.Where(a => a.Id == id).FirstOrDefault();
                //DadosTeste.avaliacoes.Remove(aux);

                _apiFacade.DeleteAvaliacao(id);

				return RedirectToAction("AvaliacoesProduto", new { produtoId = produtoId });
			}
            catch (Exception e)
            {
				return RedirectToAction("AvaliacoesProduto", new { produtoId = produtoId });
			}
        }
    }
}
