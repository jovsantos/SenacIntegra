using Microsoft.Maui.Controls;

namespace SenacIntegra
{
    public partial class CertificadosPage : ContentPage
    {
        bool situacaoFinanceiraRegular = false;

        public CertificadosPage()
        {
            InitializeComponent();
        }

        private async void BaixarAlgoritmos_Clicked(object sender, EventArgs e)
        {
            if (!situacaoFinanceiraRegular)
            {
                await DisplayAlert("Bloqueado",
                    "Regularize sua situação financeira para baixar o certificado.",
                    "OK");
                return;
            }

            await DisplayAlert("Download",
                "Certificado de Algoritmos baixado com sucesso!",
                "OK");
        }

        private async void BaixarBanco_Clicked(object sender, EventArgs e)
        {
            if (!situacaoFinanceiraRegular)
            {
                await DisplayAlert("Bloqueado",
                    "Regularize sua situação financeira para baixar o certificado.",
                    "OK");
                return;
            }

            await DisplayAlert("Download",
                "Certificado de Banco de Dados baixado com sucesso!",
                "OK");
        }

        private async void VerificarPagamentos_Clicked(object sender, EventArgs e)
        {
            bool resposta = await DisplayAlert("Pagamento",
                "Deseja regularizar sua situação financeira?",
                "Sim",
                "Não");

            if (resposta)
            {
                situacaoFinanceiraRegular = true;

                lblFinanceiro.Text = "Regular";
                lblFinanceiro.BackgroundColor = Color.FromArgb("#C8E6C9");
                lblFinanceiro.TextColor = Color.FromArgb("#1B5E20");

                await DisplayAlert("Sucesso",
                    "Situação financeira regularizada!",
                    "OK");
            }
        }
    }
}