﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PowerOnRentwebapp.BindMenuService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ProBindMenu", Namespace="http://tempuri.org/")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(PowerOnRentwebapp.BindMenuService.ArrayOfString))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(PowerOnRentwebapp.BindMenuService.ProBindMenu[]))]
    public partial class ProBindMenu : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private PowerOnRentwebapp.BindMenuService.ArrayOfString _constPField;
        
        private long UserCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MenuCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ObjectCodeField;
        
        private long CompanyCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DivNameField;
        
        private bool BtnAddField;
        
        private bool BtnEditField;
        
        private bool BtnViewField;
        
        private bool BtnDeleteField;
        
        private bool BtnSaveField;
        
        private bool BtnClearField;
        
        private bool BtnExportField;
        
        private bool BtnImportField;
        
        private bool BtnMailField;
        
        private bool BtnPrintField;
        
        private bool BtnApprovalField;
        
        private bool BtnConvertToField;
        
        private bool BtnAssignTaskField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private object ActiveButtonField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public PowerOnRentwebapp.BindMenuService.ArrayOfString _constP {
            get {
                return this._constPField;
            }
            set {
                if ((object.ReferenceEquals(this._constPField, value) != true)) {
                    this._constPField = value;
                    this.RaisePropertyChanged("_constP");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=1)]
        public long UserCode {
            get {
                return this.UserCodeField;
            }
            set {
                if ((this.UserCodeField.Equals(value) != true)) {
                    this.UserCodeField = value;
                    this.RaisePropertyChanged("UserCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string MenuCode {
            get {
                return this.MenuCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.MenuCodeField, value) != true)) {
                    this.MenuCodeField = value;
                    this.RaisePropertyChanged("MenuCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string ObjectCode {
            get {
                return this.ObjectCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.ObjectCodeField, value) != true)) {
                    this.ObjectCodeField = value;
                    this.RaisePropertyChanged("ObjectCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=4)]
        public long CompanyCode {
            get {
                return this.CompanyCodeField;
            }
            set {
                if ((this.CompanyCodeField.Equals(value) != true)) {
                    this.CompanyCodeField = value;
                    this.RaisePropertyChanged("CompanyCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=5)]
        public string DivName {
            get {
                return this.DivNameField;
            }
            set {
                if ((object.ReferenceEquals(this.DivNameField, value) != true)) {
                    this.DivNameField = value;
                    this.RaisePropertyChanged("DivName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=6)]
        public bool BtnAdd {
            get {
                return this.BtnAddField;
            }
            set {
                if ((this.BtnAddField.Equals(value) != true)) {
                    this.BtnAddField = value;
                    this.RaisePropertyChanged("BtnAdd");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=7)]
        public bool BtnEdit {
            get {
                return this.BtnEditField;
            }
            set {
                if ((this.BtnEditField.Equals(value) != true)) {
                    this.BtnEditField = value;
                    this.RaisePropertyChanged("BtnEdit");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=8)]
        public bool BtnView {
            get {
                return this.BtnViewField;
            }
            set {
                if ((this.BtnViewField.Equals(value) != true)) {
                    this.BtnViewField = value;
                    this.RaisePropertyChanged("BtnView");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=9)]
        public bool BtnDelete {
            get {
                return this.BtnDeleteField;
            }
            set {
                if ((this.BtnDeleteField.Equals(value) != true)) {
                    this.BtnDeleteField = value;
                    this.RaisePropertyChanged("BtnDelete");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=10)]
        public bool BtnSave {
            get {
                return this.BtnSaveField;
            }
            set {
                if ((this.BtnSaveField.Equals(value) != true)) {
                    this.BtnSaveField = value;
                    this.RaisePropertyChanged("BtnSave");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=11)]
        public bool BtnClear {
            get {
                return this.BtnClearField;
            }
            set {
                if ((this.BtnClearField.Equals(value) != true)) {
                    this.BtnClearField = value;
                    this.RaisePropertyChanged("BtnClear");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=12)]
        public bool BtnExport {
            get {
                return this.BtnExportField;
            }
            set {
                if ((this.BtnExportField.Equals(value) != true)) {
                    this.BtnExportField = value;
                    this.RaisePropertyChanged("BtnExport");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=13)]
        public bool BtnImport {
            get {
                return this.BtnImportField;
            }
            set {
                if ((this.BtnImportField.Equals(value) != true)) {
                    this.BtnImportField = value;
                    this.RaisePropertyChanged("BtnImport");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=14)]
        public bool BtnMail {
            get {
                return this.BtnMailField;
            }
            set {
                if ((this.BtnMailField.Equals(value) != true)) {
                    this.BtnMailField = value;
                    this.RaisePropertyChanged("BtnMail");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=15)]
        public bool BtnPrint {
            get {
                return this.BtnPrintField;
            }
            set {
                if ((this.BtnPrintField.Equals(value) != true)) {
                    this.BtnPrintField = value;
                    this.RaisePropertyChanged("BtnPrint");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=16)]
        public bool BtnApproval {
            get {
                return this.BtnApprovalField;
            }
            set {
                if ((this.BtnApprovalField.Equals(value) != true)) {
                    this.BtnApprovalField = value;
                    this.RaisePropertyChanged("BtnApproval");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=17)]
        public bool BtnConvertTo {
            get {
                return this.BtnConvertToField;
            }
            set {
                if ((this.BtnConvertToField.Equals(value) != true)) {
                    this.BtnConvertToField = value;
                    this.RaisePropertyChanged("BtnConvertTo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=18)]
        public bool BtnAssignTask {
            get {
                return this.BtnAssignTaskField;
            }
            set {
                if ((this.BtnAssignTaskField.Equals(value) != true)) {
                    this.BtnAssignTaskField = value;
                    this.RaisePropertyChanged("BtnAssignTask");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=19)]
        public object ActiveButton {
            get {
                return this.ActiveButtonField;
            }
            set {
                if ((object.ReferenceEquals(this.ActiveButtonField, value) != true)) {
                    this.ActiveButtonField = value;
                    this.RaisePropertyChanged("ActiveButton");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ArrayOfString", Namespace="http://tempuri.org/", ItemName="string")]
    [System.SerializableAttribute()]
    public class ArrayOfString : System.Collections.Generic.List<string> {
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="BindMenuService.iBindMenu")]
    public interface iBindMenu {
        
        // CODEGEN: Generating message contract since element name objParaProBindMenu from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/iBindMenu/UserCode", ReplyAction="http://tempuri.org/iBindMenu/UserCodeResponse")]
        PowerOnRentwebapp.BindMenuService.UserCodeResponse UserCode(PowerOnRentwebapp.BindMenuService.UserCodeRequest request);
        
        // CODEGEN: Generating message contract since element name objParaProBindMenu from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/iBindMenu/CheckOperaction", ReplyAction="http://tempuri.org/iBindMenu/CheckOperactionResponse")]
        PowerOnRentwebapp.BindMenuService.CheckOperactionResponse CheckOperaction(PowerOnRentwebapp.BindMenuService.CheckOperactionRequest request);
        
        // CODEGEN: Generating message contract since element name objParaProBindMenu from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/iBindMenu/BindUserMenu", ReplyAction="http://tempuri.org/iBindMenu/BindUserMenuResponse")]
        PowerOnRentwebapp.BindMenuService.BindUserMenuResponse BindUserMenu(PowerOnRentwebapp.BindMenuService.BindUserMenuRequest request);
        
        // CODEGEN: Generating message contract since element name objProBindMenu from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/iBindMenu/ActiveButtonClickEvent", ReplyAction="http://tempuri.org/iBindMenu/ActiveButtonClickEventResponse")]
        PowerOnRentwebapp.BindMenuService.ActiveButtonClickEventResponse ActiveButtonClickEvent(PowerOnRentwebapp.BindMenuService.ActiveButtonClickEventRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class UserCodeRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="UserCode", Namespace="http://tempuri.org/", Order=0)]
        public PowerOnRentwebapp.BindMenuService.UserCodeRequestBody Body;
        
        public UserCodeRequest() {
        }
        
        public UserCodeRequest(PowerOnRentwebapp.BindMenuService.UserCodeRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class UserCodeRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public PowerOnRentwebapp.BindMenuService.ProBindMenu objParaProBindMenu;
        
        public UserCodeRequestBody() {
        }
        
        public UserCodeRequestBody(PowerOnRentwebapp.BindMenuService.ProBindMenu objParaProBindMenu) {
            this.objParaProBindMenu = objParaProBindMenu;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class UserCodeResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="UserCodeResponse", Namespace="http://tempuri.org/", Order=0)]
        public PowerOnRentwebapp.BindMenuService.UserCodeResponseBody Body;
        
        public UserCodeResponse() {
        }
        
        public UserCodeResponse(PowerOnRentwebapp.BindMenuService.UserCodeResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class UserCodeResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public PowerOnRentwebapp.BindMenuService.ProBindMenu[] UserCodeResult;
        
        public UserCodeResponseBody() {
        }
        
        public UserCodeResponseBody(PowerOnRentwebapp.BindMenuService.ProBindMenu[] UserCodeResult) {
            this.UserCodeResult = UserCodeResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class CheckOperactionRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="CheckOperaction", Namespace="http://tempuri.org/", Order=0)]
        public PowerOnRentwebapp.BindMenuService.CheckOperactionRequestBody Body;
        
        public CheckOperactionRequest() {
        }
        
        public CheckOperactionRequest(PowerOnRentwebapp.BindMenuService.CheckOperactionRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class CheckOperactionRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public PowerOnRentwebapp.BindMenuService.ProBindMenu objParaProBindMenu;
        
        public CheckOperactionRequestBody() {
        }
        
        public CheckOperactionRequestBody(PowerOnRentwebapp.BindMenuService.ProBindMenu objParaProBindMenu) {
            this.objParaProBindMenu = objParaProBindMenu;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class CheckOperactionResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="CheckOperactionResponse", Namespace="http://tempuri.org/", Order=0)]
        public PowerOnRentwebapp.BindMenuService.CheckOperactionResponseBody Body;
        
        public CheckOperactionResponse() {
        }
        
        public CheckOperactionResponse(PowerOnRentwebapp.BindMenuService.CheckOperactionResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class CheckOperactionResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public PowerOnRentwebapp.BindMenuService.ProBindMenu[] CheckOperactionResult;
        
        public CheckOperactionResponseBody() {
        }
        
        public CheckOperactionResponseBody(PowerOnRentwebapp.BindMenuService.ProBindMenu[] CheckOperactionResult) {
            this.CheckOperactionResult = CheckOperactionResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class BindUserMenuRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="BindUserMenu", Namespace="http://tempuri.org/", Order=0)]
        public PowerOnRentwebapp.BindMenuService.BindUserMenuRequestBody Body;
        
        public BindUserMenuRequest() {
        }
        
        public BindUserMenuRequest(PowerOnRentwebapp.BindMenuService.BindUserMenuRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class BindUserMenuRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public PowerOnRentwebapp.BindMenuService.ProBindMenu objParaProBindMenu;
        
        public BindUserMenuRequestBody() {
        }
        
        public BindUserMenuRequestBody(PowerOnRentwebapp.BindMenuService.ProBindMenu objParaProBindMenu) {
            this.objParaProBindMenu = objParaProBindMenu;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class BindUserMenuResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="BindUserMenuResponse", Namespace="http://tempuri.org/", Order=0)]
        public PowerOnRentwebapp.BindMenuService.BindUserMenuResponseBody Body;
        
        public BindUserMenuResponse() {
        }
        
        public BindUserMenuResponse(PowerOnRentwebapp.BindMenuService.BindUserMenuResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class BindUserMenuResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public PowerOnRentwebapp.BindMenuService.ProBindMenu[] BindUserMenuResult;
        
        public BindUserMenuResponseBody() {
        }
        
        public BindUserMenuResponseBody(PowerOnRentwebapp.BindMenuService.ProBindMenu[] BindUserMenuResult) {
            this.BindUserMenuResult = BindUserMenuResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ActiveButtonClickEventRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ActiveButtonClickEvent", Namespace="http://tempuri.org/", Order=0)]
        public PowerOnRentwebapp.BindMenuService.ActiveButtonClickEventRequestBody Body;
        
        public ActiveButtonClickEventRequest() {
        }
        
        public ActiveButtonClickEventRequest(PowerOnRentwebapp.BindMenuService.ActiveButtonClickEventRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class ActiveButtonClickEventRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public PowerOnRentwebapp.BindMenuService.ProBindMenu objProBindMenu;
        
        public ActiveButtonClickEventRequestBody() {
        }
        
        public ActiveButtonClickEventRequestBody(PowerOnRentwebapp.BindMenuService.ProBindMenu objProBindMenu) {
            this.objProBindMenu = objProBindMenu;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ActiveButtonClickEventResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ActiveButtonClickEventResponse", Namespace="http://tempuri.org/", Order=0)]
        public PowerOnRentwebapp.BindMenuService.ActiveButtonClickEventResponseBody Body;
        
        public ActiveButtonClickEventResponse() {
        }
        
        public ActiveButtonClickEventResponse(PowerOnRentwebapp.BindMenuService.ActiveButtonClickEventResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class ActiveButtonClickEventResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public PowerOnRentwebapp.BindMenuService.ProBindMenu ActiveButtonClickEventResult;
        
        public ActiveButtonClickEventResponseBody() {
        }
        
        public ActiveButtonClickEventResponseBody(PowerOnRentwebapp.BindMenuService.ProBindMenu ActiveButtonClickEventResult) {
            this.ActiveButtonClickEventResult = ActiveButtonClickEventResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface iBindMenuChannel : PowerOnRentwebapp.BindMenuService.iBindMenu, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class iBindMenuClient : System.ServiceModel.ClientBase<PowerOnRentwebapp.BindMenuService.iBindMenu>, PowerOnRentwebapp.BindMenuService.iBindMenu {
        
        public iBindMenuClient() {
        }
        
        public iBindMenuClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public iBindMenuClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public iBindMenuClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public iBindMenuClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        PowerOnRentwebapp.BindMenuService.UserCodeResponse PowerOnRentwebapp.BindMenuService.iBindMenu.UserCode(PowerOnRentwebapp.BindMenuService.UserCodeRequest request) {
            return base.Channel.UserCode(request);
        }
        
        public PowerOnRentwebapp.BindMenuService.ProBindMenu[] UserCode(PowerOnRentwebapp.BindMenuService.ProBindMenu objParaProBindMenu) {
            PowerOnRentwebapp.BindMenuService.UserCodeRequest inValue = new PowerOnRentwebapp.BindMenuService.UserCodeRequest();
            inValue.Body = new PowerOnRentwebapp.BindMenuService.UserCodeRequestBody();
            inValue.Body.objParaProBindMenu = objParaProBindMenu;
            PowerOnRentwebapp.BindMenuService.UserCodeResponse retVal = ((PowerOnRentwebapp.BindMenuService.iBindMenu)(this)).UserCode(inValue);
            return retVal.Body.UserCodeResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        PowerOnRentwebapp.BindMenuService.CheckOperactionResponse PowerOnRentwebapp.BindMenuService.iBindMenu.CheckOperaction(PowerOnRentwebapp.BindMenuService.CheckOperactionRequest request) {
            return base.Channel.CheckOperaction(request);
        }
        
        public PowerOnRentwebapp.BindMenuService.ProBindMenu[] CheckOperaction(PowerOnRentwebapp.BindMenuService.ProBindMenu objParaProBindMenu) {
            PowerOnRentwebapp.BindMenuService.CheckOperactionRequest inValue = new PowerOnRentwebapp.BindMenuService.CheckOperactionRequest();
            inValue.Body = new PowerOnRentwebapp.BindMenuService.CheckOperactionRequestBody();
            inValue.Body.objParaProBindMenu = objParaProBindMenu;
            PowerOnRentwebapp.BindMenuService.CheckOperactionResponse retVal = ((PowerOnRentwebapp.BindMenuService.iBindMenu)(this)).CheckOperaction(inValue);
            return retVal.Body.CheckOperactionResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        PowerOnRentwebapp.BindMenuService.BindUserMenuResponse PowerOnRentwebapp.BindMenuService.iBindMenu.BindUserMenu(PowerOnRentwebapp.BindMenuService.BindUserMenuRequest request) {
            return base.Channel.BindUserMenu(request);
        }
        
        public PowerOnRentwebapp.BindMenuService.ProBindMenu[] BindUserMenu(PowerOnRentwebapp.BindMenuService.ProBindMenu objParaProBindMenu) {
            PowerOnRentwebapp.BindMenuService.BindUserMenuRequest inValue = new PowerOnRentwebapp.BindMenuService.BindUserMenuRequest();
            inValue.Body = new PowerOnRentwebapp.BindMenuService.BindUserMenuRequestBody();
            inValue.Body.objParaProBindMenu = objParaProBindMenu;
            PowerOnRentwebapp.BindMenuService.BindUserMenuResponse retVal = ((PowerOnRentwebapp.BindMenuService.iBindMenu)(this)).BindUserMenu(inValue);
            return retVal.Body.BindUserMenuResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        PowerOnRentwebapp.BindMenuService.ActiveButtonClickEventResponse PowerOnRentwebapp.BindMenuService.iBindMenu.ActiveButtonClickEvent(PowerOnRentwebapp.BindMenuService.ActiveButtonClickEventRequest request) {
            return base.Channel.ActiveButtonClickEvent(request);
        }
        
        public PowerOnRentwebapp.BindMenuService.ProBindMenu ActiveButtonClickEvent(PowerOnRentwebapp.BindMenuService.ProBindMenu objProBindMenu) {
            PowerOnRentwebapp.BindMenuService.ActiveButtonClickEventRequest inValue = new PowerOnRentwebapp.BindMenuService.ActiveButtonClickEventRequest();
            inValue.Body = new PowerOnRentwebapp.BindMenuService.ActiveButtonClickEventRequestBody();
            inValue.Body.objProBindMenu = objProBindMenu;
            PowerOnRentwebapp.BindMenuService.ActiveButtonClickEventResponse retVal = ((PowerOnRentwebapp.BindMenuService.iBindMenu)(this)).ActiveButtonClickEvent(inValue);
            return retVal.Body.ActiveButtonClickEventResult;
        }
    }
}