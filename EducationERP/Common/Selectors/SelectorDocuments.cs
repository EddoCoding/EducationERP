using EducationERP.Models;
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
            if (item is Passport) return TemplatePassport;
            else if (item is Snils) return TemplateSnils;
            else if (item is Inn) return TemplateInn;
            else if (item is ForeignPassport) return TemplateForeignPassport;

            return null;
        }
    }
}