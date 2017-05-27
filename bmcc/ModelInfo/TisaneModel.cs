using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLDAL;
using System.Data;

namespace ModelInfo
{
    public class TisaneModel
    {
        DataBaseLayer db = new DataBaseLayer();
        public DataTable searchTisaneClass()
        {
            string strSQL = "select id,pspnum,tisaneclassid,pspstate,remark from TisaneClassDst";
            DataTable dt = db.get_DataTable(strSQL);

            return dt;
        }
    }
}
