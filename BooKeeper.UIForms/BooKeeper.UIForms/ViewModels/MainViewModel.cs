namespace BooKeeper.UIForms.ViewModels
{
    public class MainViewModel
    {
        private static MainViewModel singleton;

        public LoginViewModel Login { get; set; }

        public BooksViewModel Books { get; set; }

        public MainViewModel()
        {
            singleton = this;
        }

        public static MainViewModel GetSingleton()
        {
            if(singleton == null)
            {
                return new MainViewModel();
            }

            return singleton;
        }
    }
}
