namespace Winium.Elements.Desktop
{
    #region using

    using System.Collections.Generic;

    using OpenQA.Selenium.Winium;

    #endregion

    public class ListBox : DesktopElement
    {
        #region Constants

        private const string ScrollToListBoxItem = "scrollToListBoxItem";

        #endregion

        #region Constructors and Destructors

        public ListBox(WiniumElement element)
            : base(element)
        {
        }

        #endregion

        #region Public Methods and Operators

        public WiniumElement ScrollTo(WiniumBy by)
        {
            var response = this.Execute(
                ScrollToListBoxItem,
                new Dictionary<string, object>
                    {
                        { "id", this.Id },
                        { "using", by.Mechanism },
                        { "value", by.Criteria },
                    });

            return this.CreateWiniumElementFromResponse(response);
        }

        #endregion
    }
}
