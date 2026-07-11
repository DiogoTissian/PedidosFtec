namespace ftec.projetoweb.TrabalhoPedidos.apresentacao.Models
{
    public record UsuarioResponseModel(
    Guid Id,
    string Nome,
    string? NomeFantasia,
    string Email,
    string Documento,
    DateOnly? DataNascimento,
    string? Telefone,
    DateTime CriadoEm);
}
