using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Umbrella.UI.Web.MVC.Helpers.HtmlHelpers.Bootstrap
{
    public class BootstrapBackground
    {
        string _class;

        public BootstrapBackground()
        {
            this._class = BootstrapNames.INFO;
        }

        public string BuildClassName()
        {
            return "bg-" + this._class;
        }

        public void Success()
        {
            this._class = BootstrapNames.SUCCESS;
        }

        public void Info()
        {
            this._class = BootstrapNames.INFO;
        }

        public void Warning()
        {
            this._class = BootstrapNames.WARNING;
        }
    }
}