namespace ftec.projetoweb.TrabalhoPedidos.apresentacao.Models
{
    public class MediaVendaPorProdutoModel
    {
        public Guid ProdutoId { get; set; }
        public string NomeProduto { get; set; }
        public int QuantidadeVendida { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal MediaVenda { get; set; }
    }
}
