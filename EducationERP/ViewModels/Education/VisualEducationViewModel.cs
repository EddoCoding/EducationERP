using Raketa;
using System.Windows;

namespace EducationERP.ViewModels.Education
{
    public class VisualEducationViewModel : RaketaViewModel
    {
        double widthButtonPanel = 196;
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

        public RaketaTCommand<double> ChangeWidthButtonPanelCommand { get; set; }

        public VisualEducationViewModel() => ChangeWidthButtonPanelCommand = RaketaTCommand<double>.Launch(ChangeWidth);

        void ChangeWidth(double width)
        {
            if (width == 196)
            {
                WidthButtonPanel = 40;
                VisibilityButtonText = Visibility.Collapsed;
                ToolTipChangeSize = "Развернуть";
            }
            else if (width == 40)
            {
                WidthButtonPanel = 196;
                VisibilityButtonText = Visibility.Visible;
                ToolTipChangeSize = "Свернуть";
            }
        }
    }
}