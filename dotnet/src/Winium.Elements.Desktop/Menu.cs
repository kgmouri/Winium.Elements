namespace Winium.Elements.Desktop
{
    #region using

    using System.Collections.Generic;

    using OpenQA.Selenium.Winium;

    #endregion

    public class Menu : DesktopElement
    {
        #region Constants

        private const string FindMenuItem = "findMenuItem";

        private const string SelectMenuItem = "selectMenuItem";

        #endregion

        #region Constructors and Destructors

        public Menu(WiniumElement element)
            : base(element)
        {
        }

        #endregion

        #region Public Methods and Operators

        public WiniumElement FindItem(string path)
        {
            return this.CallMenuItemCommand(FindMenuItem, path);
        }

        public WiniumElement SelectItem(string path)
        {
            return this.CallMenuItemCommand(SelectMenuItem, path);
        }

        #endregion

        #region Methods

        private WiniumElement CallMenuItemCommand(string command, string path)
        {
            var parameters = new Dictionary<string, object> { { "id", this.Id }, { "path", path } };
            var response = this.Execute(command, parameters);

            return this.CreateWiniumElementFromResponse(response);
        }

        #endregion
    }
}
