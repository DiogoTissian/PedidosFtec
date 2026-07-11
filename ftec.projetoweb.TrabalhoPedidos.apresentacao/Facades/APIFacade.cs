using ftec.projetoweb.TrabalhoPedidos.apresentacao.Models;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ftec.projetoweb.TrabalhoPedidos.apresentacao.Facades
{
    public class APIFacade
    {
        private readonly string _baseUrl;
        private readonly HttpClient _httpClient;
        private const string ContentType = "application/json";

        public APIFacade(string baseUrl)
        {
            _baseUrl = baseUrl.TrimEnd('/');
            _httpClient = new HttpClient();
        }

        #region Categoria
        public List<CategoriaModel> GetCategorias()
        {
            try
            {
                return Get<List<CategoriaModel>>(string.Empty);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public CategoriaModel GetCategoria(int id)
        {
            try
            {
                return Get<CategoriaModel>(id.ToString());
            }
			catch (Exception e)
			{
				throw e;
			}
		}

        public bool PostCriarCategoria(CategoriaModel cat)
        {
            try
            {
                Post<CategoriaModel>(string.Empty, cat);
                return true;
            }
			catch (Exception e)
			{
				throw e;
			}
		}

        public bool PutAtualizarCategoria(CategoriaModel cat)
        {
            try
            {
                Put<CategoriaModel>(cat.Id.ToString(), cat);
                return true;
            }
			catch (Exception e)
			{
				throw e;
			}
		}

        public List<TransportadoraModel> BuscarTransportadoras()
        {
            try
            {
                return Get<List<TransportadoraModel>>(string.Empty);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool DeleteCategoria(int id)
        {
            try
            {
                Delete(id.ToString());
                return true;
            }
			catch (Exception e)
			{
				throw e;
			}
		}

        #endregion

        #region Estatistica
        public List<EstatisticaResumoModel> GetPainelDiario()
        {
            try
            {
                return Get<List<EstatisticaResumoModel>>("painel-hoje");
            }
            catch
            {
                return new List<EstatisticaResumoModel>();
            }
        }

        public List<MediaAvaliacaoProdutoModel> GetMediaAvaliacaoProduto()
        {
            try
            {
                return Get<List<MediaAvaliacaoProdutoModel>>("media-avaliacao-produto");
            }
            catch
            {
                return new List<MediaAvaliacaoProdutoModel>();
            }
        }

        public List<MediaVendaPorProdutoModel> GetMediaVendaPorProduto()
        {
            try
            {
                return Get<List<MediaVendaPorProdutoModel>>("media-venda-produto");
            }
            catch
            {
                return new List<MediaVendaPorProdutoModel>();
            }
        }

        public List<MediaVendasClientesModel> GetMediaVendasClientes()
        {
            try
            {
                return Get<List<MediaVendasClientesModel>>("media-vendas-cliente");
            }
            catch
            {
                return new List<MediaVendasClientesModel>();
            }
        }

        public TotalVendasModel GetTotalVendas()
        {
            try
            {
                return Get<TotalVendasModel>("total-vendas");
            }
            catch
            {
                return new TotalVendasModel();
            }
        }
        #endregion

        #region Avaliações
        public List<AvaliacaoModel> GetAvaliacoes(Guid produtoId)
        {
            try
            {
                return Get<List<AvaliacaoModel>>($"produto/{produtoId}");
            }
			catch (Exception e)
			{
				throw e;
			}
		}

        public AvaliacaoModel GetAvaliacao(Guid Id)
        {
            try
            {
                return Get<AvaliacaoModel>(Id.ToString());
            }
			catch (Exception e)
			{
				throw e;
			}
		}

        public bool DeleteAvaliacao(Guid id)
        {
            try
            {
                Delete(id.ToString());
                return true;
            }
			catch (Exception e)
			{
				throw e;
			}
		}

        public bool PostCriarAvaliacao(AvaliacaoModel avaliacao)
        {
            try
            {
                Post<AvaliacaoModel>("", avaliacao);
                return true;
            }
			catch (Exception e)
			{
				throw e;
			}
		}

        public bool PutAtualizarAvaliacao(AvaliacaoModel avaliacao)
        {
            try
            {
                Put<AvaliacaoModel>("", avaliacao);
                return true;
            }
			catch (Exception e)
			{
				throw e;
			}
		}
        #endregion

        #region Pagamento
        public List<PagamentoModel> GetPagamentos()
        {
            try
            {
                return Get<List<PagamentoModel>>(string.Empty);
            }
			catch (Exception e)
			{
				throw e;
			}
		}

        public PagamentoModel GetPagamento(Guid id)
        {
            try
            {
                return Get<PagamentoModel>(id.ToString());
            }
			catch (Exception e)
			{
				throw e;
			}
		}

        public bool PostAdicionarPagamento(PagamentoModel pagamento)
        {
            try
            {
                Post(string.Empty, pagamento);
                return true;
            }
			catch (Exception e)
			{
				throw e;
			}
		}
        #endregion

        #region Usuario
        public LoginResponseModel Login(LoginEnvioModel loginEnvio)
        {
            try
            {
                LoginResponseModel loginResponse = PostLogin<LoginEnvioModel>("autenticacao/login", loginEnvio);

                if (loginResponse == null || loginResponse.UsuarioId == null || loginResponse.UsuarioId == Guid.Empty)
                {
                    throw new ApplicationException();
                }

                return loginResponse;
            }
            catch (Exception e)
            {
				throw e;
			}
        }

        public UsuarioModel GetUsuario(Guid id, string accessToken)
        {
            try
            {
                UsuarioModel usuarioModel = GetUsuario<UsuarioModel>($"usuario/{id.ToString()}", accessToken);

                if (usuarioModel == null || usuarioModel.id == null || usuarioModel.id == Guid.Empty)
                {
                    return new UsuarioModel();
                }

                return usuarioModel;
            }
            catch (Exception e)
            {
				throw e;
			}
        }

        public Guid CriarUsuario(UsuarioModel usuario)
        {
            try
            {
                UsuarioResponseModel usuarioResponse = PostCriarUsuario($"usuario", usuario);

                if (usuarioResponse == null || usuarioResponse.Id == null || usuarioResponse.Id == Guid.Empty)
                {
                    throw new ApplicationException();
                }

                return usuarioResponse.Id;
            }
            catch (Exception e)
            {
				throw e;
			}
        }

        public bool AtualizarUsuario(UsuarioModel usuario, string accesstokenUsuario)
        {
            try
            {
                PutUsuario($"usuario/{usuario.id.ToString()}", usuario, accesstokenUsuario);
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region Produto
        public bool CriarProduto(ProdutoModel produto)
        {
            try
            {
                Post<ProdutoModel>("cadastrarProduto", produto);
                return true;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public bool AtualizarProduto(ProdutoModel produto)
        {
            try
            {
                Put<ProdutoModel>("atualizarProduto", produto);
                return true;
            }
            catch (Exception e)
            {
				throw e;
			}
        }

        public bool DeletarProduto(Guid id)
        {
            try
            {
                Delete($"excluirProduto/{id}");
                return true;
            }
            catch (Exception e)
            {
				throw e;
			}
        }

        public List<ProdutoModel> ListarProdutos()
        {
            try
            {
                ResponseProdutosModel<List<ProdutoModel>> resposta = Get<ResponseProdutosModel<List<ProdutoModel>>>("listar");

                if (!resposta.Sucesso)
                {
					throw new ApplicationException();
				}

                return resposta.Data;
            }
            catch (Exception e)
            {
				throw e;
			}
        }

        public ProdutoModel BuscarProduto(Guid id)
        {
            try
            {
                ResponseProdutosModel<ProdutoModel> resposta = Get<ResponseProdutosModel<ProdutoModel>>($"obtemPorId/{id.ToString()}");

                if (!resposta.Sucesso)
                {
					throw new ApplicationException();
				}

                return resposta.Data;
            }
            catch (Exception e)
            {
				throw e;
			}
        }
        #endregion

        #region Pedido
        public List<PedidoModel> ProcurarPedidos(Guid usuarioId)
        {
            try
            {
                List<PedidoModel> pedidos = Get<List<PedidoModel>>($"GetPedidosUsuario/{usuarioId.ToString()}");
                return pedidos;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public PedidoModel ProcurarPedido(Guid id)
        {
            try
            {
                PedidoModel pedido = Get<PedidoModel>($"{id.ToString()}");
                return pedido;
            }
			catch (Exception e)
			{
				throw e;
            }
        }

        public void AtualizarStatusPedido(object atualizarPedido)
        {
            try
            {
                PutAtualizarPedido(string.Empty, atualizarPedido);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public FreteResultadoModel CalcularFrete(FreteCalcularEnvioModel freteCalcularEnvio)
        {
            try
            {
                FreteResultadoModel freteResposta = PostFrete<FreteCalcularEnvioModel>("calcular", freteCalcularEnvio);
                return freteResposta;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool RemoverPedido(Guid pedidoId)
        {
            try
            {
                Delete(pedidoId.ToString());
                return true;
            }
			catch (Exception e)
			{
				throw e;
			}
		}

        public bool CriarPedido(PedidoModel pedido)
        {
            try
            {
                Post<PedidoModel>(string.Empty, pedido);
                return true;
            }
			catch (Exception e)
			{
				throw e;
			}
		}
        #endregion

        #region Métodos privados de comunicação HTTP
        private T Get<T>(string endpoint)
        {
            using (var client = new HttpClient())
            {
                var url = $"{_baseUrl}";

                if (!string.IsNullOrEmpty(endpoint))
                {
                    url += $"/{endpoint}";
                }

                var request = new HttpRequestMessage(HttpMethod.Get, url);
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(ContentType));

                var response = client.SendAsync(request).Result;

                if (response.IsSuccessStatusCode)
                {
                    var jsonContent = response.Content.ReadAsStringAsync().Result;
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    return JsonSerializer.Deserialize<T>(jsonContent, options);
                }
                else
                {
                    var errorContent = response.Content.ReadAsStringAsync().Result;
                    throw new Exception($"Erro ao buscar dados: {errorContent}");
                }
            }
        }

        private T GetUsuario<T>(string endpoint, string accessToken)
        {
            using (var client = new HttpClient())
            {
                var url = $"{_baseUrl}";

                if (!string.IsNullOrEmpty(endpoint))
                {
                    url += $"/{endpoint}";
                }

                var request = new HttpRequestMessage(HttpMethod.Get, url);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(ContentType));

                var response = client.SendAsync(request).Result;

                if (response.IsSuccessStatusCode)
                {
                    var jsonContent = response.Content.ReadAsStringAsync().Result;
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    return JsonSerializer.Deserialize<T>(jsonContent, options);
                }
                else
                {
                    var errorContent = response.Content.ReadAsStringAsync().Result;
                    throw new Exception($"Erro ao buscar dados: {errorContent}");
                }
            }
        }

        private void Post<T>(string endpoint, T data)
        {
            using (var client = new HttpClient())
            {
                var url = $"{_baseUrl}";

                if (!string.IsNullOrEmpty(endpoint))
                {
                    url += $"/{endpoint}";
                }

                var jsonContent = JsonSerializer.Serialize(data);
                var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, ContentType);

                var response = client.PostAsync(url, content).Result;

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = response.Content.ReadAsStringAsync().Result;
                    throw new Exception($"Erro ao adicionar dados: {errorContent}");
                }
            }
        }

        private FreteResultadoModel PostFrete<T>(string endpoint, T data)
        {
            using (var client = new HttpClient())
            {
                var url = $"{_baseUrl}";

                if (!string.IsNullOrEmpty(endpoint))
                {
                    url += $"/{endpoint}";
                }

                var jsonContent = JsonSerializer.Serialize(data);
                var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, ContentType);

                var response = client.PostAsync(url, content).Result;

                if (response.IsSuccessStatusCode)
                {
                    var jsonContentResponse = response.Content.ReadAsStringAsync().Result;
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    return JsonSerializer.Deserialize<FreteResultadoModel>(jsonContentResponse, options);
                }
                else
                {
                    var errorContent = response.Content.ReadAsStringAsync().Result;
                    throw new Exception($"Erro ao adicionar dados: {errorContent}");
                }
            }
        }

        private LoginResponseModel PostLogin<T>(string endpoint, T data)
        {
            using (var client = new HttpClient())
            {
                var url = $"{_baseUrl}";

                if (!string.IsNullOrEmpty(endpoint))
                {
                    url += $"/{endpoint}";
                }

                var jsonContent = JsonSerializer.Serialize(data);
                var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, ContentType);

                var response = client.PostAsync(url, content).Result;

                if (response.IsSuccessStatusCode)
                {
                    var jsonContentResponse = response.Content.ReadAsStringAsync().Result;
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    return JsonSerializer.Deserialize<LoginResponseModel>(jsonContentResponse, options);
                }
                else
                {
                    var errorContent = response.Content.ReadAsStringAsync().Result;
                    throw new Exception($"Erro ao adicionar dados: {errorContent}");
                }
            }
        }

        private UsuarioResponseModel PostCriarUsuario<T>(string endpoint, T data)
        {
            using (var client = new HttpClient())
            {
                var url = $"{_baseUrl}";

                if (!string.IsNullOrEmpty(endpoint))
                {
                    url += $"/{endpoint}";
                }

                var jsonContent = JsonSerializer.Serialize(data);
                var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, ContentType);

                var response = client.PostAsync(url, content).Result;

                if (response.IsSuccessStatusCode)
                {
                    var jsonContentResponse = response.Content.ReadAsStringAsync().Result;
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    return JsonSerializer.Deserialize<UsuarioResponseModel>(jsonContentResponse, options);
                }
                else
                {
                    var errorContent = response.Content.ReadAsStringAsync().Result;
                    throw new Exception($"Erro ao criar usuário: {errorContent}");
                }
            }
        }

        private void Put<T>(string endpoint, T data)
        {
            using (var client = new HttpClient())
            {
                var url = $"{_baseUrl}";

                if (!string.IsNullOrEmpty(endpoint))
                {
                    url += $"/{endpoint}";
                }

                var jsonContent = JsonSerializer.Serialize(data);
                var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, ContentType);

                var response = client.PutAsync(url, content).Result;

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = response.Content.ReadAsStringAsync().Result;
                    throw new Exception($"Erro ao alterar dados: {errorContent}");
                }
            }
        }

        private void PutAtualizarPedido(string endpoint, object data)
        {
            using (var client = new HttpClient())
            {
                var url = $"{_baseUrl}";

                if (!string.IsNullOrEmpty(endpoint))
                {
                    url += $"/{endpoint}";
                }

                var jsonContent = JsonSerializer.Serialize(data);
                var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, ContentType);

                var response = client.PutAsync(url, content).Result;

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = response.Content.ReadAsStringAsync().Result;
                    throw new Exception($"Erro ao alterar dados: {errorContent}");
                }
            }
        }

        private void PutUsuario<T>(string endpoint, T data, string accesstokenUsuario)
        {
            using (var client = new HttpClient())
            {
                var url = $"{_baseUrl}";

                if (!string.IsNullOrEmpty(endpoint))
                {
                    url += $"/{endpoint}";
                }

                var jsonContent = JsonSerializer.Serialize(data);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accesstokenUsuario);
                var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, ContentType);

                var response = client.PutAsync(url, content).Result;

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = response.Content.ReadAsStringAsync().Result;
                    throw new Exception($"Erro ao alterar dados: {errorContent}");
                }
            }
        }

        private void Delete(string endpoint)
        {
            using (var client = new HttpClient())
            {
                var url = $"{_baseUrl}";

                if (!string.IsNullOrEmpty(endpoint))
                {
                    url += $"/{endpoint}";
                }

                var response = client.DeleteAsync(url).Result;

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = response.Content.ReadAsStringAsync().Result;
                    throw new Exception($"Erro ao excluir dados: {errorContent}");
                }
            }
        }
        #endregion
    }
}
