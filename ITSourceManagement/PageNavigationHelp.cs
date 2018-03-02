using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ITSourceManagement.Models;

namespace ITSourceManagement
{
    public class PageNavigationHelp<T>:List<T>
    {
        public PagerInfo Pager { get; set; }

        /// <summary>
        /// 获取某页数据
        /// </summary>
        /// <param name="pager">分页项</param>
        /// <param name="source">源数据</param>
        public PageNavigationHelp(PagerInfo pager,IEnumerable<T> source)
        {
            this.Pager = pager;
            int BeforePageIndex = pager.CurrentPageIndex - 1;
            if(BeforePageIndex<=0)
            {
                BeforePageIndex = 0;
            }
            AddRange(source.Skip(BeforePageIndex*pager.PageSize).Take(pager.PageSize));
        }
    }
}