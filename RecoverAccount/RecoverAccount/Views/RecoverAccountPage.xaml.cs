using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorand;
using Algorand.V2;
using Algorand.Client;
using Algorand.V2.Model;
using Account = Algorand.Account;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;


namespace RecoverAccount.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecoverAccountPage : ContentPage
    {
        public RecoverAccountPage()
        {
            InitializeComponent();
        }
        private async void recoverAccount(object sender, EventArgs e)
        {
            string ALGOD_API_ADDR = "https://testnet-algorand.api.purestake.io/ps2"; //find in algod.net
            string ALGOD_API_TOKEN = "B3SU4KcVKi94Jap2VXkK83xx38bsv95K5UZm2lab"; //find in algod.token  
            AlgodApi algodApiInstance = new AlgodApi(ALGOD_API_ADDR, ALGOD_API_TOKEN);
            if(MnemonicKey.Text != null)
            {
                Account src = new Account(MnemonicKey.Text);
                var accountInfo = algodApiInstance.AccountInformation(src.Address.ToString());
                if (Address.IsValid(src.Address.ToString())){
                    AccountAddress.Text = $"{src.Address.ToString()}";
                    Amount.Text = $"{accountInfo.Amount} algos";
                    StoreKey.IsEnabled = true;                    
                }
                else
                {
                    await DisplayAlert("Invalid Account Address", "No such Account Exists", "OK");
                }                
            }
            else
            {
                await DisplayAlert("Mnemonic Key Needed!!", $"Please Enter a Mnemonic Key", "OK");
            }
        }
        private async void storeKey(object sender, EventArgs e)
        {
            try
            {
                var key = AccountAddress.Text.ToString();
                await SecureStorage.SetAsync("oauth_token", key);
                await DisplayAlert("Key Stored", $"Key Successfully Stored", "OK");
                RetrieveKey.IsEnabled = true;
                RemoveKey.IsEnabled = true;
            }
            catch (Exception ex)
            {
                // Possible that device doesn't support secure storage on device.
            }
        }
        private async void retrieveKey(object sender, EventArgs e)
        {
            try
            {
                var oauthToken = await SecureStorage.GetAsync("oauth_token");
                await DisplayAlert("Key Recovered", $"{oauthToken}", "OK");
            }
            catch (Exception ex)
            {
                // Possible that device doesn't support secure storage on device.
            }
        }
        private async void removeKey(object sender, EventArgs e)
        {
            try
            {
                SecureStorage.Remove("oauth_token");
                await DisplayAlert("Key Deleted", $"Key Successfully Removed from Storage", "OK");
                StoreKey.IsEnabled = false;
                RetrieveKey.IsEnabled = false;
                RemoveKey.IsEnabled = false;
            }
            catch (Exception ex)
            {
                // Possible that device doesn't support secure storage on device.
            }
        }
    }
}