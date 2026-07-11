namespace ftec.projetoweb.TrabalhoPedidos.apresentacao.Models
{
    public class UsuarioModel
    {
        public UsuarioModel()
        {
            this.id = Guid.Empty;
            this.nome = string.Empty;
            this.senha = string.Empty;
            this.email = string.Empty;
            this.documento = string.Empty;
            this.telefone = string.Empty;
            this.tipoPessoa = 0;
            this.funcao = 0;
        }

        public Guid id { get; set; }
        public string nome { get; set; }
        public string senha { get; set; }
        public string email { get; set; }
        public string documento { get; set; }
        public DateOnly dataNascimento { get; set; }
        public string telefone { get; set; }
        public DateTime criadoEm { get; set; }
        public int tipoPessoa { get; set; }
        public int funcao { get; set; }
    }
}
