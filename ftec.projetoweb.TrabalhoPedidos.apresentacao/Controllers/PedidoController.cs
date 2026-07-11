using Microsoft.AspNetCore.Mvc;
using ftec.projetoweb.TrabalhoPedidos.apresentacao.Models;
using System.Collections.Generic;
using ftec.projetoweb.TrabalhoPedidos.apresentacao.Facades;

namespace ftec.projetoweb.TrabalhoPedidos.apresentacao.Controllers
{
    public class PedidoController : Controller
    {
        private readonly APIFacade _apiFacade;
        private readonly APIFacade _apiFacadeProduto;

        public PedidoController(IConfiguration config)
        {
            var baseUrl = config["url_api_pedido"];
            var baseUrlProduto = config["url_api_produto"];
            _apiFacade = new APIFacade(baseUrl);
            _apiFacadeProduto = new APIFacade(baseUrlProduto);
        }

        public IActionResult Index()
        {
            try
            {
                //List<PedidoModel> pedidos = _apiFacade.ProcurarPedidos(Guid.Parse("e5ae8dea-6cc4-485c-b2ae-cf92cde63979"));
                List<PedidoModel> pedidos = _apiFacade.ProcurarPedidos(DadosTeste.usuarioLogado.id);
                return View(pedidos);
            }
            catch (Exception e)
            {
				return View(null);
			}
        }

        public IActionResult Create(Guid produtoId)
        {
            try
            {
                //return View(DadosTeste.ProdutosListagem.Produtos.Where(a => a.Id == produtoId).FirstOrDefault());

                ProdutoModel produto = _apiFacadeProduto.BuscarProduto(produtoId);
                return View(produto);
            }
            catch (Exception e)
            {
                return RedirectToAction("Index");
            }
        }

        public IActionResult Remover(Guid id)
        {
            try
            {
                //PedidoModel aux = DadosTeste.pedidos.Where(a => a.Id == id).FirstOrDefault();
                //DadosTeste.pedidos.Remove(aux);

                _apiFacade.RemoverPedido(id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
				return RedirectToAction("Index");
			}
        }

        [HttpPost]
        public IActionResult Criar(PedidoModel pedido)
        {
            try
            {
                pedido.Id = Guid.NewGuid();
                pedido.UsuarioId = DadosTeste.usuarioLogado.id;
                //pedido.UsuarioId = Guid.NewGuid();

                pedido.ProdutosModel.FirstOrDefault().Id = Guid.NewGuid();
                pedido.ProdutosModel.FirstOrDefault().PedidoId = pedido.Id;
                pedido.ProdutosModel.FirstOrDefault().Preco = pedido.ValorTotal / pedido.Qtd;
                pedido.ProdutosModel.FirstOrDefault().Quantidade = pedido.Qtd;

                _apiFacade.CriarPedido(pedido);

                //DadosTeste.pedidos.Add(pedido);

                //atualizar no banco o produto com a nova quantidade
                //ProdutoModel aux = DadosTeste.ProdutosListagem.Produtos.Where(a => a.Id == pedido.ProdutosModel.FirstOrDefault().Id).FirstOrDefault();
                //DadosTeste.ProdutosListagem.Produtos.Remove(aux);

                //aux.QuantidadeEstoque -= pedido.Qtd;
                //DadosTeste.ProdutosListagem.Produtos.Add(aux);

                //pedido.ProdutosModel.Clear();
                //pedido.ProdutosModel.Add(aux);

                ProdutoModel aux = _apiFacadeProduto.BuscarProduto(pedido.ProdutosModel.FirstOrDefault().Id);
                aux.QuantidadeEstoque -= pedido.Qtd;

                _apiFacadeProduto.AtualizarProduto(aux);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
				return RedirectToAction("Index");
			}
        }
    }
}
