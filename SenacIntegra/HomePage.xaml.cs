using SenacIntegra.DTO;
using SenacIntegra.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenacIntegra
{
    public partial class HomePage : ContentPage
    {
        private readonly AuthService _authService;

        public HomePage( AuthService authService)
        {
             InitializeComponent();
             _authService = authService; // Inicializa o serviço de autenticação
        }

        public HomePage()
        {
            InitializeComponent();
        }

        async void OnTelaLoginClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("MainPage");
        }

        async void OnCadastrarClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("Cadastro");
        }

      

        async void OnSairClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//MainPage");
        }
        async void OnEntrarClicked(object sender, EventArgs e)
        {
            string email = Email.Text; // Obtém o email do campo de entrada
            string senha = Senha.Text; // Obtém a senha do campo de entrada

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
            {
                await DisplayAlert("Erro", "Por favor, preencha todos os campos.", "OK");
                return;
            }

            RequestLoginDTO dadosUsuario = new RequestLoginDTO
            {
                Email = email,
                Senha = senha
            };

            ResponseLoginDTO responseLoginDTO = await _authService.LoginAsync(dadosUsuario); // Chama o método de login para autenticar o usuário

            if (!responseLoginDTO.Erro)
            {
                await Shell.Current.GoToAsync("MainPage");
                return;// Navega para a página inicial se a autenticação for bem-sucedida

            }
            await DisplayAlert("Erro", "Verifique os seus dados e tente novamente", "Tentar Novamente"); // Exibe uma mensagem de erro se a autenticação falhar
        }
    }
} 

    

