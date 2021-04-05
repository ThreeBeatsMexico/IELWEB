<%@ Page Title="" Theme="IELSkin" Language="C#" MasterPageFile="~/Startup/App.master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="IELWEB.Usuarios.Profile" %>

<%@ Register Src="~/Usuarios/UserControls/UserWUC.ascx" TagPrefix="uc1" TagName="UserWUC" %>
<%@ Register Src="~/Usuarios/UserControls/DomicilioWUC.ascx" TagPrefix="uc1" TagName="DomicilioWUC" %>
<%@ Register Src="~/Usuarios/UserControls/ContactoWUC.ascx" TagPrefix="uc1" TagName="ContactoWUC" %>
<%@ Register Src="~/Usuarios/UserControls/PasswordWUC.ascx" TagPrefix="uc1" TagName="PasswordWUC" %>
<%@ Register Src="~/Common/UserControls/MensajeWUC.ascx" TagPrefix="uc1" TagName="MensajeWUC" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPagina" runat="server">
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <asp:UpdatePanel ID="udpProfile" runat="server">
            <ContentTemplate>
                <section class="content-header">
                    <h1>Profile
            <small>Usuario</small>
                    </h1>
                    <ol class="breadcrumb">
                        <li><a href="/Startup/Inicio.aspx"><i class="fa fa-dashboard"></i>Inicio</a></li>
                        <li class="active">Usuario
                        </li>
                    </ol>
                </section>

                <section class="content">
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="box box-primary">
                                <div class="box-header with-border">
                                    <h3 class="box-title">Usuario</h3>
                                    <div class="box-tools pull-right">
                                        <button class="btn btn-box-tool" data-widget="collapse" onclick="return;"><i class="fa fa-minus"></i></button>
                                    </div>
                                </div>

                                <div class="box-body">
                                    <uc1:UserWUC runat="server" ID="UserWUC" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="box box-primary">
                                <div class="box-header with-border">
                                    <h3 class="box-title">Domicilios</h3>
                                    <div class="box-tools pull-right">
                                        <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                                    </div>
                                </div>
                                <div class="box-body">
                                    <uc1:DomicilioWUC runat="server" ID="DomicilioWUC" />
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-12">
                            <div class="box box-primary">
                                <div class="box-header with-border">
                                    <h3 class="box-title">Contactos</h3>
                                    <div class="box-tools pull-right">
                                        <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                                    </div>
                                </div>
                                <div class="box-body">
                                    <uc1:ContactoWUC runat="server" ID="ContactoWUC" />
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-12">
                            <div class="form-group">
                                <div class="btn-group" role="group">
                                    <div class="btn-group" role="group">
                                        <asp:Button ID="btnGuardar" CssClass="btn btn-block btn-success" runat="server" Text="Guardar" OnClick="btnGuardar_Click" ValidationGroup="GuardarProfile" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </section>
                <uc1:MensajeWUC runat="server" ID="MensajeWUC" />
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="UserWUC" />
                <asp:AsyncPostBackTrigger ControlID="DomicilioWUC" />
                <asp:AsyncPostBackTrigger ControlID="ContactoWUC" />
                <asp:AsyncPostBackTrigger ControlID="btnGuardar" />
            </Triggers>
        </asp:UpdatePanel>
    </div>

    <div id="mdlPass" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="addModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <asp:UpdatePanel ID="udpPass" runat="server">
                    <ContentTemplate>
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h4 class="modal-title"><span class="fa fa-user-plus"></span>
                                <asp:Label ID="lblModalPass" runat="server" Text="Label"></asp:Label>
                            </h4>
                        </div>
                        <uc1:PasswordWUC runat="server" ID="PasswordWUC" />
                        <div class="modal-footer clearfix">
                            <asp:Button ID="btnSavePass" runat="server" CssClass="btn btn-primary pull-left" Text="Guardar" OnClick="btnSavePass_Click" ValidationGroup="Password"></asp:Button>
                            <button type="button" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-times"></i>Cancelar</button>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>

</asp:Content>
