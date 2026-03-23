using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Atividade_Mediator.Viewmodels
{
    public class StatusViewModel : INotifyPropertyChanged
    {
        private string _mensagem = "Aguardando ações...";
        private int _totalClientes = 0;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Mensagem
        {
            get => _mensagem;
            set { _mensagem = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Mensagem))); }
        }

        public int TotalClientes
        {
            get => _totalClientes;
            set { _totalClientes = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TotalClientes))); }
        }

        public void AtualizarStatus(string nomeSalvo, int totalAtual)
        {
            Mensagem = $"Último cliente salvo: {nomeSalvo}";
            TotalClientes = totalAtual;
        }
    }
}