namespace ftec.projetoweb.TrabalhoPedidos.apresentacao.Models
{
    public class PagamentoModel
    {
        public enum MetodoPagamento1
        {
            CartaoCredito = 1,
            CartaoDebito = 2,
            Pix = 3,
            Boleto = 4
        }

        public enum StatusPagamento1
        {
            Pendente = 1,
            Processando = 2,
            Pago = 3,
            Recusado = 4,
            Cancelado = 5,
        }

        public Guid PagamentoId { get; set; }
        public Guid PedidoId { get; set; }
        public string CpfCliente { get; set; }
        public decimal ValorProdutos { get; set; }
        public decimal ValorFrete { get; set; }
        public decimal ValorTotal { get; set; }
        public int NumeroParcelas { get; set; }
        public decimal ValorParcela { get; set; }
        public MetodoPagamento1 MetodoPagamento { get; set; }
        public StatusPagamento1 StatusPagamento { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime? DataPagamento { get; set; }
    }
}
