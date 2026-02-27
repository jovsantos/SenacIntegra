using SenacIntegra.DTO;

namespace SenacIntegra
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void OnEntrarClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("HomePage");
        }

        async void OnCadastrarClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("Cadastro");
        }

        async void OnSairClicked(object sender, EventArgs e)
        {
            bool confirmar = await DisplayAlert("Sair", "Deseja voltar à tela de login?", "Sim", "Não");
            if (confirmar)
            {
                Application.Current.MainPage = new HomePage(); // Redefine a MainPage para a tela de login
            }
        }
    }
}
