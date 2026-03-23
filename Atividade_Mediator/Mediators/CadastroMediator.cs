using Atividade_Mediator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atividade_Mediator.Viewmodels;
using Atividade_Mediator.Interfaces;
using System.Windows;
using Atividade_Mediator.Interfaces;
using Atividade_Mediator.Viewmodels;

namespace Atividade_Mediator.Mediators
{
    public class CadastroMediator : IMediator
    {
        private CadastroViewModel _cadastroVM;
        private ListaViewModel _listaVM;
        private StatusViewModel _statusVM;
        private PesquisaViewModel _pesquisaVM;

        public void RegistrarCadastro(CadastroViewModel vm) { _cadastroVM = vm; }
        public void RegistrarLista(ListaViewModel vm) { _listaVM = vm; }
        public void RegistrarStatus(StatusViewModel vm) { _statusVM = vm; }
        public void RegistrarPesquisa(PesquisaViewModel vm) { _pesquisaVM = vm; }

        public void Notificar(object remetente, string evento)
        {
            if (evento == "ClienteSalvo")
            {
                if (string.IsNullOrWhiteSpace(_cadastroVM.NomeCliente)) return;

                _listaVM.AdicionarCliente(_cadastroVM.NomeCliente);
                _statusVM.AtualizarStatus($"Salvo: {_cadastroVM.NomeCliente}", _listaVM.Clientes.Count);
                _cadastroVM.NomeCliente = string.Empty;
            }
            else if (evento == "ClienteSelecionado")
            {
                _cadastroVM.NomeCliente = _listaVM.ClienteSelecionado.Nome;
                _statusVM.Mensagem = $"A visualizar: {_cadastroVM.NomeCliente}";
            }
            else if (evento == "ClienteExcluido")
            {
                if (string.IsNullOrWhiteSpace(_cadastroVM.NomeCliente)) return;

                _listaVM.RemoverCliente(_cadastroVM.NomeCliente);
                _statusVM.AtualizarStatus($"Excluído: {_cadastroVM.NomeCliente}", _listaVM.Clientes.Count);
                _cadastroVM.NomeCliente = string.Empty;
            }
            else if (evento == "Pesquisar")
            {
                _listaVM.FiltrarClientes(_pesquisaVM.TermoPesquisa);
                _statusVM.Mensagem = $"A filtrar por: '{_pesquisaVM.TermoPesquisa}'...";
            }
            else if (evento == "AutoCarregado")
            {
                _statusVM.AtualizarStatus("Dados carregados com sucesso.", _listaVM.Clientes.Count);
            }
            else if (evento == "AutoSalvo")
            {
                _statusVM.Mensagem = "Alterações guardadas automaticamente.";
            }
        }
    }
}