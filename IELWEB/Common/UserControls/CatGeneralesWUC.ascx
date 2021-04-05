<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CatGeneralesWUC.ascx.cs" Inherits="IELWEB.Common.UserControls.CatGeneralesWUC" %>

<div class="modal-body">
    <div class="form-group">
        <div class="input-group">
            <span class="input-group-addon">Captura Personalizada:</span>
            <asp:CheckBox ID="chkPersonalizado" runat="server" CssClass="form-control" AutoPostBack="true" OnCheckedChanged="chkPersonalizado_CheckedChanged" />
        </div>
        <div class="input-group">
            <span class="input-group-addon">NOMBRE:</span>
            <asp:TextBox ID="txtCatGenerales" runat="server" CssClass="form-control" placeholder="Nombre Catalogo" Visible="false"></asp:TextBox>
            <asp:DropDownList ID="ddlCatGenerales" CssClass="form-control" runat="server" OnTextChanged="ddlCatGenerales_TextChanged" AutoPostBack="true"></asp:DropDownList>
        </div>
        <div class="input-group">
            <span class="input-group-addon">COLUMNAID:</span>
            <asp:TextBox ID="txtColumnaId" runat="server" CssClass="form-control" placeholder="Columna Id" Enabled="false"></asp:TextBox>
            <%--<input name="email_to" type="email" class="form-control" placeholder="Nombre de Aplicacion">--%>
        </div>
    </div>
    <div class="form-group">
        <div class="input-group">
            <span class="input-group-addon">Descripción:</span>
            <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" placeholder="Descripción del catalogo" Enabled="false"></asp:TextBox>
        </div>
        <div class="input-group">
            <span class="input-group-addon">Filtro:</span>
            <asp:TextBox ID="txtFiltro" runat="server" CssClass="form-control" placeholder="Descripción del catalogo" Enabled="false"></asp:TextBox>
            <span class="input-group-addon">Activo:</span>
            <asp:CheckBox ID="chkActivo" runat="server" CssClass="form-control" />
        </div>
    </div>

    <%--<input name="email_to" type="email" class="form-control" placeholder="Password de Aplicacion">--%>
</div>
