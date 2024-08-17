﻿using EducationERP.Common.Components.Services;
using EducationERP.ViewModels.Education;
using Raketa;

namespace EducationERP.ViewModels
{
    public class EducationViewModel : RaketaViewModel
    {
        public VisualEducationViewModel Visual { get; set; } = new();
        public RaketaCommand AddTabItemCommand { get; set; }

        IServiceView _serviceView;
        public ITabControl TabControl { get; set; }
        public EducationViewModel(IServiceView serviceView, ITabControl tabControl)
        {
            _serviceView = serviceView;
            TabControl = tabControl;

            AddTabItemCommand = RaketaCommand.Launch(AddTabItem);
        }

        void AddTabItem() => TabControl.AddItem<UserControlViewModel>();
    }
}