using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PowerOnRentwebapp.Login;
using PowerOnRentwebapp.PORServicePartRequest;
using PowerOnRentwebapp.ToolbarService;
using System.Web.Services;

namespace PowerOnRentwebapp.PowerOnRent
{
    public partial class GridRequestSummary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["FillBy"] != null)
            {
                FillGVRequest(Request.QueryString["FillBy"].ToString());
            }
        }

        protected void Page_PreInit(Object sender, EventArgs e)
        {
            CustomProfile profile = CustomProfile.GetProfile();
            if (profile.Personal.Theme == null || profile.Personal.Theme == string.Empty) { Page.Theme = "Blue"; } else { Page.Theme = profile.Personal.Theme; }
        }

        protected void FillGVRequest(string FillBy)
        {
            iPartRequestClient objServie = new iPartRequestClient();
            try
            {
                CustomProfile profile = CustomProfile.GetProfile();
                GVRequest.DataSource = null;
                GVRequest.DataBind();
                if (FillBy == "UserID")
                {
                    GVRequest.DataSource = objServie.GetRequestSummayByUserID(profile.Personal.UserID, profile.DBConnection._constr);
                }
                else if (FillBy == "SiteIDs")
                {
                    GVRequest.DataSource = objServie.GetRequestSummayBySiteIDs(Session["SiteIDs"].ToString(), profile.DBConnection._constr);
                }
                GVRequest.DataBind();
            }
            catch { }
            finally { objServie.Close(); }
        }

    }
}