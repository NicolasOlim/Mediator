using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Atividade_Mediator.Viewmodels;
using Atividade_Mediator.Mediators;


namespace Atividade_Mediator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            
            var mediador = new CadastroMediator();

            
            var cadastroVM = new CadastroViewModel(mediador);
            var listaVM = new ListaViewModel(mediador);
            var statusVM = new StatusViewModel();
            var pesquisaVM = new PesquisaViewModel(mediador);

            
            mediador.RegistrarCadastro(cadastroVM);
            mediador.RegistrarLista(listaVM);
            mediador.RegistrarStatus(statusVM);
            mediador.RegistrarPesquisa(pesquisaVM);

            
            listaVM.CarregarDoArquivo();

            PainelCadastro.DataContext = cadastroVM;
            PainelLista.DataContext = listaVM;
            PainelStatus.DataContext = statusVM;
            PainelPesquisa.DataContext = pesquisaVM;
        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {
            if (PainelCadastro.DataContext is CadastroViewModel vm)
                vm.Salvar();
        }

        private void BtnExcluir_Click(object sender, RoutedEventArgs e)
        {
            if (PainelCadastro.DataContext is CadastroViewModel vm)
                vm.Excluir();
        }
    }
}