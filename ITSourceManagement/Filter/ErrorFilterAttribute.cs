using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITSourceManagement.Filter
{
    public class ErrorFilterAttribute : FilterAttribute
    {
        public void Application_Error(object sender,EventArgs e)
        {
            Exception exception = HttpContext.Current.Server.GetLastError();
            if(exception!=null)
            {
                HttpException httpException = exception as HttpException;
                if(httpException!=null)
                {
                    int errorCode = httpException.GetHttpCode();
                    if(errorCode == 400 || errorCode == 404)
                    {
                        HttpContext.Current.Response.StatusCode = 404;
                        HttpContext.Current.Response.Redirect(string.Format("~/Error/Error404"),true);
                        return;
                    }
                }

                var postData = string.Empty;
                try
                {
                    using (System.IO.Stream stream = HttpContext.Current.Request.InputStream)
                    {
                        using (System.IO.StreamReader reader = new System.IO.StreamReader(stream, System.Text.Encoding.UTF8))
                        {
                            postData = reader.ReadToEnd();
                        }
                    }
                }
                catch { }

                HttpContext.Current.Response.StatusCode = 500;
                HttpContext.Current.Response.Redirect("~/Error/Error500",true);
                HttpContext.Current.Server.ClearError();
            }
        }
    }
}