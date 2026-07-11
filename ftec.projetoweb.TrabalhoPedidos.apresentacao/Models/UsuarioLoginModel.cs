namespace ftec.projetoweb.TrabalhoPedidos.apresentacao.Models
{
    public class UsuarioLoginModel
    {
        public UsuarioLoginModel()
        {
            this.Email = string.Empty;
            this.Senha = string.Empty;
        }

        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
