using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using Obout.Interface;
using System.Collections;
using PowerOnRentwebapp.DocumentService;
using PowerOnRentwebapp.Login;
using System.Web.Services;

namespace PowerOnRentwebapp.Document
{
    public partial class UC_AttachDocument : System.Web.UI.UserControl
    {
        [WebMethod]
        public static void ClearDocument(string TargetObjectName, string SessionID)
        {
            CustomProfile profile = CustomProfile.GetProfile();
            DocumentService.iUC_AttachDocumentClient DocumentServiceClient = new iUC_AttachDocumentClient();
            DocumentServiceClient.ClearTempData(SessionID, profile.Personal.UserID.ToString(), TargetObjectName + "Document", profile.DBConnection._constr);
            DocumentServiceClient.Close();
        }

        public void ClearDocument(string TargetObjectName)
        {
            CustomProfile profile = CustomProfile.GetProfile();
            hndDocumentTargetObjectName.Value = TargetObjectName;
            DocumentService.iUC_AttachDocumentClient DocumentServiceClient = new iUC_AttachDocumentClient();
            DocumentServiceClient.ClearTempData(Session.SessionID, profile.Personal.UserID.ToString(), TargetObjectName + "Document", profile.DBConnection._constr);
            DocumentServiceClient.Close();
            GvDocument.DataSource = null;
            GvDocument.DataBind();
        }

        public void FinalSaveDocument(long ReferenceID)
        {
            CustomProfile profile = CustomProfile.GetProfile();
            iUC_AttachDocumentClient DocumentSourceClient = new iUC_AttachDocumentClient();
            DocumentSourceClient.FinalSaveToDBtDocument(Session.SessionID, ReferenceID, profile.Personal.UserID.ToString(), hndDocumentTargetObjectName.Value + "Document", HttpRuntime.AppDomainAppPath.ToString(), profile.DBConnection._constr);
        }

        [WebMethod]
        public static void FinalSaveDocument1(long ReferenceID, string SessionID, string TargetObjectName)
        {
            CustomProfile profile = CustomProfile.GetProfile();
            iUC_AttachDocumentClient DocumentSourceClient = new iUC_AttachDocumentClient();
            DocumentSourceClient.FinalSaveToDBtDocument(SessionID, ReferenceID, profile.Personal.UserID.ToString(), TargetObjectName + "Document", HttpRuntime.AppDomainAppPath.ToString(), profile.DBConnection._constr);
        }

        public void FillDocumentByObjectNameReferenceID(long ReferenceID, string SourceObjectName, string TargetObjectName)
        {
            try
            {
                CustomProfile profile = CustomProfile.GetProfile();
                hndDocumentTargetObjectName.Value = TargetObjectName;
                DocumentService.iUC_AttachDocumentClient DocumentServiceClient = new iUC_AttachDocumentClient();
                GvDocument.DataSource = DocumentServiceClient.GetDocumentByReferenceId(SourceObjectName + "Document", TargetObjectName + "Document", ReferenceID, profile.Personal.UserID.ToString(), Session.SessionID.ToString(), profile.DBConnection._constr);
                GvDocument.DataBind();
            }
            catch (System.Exception ex)
            {
                Login.Profile.ErrorHandling(ex, "UC_AttachDocuments.ascx.cs", "FillDocumentByObjectNameReferenceID");
            }
        }

        protected void GvDocument_OnRebind(object sender, EventArgs e)
        {
            CustomProfile profile = CustomProfile.GetProfile();
            DocumentService.iUC_AttachDocumentClient DocumentServiceClient = new iUC_AttachDocumentClient();
            GvDocument.DataSource = DocumentServiceClient.GetExistingTempDataBySessionIDObjectNameToRebind(Session.SessionID, profile.Personal.UserID.ToString(), hndDocumentTargetObjectName.Value + "Document", profile.DBConnection._constr);
            GvDocument.DataBind();
            DocumentServiceClient.Close();
        }

    }
}