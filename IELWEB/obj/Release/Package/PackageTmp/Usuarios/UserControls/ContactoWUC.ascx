<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContactoWUC.ascx.cs" Inherits="IELWEB.Usuarios.UserControls.ContactoWUC" %>

<%--<div class="box box-primary">
    <div class="box-header with-border">
        <h3 class="box-title">Contacto</h3>
    </div>
    <div class="box-body">--%>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>

        <div class="form-group">
            <div class="input-group">
                <span class="input-group-addon">ID</span>
                <asp:TextBox ID="txtIdContacto" runat="server" CssClass="form-control" placeholder="IdContacto" Enabled="false"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <div class="input-group">
                <span class="input-group-addon"><span class="glyphicon glyphicon-road"></span></span>
                <asp:DropDownList ID="ddlTipoContacto" runat="server" CssClass="form-control" ValidationGroup="AgregarContacto" required="required" OnSelectedIndexChanged="ddlTipoContacto_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
            </div>
            <asp:RequiredFieldValidator ID="reqTipoContacto" runat="server" CssClass="text-danger small pull-left" ErrorMessage="Seleccione Tipo Contacto" ControlToValidate="ddlTipoContacto" InitialValue="0" ValidationGroup="AgregarContacto"></asp:RequiredFieldValidator>
        </div>
        <div class="clearfix"></div>
        <div class="form-group">
            <div class="input-group">
                <span class="input-group-addon"><span class="glyphicon glyphicon-phone"></span></span>
                <asp:TextBox ID="txtValor" runat="server" CssClass="form-control" placeholder="Valor Contacto" ValidationGroup="AgregarContacto"></asp:TextBox>
            </div>
            <asp:RequiredFieldValidator ID="reqValor" runat="server" CssClass="text-danger small pull-left" ErrorMessage="Valor de contacto invalido" ControlToValidate="txtValor" ValidationGroup="AgregarContacto" Enabled="false"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="rexValor" runat="server" CssClass="text-danger small pull-left" ErrorMessage="Valor Invalido" ControlToValidate ="txtValor" ValidationGroup ="AgregarContacto"></asp:RegularExpressionValidator>
        </div>

        <div class="form-group">
            <div class="btn-group btn-group-justified" role="group">
                <div class="btn-group" role="group">
                    <asp:Button ID="btnAgregarContacto" CssClass="btn btn-block btn-success" runat="server" Text="Guardar Contacto" OnClick="btnAgregarContacto_Click" ValidationGroup="AgregarContacto" />
                </div>
                <div class="btn-group" role="group">
                    <asp:Button ID="btnCancelarContactos" CssClass="btn btn-group btn-danger" runat="server" Text="Cancelar" OnClick="btnCancelarContactos_Click"/>
                </div>
            </div>
        </div>

        <asp:GridView ID="grdContacto" runat="server" HorizontalAlign="Center"
            AutoGenerateColumns="false"
            DataKeyNames="IDCONTACTO,IDUSUARIO" CssClass="table table-striped table-bordered table-condensed table-responsive"
            EmptyDataText="No se encontraron regisros ..." OnRowCommand="grdContacto_RowCommand">
            <HeaderStyle CssClass="label-primary" />
            <Columns>
                <asp:BoundField DataField="IDCONTACTO" HeaderText="IDCONTACTO" SortExpression="IDCONTACTO" HeaderStyle-CssClass="hidden-xs" ItemStyle-CssClass=" hidden-xs" />
                <asp:BoundField DataField="TIPOCONTACTO" HeaderText="TIPOCONTACTO" SortExpression="TIPOCONTACTO" HeaderStyle-CssClass="hidden-xs" ItemStyle-CssClass="hidden-xs" />
                <asp:BoundField DataField="VALOR" HeaderText="VALOR" SortExpression="VALOR" />
                <asp:ButtonField CommandName="EditContacto" ItemStyle-Width="20px"
                    ButtonType="Image" ImageUrl="~/dist/img/editMenu.png">
                    <ControlStyle CssClass=" btn btn-default btn-xs"></ControlStyle>
                </asp:ButtonField>
                <asp:ButtonField CommandName="DeleteContacto" ItemStyle-Width="20px"
                    ButtonType="Image" ImageUrl="~/dist/img/delMenu.png">
                    <ControlStyle CssClass=" btn btn-default btn-xs"></ControlStyle>
                </asp:ButtonField>
            </Columns>
            <PagerStyle HorizontalAlign="Center" CssClass="pagination-ys" />
        </asp:GridView>
    </ContentTemplate>
</asp:UpdatePanel>
