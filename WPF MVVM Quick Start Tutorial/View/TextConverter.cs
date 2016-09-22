    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_MVVM_Quick_Start_Tutorial
{
    public class TextConverter
    {
        private readonly Func<string, string> _converstion;
        public TextConverter(Func<string,string> conversion)
        {
            _converstion = conversion;
        }
        public string ConvertText(string inputText)
        {
            return _converstion(inputText);
        }
    }
}
