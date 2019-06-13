using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EduServiceHelper.BLL;
using System.Web.Script.Serialization;
using System.Data.SqlClient;

namespace Test
{
    public partial class ChangeCalc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {

            } 
        }


        protected void btnAlterTable_Click(object sender, EventArgs e)
        {
            if (tbAlterText.Text != "Start") return;
            //string alterText = "alter table Jft_{0}_Menus add [IsPay] [bit] NULL"; 
            KCourse _courseBll = new KCourse("DestConn");
            string _strWhere = " ifmod=1 ";
            var courses = _courseBll.Select(_strWhere);
            EduServiceHelper.DbHelperSql sqlhelp = new EduServiceHelper.DbHelperSql("DestConn");
            string signs = "";
            foreach (var c in courses)
            {
                try
                {
                    SqlParameter[] _parameters = new SqlParameter[] {
                        new SqlParameter("@Sign",c.Sign)
                    };
                    //var b = sqlhelp.RunNonQueryProcedure("PR_AlterReclaimTable", _parameters); //添加列
                    var gb = sqlhelp.RunNonQueryProcedure("PR_UpdateReclaimTable", _parameters); //修改列数据
                    if (!gb)
                    {
                        signs += c.Sign + ",";
                    }
                }
                catch
                {
                    signs += c.Sign + ",";
                }
            }


        }
    }

    public class TempKMatch
    {
        /// <summary>
        /// 当前试卷号
        /// </summary>
        public string ExamNumber { get; set; }
        /// <summary>
        /// 需要匹配的题型
        /// </summary>
        public int ProbId { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int OrderNo { get; set; }


    }
}