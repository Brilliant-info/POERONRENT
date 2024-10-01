using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PowerOnRentwebapp.Login;
using PowerOnRentwebapp.UCProductSearchService;

namespace PowerOnRentwebapp.Product
{
    public partial class ProductSearch : System.Web.UI.Page
    {

        protected void Page_PreInit(Object sender, EventArgs e)
        { //CustomProfile profile = CustomProfile.GetProfile(); if (profile.Personal.Theme == null || profile.Personal.Theme == string.Empty) { Page.Theme = "Blue"; } else { Page.Theme = profile.Personal.Theme; } 
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                hndgrupByGrid.Value = GridProductSearch.GroupBy;
                RebindGrid(sender, e);
            }
            catch (System.Exception ex)
            {
                Login.Profile.ErrorHandling(ex, this, "ProductSearch.aspx.cs", "Page_Load");
            }

        }

        protected void RebindGrid(object sender, EventArgs e)
        {
            try
            {
                UCProductSearchService.iUCProductSearchClient productSearchService = new UCProductSearchService.iUCProductSearchClient();
                CustomProfile profile = CustomProfile.GetProfile();
                List<GetProductDetail> ProductList = new List<GetProductDetail>();
                ProductList = productSearchService.GetProductList1(GridProductSearch.CurrentPageIndex, hdnFilterText.Value, profile.DBConnection._constr).ToList();
               
                GridProductSearch.DataSource = ProductList;
                GridProductSearch.GroupBy = hndgrupByGrid.Value;
                if (!Page.IsPostBack) { GridProductSearch.GroupBy = "ProductType"; }
                GridProductSearch.DataBind();
                productSearchService.Close();
            }
            catch (System.Exception ex)
            {
                Login.Profile.ErrorHandling(ex, this, "ProductSearch.aspx.cs", "RebindGrid");
            }
        }


    }
}