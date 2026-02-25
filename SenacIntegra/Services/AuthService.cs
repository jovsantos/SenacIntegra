using SenacIntegra.DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace SenacIntegra.Services
{
    public class AuthService
    {
        private readonly HttpClient _httpClient; // Injeção de dependência do HttpClient

        private const string BaseUrl = "https://localhost:7177/"; // URL base para as requisições de autenticação

        public AuthService()
        { // Construtor para receber o HttpClient via injeção de dependência

            _httpClient = new HttpClient(); // Atribuição do HttpClient recebido ao campo privado

        }

        public async Task<ResponseLoginDTO> LoginAsync(RequestLoginDTO dadosUsuario)
        {
            var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}api/Usuarios/login", dadosUsuario); // Envia uma solicitação POST para o endpoint de login com os dados do usuário

            Debug.WriteLine(response);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<ResponseLoginDTO>();  // Lê a resposta da solicitação e desserializa para um objeto ResponseLoginDTO

                return new ResponseLoginDTO
                {
                    Erro = false,
                    Message = "Login realizado com sucesso"// Retorna o resultado da autenticação,   
                };
            }

            return new ResponseLoginDTO
            {
                Erro = true,
                Message = "Falha na autenticação. Verifique suas credenciais e tente novamente."

            };

        }
   
         
    }
    }


