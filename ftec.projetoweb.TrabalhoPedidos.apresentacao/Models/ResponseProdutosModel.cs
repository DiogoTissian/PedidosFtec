namespace ftec.projetoweb.TrabalhoPedidos.apresentacao.Models
{
    public class ResponseProdutosModel<T>
    {
        public bool Sucesso { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
    }
}
