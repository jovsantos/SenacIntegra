using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenacIntegra
{
    public partial class TelaLogin : ContentPage
    {
        public TelaLogin()
        {
            InitializeComponent(); // Adicionado 'this.' para garantir o contexto correto
        }

        async void OnEntrarClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("HomePage");
        }
    }
}
