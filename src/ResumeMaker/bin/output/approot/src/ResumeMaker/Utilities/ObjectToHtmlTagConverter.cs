using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc.Rendering;

namespace ResumeMaker.Utilities
{
    public class ObjectToHtmlTagConverter
    {
        private object _obj;

        public ObjectToHtmlTagConverter(object obj)
        {
            _obj = obj;
        }

        public HtmlString GetHtmlElement()
        {
            return new HtmlString("");
        }

    }
}
