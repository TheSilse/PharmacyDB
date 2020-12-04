using PharmacyDBCore.Commands;

namespace PharmacyDBCore.ViewModels
{
    public class UserViewModel : Notify
    {
        private string _login;
        private string _password;

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged();
            }
        }

        public LoginCommand LoginCommand => new LoginCommand(this);
    }

}
