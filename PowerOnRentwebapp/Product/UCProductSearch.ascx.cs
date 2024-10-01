using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using PowerOnRentwebapp.UCProductSearchService;
using PowerOnRentwebapp.Login;



namespace PowerOnRentwebapp.Product
{
    public partial class UCProductSearch : System.Web.UI.UserControl
    {
        public Page ParentPage { get; set; }
        UCProductSearchService.iUCProductSearchClient productSearchService = new UCProductSearchService.iUCProductSearchClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    CustomProfile profile = CustomProfile.GetProfile();
            //    GridProductSearch.DataSource = productSearchService.GetProductList(profile.DBConnection._constr);
            //    GridProductSearch.DataBind();
            //}
            //catch (System.Exception ex)
            //{
            //    Login.Profile.ErrorHandling(ex, ParentPage, "UCProductSearch", "Page_Load");
            //}

        }

        //protected void RebindGrid(object sender, EventArgs e)
        //{
        //}
    }
}