<%@ Page Title="" Theme="IELSkin" Language="C#" MasterPageFile="~/Startup/App.master" AutoEventWireup="true" CodeBehind="Permisos.aspx.cs" Inherits="IELWEB.Permisos.Permisos" %>

<%@ Register Src="~/Permisos/UserControls/MetodosWUC.ascx" TagPrefix="uc1" TagName="MetodosWUC" %>
<%@ Register Src="~/Common/UserControls/MensajeWUC.ascx" TagPrefix="uc1" TagName="MensajeWUC" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPagina" runat="server">
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <asp:UpdatePanel ID="udpProfile" runat="server">
            <ContentTemplate>
                <section class="content-header">
                    <h1>Permisos Aplicación
            <small>Metodos y Objetos</small>
                    </h1>
                    <ol class="breadcrumb">
                        <li><a href="/Startup/Inicio.aspx"><i class="fa fa-dashboard"></i>Inicio</a></li>
                        <li class="active">Metodos y Objetos
                        </li>
                    </ol>
                </section>
                <section class="content">
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="box box-primary">
                                <div class="box-header with-border">
                                    <h3 class="box-title">Métodos</h3>
                                    <div class="box-tools pull-right">
                                        <button class="btn btn-box-tool" data-widget="collapse" onclick="return;"><i class="fa fa-minus"></i></button>
                                    </div>
                                </div>
                                <div class="box-body">
                                    <uc1:MetodosWUC runat="server" id="MetodosWUC" />
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-12">
                            <div class="box box-primary">
                                <div class="box-header with-border">
                                    <h3 class="box-title">Usuario</h3>
                                    <div class="box-tools pull-right">
                                        <button class="btn btn-box-tool" data-widget="collapse" onclick="return;"><i class="fa fa-minus"></i></button>
                                    </div>
                                </div>
                                <div class="box-body">
                                </div>
                            </div>
                        </div>
                    </div>
                    <uc1:MensajeWUC runat="server" ID="MensajeWUC" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    
</asp:Content>
