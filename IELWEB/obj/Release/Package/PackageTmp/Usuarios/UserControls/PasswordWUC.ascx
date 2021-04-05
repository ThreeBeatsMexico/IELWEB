<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PasswordWUC.ascx.cs" Inherits="IELWEB.Usuarios.UserControls.PasswordWUC" %>
<div class="form-group">
    <div class="input-group">
        <span class="input-group-addon"><span class="glyphicon glyphicon glyphicon-lock"></span></span>
        <asp:TextBox ID="txtPasswordActual" runat="server" CssClass="form-control" TextMode="Password" placeholder="Password Actual"></asp:TextBox>
    </div>
    <asp:RequiredFieldValidator ID="reqPassActual" runat="server" CssClass="text-danger small pull-left" ErrorMessage="Password Requerido" ControlToValidate="txtPasswordActual" ValidationGroup="Password"></asp:RequiredFieldValidator>
</div>
<div class="clearfix"></div>
<div class="form-group">
    <div class="input-group">
        <span class="input-group-addon"><span class="glyphicon glyphicon glyphicon-lock"></span></span>
        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Password Nuevo"></asp:TextBox>
    </div>
    <asp:RequiredFieldValidator ID="reqPassword" runat="server" CssClass="text-danger small pull-left" ErrorMessage="Password Requerido" ControlToValidate="txtPassword" ValidationGroup="Password"></asp:RequiredFieldValidator>
</div>
<div class="clearfix"></div>
<div class="form-group">
    <div class="input-group">
        <span class="input-group-addon"><span class="glyphicon glyphicon glyphicon-lock"></span></span>
        <asp:TextBox ID="txtPassConfirma" runat="server" CssClass="form-control" TextMode="Password" placeholder="Confirmas Password" ValidationGroup="Password"></asp:TextBox>
    </div>
    <asp:RequiredFieldValidator ID="reqPassConfirma" runat="server" CssClass="text-danger small pull-left" ErrorMessage="Password Requerido" ControlToValidate="txtPassConfirma" ValidationGroup="Password"></asp:RequiredFieldValidator>
    <asp:CompareValidator ID="cmpPassword" runat="server" ErrorMessage="Las contraseñas no son Iguales" ControlToCompare="txtPassConfirma" ControlToValidate="txtPassword" ValidationGroup="Password"></asp:CompareValidator>
</div>
<div class="clearfix"></div>
