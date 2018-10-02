using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace RazorEngineExpl.Models
{
    public class CommonModel
    {
        public DataTable PrimaryData { get; set; }

        public DataTable DetailListData { get; set; }

        public DataTable TaskData { get; set; }

        public DataTable AttacData { get; set; }
    }
}