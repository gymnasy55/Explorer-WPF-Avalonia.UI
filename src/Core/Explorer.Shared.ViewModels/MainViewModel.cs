using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Shared.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Public Properties

        public string MainDiskName { get; set; }

        #endregion

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Constructor

        public MainViewModel()
        {
            MainDiskName = Environment.SystemDirectory;
        }

        #endregion

        #region Protected Methods

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}