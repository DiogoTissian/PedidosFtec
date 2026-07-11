using Microsoft.AspNetCore.Mvc;
using ftec.projetoweb.TrabalhoPedidos.apresentacao.Models;
using ftec.projetoweb.TrabalhoPedidos.apresentacao.Facades;

namespace ftec.projetoweb.TrabalhoPedidos.apresentacao.Controllers
{
    public class EstatisticaController : Controller
    {
        private readonly APIFacade _apiFacade;

        public EstatisticaController(IConfiguration config)
        {
            var baseUrl = config["url_api_estatistica"];
            _apiFacade = new APIFacade(baseUrl);
        }

        public IActionResult Index()
        {
            try
            {
                EstatisticaModel estatistica = new EstatisticaModel();
                estatistica.EstatisticaResumo = _apiFacade.GetPainelDiario();

                /*
                estatistica.EstatisticaResumo = new List<EstatisticaResumoModel>();
                estatistica.EstatisticaResumo.Add(new EstatisticaResumoModel()
                {
                    Titulo = "t1",
                    Valor = "v1",
                    Detalhe = "d1"
                });
                estatistica.EstatisticaResumo.Add(new EstatisticaResumoModel()
                {
                    Titulo = "t2",
                    Valor = "v2",
                    Detalhe = "d2"
                });
                */

                estatistica.MediaAvaliacaoProduto = _apiFacade.GetMediaAvaliacaoProduto();

                /*
                estatistica.MediaAvaliacaoProduto = new List<MediaAvaliacaoProdutoModel>();
                estatistica.MediaAvaliacaoProduto.Add(new MediaAvaliacaoProdutoModel()
                {
                    Data = DateTime.Now,
                    MediaAvaliacao = 11,
                    NomeProduto = "prod1",
                    ProdutoId = Guid.Empty,
                    QuantidadeAvaliacao = 12,
                    SomaAvaliacao = 123,
                    TotalAvaliacoes = 345
                });
                estatistica.MediaAvaliacaoProduto.Add(new MediaAvaliacaoProdutoModel()
                {
                    Data = DateTime.Now,
                    MediaAvaliacao = 22,
                    NomeProduto = "prod2",
                    ProdutoId = Guid.Empty,
                    QuantidadeAvaliacao = 23,
                    SomaAvaliacao = 444,
                    TotalAvaliacoes = 555
                });
                */

                estatistica.MediaVendaPorProduto = _apiFacade.GetMediaVendaPorProduto();

                /*
                estatistica.MediaVendaPorProduto = new List<MediaVendaPorProdutoModel>();
                estatistica.MediaVendaPorProduto.Add(new MediaVendaPorProdutoModel()
                {
                    MediaVenda = 12,
                    NomeProduto = "prod1",
                    ProdutoId = Guid.Empty,
                    QuantidadeVendida = 334,
                    ValorTotal = 789
                });
                estatistica.MediaVendaPorProduto.Add(new MediaVendaPorProdutoModel()
                {
                    MediaVenda = 45,
                    NomeProduto = "prod2",
                    ProdutoId = Guid.Empty,
                    QuantidadeVendida = 667,
                    ValorTotal = 444
                });
                */

                estatistica.MediaVendasClientes = _apiFacade.GetMediaVendasClientes();
                
                /*
                estatistica.MediaVendasClientes = new List<MediaVendasClientesModel>();
                estatistica.MediaVendasClientes.Add(new MediaVendasClientesModel()
                {
                    MediaVendas = 346,
                    NomeCliente = "cli1",
                    QuantidadePedidos = 677,
                    TotalVendas = 990
                });
                estatistica.MediaVendasClientes.Add(new MediaVendasClientesModel()
                {
                    MediaVendas = 607,
                    NomeCliente = "cli2",
                    QuantidadePedidos = 404,
                    TotalVendas = 101
                });
                */

                estatistica.TotalVendas = _apiFacade.GetTotalVendas();

                /*
                estatistica.TotalVendas = new TotalVendasModel()
                {
                    TotalPedidos = 10,
                    TotalVendas = 20
                };
                */

                return View(estatistica);
            }
            catch (Exception e)
            {
                return View(null);
            }
        }
    }
}
