<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PermisosWUC.ascx.cs" Inherits="IELWEB.Usuarios.UserControls.PermisosWUC" %>
<%@ Register Src="~/Common/UserControls/MensajeWUC.ascx" TagPrefix="uc1" TagName="MensajeWUC" %>
<asp:UpdatePanel runat="server" ID="udpPermisos">
    <ContentTemplate>
        <div class="form-group col-lg-6 col-md-6 col-sm-6 text-center">
            <div class="input-group">
                <span class=" control-label">Aplicaciones Asignadas</span>
                <asp:DropDownList ID="ddlAplicacionXUsuario" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlAplicacionXUsuario_SelectedIndexChanged"></asp:DropDownList>
            </div>
            <asp:RequiredFieldValidator ID="reqAplicacion" CssClass="text-danger small pull-left" runat="server" ErrorMessage="Aplicación Requerida" ControlToValidate="ddlAplicacionXUsuario" InitialValue ="0" ValidationGroup="AgregarRol"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group col-lg-6 col-md-6 col-sm-6 text-center">
            <span class="control-label">Aplicaciones</span>
            <div class="input-group">
                <asp:DropDownList ID="ddlAplicacionNueva" CssClass="form-control" runat="server" CausesValidation="True" ValidationGroup="AppNueva"></asp:DropDownList>
                <span class=" input-group-btn">
                    <asp:Button ID="btnAgregarAplicacion" CssClass=" btn btn-success pull-left" runat="server" Text="Agregar App" OnClick="btnAgregarAplicacion_Click" ValidationGroup="AppNueva" />
                </span>
            </div>
            <asp:RequiredFieldValidator ID="reqAgregarApp" runat="server" CssClass="text-danger small pull-left" ErrorMessage="Seleccione un aplicación" InitialValue="0" ControlToValidate="ddlAplicacionNueva" ValidationGroup="AppNueva"></asp:RequiredFieldValidator>
            <div class="clearfix"></div>
        </div>

        <div class="form-group col-lg-12 col-md-12 col-sm-12 text-center">
            <div class="input-group">
                <span class="input-group-addon">Roles</span>
                <asp:DropDownList ID="ddlRol" CssClass="form-control" runat="server" CausesValidation="True"></asp:DropDownList>
            </div>
            <asp:RequiredFieldValidator ID="reqRol" CssClass="text-danger small pull-left" runat="server" ErrorMessage="Rol Requerido" ControlToValidate="ddlRol" InitialValue ="0" ValidationGroup="AgregarRol"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <div class="btn-group btn-group-justified" role="group">
                <div class="btn-group" role="group">
                    <asp:Button ID="btnAgregarPermiso" CssClass="btn btn-block btn-success" runat="server" Text="Guardar Permiso" OnClick="btnAgregarPermiso_Click" CausesValidation="true" ValidationGroup="AgregarRol"/>
                </div>
                <div class="btn-group" role="group">
                    <asp:Button ID="btnCancelarPermiso" CssClass="btn btn-group btn-danger" runat="server" Text="Cancelar" OnClick="btnCancelarPermiso_Click" />
                </div>
            </div>
        </div>
        <asp:GridView ID="grdRoles" runat="server" HorizontalAlign="Center"
            AutoGenerateColumns="false"
            DataKeyNames="IDROL,IDAPLICACION,IDROLXUSUARIO" CssClass="table table-striped table-bordered table-condensed table-responsive"
            EmptyDataText="No se encontraron regisros ..." OnRowCommand="grdRoles_RowCommand">
            <HeaderStyle CssClass="label-primary" />
            <Columns>
                <%-- <asp:CheckBoxField DataField="ACTIVO" HeaderText="ACTIVO" SortExpression="ACTIVO" />
                <asp:TemplateField HeaderText="ACTIVO">
                    <ItemTemplate>
                        <asp:RadioButton ID="rbRolAplicacion" runat="server" Checked='<%#Eval("ACTIVO")%>' onclick="RadioCheck(this);" />
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:BoundField DataField="IDROLXUSUARIO" HeaderText="IDROLXUSUARIO" SortExpression="IDROLXUSUARIO" />
                <asp:BoundField DataField="APLICACION" HeaderText="APLICACION" SortExpression="APLICACION" />
                <asp:BoundField DataField="DESCROL" HeaderText="DESCROL" SortExpression="DESCROL" />
                <asp:ButtonField CommandName="EditRol" ItemStyle-Width="20px"
                    ButtonType="Image" ImageUrl="~/dist/img/editMenu.png">
                    <ControlStyle CssClass=" btn btn-default btn-xs"></ControlStyle>
                </asp:ButtonField>
                <asp:ButtonField CommandName="DeleteRol" ItemStyle-Width="20px"
                    ButtonType="Image" ImageUrl="~/dist/img/delMenu.png">
                    <ControlStyle CssClass=" btn btn-default btn-xs"></ControlStyle>
                </asp:ButtonField>
            </Columns>
            <PagerStyle HorizontalAlign="Center" CssClass="pagination-ys" />
        </asp:GridView>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnAgregarAplicacion" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="ddlAplicacionXUsuario" EventName="SelectedIndexChanged" />
    </Triggers>
</asp:UpdatePanel>
