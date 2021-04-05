<%@ Page Title="" Language="C#" MasterPageFile="~/Startup/main.Master" AutoEventWireup="true" CodeBehind="Deudores.aspx.cs" Inherits="IELWEB.Reportes.Deudores" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="server">
    

     <telerik:RadAjaxLoadingPanel runat="server" ID="LoadingPanel1" Skin="Web20" BackColor="White">
    </telerik:RadAjaxLoadingPanel>
    
           <telerik:RadSplitter runat="server" ID="RSCotizaciones" CssClass="outerMultiPage"  Width="100%" Height="940px"  Orientation="Vertical" >
                
                   
                    <telerik:RadPane ID="ContentPane" runat="server" ContentUrl = "../Reportes/ReporteDeudores.aspx" ShowContentDuringLoad="false" CssClass="outerMultiPage"  Height="900px" Width="100%">
                        <!-- Place the content of the pane here -->
                    </telerik:RadPane>

                </telerik:RadSplitter>
</asp:Content>
