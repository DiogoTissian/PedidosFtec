using System.ComponentModel.DataAnnotations.Schema;

namespace ftec.projetoweb.TrabalhoPedidos.apresentacao.Models
{
    public class CategoriaModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}
