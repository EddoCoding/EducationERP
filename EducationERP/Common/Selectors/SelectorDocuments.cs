using EducationERP.ViewModels.Modules.AdmissionsCampaign.Documents;
using System.Windows;
using System.Windows.Controls;

namespace EducationERP.Common.Selectors
{
    public class SelectorDocuments : DataTemplateSelector
    {
        public DataTemplate TemplatePassport { get; set; }
        public DataTemplate TemplateSnils { get; set; }
        public DataTemplate TemplateInn { get; set; }
        public DataTemplate TemplateForeignPassport { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is PassportViewModel) return TemplatePassport;
            else if (item is SnilsViewModel) return TemplateSnils;
            else if (item is InnViewModel) return TemplateInn;
            else if (item is ForeignPassportViewModel) return TemplateForeignPassport;

            return null;
        }
    }
}