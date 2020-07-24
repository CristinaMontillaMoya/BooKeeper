namespace BooKeeper.UIForms.ViewModels
{
    using BooKeeper.UIForms.Views;
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class LoginViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public ICommand LoginCommand => new RelayCommand(Login);

        public LoginViewModel()
        {
            
        }
        
        private async void Login()
        {
            Console.WriteLine("Entra en el evento");
            if (string.IsNullOrEmpty(this.Email))
            {
                Console.WriteLine("Entra en el if del Email");

                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter an email",
                    "Accept");
                return;
            }
            if (string.IsNullOrEmpty(this.Password))
            {
                Console.WriteLine("Entra en el if del Password");

                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter a password",
                    "Accept");
                return;
            }

            MainViewModel.GetSingleton().Books = new BooksViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new BooksPage());
        }
    }
}
