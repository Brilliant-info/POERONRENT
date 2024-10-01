using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using PowerOnRentwebapp.Login;
using PowerOnRentwebapp.DocumentService;
using System.IO;
using System.Web.UI;



namespace PowerOnRentwebapp.Document
{
    public partial class Document : System.Web.UI.Page
    {
        static string sessionID, TargetObjectName;
        static long Sequence;
        static FileUpload DocFileUpload;
        protected void Page_PreInit(Object sender, EventArgs e)
        {
            CustomProfile profile = CustomProfile.GetProfile();
            if (profile.Personal.Theme == null || profile.Personal.Theme == string.Empty) { Page.Theme = "Blue"; } else { Page.Theme = profile.Personal.Theme; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            DocFileUpload = FileUploadDocument;
            sessionID = Session.SessionID;
            if (Request.QueryString["Sequence"] != null) { Sequence = Convert.ToInt32(Request.QueryString["Sequence"]); }
            if (Request.QueryString["TargetObjectName"] != null) { TargetObjectName = Request.QueryString["TargetObjectName"].ToString() + "Document"; }
        }

        [WebMethod]
        public static string CheckDocumentTitle(string DocumentTitle)
        {
            DocumentService.iUC_AttachDocumentClient DocumentClient = new DocumentService.iUC_AttachDocumentClient();
            CustomProfile profile = CustomProfile.GetProfile();
            string Result;
            Result = DocumentClient.CheckDuplicateDocumentTitle(sessionID, DocumentTitle, profile.Personal.UserID.ToString(), TargetObjectName, profile.DBConnection._constr);
            DocumentClient.Close();
            return Result;
        }


        protected void upload_LinkBtn_Click(object sender, EventArgs e)
        {
            string DocumentSaveAsPath = "";
            string DocumentDownLoadPath = "";
            string HttpAppPath = HttpRuntime.AppDomainAppPath;
            iUC_AttachDocumentClient documentClient = new iUC_AttachDocumentClient();
            try
            {
                CustomProfile profile = CustomProfile.GetProfile();
                if (FileUploadDocument.PostedFile != null)
                {
                    if (profile.Personal.CompanyID.ToString() != "")
                    {
                        if (!(Directory.Exists(HttpAppPath + "Document\\TempAttach_Document\\" + profile.Personal.CompanyID.ToString())))
                        {
                            Directory.CreateDirectory(HttpAppPath + "Document\\TempAttach_Document\\" + profile.Personal.CompanyID.ToString());
                        }
                    }
                    //string FileType = FileUploadDocument.PostedFile.ContentType.Split('/').LastOrDefault();
                    string[] strArr = FileUploadDocument.PostedFile.FileName.Split('.');
                    string FileType = strArr[strArr.Length - 1];
                    string FileName = Session.SessionID.ToString() + "_" + DateTime.Now.Ticks.ToString() + "." + FileType;
                    DocumentDownLoadPath = "../Document/TempAttach_Document/" + profile.Personal.CompanyID.ToString() + "/" + FileName;
                    DocumentSaveAsPath = HttpAppPath + "Document\\TempAttach_Document\\" + profile.Personal.CompanyID.ToString() + "\\" + FileName;
                    FileUploadDocument.SaveAs(DocumentSaveAsPath);

                    /*Insert into TempData*/
                    SP_GetDocumentList_Result newDocument = new SP_GetDocumentList_Result();

                    newDocument.ObjectName = TargetObjectName; ;
                    newDocument.ReferenceID = Convert.ToInt64(Sequence);
                    newDocument.DocumentName = null;
                    if (txtDocTitle.Text.ToString().Trim() != "") newDocument.DocumentName = txtDocTitle.Text.ToString().Trim();
                    newDocument.Sequence = Convert.ToInt32(Sequence);
                    newDocument.Description = null;
                    if (txtDocDesc.Text.ToString().Trim() != "") newDocument.Description = txtDocDesc.Text.ToString().Trim();

                    newDocument.DocumentDownloadPath = DocumentDownLoadPath;
                    newDocument.DocumentSavePath = DocumentSaveAsPath;
                    newDocument.FileType = FileType;

                    newDocument.Keywords = null;
                    if (txtKeyword.Text.ToString().Trim() != "") newDocument.Keywords = txtKeyword.Text.ToString().Trim();

                    if (rbtnPrivate.Checked == true)
                    {
                        newDocument.ViewAccess_Value = "";
                        newDocument.DeleteAccess_Value = hdnDeleteAccessIDs.Value;
                        newDocument.DowloadAccess_Value = hdDownLoadAccessIDs.Value;
                    }
                    else if (rbtnPublic.Checked == true)
                    {
                        newDocument.ViewAccess_Value = "Public";
                        newDocument.DeleteAccess_Value = "Public";
                        newDocument.DowloadAccess_Value = "Public";
                    }
                    else if (rbtnSelf.Checked == true)
                    {
                        newDocument.ViewAccess_Value = newDocument.DeleteAccess_Value = newDocument.DowloadAccess_Value = profile.Personal.UserID.ToString();
                    }

                    newDocument.Active = "Y";
                    newDocument.CreatedBy = profile.Personal.UserID.ToString();
                    newDocument.CreationDate = DateTime.Now;
                    newDocument.CustomerHeadID = 0;
                    newDocument.CompanyID = profile.Personal.CompanyID;
                    newDocument.ViewAccess = "true";
                    newDocument.DeleteAccess = "true";
                    newDocument.DowloadAccess = "true";
                    documentClient.InsertIntoTemp(newDocument, Session.SessionID.ToString(), profile.Personal.UserID.ToString(), TargetObjectName, profile.DBConnection._constr);
                    ClientScript.RegisterStartupScript(GetType(), "hwa", "onSuccessTempSaveDocument('true');", true);

                }
            }
            catch (System.Exception ex)
            {
                if (DocumentSaveAsPath != "") if (File.Exists(DocumentSaveAsPath)) File.Delete(DocumentSaveAsPath);
                Login.Profile.ErrorHandling(ex, this, "UC Document", "upload_LinkBtn_Click");
            }
            finally { documentClient.Close(); }
        }
    }
}
