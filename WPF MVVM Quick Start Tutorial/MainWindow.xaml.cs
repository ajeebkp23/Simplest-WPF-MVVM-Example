using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

            ModbusNode tcpNode = new ModbusNode("ModbusTCP");
            ModbusNode rtuNode = new ModbusNode("ModbusRTU");

            tcpNode.PortNodes = new ObservableCollection<ModbusPortNode> { new ModbusPortNode("11"), new ModbusPortNode("22") };

            RealTimeDataNode rootNode = new RealTimeDataNode(new ObservableCollection<ModbusNode> { tcpNode, rtuNode });
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

    public class ModbusNode
    {
        public string DisplayName { get; set; }
        public ModbusNode(string displayName)
        {
            DisplayName = displayName;
        }

        private ObservableCollection<ModbusPortNode> portNodes;
        public ObservableCollection<ModbusPortNode> PortNodes
        {
            get { return portNodes; }
            set { portNodes = value; }
        }
    }

    public class RealTimeDataNode
    {
        private ObservableCollection<ModbusNode> rTSources;
        public ObservableCollection<ModbusNode> RTSources
        {
            get { return rTSources; }
            set { rTSources = value; }
        }

        public RealTimeDataNode(ObservableCollection<ModbusNode> sources)
        {
            rTSources = sources;
        }
    }

}
