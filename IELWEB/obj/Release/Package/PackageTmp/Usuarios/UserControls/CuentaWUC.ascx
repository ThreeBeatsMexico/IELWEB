<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CuentaWUC.ascx.cs" Inherits="IELWEB.Usuarios.UserControls.CuentaWUC" %>
<div class="form-group">
    <div class="text-center">
        <div class="kv-avatar center-block" style="width: 180px">
            <%--<input id="avatar" name="avatar" type="file" class="file-loading">--%>
            <asp:FileUpload ID="avatar" runat="server" CssClass="file-loading" />
        </div>
    </div>
</div>
<div class=" clearfix"></div>
<div class="form-group">
    <div class="input-group">
        <span class="input-group-addon">ID</span>
        <asp:TextBox ID="txtIdCuenta" runat="server" CssClass="form-control" placeholder="IdCuenta" Enabled="false"></asp:TextBox>
    </div>
</div>
<div class="clearfix"></div>
<div class="form-group">
    <div class="input-group">
        <span class="input-group-addon"><span class="glyphicon glyphicon-font"></span></span>
        <asp:TextBox ID="txtAPaterno" runat="server" CssClass="form-control" placeholder="Apellido Paterno"></asp:TextBox>
    </div>
    <%--<asp:RequiredFieldValidator ID="reqAPaterno" runat="server" CssClass="text-danger small pull-left" ErrorMessage="Apellido Paterno Requerido" ControlToValidate="txtAPaterno" ValidationGroup="AgregarUsuario"></asp:RequiredFieldValidator>--%>
    <asp:RegularExpressionValidator ID="rexAPaterno" runat="server" CssClass="text-danger small pull-left" ErrorMessage="Apellido Paterno (Solo Letras)" ValidationExpression="^[a-zA-Z\s]+$" ControlToValidate="txtAPaterno" ValidationGroup="AgregarCuenta"></asp:RegularExpressionValidator>
</div>
<div class="clearfix"></div>
<div class="form-group">
    <div class="input-group">
        <span class="input-group-addon"><span class="glyphicon glyphicon-font"></span></span>
        <asp:TextBox ID="txtAMaterno" runat="server" CssClass="form-control" placeholder="Apellido Materno"></asp:TextBox>
    </div>
    <%--<asp:RequiredFieldValidator ID="reqAMaterno" runat="server" CssClass="text-danger small pull-left" ErrorMessage="Apellido Materno Requerido" ControlToValidate="txtAMaterno" ValidationGroup="AgregarUsuario"></asp:RequiredFieldValidator>--%>
    <asp:RegularExpressionValidator ID="rexAMaterno" runat="server" CssClass="text-danger small pull-left" ErrorMessage="Apellido Materno (Solo Letras)" ValidationExpression="^[a-zA-Z\s]+$" ControlToValidate="txtAMaterno" ValidationGroup="AgregarCuenta"></asp:RegularExpressionValidator>
</div>
<div class="clearfix"></div>
<div class="form-group">
    <div class="input-group">
        <span class="input-group-addon"><span class="glyphicon glyphicon-font"></span></span>
        <asp:TextBox ID="txtNombres" runat="server" CssClass="form-control" placeholder="Nombres"></asp:TextBox>
    </div>
    <asp:RequiredFieldValidator ID="reqNombre" runat="server" CssClass="text-danger small pull-left" ErrorMessage="Nombre Requerido" ControlToValidate="txtNombres" ValidationGroup="AgregarCuenta"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="rexNombre" runat="server" CssClass="text-danger small pull-left" ErrorMessage="Nombre (Solo Letras ,.)" ValidationExpression="^[\w\s.]+$" ControlToValidate="txtNombres" ValidationGroup="AgregarCuenta"></asp:RegularExpressionValidator>
</div>
<div class="clearfix"></div>
<div class="form-group">
    <div class="input-group">
        <span class="input-group-addon">RFC</span>
        <asp:TextBox ID="txtRFCSiglas" runat="server" CssClass="form-control" placeholder="RFCSiglas"></asp:TextBox>
        <asp:TextBox ID="txtRFCFecha" runat="server" CssClass="form-control" placeholder="RFCFecha"></asp:TextBox>
        <asp:TextBox ID="txtRFCHomo" runat="server" CssClass="form-control" placeholder="RFCHomo"></asp:TextBox>
    </div>
    <asp:RequiredFieldValidator ID="reqRFCSiglas" runat="server" CssClass="text-danger small pull-left" ErrorMessage="Siglas Requeridad" ControlToValidate="txtRFCSiglas" ValidationGroup="AgregarCuenta"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="reqRFCFecha" runat="server" CssClass="text-danger small pull-left" ErrorMessage="Fecha Requeridad" ControlToValidate="txtRFCFecha" ValidationGroup="AgregarCuenta"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="reqRFCHomo" runat="server" CssClass="text-danger small pull-left" ErrorMessage="Homo Requeridad" ControlToValidate="txtRFCHomo" ValidationGroup="AgregarCuenta"></asp:RequiredFieldValidator>
</div>
<div class="clearfix"></div>