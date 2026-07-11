namespace ftec.projetoweb.TrabalhoPedidos.apresentacao.Models
{
    public class EstatisticaModel
    {
        public EstatisticaModel()
        {
            this.EstatisticaResumo = new List<EstatisticaResumoModel>();
            this.MediaAvaliacaoProduto = new List<MediaAvaliacaoProdutoModel>();
            this.MediaVendaPorProduto = new List<MediaVendaPorProdutoModel>();
            this.MediaVendasClientes = new List<MediaVendasClientesModel>();
            this.TotalVendas = new TotalVendasModel();
        }

        public List<EstatisticaResumoModel> EstatisticaResumo { get; set; }
        public List<MediaAvaliacaoProdutoModel> MediaAvaliacaoProduto { get; set; }
        public List<MediaVendaPorProdutoModel> MediaVendaPorProduto { get; set; }
        public List<MediaVendasClientesModel> MediaVendasClientes { get; set; }
        public TotalVendasModel TotalVendas { get; set; }
    }
}
