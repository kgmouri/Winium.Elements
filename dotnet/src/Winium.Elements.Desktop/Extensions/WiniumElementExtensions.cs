namespace Winium.Elements.Desktop.Extensions
{
    #region using

    using System.Reflection;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Winium;

    #endregion

    public static class WiniumElementExtensions
    {
        #region Public Methods and Operators

        public static DataGrid ToDataGrid(this WiniumElement element)
        {
            return new DataGrid(element);
        }

        public static ListBox ToListBox(this WiniumElement element)
        {
            return new ListBox(element);
        }

        public static ComboBox ToComboBox(this WiniumElement element)
        {
            return new ComboBox(element);
        }

        public static Menu ToMenu(this WiniumElement element)
        {
            return new Menu(element);
        }

        #endregion

        #region Methods

        internal static Response Execute(this WiniumElement element, params object[] parameters)
        {
            var methodInfo = element.GetType().GetMethod("Execute", BindingFlags.NonPublic | BindingFlags.Instance);
            return (Response)methodInfo.Invoke(element, parameters);
        }

        internal static string GetId(this WiniumElement element)
        {
            var propertyInfo = element.GetType()
                .GetProperty("Id", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.GetProperty);
            return propertyInfo.GetValue(element, null).ToString();
        }

        #endregion
    }
}
