using System.Globalization;
using System;
using System.Collections.Generic;
using SenacIntegra.DTO;
using SenacIntegra.Services;

namespace SenacIntegra;

public partial class AgendaPage : ContentPage
{
    DateTime _currentMonth = DateTime.Today; // Variável para controlar o mês atual exibido no calendário
    DateTime _selectedDate = DateTime.Today;

    public AgendaPage()
    {
        InitializeComponent();
        LoadCalendar(); // Carrega o calendário ao iniciar a página
    }

    void LoadCalendar()
    {
        CalendarGrid.Children.Clear();// Limpa os elementos existentes no Grid do calendário
        CalendarGrid.RowDefinitions.Clear();// Limpa as definições de linha do Grid para evitar acúmulo de linhas ao navegar entre os meses

        MonthLabel.Text = _currentMonth.ToString("MMMM yyyy", new CultureInfo("pt-BR")); // Atualiza o rótulo do mês para exibir o mês e ano atuais no formato "Mês Ano" (ex: "Janeiro 2024")

        DateTime firstDay = new DateTime(_currentMonth.Year, _currentMonth.Month, 1); // Obtém o primeiro dia do mês atual para calcular a posição dos dias no calendário
        int daysInMonth = DateTime.DaysInMonth(_currentMonth.Year, _currentMonth.Month);// Obtém o número total de dias no mês atual para determinar quantos dias serão exibidos no calendário
        int startDay = (int)firstDay.DayOfWeek; // Calcula o dia da semana do primeiro dia do mês para posicionar corretamente os dias no calendário (0 = Domingo, 1 = Segunda-feira, ..., 6 = Sábado)

        int totalRows = (int)Math.Ceiling((daysInMonth + startDay) / 7.0); // Calcula o número total de linhas necessárias para exibir todos os dias do mês, considerando o deslocamento inicial causado pelo dia da semana do primeiro dia do mês

        for (int i = 0; i < totalRows; i++) // Adiciona as linhas necessárias ao Grid do calendário com altura automática para acomodar os botões dos dias
            CalendarGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });// Adiciona as colunas necessárias ao Grid do calendário para os dias da semana (7 colunas)

        int dayCounter = 1;// Variável para contar os dias do mês e exibi-los nos botões do calendário

        for (int row = 0; row < totalRows; row++) // Loop para criar os botões dos dias do mês e posicioná-los corretamente no Grid do calendário, considerando o deslocamento inicial causado pelo dia da semana do primeiro dia do mês
        {
            for (int col = 0; col < 7; col++)
            {
                if (row == 0 && col < startDay)
                    continue;

                if (dayCounter > daysInMonth)
                    return;

                var date = new DateTime(_currentMonth.Year, _currentMonth.Month, dayCounter); // Cria um objeto DateTime para o dia atual do mês, que será usado para configurar os botões do calendário e para identificar a data selecionada pelo usuário

                var button = new Button
                {
                    Text = dayCounter.ToString(), // Define o texto do botão como o número do dia do mês
                    BackgroundColor = Colors.Transparent,
                    TextColor = Colors.Black,
                    CornerRadius = 10
                };

                if (date.Date == DateTime.Today) // Destaca o botão do dia atual com uma cor de fundo diferente para facilitar a identificação visual do dia atual no calendário
                    button.BackgroundColor = Colors.LightBlue;

                button.Clicked += (s, e) => // Adiciona um evento de clique para cada botão do dia, que atualiza a data selecionada e exibe um alerta com a data escolhida pelo usuário
                {
                    _selectedDate = date;
                    DisplayAlert("Data Selecionada", _selectedDate.ToString("dd/MM/yyyy"), "OK"); // Exibe um alerta com a data selecionada pelo usuário no formato "dd/MM/yyyy" (ex: "15/01/2024")
                    LoadCalendar();
                };

                if (date.Date == _selectedDate.Date)
                    button.BackgroundColor = Colors.RoyalBlue; // Destaca o botão da data selecionada com uma cor de fundo diferente para facilitar a identificação visual da data escolhida pelo usuário no calendário

                CalendarGrid.Add(button, col, row); // Adiciona o botão do dia ao Grid do calendário na posição correta, considerando o deslocamento inicial causado pelo dia da semana do primeiro dia do mês

                dayCounter++;
            }
        }
    }

    void OnPreviousMonthClicked(object sender, EventArgs e) // Evento para o botão de mês anterior, que atualiza o mês atual para o mês anterior e recarrega o calendário para exibir os dias do novo mês selecionado pelo usuário
    {
        _currentMonth = _currentMonth.AddMonths(-1); // Atualiza o mês atual para o mês anterior usando o método AddMonths com um valor negativo
        LoadCalendar();
    }

    void OnNextMonthClicked(object sender, EventArgs e)
    {
        _currentMonth = _currentMonth.AddMonths(1); // Evento para o botão de mês seguinte, que atualiza o mês atual para o mês seguinte e recarrega o calendário para exibir os dias do novo mês selecionado pelo usuário
        LoadCalendar();
    }
    void OnDispareEvento(object sender, EventArgs e)
    {
        DisplayAlert("Evento", $"Evento para {_selectedDate:dd/MM/yyyy} ", "OK");
    }
}
