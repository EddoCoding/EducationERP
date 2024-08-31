using EducationERP.Common.Components;
using Raketa;
using System.Windows;

namespace EducationERP.ViewModels.Education
{
    public class VisualEducation : RaketaViewModel
    {
        #region Движение панели кнопок
        double widthButtonPanel = 175;
        public double WidthButtonPanel
        {
            get => widthButtonPanel;
            set => SetValue(ref widthButtonPanel, value);
        }

        Visibility visibilityButtonText = Visibility.Visible;
        public Visibility VisibilityButtonText
        {
            get => visibilityButtonText;
            set => SetValue(ref visibilityButtonText, value);
        }

        string toolTipChangeSize = "Свернуть";
        public string ToolTipChangeSize
        {
            get => toolTipChangeSize;
            set => SetValue(ref toolTipChangeSize, value);
        }
        void ChangeWidth(double width)
        {
            if (width == 175)
            {
                WidthButtonPanel = 40;
                VisibilityButtonText = Visibility.Collapsed;
                ToolTipChangeSize = "Развернуть";
            }
            else if (width == 40)
            {
                WidthButtonPanel = 175;
                VisibilityButtonText = Visibility.Visible;
                ToolTipChangeSize = "Свернуть";
            }
        }
        #endregion
        #region Видимость кнопок по роли
        public bool ModuleAdmissionCampaign { get; set; } = false;
        public bool ModuleAdministration { get; set; } = false;
        public void GetAccess(UserSystem userSystem) 
        {
            if(userSystem.Administration == true) ModuleAdministration = true;
            else if(userSystem.Administration == false) ModuleAdministration = true;
        }
        #endregion

        public RaketaTCommand<double> ChangeWidthButtonPanelCommand { get; set; }

        public VisualEducation(UserSystem userSystem)
        {
            ChangeWidthButtonPanelCommand = RaketaTCommand<double>.Launch(ChangeWidth);
            GetAccess(userSystem);
        }

    }
}