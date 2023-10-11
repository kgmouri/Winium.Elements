namespace Winium.Elements.Desktop
{
    #region using

    using System.Collections.Generic;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Winium;

    #endregion

    public class ComboBox : DesktopElement
    {
        #region Constants

        private const string CollapseComboBox = "collapseComboBox";

        private const string ExpandComboBox = "expandComboBox";

        private const string FindComboBoxSelectedItem = "findComboBoxSelectedItem";

        private const string IsComboBoxExpanded = "isComboBoxExpanded";

        private const string ScrollToComboBoxItem = "scrollToComboBoxItem";

        #endregion

        #region Constructors and Destructors

        public ComboBox(WiniumElement element)
            : base(element)
        {
        }

        #endregion

        #region Public Properties

        public bool IsExpanded
        {
            get
            {
                var parameters = new Dictionary<string, object> { { "id", this.Id } };
                var response = this.Execute(IsComboBoxExpanded, parameters);

                return bool.Parse(response.Value.ToString());
            }
        }

        #endregion

        #region Public Methods and Operators

        public void Collapse()
        {
            this.CallComboBoxCommand(CollapseComboBox);
        }

        public void Expand()
        {
            this.CallComboBoxCommand(ExpandComboBox);
        }

        public WiniumElement FindSelected(int row, int column)
        {
            return this.CreateWiniumElementFromResponse(this.CallComboBoxCommand(FindComboBoxSelectedItem));
        }

        public WiniumElement ScrollTo(WiniumBy by)
        {
            var response = this.Execute(
                ScrollToComboBoxItem,
                new Dictionary<string, object>
                    {
                        { "id", this.Id },
                        { "using", by.Mechanism },
                        { "value", by.Criteria },
                    });

            return this.CreateWiniumElementFromResponse(response);
        }

        #endregion

        #region Methods

        private Response CallComboBoxCommand(string command)
        {
            var parameters = new Dictionary<string, object> { { "id", this.Id } };
            return this.Execute(command, parameters);
        }

        #endregion
    }
}
