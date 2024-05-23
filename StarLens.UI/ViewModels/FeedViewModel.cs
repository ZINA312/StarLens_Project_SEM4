using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarLens.UI.ViewModels
{
    public partial class FeedViewModel : ObservableObject
    {
        private readonly IMediator _mediator;

        public FeedViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }
        [RelayCommand]
        async Task SearchButtonClicked() => await GoToSearchPage();
        [RelayCommand]
        async Task UserButtonClicked() => await GoToUserPage();

        public async Task GoToSearchPage()
        {
            await Shell.Current.GoToAsync("SearchPage", false);
        }
        public async Task GoToUserPage()
        {
            await Shell.Current.GoToAsync("UserPage", false);
        }
    }
}
