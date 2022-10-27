using MilkRun.UtilizeApp.Models;
using System.Collections.Generic;

namespace MilkRun.UtilizeApp.ViewModel
{
    public class PackagingPartVM
    {
        ///<summary>
        /// Gets or sets Customers.
        ///</summary>
        public List<AppPackagingPart> AppPackagingParts { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int RecordCount { get; set; }
    }
}
