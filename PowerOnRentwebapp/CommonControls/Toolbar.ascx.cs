﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PowerOnRentwebapp.ToolbarService;
using PowerOnRentwebapp.Login;

namespace PowerOnRentwebapp.CommonControls
{
    public partial class Toolbar : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public mUserRolesDetail GetUserRightsByObjectName(string ObjectName, string FormType, string AlertMsg)
        {
            mUserRolesDetail userRights = new mUserRolesDetail();
            iUCToolbarClient objService = new iUCToolbarClient();
            try
            {
                if (AlertMsg == "") AlertMsg = "Not Allowed";
                CustomProfile profile = CustomProfile.GetProfile();
                userRights = objService.GetUserRightsBy_ObjectNameUserID(ObjectName, profile.Personal.UserID, profile.DBConnection._constr);
            }
            catch { }
            finally { objService.Close(); }
            return userRights;
        }

        public void SetUserRights(string ObjectName, string FormType, string AlertMsg)
        {
            iUCToolbarClient objService = new iUCToolbarClient();
            try
            {
                if (AlertMsg == "") AlertMsg = "Not Allowed";
                CustomProfile profile = CustomProfile.GetProfile();
                mUserRolesDetail userRights = new mUserRolesDetail();
                userRights = objService.GetUserRightsBy_ObjectNameUserID(ObjectName, profile.Personal.UserID, profile.DBConnection._constr);
                SetAddNewRight(false, AlertMsg);
                SetSaveRight(false, AlertMsg);
                SetClearRight(false, AlertMsg);
                SetExportRight(false, AlertMsg);
                SetImportRight(false, AlertMsg);
                SetMailRight(false, AlertMsg);
                SetPrintRight(false, AlertMsg);
                SetConvertToRight(false, AlertMsg);

                if (userRights != null)
                {
                    SetAddNewRight(Convert.ToBoolean(userRights.Add), AlertMsg);
                    if (FormType == "EntryForm" && Convert.ToBoolean(userRights.Add) == true)
                    {
                        SetSaveRight(true, "");
                        SetClearRight(true, "");
                    }
                }

            }
            catch { }
            finally { objService.Close(); }
        }

        public void SetAddNewRight(bool val, string msg, string RedirectTo = "#")
        {
            btnAddNew.Attributes.Add("class", "Off buttonON");
            btnAddNew.Attributes.Add("onclick", "showAlert('" + msg + "','orange','" + RedirectTo + "')");

            if (val == true)
            {
                btnAddNew.Attributes.Add("class", "buttonON");
                btnAddNew.Attributes.Add("onclick", "jsAddNew()");
            }

        }
        public void SetSaveRight(bool val, string msg)
        {
            btnSave.Attributes.Add("class", "Off buttonON");
            btnSave.Attributes.Add("onclick", "showAlert('" + msg + "','orange','#')");

            if (val == true)
            {
                btnSave.Attributes.Add("class", "buttonON");
                btnSave.Attributes.Add("onclick", "jsbtnSave_onclick();");
            }
        }
        public void SetClearRight(bool val, string msg)
        {
            btnClear.Attributes.Add("class", "Off buttonON");
            btnClear.Attributes.Add("onclick", "showAlert('" + msg + "','orange','#')");

            if (val == true)
            {
                btnClear.Attributes.Add("class", "buttonON");
                btnClear.Attributes.Add("onclick", "jsAddNew()");
            }
        }
        public void SetExportRight(bool val, string msg)
        {
            btnExport.Attributes.Add("class", "Off buttonON");
            btnExport.Attributes.Add("onclick", "showAlert('" + msg + "','orange','#')");
        }
        public void SetImportRight(bool val, string msg)
        {
            btnImport.Attributes.Add("class", "Off buttonON");
            btnImport.Attributes.Add("onclick", "showAlert('" + msg + "','orange','#')");
        }
        public void SetMailRight(bool val, string msg)
        {
            btnMail.Attributes.Add("class", "Off buttonON");
            btnMail.Attributes.Add("onclick", "showAlert('" + msg + "','orange','#')");
        }
        public void SetPrintRight(bool val, string msg)
        {
            btnPrint.Attributes.Add("class", "Off buttonON");
            btnPrint.Attributes.Add("onclick", "showAlert('" + msg + "','orange','#')");
        }
        public void SetConvertToRight(bool val, string msg)
        {
            btnConvertTo.Attributes.Add("class", "Off buttonON");
            btnConvertTo.Attributes.Add("onclick", "showAlert('" + msg + "','orange','#')");
        }
    }
}