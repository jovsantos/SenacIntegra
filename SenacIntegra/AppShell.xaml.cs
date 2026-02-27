using SenacIntegra;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SenacIntegra
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(Cadastro), typeof(Cadastro));
            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(AgendaPage), typeof(AgendaPage));
            
        
          



    }
}
}
