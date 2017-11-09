using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.ViewModel
{
    public class ViewListModel<T>
    {
        /// <summary>
        /// 当前索引
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// 每页数量
        /// </summary>
        public int PageSize { get; set; } = 10;

        /// <summary>
        /// 总记录
        /// </summary>
        public int TotalRecord { get; set; }
        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPage { get; set; }

        /// <summary>
        /// 数据集
        /// </summary>
        public List<T> Rows { get; set; }
    }
}
