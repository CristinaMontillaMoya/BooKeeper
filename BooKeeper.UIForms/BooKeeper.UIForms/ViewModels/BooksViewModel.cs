
namespace BooKeeper.UIForms.ViewModels
{
    using Common.Models;
    using Common.Services;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Text;
    using Xamarin.Forms;

    public class BooksViewModel : BaseViewModel
    {
        private ApiService apiService;
        private ObservableCollection<Book> books;
        public ObservableCollection<Book> Books 
        { 
            get { return this.books; } 
            set { this.SetValue(ref this.books, value); } 
        }

        public BooksViewModel()
        {
            this.apiService = new ApiService();
            this.LoadBooks();
        }

        private async void LoadBooks()
        {
            var response = await apiService.GetListAsync<Book>(
                "https://localhost:5001",
                "/api",
                "/Books");
            
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
