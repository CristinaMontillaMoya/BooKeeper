namespace BooKeeper.UIForms.ViewModels
{
    using Common.Models;
    using Common.Services;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Xamarin.Forms;

    public class BooksViewModel : BaseViewModel
    {
        private readonly ApiService apiService;
        private ObservableCollection<Book> books;
        private bool isRefreshing;
        public ObservableCollection<Book> Books
        {
            get => this.books;
            set => this.SetValue(ref this.books, value);
        }

        public bool IsRefreshing
        {
            get => this.isRefreshing;
            set => this.SetValue(ref this.isRefreshing, value);
        }

        public BooksViewModel()
        {
            this.apiService = new ApiService();
            this.LoadBooks();
        }

        private async void LoadBooks()
        {
            this.IsRefreshing = true;

            var response = await apiService.GetListAsync<Book>(
                "https://bookeeperweb.azurewebsites.net",
                "/api",
                "/Books");

            this.IsRefreshing = false;

            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Accept");
                return;
            }

            var BooksList = (List<Book>)response.Result;
            this.Books = new ObservableCollection<Book>(BooksList);


        }
    }
}
