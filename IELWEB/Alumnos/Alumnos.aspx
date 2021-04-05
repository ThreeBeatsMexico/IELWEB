<%@ Page Title="" Theme="IELSkin"  Language="C#" MasterPageFile="~/Startup/App.master" AutoEventWireup="true" CodeBehind="Alumnos.aspx.cs" Inherits="IELWEB.Alumnos.Alumnos" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPagina" runat="server">
    <script type="text/javascript">

        function setUrl(PanelID, Url, Token) {


            var panel = ResolvePaneId(PanelID);


            switch (PanelID) {
                case "LeftPane": panel.set_contentUrl(Url + "?Token=" + Token);
                    CleanWorkArea();
                    break;
                case "ContentPane": panel.set_contentUrl(Url + "?Token=" + Token);

                    break;


            }
        }

        function ResolvePaneId(PanelID) {

            var panel;

            switch (PanelID) {
                case "LeftPane": panel = $find("<%= LeftPane.ClientID%>");
                break;
            case "ContentPane": panel = $find("<%= ContentPane.ClientID%>");
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
            <small>Alumnos</small>
            </h1>
            <ol class="breadcrumb">
                <li><a href="/Startup/Inicio.aspx"><i class="fa fa-dashboard"></i>Inicio</a></li>
                <li class="active">Alumnos
                </li>
            </ol>
        </section>
        <section class="content">
            <div class="box box-primary">
                <div class="box-header with-border">
                    <h3 class="box-title">Alumnos</h3>
                    <div class="box-tools pull-right">
                        <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    </div>
                </div>
                <div class="box-body">



     <telerik:RadAjaxLoadingPanel runat="server" ID="LoadingPanel1" EnableEmbeddedSkins="false" Skin="IELSkin" BackColor="White">
    </telerik:RadAjaxLoadingPanel>






    
           <telerik:RadSplitter runat="server" ID="RSCotizaciones" CssClass="outerMultiPage"  Width="100%" Height="940px" EnableEmbeddedSkins="false" Skin="IELSkin"  Orientation="Vertical" >
                
                    <telerik:RadPane ID="LeftPane"  runat="server" Height="900px" ContentUrl = "AlumnosBusqueda.aspx" Width="210" CssClass="outerMultiPage"  MinWidth="250" MaxWidth="400"
                        ShowContentDuringLoad="false">
                        <!-- Place the content of the pane here -->
                    </telerik:RadPane>
                    <telerik:RadSplitBar ID="VerticalSplitBar" runat="server" CollapseMode="Forward" />
                    <telerik:RadPane ID="ContentPane" runat="server" ContentUrl = "../Startup/Blank.html" ShowContentDuringLoad="false" CssClass="outerMultiPage"  Height="900px" Width="100%">
                        <!-- Place the content of the pane here -->
                    </telerik:RadPane>

                </telerik:RadSplitter>


                    </div>
                </div>
            </section>
        </div>

</asp:Content>
