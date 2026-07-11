namespace ftec.projetoweb.TrabalhoPedidos.apresentacao.Models
{
    public static class DadosTeste
    {
        public static string accesstokenUsuario = string.Empty;
        public static List<AvaliacaoModel> avaliacoes = GerarAvaliacoes();
        
        
        public static List<CategoriaModel> categorias = GerarCategorias();


        public static ProdutosListagemModel ProdutosListagemAux = GerarProdutosListagem();
        public static ProdutosListagemModel ProdutosListagem = new ProdutosListagemModel();


        public static List<PagamentoModel> pagamentos = GerarPagamentos();


        public static List<PedidoModel> pedidosAux = GerarPedidos();
        public static List<PedidoModel> pedidos = new List<PedidoModel>();

        public static List<UsuarioModel> usuarios = new List<UsuarioModel>();
        public static UsuarioModel usuarioLogado = null;

        public static List<PedidoModel> GerarPedidos()
        {
            List<PedidoModel> retorno = new List<PedidoModel>();

            retorno.Add(new PedidoModel()
            {
                CEPEnderecoEntrega = "cep1",
                DataPedido = DateTime.Now,
                Id = Guid.NewGuid(),
                NumeroEnderecoEntrega = "num1",
                StatusPedido = 1,
                UsuarioId = Guid.Empty,
                ValorTotal = 123,
                ProdutosModel = new List<ProdutoPedidoModel>()
                {
                }
            });

            return retorno;
        }

        private static List<PagamentoModel> GerarPagamentos()
        {
            List<PagamentoModel> retorno = new List<PagamentoModel>();

            retorno.Add(new PagamentoModel()
            {
                CpfCliente = "1",
                CriadoEm = DateTime.Now,
                DataPagamento = DateTime.Now,
                MetodoPagamento = PagamentoModel.MetodoPagamento1.Pix,
                NumeroParcelas = 1,
                PagamentoId = Guid.NewGuid(),

                PedidoId = Guid.NewGuid(),
                
                StatusPagamento = PagamentoModel.StatusPagamento1.Pago,
                ValorFrete = 100,
                ValorParcela = 100,
                ValorTotal = 10000
            });

            return retorno;
        }

        private static ProdutosListagemModel GerarProdutosListagem()
        {
            ProdutosListagemModel retorno = new ProdutosListagemModel();

            retorno.Categorias = new List<CategoriaModel>();

            retorno.Produtos = new List<ProdutoModel>();
            retorno.Produtos.Add(new ProdutoModel()
            {
                Id = Guid.Parse("db81478e-a57f-4276-ae50-5d133b6294a4"),
                Disponivel = true,
                Excluido = false,
                Nome = "prod1",
                Preco = 12,
            });

            retorno.Produtos.Add(new ProdutoModel()
            {
                Id = Guid.Parse("a26d84e6-f962-48dd-9ea1-9ab354f1b6c7"),
                Disponivel = true,
                Excluido = false,
                Nome = "prod2",
                Preco = 34,
            });

            return retorno;
        }

        public static List<AvaliacaoModel> GerarAvaliacoes()
        {
            List<AvaliacaoModel> retorno = new List<AvaliacaoModel>();

            retorno.Add(new AvaliacaoModel()
            {
                Id = Guid.NewGuid(),
                idCliente = Guid.NewGuid(),
                Descricao = "Muito bom 1",
                idProduto = Guid.Parse("db81478e-a57f-4276-ae50-5d133b6294a4"),
                Nota = 10
            });
            retorno.Add(new AvaliacaoModel()
            {
                Id = Guid.NewGuid(),
                idCliente = Guid.NewGuid(),
                Descricao = "Muito bom 2",
                idProduto = Guid.Parse("a26d84e6-f962-48dd-9ea1-9ab354f1b6c7"),
                Nota = 9
            });

            return retorno;
        }

        public static List<CategoriaModel> GerarCategorias()
        {
            List<CategoriaModel> retorno = new List<CategoriaModel>();

            retorno.Add(new CategoriaModel()
            {
                Id = 1,
                Descricao = "Desc1",
                Nome = "Nome1"
            });

            retorno.Add(new CategoriaModel()
            {
                Id = 2,
                Descricao = "Desc2",
                Nome = "Nome2"
            });

            return retorno;
        }
    }
}
