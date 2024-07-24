using System.Windows;

namespace EducationERP.Common.ToolsDev
{
    public static class Dev
    {
        public static string Str = "Дефолтное значение";
        public static int Int = 666;

        public static void NotReady() => MessageBox.Show("Метод не реализован");
        public static void NotReady(object check) => MessageBox.Show(check.ToString());
    }
}