namespace ftec.projetoweb.TrabalhoPedidos.apresentacao.Models
{
    public class PedidoModel
    {
        public PedidoModel()
        {
            this.Id = Guid.Empty;
            this.UsuarioId = Guid.Empty;
            this.ProdutosModel = new List<ProdutoPedidoModel>();
            this.DataPedido = DateTime.MinValue;
            this.StatusPedido = 0;
            this.ValorTotal = 0;
            this.CEPEnderecoEntrega = string.Empty;
            this.NumeroEnderecoEntrega = string.Empty;
            this.Qtd = 0;
        }

        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; }
        public List<ProdutoPedidoModel> ProdutosModel { get; set; }
        public DateTime DataPedido { get; set; }
        public int StatusPedido { get; set; }
        public int Qtd { get; set; }
        public decimal ValorTotal { get; set; }
        public string CEPEnderecoEntrega { get; set; }
        public string NumeroEnderecoEntrega { get; set; }
    }
}
