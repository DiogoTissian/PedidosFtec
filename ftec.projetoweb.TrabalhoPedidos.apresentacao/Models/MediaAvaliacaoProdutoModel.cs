namespace ftec.projetoweb.TrabalhoPedidos.apresentacao.Models
{
    public class MediaAvaliacaoProdutoModel
    {
        public Guid ProdutoId { get; set; }
        public string NomeProduto { get; set; }
        public int QuantidadeAvaliacao { get; set; }
        public int SomaAvaliacao { get; set; }
        public int TotalAvaliacoes { get; set; }
        public decimal MediaAvaliacao { get; set; }
        public DateTime Data { get; set; }
    }
}
