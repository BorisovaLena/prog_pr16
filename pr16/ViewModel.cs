using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace pr16
{
    class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        int cbIndex = -1;

        public int IndexSelected // свойство для нахождения индекса выбранного в Combobox элемента
        {
            set
            {
                cbIndex = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Position"));
            }
        }

        public string Position // отображение знака
        {
            get
            {
                if (cbIndex == -1)
                {
                    return "";
                }
                else
                {
                    return Model.signsList[cbIndex].ToString();
                }
            }
        }
        public string ShowResult // свойство для отображения числа в TextBlock
        {
            get
            {
                return Model.res;
            }
        }
        
        public int One
        {
            set
            {
                Model.one = value;
            }
        }

        public int Two
        {
            set
            {
                Model.two = value;
            }
        }

        public RoutedCommand Command { get; set; } = new RoutedCommand();

        public void Command_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Regex r1 = new Regex("^[0-9]+$");
            if (r1.IsMatch(Model.one.ToString()) && r1.IsMatch(Model.two.ToString()))
            {
                switch (cbIndex)
                {
                    case 0:
                        Model.res = (Model.one + Model.two).ToString();
                        break;
                    case 1:
                        Model.res = (Model.one - Model.two).ToString();
                        break;
                    case 2:
                        Model.res = (Model.one * Model.two).ToString();
                        break;
                    case 3:
                        Model.res = (Model.one / Model.two).ToString();
                        break;
                    default:
                        break;
                }   
            }
            else
            {
                Model.res = "Введены данные неправильного формата!!! Введите только натуральные числа!!!";
            }
            PropertyChanged(this, new PropertyChangedEventArgs("ShowResult"));
        }
        public CommandBinding bind;
        public ViewModel()
        {
            bind = new CommandBinding(Command);
            bind.Executed += Command_Executed;
        }
    }
}
