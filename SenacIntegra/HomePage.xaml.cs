using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenacIntegra
{
    partial class HomePage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        async void OnSairClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//MainPage");
        }
    }
}
