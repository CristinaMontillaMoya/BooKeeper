namespace BooKeeper.UIForms.Infrastructure
{
    using BooKeeper.UIForms.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class InstaceLocator
    {
        public MainViewModel Main { get; set; }
        public InstaceLocator()
        {
            Main = new MainViewModel();              
        }
    }
}
