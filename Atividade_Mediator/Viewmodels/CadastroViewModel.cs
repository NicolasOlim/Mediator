using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atividade_Mediator.Interfaces;

namespace Atividade_Mediator.Viewmodels
{
    public class CadastroViewModel : INotifyPropertyChanged
    {
        private readonly IMediator _mediator;
        private string _nomeCliente;

        public event PropertyChangedEventHandler PropertyChanged;

        public string NomeCliente
        {
            get => _nomeCliente;
            set { _nomeCliente = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NomeCliente))); }
        }

        public CadastroViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void Salvar()
        {
            _mediator.Notificar(this, "ClienteSalvo");
        }

        public void Excluir()
        {
            _mediator.Notificar(this, "ClienteExcluido");
        }
    }
}