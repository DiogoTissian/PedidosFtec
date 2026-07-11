using ftec.projetoweb.TrabalhoPedidos.apresentacao.Facades;
using ftec.projetoweb.TrabalhoPedidos.apresentacao.Models;
using Microsoft.AspNetCore.Mvc;

namespace ftec.projetoweb.TrabalhoPedidos.apresentacao.Controllers
{
    public class PagamentoController : Controller
    {
        private readonly APIFacade _apiFacade;
        private readonly APIFacade _apiFacadePedido;
        private readonly APIFacade _apiFacadeFrete;
        private readonly APIFacade _apiFacadeTransportadora;

        public PagamentoController(IConfiguration config)
        {
            var baseUrl = config["url_api_pagamento"];
            var baseUrlPedido = config["url_api_pedido"];
            var baseUrlFrete = config["url_api_frete"];
            var baseUrlTransportadora = config["url_api_transportadora"];
            _apiFacade = new APIFacade(baseUrl);
            _apiFacadePedido = new APIFacade(baseUrlPedido);
            _apiFacadeFrete = new APIFacade(baseUrlFrete);
            _apiFacadeTransportadora = new APIFacade(baseUrlTransportadora);
        }

        public IActionResult MostrarPagamento(Guid pedidoId)
        {
            try
            {
                //PedidoModel ped = DadosTeste.pedidos.Where(a => a.Id == pedidoId).FirstOrDefault();
                //ped.ValorTotal = ped.ProdutosModel.FirstOrDefault().Preco * ped.Qtd;
                //return View(ped);

                //PedidoModel pedido = DadosTeste.pedidos.Where(a => a.Id == pedidoId).FirstOrDefault(); //facade pedido
                PedidoModel pedido = _apiFacadePedido.ProcurarPedido(pedidoId);
                if (pedido != null)
                {
                    pedido.ValorTotal = pedido.ValorTotal;
                }

                ViewBag.transportadoras = _apiFacadeTransportadora.BuscarTransportadoras();

                return View(pedido);
            }
            catch (Exception e)
            {
				return RedirectToAction("Index");
			}
        }

        public IActionResult Pagar(PagamentoModel pagamento)
        {
            try
            {
                //DadosTeste.pagamentos.Add(pagamento);

                _apiFacade.PostAdicionarPagamento(pagamento);

                var atualizarPedido = new
                {
                    id = pagamento.PedidoId,
                    statusPedido = 1
                };

                _apiFacadePedido.AtualizarStatusPedido(atualizarPedido);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
				return RedirectToAction("Index");
			}
        }

        public IActionResult CalcularFrete(FreteCalcularEnvioModel freteCalcularEnvio)
        {
            try
            {
                freteCalcularEnvio.EnderecoEntregaId = Guid.NewGuid();
                FreteResultadoModel freteResultado = _apiFacadeFrete.CalcularFrete(freteCalcularEnvio);
                return Json(new { sucesso = true, ValorFrete = freteResultado.ValorFrete.ToString("F2") });
            }
            catch (Exception e)
            {
                return Json(new { sucesso = false });
            }
        }

        public IActionResult DetalhesPagamento(Guid id)
        {
            try
            {
                PagamentoModel pagamento = _apiFacade.GetPagamento(id);
                return View(pagamento);
            }
            catch (Exception e)
            {
				return RedirectToAction("Index");
			}
        }

        public IActionResult Index()
        {
            try
            {
                //return View(DadosTeste.pagamentos);
                List<PagamentoModel> pagamentosHistorico = _apiFacade.GetPagamentos();

				if (DadosTeste.usuarioLogado.funcao == 0)
                {
					List<PedidoModel> pedidos = _apiFacadePedido.ProcurarPedidos(DadosTeste.usuarioLogado.id);

                    if (pedidos != null && pedidos.Count > 0)
                    {
						pagamentosHistorico = _apiFacade.GetPagamentos().Where(a => pedidos.Select(a => a.Id).ToList().Contains(a.PedidoId)).ToList();
					}
				}

                return View(pagamentosHistorico);
            }
            catch (Exception e)
            {
				return View(null);
			}
        }
    }
}
