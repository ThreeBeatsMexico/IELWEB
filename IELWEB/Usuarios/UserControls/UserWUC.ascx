<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserWUC.ascx.cs" Inherits="IELWEB.Usuarios.UserControls.UserWUC" %>
<%--<div class="box box-primary">
    <div class="box-header with-border">
        <h3 class="box-title">Usuario</h3>
    </div>
    <div class="clearfix"></div>
    <div class="box-body">
        <div class="box-tools pull-right">--%>
<div class="form-group">
    <div class="text-center">
        <div class="kv-avatar center-block" style="width: 180px">
            <button class="btn btn-default" data-toggle="modal" href="#stack2">Launch modal</button>
            <input id="avatar" runat="server" name="avatar" type="file" class="file-loading">
            <%--<asp:FileUpload ID="avatar" runat="server" CssClass="file-loading" />--%>
        </div>
    </div>
</div>
<div class=" clearfix"></div>
<div class="form-group">
    <div class="input-group">
        <span class="input-group-addon">ID</span>
        <asp:TextBox ID="txtIdUsuario" runat="server" CssClass="form-control" placeholder="IdUsuario" Enabled="false"></asp:TextBox>
    </div>
</div>
<div class="form-group">
    <div class="input-group">
        <span class="input-group-addon"><span class="glyphicon glyphicon-user"></span></span>
        <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" placeholder="@Nombre de Usuario"></asp:TextBox>
    </div>
    <asp:RequiredFieldValidator ID="reqUsuario" runat="server" CssClass="text-danger small pull-left" ErrorMessage="Usuario Requerido" ControlToValidate="txtUsuario" ValidationGroup="AgregarUsuario"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="rexUsuario" runat="server" CssClass="text-danger small pull-left" ErrorMessage="Usuario Invalido" ControlToValidate ="txtUsuario" ValidationGroup="AgregarUsuario" ValidationExpression="^[\w\s.,@]+"></asp:RegularExpressionValidator>
</div>
<div class="clearfix"></div>
<div class="form-group">
    <div class="input-group">
        <span class="input-group-addon"><span class="glyphicon glyphicon-font"></span></span>
        <asp:TextBox ID="txtAPaterno" runat="server" CssClass="form-control" placeholder="Apellido Paterno"></asp:TextBox>
    </div>
    <%--<asp:RequiredFieldValidator ID="reqAPaterno" runat="server" CssClass="text-danger small pull-left" ErrorMessage="Apellido Paterno Requerido" ControlToValidate="txtAPaterno" ValidationGroup="AgregarUsuario"></asp:RequiredFieldValidator>--%>
    <asp:RegularExpressionValidator ID="rexAPaterno" runat="server" CssClass="text-danger small pull-left" ErrorMessage="Apellido Paterno (Solo Letras)" ValidationExpression="^[a-zA-Z\s]+$" ControlToValidate="txtAPaterno" ValidationGroup="AgregarUsuario"></asp:RegularExpressionValidator>
</div>
<div class="clearfix"></div>
<div class="form-group">
    <div class="input-group">
        <span class="input-group-addon"><span class="glyphicon glyphicon-font"></span></span>
        <asp:TextBox ID="txtAMaterno" runat="server" CssClass="form-control" placeholder="Apellido Materno"></asp:TextBox>
    </div>
    <%--<asp:RequiredFieldValidator ID="reqAMaterno" runat="server" CssClass="text-danger small pull-left" ErrorMessage="Apellido Materno Requerido" ControlToValidate="txtAMaterno" ValidationGroup="AgregarUsuario"></asp:RequiredFieldValidator>--%>
    <asp:RegularExpressionValidator ID="rexAMaterno" runat="server" CssClass="text-danger small pull-left" ErrorMessage="Apellido Materno (Solo Letras)" ValidationExpression="^[a-zA-Z\s]+$" ControlToValidate="txtAMaterno" ValidationGroup="AgregarUsuario"></asp:RegularExpressionValidator>
</div>
<div class="clearfix"></div>
<div class="form-group">
    <div class="input-group">
        <span class="input-group-addon"><span class="glyphicon glyphicon-font"></span></span>
        <asp:TextBox ID="txtNombres" runat="server" CssClass="form-control" placeholder="Nombres"></asp:TextBox>
    </div>
    <asp:RequiredFieldValidator ID="reqNombre" runat="server" CssClass="text-danger small pull-left" ErrorMessage="Nombre Requerido" ControlToValidate="txtNombres" ValidationGroup="AgregarUsuario"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="rexNombre" runat="server" CssClass="text-danger small pull-left" ErrorMessage="Nombre (Solo Letras ,.)" ValidationExpression="^[\w\s.]+$" ControlToValidate="txtNombres" ValidationGroup="AgregarUsuario"></asp:RegularExpressionValidator>
</div>
<div class="clearfix"></div>
<div class="form-group">
    <div class="input-group">
        <span class="input-group-addon"><span class="glyphicon glyphicon-time"></span></span>
        <asp:TextBox ID="txtFechaNacimiento" runat="server" CssClass="form-control" placeholder="Fecha Nacimiento"></asp:TextBox>
        <span class="input-group-addon">Sexo:</span>
        <asp:DropDownList ID="ddlSexo" CssClass="form-control" runat="server"></asp:DropDownList>
    </div>
    <asp:RequiredFieldValidator ID="reqFechaNacimiento" runat="server" CssClass="text-danger small pull-left" ErrorMessage="Fecha requerida" ControlToValidate="txtFechaNacimiento" ValidationGroup="AgregarUsuario"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="reqSexo" runat="server" CssClass="text-danger small pull-left" ErrorMessage="Seleccione el sexo" InitialValue="0" ControlToValidate="ddlSexo" ValidationGroup="AgregarUsuario"></asp:RequiredFieldValidator>
</div>
<div class="clearfix"></div>
<div class="form-group">
    <div class="input-group">
        <span class="input-group-addon">E.Civil:</span>
        <asp:DropDownList ID="ddlEstadoCivil" CssClass="form-control" runat="server"></asp:DropDownList>
    </div>
</div>





