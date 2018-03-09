using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITSourceManagement.Filter
{
    public class MyAuthorizationAttribute:AuthorizeAttribute
    {
        bool localAllowed;
        public MyAuthorizationAttribute(bool allowed)
        {
            localAllowed = allowed;
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if(httpContext!=null)
            {
                if(httpContext.Request.IsLocal)
                {
                    return localAllowed;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }
    }
}