using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_MVVM_Quick_Start_Tutorial.Model;

namespace WPF_MVVM_Quick_Start_Tutorial.ViewModel
{
    public class ViewModel: ObservableObject
    {
        private readonly TextConverter _textConverter = new TextConverter(delegate(string s) {
            if (s != null)
                return s.ToUpper();
            else
                return "";
        });
        private string _someText;
        private readonly ObservableCollection<string> _history = new ObservableCollection<string>();

        public string SomeText
        {
            get { return _someText; }
            set
            {
                _someText = value;
                if(_someText!="")
                    RaisePropertyChangedEvent("SomeText");
            }
        }
        public IEnumerable<string> History
        {
            get { return _history; }
        }
        public ICommand ConvertTextCommand
        {
            get { return new DelegateCommand(ConvertText); }
        }
        private void ConvertText()
        {
            AddToHistory(_textConverter.ConvertText(SomeText));
            SomeText = String.Empty;
        }

        private void AddToHistory(string item)
        {
            if (!_history.Contains(item) & item != "")
                _history.Add(item);
        }
    }
}
