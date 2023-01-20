using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace pr16
{
    class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string ShowResult // свойство для отображения числа в TextBlock
        {
            get
            {
                return "Работает";
            }
        }

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



        // класс, который реализазует интерфейс ICommand
        public RoutedCommand Command { get; set; } = new RoutedCommand();

        // обработчик события для Command (увеличение значения числа на 1)
        public void Command_Executed(object sender, ExecutedRoutedEventArgs e)
        {

            PropertyChanged(this, new PropertyChangedEventArgs("ShowResult"));
        }
        public CommandBinding bind; // создание объекта для привязки команды
        public ViewModel()
        {
            bind = new CommandBinding(Command);  // инициализация объекта для привязки данных
            bind.Executed += Command_Executed;  // добавление обработчика событий
        }
    }
}
