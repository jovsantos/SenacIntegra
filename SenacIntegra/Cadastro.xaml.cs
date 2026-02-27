using System;
using System.Collections.Generic;
using SenacIntegra.DTO;
using SenacIntegra.Services;

namespace SenacIntegra
{
    public partial class Cadastro : ContentPage
    {
        static List<Usuario> usuarios = new List<Usuario>();

        public Cadastro()
        {
            InitializeComponent();
        }

        async void OnCadastrarClicked(object sender, EventArgs e)
        {
            // Validação de campos obrigatórios
            if (string.IsNullOrWhiteSpace(entryPrimeiroNome.Text) ||
                string.IsNullOrWhiteSpace(entrySobrenome.Text) ||
                string.IsNullOrWhiteSpace(entryEmail.Text) ||
                string.IsNullOrWhiteSpace(entrySenha.Text) ||
                string.IsNullOrWhiteSpace(entryConfirmarSenha.Text))
            {
                await DisplayAlert("Erro", "Preencha todos os campos!", "OK");
                return;
            }

            // Validação de senha
            if (entrySenha.Text != entryConfirmarSenha.Text)
            {
                await DisplayAlert("Erro", "As senhas não coincidem!", "OK");
                return;
            }

            // Cria novo usuário
            Usuario novoUsuario = new Usuario
            {
                Nome = entryPrimeiroNome.Text + " " + entrySobrenome.Text,
                Email = entryEmail.Text,
                Senha = entrySenha.Text
            };

            usuarios.Add(novoUsuario);

            await DisplayAlert("Sucesso", "Usuário cadastrado com sucesso!", "OK");

            // Navegação para MainPage (ajuste conforme seu Shell)
            await Shell.Current.GoToAsync("MainPage");
        }
    }
}