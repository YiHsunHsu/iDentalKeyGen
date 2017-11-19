using iDentalKeyGen.Class;
using iDentalKeyGen.Commands;
using System.Windows;
using System.Windows.Input;

namespace iDentalKeyGen.ViewModels
{
    public class MainWindowViewModel : ViewModelBase.PropertyChangedBase
    {
        public MainWindowViewModel()
        {
        }

        private string clinicCode;
        public string ClinicCode
        {
            get { return clinicCode; }
            set
            {
                clinicCode = value;
                OnPropertyChanged("ClinicCode");
                OnPropertyChanged("ClincCodeEncode");
            }
        }

        public string ClincCodeEncode
        {
            get { return string.IsNullOrEmpty(ClinicCode) ? string.Empty : KeyGenerator.SHA384Encode(ClinicCode); }
        }

        private RelayCommand _copyKey;
        public ICommand CopyKeyToClipboard
        {
            get
            {
                if (_copyKey == null)
                {
                    _copyKey = new RelayCommand(CopyKey, CanCopyKey);
                }
                return _copyKey;
            }
        }

        private void CopyKey(object parameter)
        {
            Clipboard.SetText(ClincCodeEncode);
        }

        private bool CanCopyKey()
        {
            if (string.IsNullOrEmpty(ClincCodeEncode))
                return false;
            else
                return true;
        }
    }
}
