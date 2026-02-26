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
            if (string.IsNullOrWhiteSpace(entryNome.Text) ||
                string.IsNullOrWhiteSpace(entryEmail.Text) ||
                string.IsNullOrWhiteSpace(entrySenha.Text))
            {
                await DisplayAlert("Erro", "Preencha todos os campos!", "OK");
                return;
            }

            Usuario novoUsuario = new Usuario
            {
                Nome = entryNome.Text,
                Email = entryEmail.Text,
                Senha = entrySenha.Text
            };

            usuarios.Add(novoUsuario);

            await DisplayAlert("Sucesso", "Usuário cadastrado com sucesso!", "OK");

            await Shell.Current.GoToAsync("MainPage");
        }
    }
}
