<%@ Page Title="" Language="C#" MasterPageFile="~/Startup/App.master" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="IELWEB.Reportes.Reportes" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPagina" runat="server">
  

    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>Reportes
            <small></small>
            </h1>
            <ol class="breadcrumb">
                <li><a href="/Startup/Inicio.aspx"><i class="fa fa-dashboard"></i>Inicio</a></li>
                <li class="active">Reportes
                </li>
            </ol>
        </section>
        <section class="content">
            <div class="box box-primary">
                <div class="box-header with-border">
                    <h3 class="box-title">Reporte</h3>
                    <div class="box-tools pull-right">
                        <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    </div>
                </div>
                <div class="box-body">



     <telerik:RadAjaxLoadingPanel runat="server" ID="LoadingPanel1" EnableEmbeddedSkins="false" Skin="IELSkin" BackColor="White">
    </telerik:RadAjaxLoadingPanel>






    
           <telerik:RadSplitter runat="server" ID="RSCotizaciones" CssClass="outerMultiPage"  Width="100%" Height="940px" EnableEmbeddedSkins="false" Skin="IELSkin"  Orientation="Vertical" >
                
                  
                    <telerik:RadPane ID="ContentPane" runat="server" ContentUrl = "../Startup/Blank.html" ShowContentDuringLoad="false" CssClass="outerMultiPage"  Height="900px" Width="100%">
                        <!-- Place the content of the pane here -->
                    </telerik:RadPane>

                </telerik:RadSplitter>


                    </div>
                </div>
            </section>
        </div>










</asp:Content>
