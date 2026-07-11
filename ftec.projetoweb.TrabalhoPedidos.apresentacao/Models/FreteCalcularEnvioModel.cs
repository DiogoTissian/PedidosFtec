namespace ftec.projetoweb.TrabalhoPedidos.apresentacao.Models
{
    public class FreteCalcularEnvioModel
    {
        public Guid PedidoId { get; set; }
        public Guid EnderecoEntregaId { get; set; }
        public Guid TransportadoraId { get; set; }
        public string CepOrigem { get; set; } = string.Empty;
        public string CepDestino { get; set; } = string.Empty;
        public string Logradouro { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public string? Complemento { get; set; }
        public string Bairro { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
    }
}
