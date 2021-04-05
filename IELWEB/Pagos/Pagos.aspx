<%@ Page Title="" Theme="IELSkin" Language="C#" MasterPageFile="~/Startup/App.master" AutoEventWireup="true" CodeBehind="Pagos.aspx.cs" Inherits="IELWEB.Pagos.Pagos" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPagina" runat="server">
    <script type="text/javascript">

        function setUrl(PanelID, Url, Token) {


            var panel = ResolvePaneId(PanelID);


            switch (PanelID) {
                case "LeftPanePagos": panel.set_contentUrl(Url + "?Token=" + Token);
                    CleanWorkArea();
                    break;
                case "ContentPanePagos": panel.set_contentUrl(Url + "?Token=" + Token);

                    break;


            }
        }

        function ResolvePaneId(PanelID) {

            var panel;

            switch (PanelID) {
                case "LeftPanePagos": panel = $find("<%= LeftPanePagos.ClientID%>");
                break;
            case "ContentPanePagos": panel = $find("<%= ContentPanePagos.ClientID%>");
                break;

        }

        return panel;
    }

    function setTabStrip(PanelID, Url, Token) {
        var splitterPageWnd = window.parent;
        var splitterObject = splitterPageWnd.setTabStrip(PanelID, Url, Token);
    }


    </script>

     <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>Administración
            <small>Pagos</small>
            </h1>
            <ol class="breadcrumb">
                <li><a href="/Startup/Inicio.aspx"><i class="fa fa-dashboard"></i>Inicio</a></li>
                <li class="active">Pagos
                </li>
            </ol>
        </section>
        <section class="content">
            <div class="box box-primary">
                <div class="box-header with-border">
                    <h3 class="box-title">Pagos</h3>
                    <div class="box-tools pull-right">
                        <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    </div>
                </div>
                <div class="box-body">


     <telerik:RadAjaxLoadingPanel runat="server" ID="LoadingPanel1" Skin="Web20" BackColor="White">
    </telerik:RadAjaxLoadingPanel>
    
           <telerik:RadSplitter runat="server" ID="RSPagos" CssClass="outerMultiPage" EnableEmbeddedSkins="false" Skin="IELSkin"  Width="100%" Height="940px"  Orientation="Vertical" >
                
                    <telerik:RadPane ID="LeftPanePagos"  runat="server" Height="900px" ContentUrl = "PagosBusqueda.aspx" Width="210" CssClass="outerMultiPage"  MinWidth="250" MaxWidth="400"
                        ShowContentDuringLoad="false">
                        <!-- Place the content of the pane here -->
                    </telerik:RadPane>
                    <telerik:RadSplitBar ID="VerticalSplitBar" runat="server" CollapseMode="Forward" />
                    <telerik:RadPane ID="ContentPanePagos" runat="server" ContentUrl = "../Startup/Blank.html" ShowContentDuringLoad="false" CssClass="outerMultiPage"  Height="900px" Width="100%">
                        <!-- Place the content of the pane here -->
                    </telerik:RadPane>

                </telerik:RadSplitter>
                    </div>
                </div>
            </section>
            </div>
   
</asp:Content>

