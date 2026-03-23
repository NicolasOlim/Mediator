using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Atividade_Mediator.Interfaces;

namespace Atividade_Mediator.Viewmodels
{
    public class PesquisaViewModel : INotifyPropertyChanged
    {
        private readonly IMediator _mediator;
        private string _termoPesquisa;

        public event PropertyChangedEventHandler PropertyChanged;

        public string TermoPesquisa
        {
            get => _termoPesquisa;
            set
            {
                _termoPesquisa = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TermoPesquisa)));

                
                _mediator.Notificar(this, "Pesquisar");
            }
        }

        public PesquisaViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
