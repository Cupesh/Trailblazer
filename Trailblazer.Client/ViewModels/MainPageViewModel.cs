using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Trailblazer.Services;

namespace Trailblazer.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        int count = 0;
        public string BtnText { get; set; }
        public ICommand OnCounterClicked { get { return new Command(() => OnClicked()); } }

        public MainPageViewModel(IDataService dataService)
        {
            DataService = dataService;
            BtnText = "Click Me";
        }

        public async void OnClicked()
        {
            count++;

            if (count == 1)
                BtnText = $"Clicked {count} time";
            else
                BtnText = $"Clicked {count} times";
            try
            {
                var resp = await DataService.Test();
                var data = resp.ApiData;

                BtnText = data.FirstOrDefault().UserName;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            RaisePropertyChanged(nameof(BtnText));
            SemanticScreenReader.Announce(BtnText);
        }
    }
}