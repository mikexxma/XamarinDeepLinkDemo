using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepLinkForXamarinDemo.UWP
{
    class DeepLinkToImp : DeepLinkForXamarinDemo.DeepLinkTo
    {

        public string DeepLinkTo(string absolutePath)
        {
            switch (absolutePath)
            {
                case "/":
                    return "mainpage";
                case "/index.html":
                    return "mainpage";
                case "/page1.html":
                    return "page1";
                case "/page2.html":
                    return "page2";
            }
            return null;
        }
    }
}
