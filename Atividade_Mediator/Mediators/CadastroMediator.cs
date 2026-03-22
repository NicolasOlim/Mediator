using Atividade_Mediator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atividade_Mediator.Viewmodels;
using Atividade_Mediator.Interfaces;
using System.Windows;

namespace Atividade_Mediator.Mediators
{
    internal class CadastroMediator : IMediator
    {
        private CadastroViewModel _cadastroVM;

        public void RegistrarViewModel(CadastroViewModel vm)
        {
            _cadastroVM = vm;
        }

        public void Notificar(object remetente, string evento)
        {
            if (evento == "ClienteSalvo")
            {
                string nome = _cadastroVM.NomeCliente;

                MessageBox.Show($"Cliente '{_cadastroVM.NomeCliente}' salvo com sucesso!");

                _cadastroVM.NomeCliente = string.Empty;
            }
        }
    }
}
