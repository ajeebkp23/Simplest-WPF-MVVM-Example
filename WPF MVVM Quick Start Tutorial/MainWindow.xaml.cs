using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_MVVM_Quick_Start_Tutorial
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ModbusNodeViewModel tcpNode = new ModbusNodeViewModel("ModbusTCP");
            ModbusNodeViewModel rtuNode = new ModbusNodeViewModel("ModbusRTU");

            tcpNode.PortNodes = new ObservableCollection<ModbusPortNode> { new ModbusPortNode("11"), new ModbusPortNode("22") };

            RealTimeDataNodeViewModel rootNode = new RealTimeDataNodeViewModel(new ObservableCollection<ModbusNodeViewModel> { tcpNode, rtuNode });
            DataSourcesTreeView.DataContext = rootNode;
        }
    }


    public class ModbusPortNode
    {
        private string portName;

        public string PortName
        {
            get { return portName; }
            set { portName = value; }
        }

        public ModbusPortNode(string Name)
        {
            portName = Name;
        }
    }

    public class ModbusNodeViewModel:INotifyPropertyChanged
    {
        public string DisplayName { get; set; }
        public ModbusNodeViewModel(string displayName)
        {
            DisplayName = displayName;
        }

        private ObservableCollection<ModbusPortNode> portNodes;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<ModbusPortNode> PortNodes
        {
            get { return portNodes; }
            set { portNodes = value; }
        }
    }

    public class RealTimeDataNodeViewModel
    {
        private ObservableCollection<ModbusNodeViewModel> rTSources;
        public ObservableCollection<ModbusNodeViewModel> RTSources
        {
            get { return rTSources; }
            set { rTSources = value; }
        }

        public RealTimeDataNodeViewModel(ObservableCollection<ModbusNodeViewModel> sources)
        {
            rTSources = sources;
        }
    }

}
