using RecoverAccount.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace RecoverAccount.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}