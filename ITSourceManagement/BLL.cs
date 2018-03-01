using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITSourceManagement
{
    public interface IPageList
    {
        int TotalPage //总页数
        {
            get;
        }
        int TotalCount//总数量
        {
            get;
            set;
        }

        int PageIndex//第几页
        {
            get;
            set;
        }

        int PageSize//一页显示几条数据
        {
            get;
            set;
        }

        bool IsPreviousPage//是否上一页
        {
            get;
        }

        bool IsNextPage
        {
            get;
        }
    }

    public class PagedList<T>:List<T>,IPageList
    {
        #region 初始化
        public int TotalPage
        {
            get
            {
                return (int)Math.Ceiling((double)TotalCount / PageSize);
            }
        }
        public int TotalCount
        {
            get;
            set;
        }

        public int PageIndex
        {
            get;
            set;
        }

        public int PageSize
        {
            get;
            set;
        }

        public bool IsPreviousPage
        {
            get { return (PageIndex > 1); }
        }

        public bool IsNextPage
        {
            get
            {
                return ((PageIndex) * PageSize) < TotalCount;
            }
        }
        #endregion

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="source">数据源</param>
        /// <param name="pageIndex">第几页</param>
        /// <param name="pageSize">每页数据量</param>
        public PagedList(IQueryable<T> source,int? pageIndex,int? pageSize)
        {
            if (!pageIndex.HasValue) pageIndex = 1;
            if (!pageSize.HasValue) pageSize = 10;
            this.TotalCount = source.Count();
            this.PageSize = PageSize;
            this.PageIndex = PageIndex;
            if (IsPreviousPage == false) PageIndex = 1;
            if (IsNextPage == false) PageIndex = TotalPage;
            int BeforePageIndex = pageIndex.Value - 1;
            BeforePageIndex = BeforePageIndex<=0?0:BeforePageIndex;

            AddRange(source.Skip(BeforePageIndex*pageSize.Value).Take(pageSize.Value));
        }

        public PagedList(IEnumerable<T> source, int? pageIndex, int? pageSize)
        {
            if (!pageIndex.HasValue) pageIndex = 1;
            if (!pageSize.HasValue) pageSize = 20;
            this.TotalCount = source.Count();
            this.PageSize = PageSize;
            this.PageIndex = PageIndex;
            if (IsPreviousPage == false) PageIndex = 1;
            if (IsNextPage == false) PageIndex = TotalPage;
            int BeforePageIndex = pageIndex.Value - 1;
            BeforePageIndex = BeforePageIndex <= 0 ? 0 : BeforePageIndex;

            AddRange(source.Skip(BeforePageIndex * pageSize.Value).Take(pageSize.Value));
        }
    }

    public static class Pagination
    {
        public static PagedList<T> ToPagedList<T>(this IQueryable<T> source,int? index,int? pageSize)
        {
            return new PagedList<T>(source,index,pageSize);
        }

        public static PagedList<T> ToPagedList<T>(this IQueryable<T> source, int? index)
        {
            return new PagedList<T>(source, index,10);
        }

        public static PagedList<T> ToPagedList<T>(this IEnumerable<T> source,int? index,int? pageSize)
        {
            return new PagedList<T>(source,index,pageSize);
        }

        public static PagedList<T> ToPagedList<T>(this IEnumerable<T> source, int? index)
        {
            return new PagedList<T>(source, index,20);
        }
    }
}