namespace ftec.projetoweb.TrabalhoPedidos.apresentacao.Models
{
    public class LoginEnvioModel
    {
        public LoginEnvioModel()
        {
            this.email = string.Empty;
            this.senha = string.Empty;
        }

        public string email { get; set; }
        public string senha { get; set; }
    }
}
