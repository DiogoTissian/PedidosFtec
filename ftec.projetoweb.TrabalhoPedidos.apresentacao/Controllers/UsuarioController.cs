using ftec.projetoweb.TrabalhoPedidos.apresentacao.Facades;
using ftec.projetoweb.TrabalhoPedidos.apresentacao.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ftec.projetoweb.TrabalhoPedidos.apresentacao.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly APIFacade _apiFacade;
        private readonly APIFacade _apiFacadeUsuario;

        public UsuarioController(IConfiguration config)
        {
            var baseUrl = config["url_api_autenticacao"];
            var baseUrlUsuario = config["url_api_autenticacao"];
            _apiFacade = new APIFacade(baseUrl);
            _apiFacadeUsuario = new APIFacade(baseUrlUsuario);
        }

        public IActionResult Index(bool usuarioEncontrado = true)
        {
            ViewBag.usuarioEncontrado = usuarioEncontrado;
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Login(UsuarioLoginModel usuario)
        {
            try
            {
                /*
                UsuarioModel usuarioBusca = DadosTeste.usuarios.Where(a => a.email == usuario.Email && a.senha == usuario.Senha).FirstOrDefault();
                if (usuarioBusca != null)
                {
                    DadosTeste.usuarioLogado = usuarioBusca;
                    return RedirectToAction("Index", "Home");
                }
                */

                LoginEnvioModel loginEnvio = new LoginEnvioModel()
                {
                    email = usuario.Email,
                    senha = usuario.Senha
                };

				LoginResponseModel loginResponse = _apiFacade.Login(loginEnvio);

                if (loginResponse != null)
                {
                    DadosTeste.accesstokenUsuario = loginResponse.AccessToken;

                    UsuarioModel usuarioModel = _apiFacadeUsuario.GetUsuario(loginResponse.UsuarioId, loginResponse.AccessToken);

                    if (usuarioModel != null)
                    {
                        DadosTeste.usuarioLogado = usuarioModel;

                        return RedirectToAction("Index", "Produto");
                    }
                }

                return RedirectToAction("Index", new { usuarioEncontrado = false });
            }
            catch (Exception e)
            {
				return RedirectToAction("Index", new { usuarioEncontrado = false });
			}
        }

        public IActionResult LoginAtualizacao(string email, string senha)
        {
            try
            {
                LoginEnvioModel loginEnvio = new LoginEnvioModel()
                {
                    email = email,
                    senha = senha
                };

                LoginResponseModel loginResponse = _apiFacade.Login(loginEnvio);

                if (loginResponse != null)
                {
                    DadosTeste.accesstokenUsuario = loginResponse.AccessToken;

                    UsuarioModel usuarioModel = _apiFacadeUsuario.GetUsuario(loginResponse.UsuarioId, loginResponse.AccessToken);

                    if (usuarioModel != null)
                    {
                        DadosTeste.usuarioLogado = usuarioModel;

                        return RedirectToAction("Index", "Produto");
                    }
                }

                return RedirectToAction("Index", new { usuarioEncontrado = false });
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", new { usuarioEncontrado = false });
            }
        }

        public IActionResult CriarConta(UsuarioModel usuario)
        {
            try
            {
                //DadosTeste.usuarios.Add(usuario);
                //DadosTeste.usuarioLogado = usuario;

                if (usuario.id == null || usuario.id == Guid.Empty)
                {
                    usuario.id = _apiFacadeUsuario.CriarUsuario(usuario);
                    DadosTeste.usuarioLogado = usuario;
                }
                else
                {
                    _apiFacadeUsuario.AtualizarUsuario(usuario, DadosTeste.accesstokenUsuario);

                    DadosTeste.usuarioLogado.nome = usuario.nome;
                    DadosTeste.usuarioLogado.email = usuario.email;
                    DadosTeste.usuarioLogado.telefone = usuario.telefone;
                    DadosTeste.usuarioLogado.dataNascimento = usuario.dataNascimento;
                }

                return RedirectToAction("Index", "Produto");
            }
            catch (Exception e)
            {
				return RedirectToAction("Index", new { usuarioEncontrado = false });
			}
        }

        public IActionResult Edit()
        {
            return View(DadosTeste.usuarioLogado);
        }

        public IActionResult Logoff()
        {
            DadosTeste.usuarioLogado = null;
            return RedirectToAction("Index", "Produto");
        }
    }
}
