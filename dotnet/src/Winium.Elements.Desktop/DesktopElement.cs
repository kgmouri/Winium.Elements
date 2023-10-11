namespace Winium.Elements.Desktop
{
    #region using

    using System;
    using System.Collections.Generic;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Winium;
    using Winium.Elements.Desktop.Extensions;

    #endregion

    public abstract class DesktopElement : WiniumElement
    {
        #region Constructors and Destructors

        protected DesktopElement(WiniumElement element)
            : base(GetWiniumDriver(element), element.GetId())
        {
        }

        #endregion

        #region Methods

        protected WiniumElement CreateWiniumElementFromResponse(Response response)
        {
            var elementDictionary = response.Value as Dictionary<string, object>;
            if (elementDictionary == null)
            {
                return null;
            }

            return new WiniumElement((WiniumDriver)this.WrappedDriver, (string)elementDictionary["element-6066-11e4-a52e-4f735466cecf"]);
        }

        private static WiniumDriver GetWiniumDriver(WiniumElement element)
        {
            var winiumElement = element as WiniumElement;
            if (winiumElement == null)
            {
                throw new InvalidCastException("Specified cast is not valid. Please use WiniumElement as parameter.");
            }

            return (WiniumDriver)winiumElement.WrappedDriver;
        }

        #endregion
    }
}
