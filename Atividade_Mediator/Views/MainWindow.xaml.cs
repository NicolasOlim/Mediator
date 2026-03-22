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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var mediador = new CadastroMediator();
            var vm = new CadastroViewModel(mediador);
            mediador.RegistrarViewModel(vm);

            this.DataContext = vm;
        }

        // Este método resolve o erro CS1061
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is CadastroViewModel vm)
            {
                vm.Salvar(); 
            }
        }
    }
}