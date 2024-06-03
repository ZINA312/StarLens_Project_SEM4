using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StarLens.Applicationn.CameraUseCases.Queries.GetAllCameras;
using StarLens.Applicationn.FilterUseCases.Queries.GetAllFilters;
using StarLens.Applicationn.MountUseCases.Queries.GetAllMounts;
using StarLens.Applicationn.TelescopeUseCases.Queries.GetAllTelescopes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarLens.UI.ViewModels
{
    public partial class AddSessionViewModel : ObservableObject
    {
        private readonly IMediator _mediator;
        private DateTime _date = DateTime.Now;
        private string _frames = string.Empty;
        private string _exposure = string.Empty;
        private string _gain = string.Empty;
        private string _offset = string.Empty;
        private string _notifylabel = string.Empty;
        public const string SessionAddedMessage = "SessionAdded";
        private Telescope _selectedTelescope = null;
        private Camera _selectedCamera = null;
        private Mount _selectedMount = null;
        private Filter _selectedFilter = null;
        private IEnumerable<Telescope> _telescopes;
        private IEnumerable<Camera> _cameras;
        private IEnumerable<Mount> _mounts;
        private IEnumerable<Filter> _filters;

        public AddSessionViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; OnPropertyChanged(); }
        }
        public string NotifyLabel
        {
            get { return _notifylabel; }
            set { _notifylabel = value; OnPropertyChanged(); }
        }
        public string Frames
        {
            get { return _frames; }
            set { _frames = value; OnPropertyChanged(); }
        }
        public string Exposure
        {
            get { return _exposure; }
            set { _exposure = value; OnPropertyChanged(); }
        }
        public string Gain
        {
            get { return _gain; }
            set { _gain = value; OnPropertyChanged(); }
        }
        public string Offset
        {
            get { return _offset; }
            set { _offset = value; OnPropertyChanged(); }
        }
        public Telescope SelectedTelescope
        {
            get { return _selectedTelescope; }
            set { _selectedTelescope = value; OnPropertyChanged(); }
        }
        public Camera SelectedCamera
        {
            get { return _selectedCamera; }
            set { _selectedCamera = value; OnPropertyChanged(); }
        }
        public Mount SelectedMount
        {
            get { return _selectedMount; } 
            set { _selectedMount = value; OnPropertyChanged(); }
        }
        public Filter SelectedFilter
        {
            get { return _selectedFilter; }
            set { _selectedFilter = value; OnPropertyChanged(); }
        }
        public IEnumerable<Telescope> Telescopes
        {
            get { return _telescopes; }
            set { _telescopes = value; OnPropertyChanged(); }
        }
        public IEnumerable<Mount> Mounts
        {
            get { return _mounts; }
            set { _mounts = value; OnPropertyChanged(); }
        }
        public IEnumerable<Camera> Cameras
        {
            get { return _cameras; }
            set { _cameras = value; OnPropertyChanged(); }
        }
        public IEnumerable<Filter> Filters
        {
            get { return _filters; }
            set { _filters = value; OnPropertyChanged(); }
        }

        [RelayCommand]
        async Task LoadEquipment() => await LoadEquipmentFromDb();
        [RelayCommand]
        async Task SaveButtonClicked() => await SaveSession();
        [RelayCommand]
        async Task GoBackButtonClicked() => await GoBack();
        public async Task LoadEquipmentFromDb()
        {
            Telescopes = await _mediator.Send(new GetAllTelescopesRequest());
            Mounts = await _mediator.Send(new GetAllMountsRequest());
            Cameras = await _mediator.Send(new GetAllCamerasRequest());
            Filters = await _mediator.Send(new GetAllFiltersRequest());
        }
        public async Task SaveSession()
        {
            int frames = 0, offset = 0, gain = 0;
            float exposure = 0;
            if (SelectedTelescope == null) { NotifyLabel = "Select a telescope!"; return; }
            if (SelectedMount == null) { NotifyLabel = "Select a mount!"; return; }
            if (SelectedCamera == null) { NotifyLabel = "Select a camera!"; return; }
            if (!int.TryParse(Frames, out frames) || frames < 1) { NotifyLabel = "Incorrect frames value!"; return; }
            if (!int.TryParse(Gain, out gain) || gain < 0) { NotifyLabel = "Incorrect gain value!"; return; }
            if(Offset == string.Empty) { offset = 0; }
            else
            {
                if (!int.TryParse(Offset, out offset) || offset < 0) { NotifyLabel = "Incorrect offset value!"; return; }
            }
            if(!float.TryParse(Exposure, out exposure) || exposure < 0) { NotifyLabel = "Incorrect exposure value!"; return; }
            Session session = new Session(Date.ToString("d"), frames, exposure, gain, offset,
                SelectedTelescope.Id, SelectedCamera.Id, SelectedMount.Id, SelectedFilter.Id);
            MessagingCenter.Send(this, SessionAddedMessage, session);
            await Shell.Current.GoToAsync("..", false);
        }
        public async Task GoBack()
        {
            await Shell.Current.GoToAsync("..", false);
        }
    }
}
