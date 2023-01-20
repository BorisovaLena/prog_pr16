using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
