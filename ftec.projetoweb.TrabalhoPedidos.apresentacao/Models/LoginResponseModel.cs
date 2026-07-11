namespace ftec.projetoweb.TrabalhoPedidos.apresentacao.Models
{
    public record LoginResponseModel(
    string AccessToken,
    DateTime AccessTokenExpiresIn,
    string RefreshToken,
    DateTime RefreshTokenExpiresIn,
    Guid UsuarioId,
    string Nome,
    string Email);
}
