using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using Atividade_Mediator.Interfaces;
using Atividade_Mediator.Models;

namespace Atividade_Mediator.Viewmodels
{
    public class ListaViewModel : INotifyPropertyChanged
    {
        private readonly IMediator _mediator;
        private Cliente _clienteSelecionado;
        private List<Cliente> _todosClientes = new List<Cliente>();
        private const string CaminhoArquivo = "clientes.txt";

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Cliente> Clientes { get; set; }

        public Cliente ClienteSelecionado
        {
            get => _clienteSelecionado;
            set
            {
                _clienteSelecionado = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ClienteSelecionado)));
                if (_clienteSelecionado != null) _mediator.Notificar(this, "ClienteSelecionado");
            }
        }

        public ListaViewModel(IMediator mediator)
        {
            _mediator = mediator;
            Clientes = new ObservableCollection<Cliente>();
        }

        public void AdicionarCliente(string nome)
        {
            var novoCliente = new Cliente { Nome = nome };
            _todosClientes.Add(novoCliente);

            SalvarNoArquivo();
            AtualizarTela();
        }

        public void RemoverCliente(string nome)
        {
            var cliente = _todosClientes.FirstOrDefault(c => c.Nome == nome);
            if (cliente != null)
            {
                _todosClientes.Remove(cliente);

                SalvarNoArquivo();
                AtualizarTela();
            }
        }

        public void FiltrarClientes(string termo)
        {
            Clientes.Clear();
            var filtrados = string.IsNullOrWhiteSpace(termo)
                ? _todosClientes
                : _todosClientes.Where(c => c.Nome.ToLower().Contains(termo.ToLower())).ToList();

            foreach (var c in filtrados) Clientes.Add(c);
        }

        private void AtualizarTela() => FiltrarClientes("");

        public void CarregarDoArquivo()
        {
            if (File.Exists(CaminhoArquivo))
            {
                var linhas = File.ReadAllLines(CaminhoArquivo);
                foreach (var linha in linhas)
                {
                    if (!string.IsNullOrWhiteSpace(linha))
                        _todosClientes.Add(new Cliente { Nome = linha });
                }
                AtualizarTela();
                _mediator.Notificar(this, "AutoCarregado");
            }
        }

        private void SalvarNoArquivo()
        {
            var nomes = _todosClientes.Select(c => c.Nome).ToArray();
            File.WriteAllLines(CaminhoArquivo, nomes);
            _mediator.Notificar(this, "AutoSalvo");
        }
    }
}