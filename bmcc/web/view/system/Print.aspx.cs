using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ModelInfo;
using SQLDAL;



using System.Data.SqlClient;

using System.Web.UI.HtmlControls;
using System.Web.Script.Services;
using System.Web.Services;





using System.Data;
using System.Collections;



public partial class view_system_Print : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {









    }



    [WebMethod]
    public static int changeprintstatus(string id, string bartype)
    {

        RecipeModel rm = new RecipeModel();
        int result = rm.changeprintstatus(id, bartype);


        return result;

    }

    [WebMethod]
    public static int changeprintstatus3(string id, string bartype)
    {

        RecipeModel rm = new RecipeModel();
        int result = rm.changeprintstatus3(id, bartype);
        return result;

    }
    [WebMethod]
    public static int changeprintstatus4(string id, string bartype)
    {

        RecipeModel rm = new RecipeModel();
        int result = rm.changeprintstatus4(id, bartype);
        return result;

    }
    [WebMethod]
    public static int changeprintstatus5(string id, string bartype)
    {

        RecipeModel rm = new RecipeModel();
        int result = rm.changeprintstatus5(id, bartype);
        return result;

    }
    [WebMethod]
    public static int changeprintstatus6(string id, string bartype)
    {

        RecipeModel rm = new RecipeModel();
        int result = rm.changeprintstatus6(id, bartype);
        return result;

    }
    [WebMethod]
    public static int changeprintstatus7(string id, string bartype)
    {

        RecipeModel rm = new RecipeModel();
        int result = rm.changeprintstatus7(id, bartype);
        return result;

    }
    [WebMethod]
    public static int changeprintstatus8(string id, string bartype)
    {

        RecipeModel rm = new RecipeModel();
        int result = rm.changeprintstatus8(id, bartype);
        return result;
    }
    [WebMethod]
    public static int changeprintstatus9(string id, string bartype)
    {

        RecipeModel rm = new RecipeModel();
        int result = rm.changeprintstatus9(id, bartype);
        return result;

    }
    [WebMethod]
    public static int changeprintstatus10(string id, string bartype)
    {

        RecipeModel rm = new RecipeModel();
        int result = rm.changeprintstatus10(id, bartype);
        return result;

    }
    [WebMethod]
    public static int changeprintstatus11(string id, string bartype)
    {

        RecipeModel rm = new RecipeModel();
        int result = rm.changeprintstatus11(id, bartype);
        return result;

    }
    [WebMethod]
    public static int changeprintstatus12(string id, string bartype)
    {

        RecipeModel rm = new RecipeModel();
        int result = rm.changeprintstatus12(id, bartype);
        return result;

    }
    [WebMethod]
    public static int changeprintstatus13(string id, string bartype)
    {

        RecipeModel rm = new RecipeModel();
        int result = rm.changeprintstatus13(id, bartype);
        return result;

    }
    [WebMethod]
    public static int changeprintstatus14(string id, string bartype)
    {

        RecipeModel rm = new RecipeModel();
        int result = rm.changeprintstatus14(id, bartype);
        return result;

    }
    [WebMethod]
    public static int changeprintstatus15(string id, string bartype)
    {

        RecipeModel rm = new RecipeModel();
        int result = rm.changeprintstatus15(id, bartype);
        return result;

    }
    [WebMethod]
    public static int changeprintstatus16(string id, string bartype)
    {

        RecipeModel rm = new RecipeModel();
        int result = rm.changeprintstatus16(id, bartype);
        return result;

    }
    [WebMethod]
    public static int changeprintstatus17(string id, string bartype)
    {

        RecipeModel rm = new RecipeModel();
        int result = rm.changeprintstatus17(id, bartype);
        return result;

    }
    [WebMethod]
    public static int changeprintstatus18(string id, string bartype)
    {

        RecipeModel rm = new RecipeModel();
        int result = rm.changeprintstatus18(id, bartype);
        return result;

    }

    [WebMethod]
    public static int changeprintstatus19(string id, string bartype)
    {

        RecipeModel rm = new RecipeModel();
        int result = rm.changeprintstatus19(id, bartype);
        return result;

    }

    [WebMethod]
    public static string getstatus(string bartype)
    {

        RecipeModel rm = new RecipeModel();
        string result = rm.getstatus(bartype);
        return result;

    }
}