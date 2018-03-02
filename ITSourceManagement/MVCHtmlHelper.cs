using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ITSourceManagement.Models;
using System.Web.Mvc;

namespace ITSourceManagement
{
    public static class MVCHtmlHelper
    {
        public static MvcHtmlString Pager(this HtmlHelper helper,string id,int currentPageIndex,int pageSize,int recordCount,object htmlAttributes,string className)
        {
            TagBuilder builder = new TagBuilder("table");
            builder.IdAttributeDotReplacement = "_";
            builder.GenerateId(id);
            builder.AddCssClass(className);
            builder.InnerHtml = GetNormalPage(currentPageIndex, pageSize, recordCount);

            return builder.ToMvcHtmlString(TagRenderMode.Normal);
        }

        public static MvcHtmlString ToMvcHtmlString(this TagBuilder tagBuilder,TagRenderMode renderMode)
        {
            return new MvcHtmlString(tagBuilder.ToString(renderMode));
        }

        /// <summary>
        /// 生成分页的html
        /// </summary>
        /// <param name="currentPageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="RecordCount"></param>
        /// <returns></returns>
        private static string GetNormalPage(int currentPageIndex, int PageSize, int RecordCount)
        {
            int pageCount = Convert.ToInt32(Math.Ceiling((double)RecordCount / (double)PageSize));
            var url = new StringBuilder();
            url.Append(HttpContext.Current.Request.Url.AbsolutePath + "?page={0}");

            var sb = new StringBuilder();
            sb.Append("<tr><td>");
            sb.AppendFormat("总共{0}条记录,共{1}页,当前第{2}页&nbsp;&nbsp;", RecordCount, pageCount, currentPageIndex);
            if(currentPageIndex==1)
            {
                sb.Append("<span>首页</span>&nbsp");
            }
            else
            {
                var url1 = string.Format(url.ToString(),1);
                sb.AppendFormat("<span><a href={0}>首页</a></span>&nbsp;", url1);
            }

            if(currentPageIndex>1)
            {
                var url1 = string.Format(url.ToString(), currentPageIndex - 1);
                sb.AppendFormat("<span><a href={0}>上一页</a></span>&nbsp;", url1);
            }
            else
                sb.Append("<span>上一页</span>&nbsp;");
             if (currentPageIndex < pageCount)
            {
                string url1 = string.Format(url.ToString(), currentPageIndex + 1);
                sb.AppendFormat("<span><a href={0}>下一页</a></span>&nbsp;", url1);
            }
            else
                sb.Append("<span>下一页</span>&nbsp;");

            if (currentPageIndex == pageCount)
                sb.Append("<span>末页</span>&nbsp;");
            else
            {
                string url1 = string.Format(url.ToString(), pageCount);
                sb.AppendFormat("<span><a href={0}>末页</a></span>&nbsp;", url1);
            }

            return sb.ToString();
        }
    }
}