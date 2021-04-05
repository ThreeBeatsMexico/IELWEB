<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserFullWUC.ascx.cs" Inherits="IELWEB.Usuarios.UserControls.WebUserControl1" %>
<%@ Register Src="~/Usuarios/UserControls/UserWUC.ascx" TagPrefix="uc1" TagName="UserWUC" %>
<%@ Register Src="~/Usuarios/UserControls/DomicilioWUC.ascx" TagPrefix="uc1" TagName="DomicilioWUC" %>
<%@ Register Src="~/Usuarios/UserControls/ContactoWUC.ascx" TagPrefix="uc1" TagName="ContactoWUC" %>
<%@ Register Src="~/Usuarios/UserControls/PermisosWUC.ascx" TagPrefix="uc1" TagName="PermisosWUC" %>
<%@ Register Src="~/Common/UserControls/MensajeWUC.ascx" TagPrefix="uc1" TagName="MensajeWUC" %>
<div class="box box-primary">
    <div class="box-header with-border">
        <h3 class="box-title">Datos Usuario</h3>
    </div>
</div>
<div class="clearfix"></div>
<div class="box-body">
    <div class="box-tools pull-left">
        <div id="Tabs" role="tabpanel">
            <asp:HiddenField ID="TabName" runat="server" />
            <ul class="nav nav-tabs" id="Registrotab" runat="server">
                <li class="active"><a href="#Tab_User" role="tab" data-toggle="tab">Usuario</a></li>
                <li><a href="#Tab_Domicilio" role="tab" data-toggle="tab">Domicilios</a></li>
                <li><a href="#Tab_Contacto" role="tab" data-toggle="tab">Contactos</a></li>
                <li><a href="#Tab_Permisos" role="tab" data-toggle="tab">Permisos</a></li>
            </ul>
            <div class="tab-content">
                <div class="tab-pane active" id="Tab_User">
                    <uc1:UserWUC runat="server" ID="UserWUC" />
                </div>
                <div class="tab-pane" id="Tab_Domicilio">
                    <uc1:DomicilioWUC runat="server" ID="DomicilioWUC" />
                </div>
                <div class="tab-pane" id="Tab_Contacto">
                    <uc1:ContactoWUC runat="server" ID="ContactoWUC" />
                </div>
                <div class="tab-pane" id="Tab_Permisos">
                    <uc1:PermisosWUC runat="server" ID="PermisosWUC" />
                </div>
            </div>
        </div>
    </div>
</div>
<uc1:MensajeWUC runat="server" ID="MensajeWUC" />
