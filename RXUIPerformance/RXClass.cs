using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;

namespace RXUIPerformance
{
    public class RXClass : ReactiveObject, INotifyPropertyChanged
    {
        private int _RXSetter = 0;
        public int RXSetter
        {
            get { return _RXSetter; }
            set { this.RaiseAndSetIfChanged(ref _RXSetter, value); }
        }

        /// <summary>
        /// Not applicable anymore
        /// </summary>
        //private int _OldSetter = 0;
        //public int OldSetter
        //{
        //    get { return _OldSetter; }
        //    set { this.RaiseAndSetIfChanged(x => x.OldSetter, value); }
        //}
    }

    public class PlainWPFWithAttachedPropertyChangeEvents : INotifyPropertyChanged, System.ComponentModel.INotifyPropertyChanging
    {        
        private int _NotifySetter = 0;
        public int NotifySetter
        {
            get { return _NotifySetter; }
            set
            {
                _NotifySetter = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("NotifySetter"));
            }
        }

        private int _ChangingAndChangedSetter = 0;
        public int ChangingAndChangedSetter
        {
            get { return _ChangingAndChangedSetter; }
            set 
            {
                if (PropertyChanging != null)
                    PropertyChanging(this, new System.ComponentModel.PropertyChangingEventArgs("ChangingAndChangedSetter"));
                _ChangingAndChangedSetter = value;
                if(PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("ChangingAndChangedSetter"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = (_, __) => { };
        public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging = (_, __) => { };
    }

    public class PlainWPFWithoutAttachedPropertyChangeEvents : INotifyPropertyChanged, System.ComponentModel.INotifyPropertyChanging
    {
        private int _NotifySetter = 0;
        public int NotifySetter
        {
            get { return _NotifySetter; }
            set
            {
                _NotifySetter = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("NotifySetter"));
            }
        }

        private int _ChangingAndChangedSetter = 0;
        public int ChangingAndChangedSetter
        {
            get { return _ChangingAndChangedSetter; }
            set
            {
                if (PropertyChanging != null)
                    PropertyChanging(this, new System.ComponentModel.PropertyChangingEventArgs("ChangingAndChangedSetter"));
                _ChangingAndChangedSetter = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("ChangingAndChangedSetter"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;
    }

    public class PlainClass
    {
        private int _PlainSetter = 0;
        public int PlainSetter
        {
            get { return _PlainSetter; }
            set { _PlainSetter = value; }
        }

        public int AutoSetter { get; set; }
    }
}
