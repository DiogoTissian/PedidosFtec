namespace ftec.projetoweb.TrabalhoPedidos.apresentacao.Models
{
    public class ProdutosListagemModel
    {
        public ProdutosListagemModel()
        {
            this.Categorias = new List<CategoriaModel>();
            this.Produtos = new List<ProdutoModel>();
        }

        public List<CategoriaModel> Categorias { get; set; }
        public List<ProdutoModel> Produtos { get; set; }
    }
}
