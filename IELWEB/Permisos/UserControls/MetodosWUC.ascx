<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MetodosWUC.ascx.cs" Inherits="IELWEB.Permisos.UserControls.MetodosWUC" %>
<asp:UpdatePanel runat="server" ID="udpMetodos">
    <ContentTemplate>
        <div class="form-group col-lg-12 col-md-12 col-sm-12 text-center">
            <div class="input-group">
                <span class="input-group-addon">Id</span>
                <asp:TextBox ID="txtIdMetodo" runat="server" CssClass="form-control" Enabled ="false"></asp:TextBox>
                <span class="input-group-addon">Aplicacion</span>
                <asp:DropDownList ID="ddlAplicacion" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlAplicacion_SelectedIndexChanged"></asp:DropDownList>
                <span class="input-group-addon">Servicio</span>
                <asp:DropDownList ID="ddlServicio" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlServicio_SelectedIndexChanged"></asp:DropDownList>
            </div>
            <%--<asp:RequiredFieldValidator ID="reqAplicacion" CssClass="text-danger small pull-left" runat="server" ErrorMessage="Aplicación Requerida" ControlToValidate="ddlAplicacion" InitialValue="0"></asp:RequiredFieldValidator>--%>
        </div>
        <div class="form-group col-lg-12 col-md-12 col-sm-12 text-center">
            <div class="input-group">
                <span class="input-group-addon">Nombre:</span>
                <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server" placeholder="Nombre Metodo" CausesValidation ="true" ValidationGroup="AgregarMetodo"></asp:TextBox>
                <span class="input-group-addon">Recurrente:</span>
                <asp:CheckBox ID="chkRecurrente" runat="server" CssClass="form-control" CausesValidation ="true" ValidationGroup="AgregarMetodo"/>
                <span class="input-group-addon">Activo:</span>
                <asp:CheckBox ID="chkActivo" runat="server" CssClass="form-control" CausesValidation ="true" ValidationGroup="AgregarMetodo"/>
            </div>
            <asp:RequiredFieldValidator ID="reqNombre" runat="server" CssClass="text-danger small pull-left" ErrorMessage="Seleccione un aplicación" ControlToValidate="txtNombre" ValidationGroup="AppNueva"></asp:RequiredFieldValidator>
            <div class="clearfix"></div>
        </div>
        <div class="form-group">
            <div class="btn-group btn-group-justified" role="group">
                <div class="btn-group" role="group">
                    <asp:Button ID="btnAgregarMetodo" CssClass="btn btn-block btn-success" runat="server" Text="Guardar Metodo" OnClick="btnAgregarMetodo_Click" CausesValidation="true" ValidationGroup="AppNueva" />
                </div>
                <div class="btn-group" role="group">
                    <asp:Button ID="btnCancelarMetodo" CssClass="btn btn-group btn-danger" runat="server" Text="Cancelar" OnClick="btnCancelarMetodo_Click" />
                </div>
            </div>
        </div>
        <asp:GridView ID="grdMetodos" runat="server" HorizontalAlign="Center"
            AutoGenerateColumns="false"
            DataKeyNames="IDMETODOS" CssClass="table table-striped table-bordered table-condensed table-responsive"
            EmptyDataText="No se encontraron regisros ..." OnRowCommand="grdMetodos_RowCommand">
            <HeaderStyle CssClass="label-primary" />
            <Columns>
                <asp:BoundField DataField="IDMETODOS" HeaderText="IDMETODOS" SortExpression="IDMETODOS" />
                <asp:BoundField DataField="NOMBREMETODO" HeaderText="NOMBREMETODO" SortExpression="NOMBREMETODO" />
                <asp:CheckBoxField DataField="RECURRENTE" HeaderText ="RECURRENTE" SortExpression ="RECURRENTE" />
                <asp:CheckBoxField DataField="ACTIVO" HeaderText ="ACTIVO" SortExpression ="ACTIVO" />
                <asp:ButtonField CommandName="EditMetodo" ItemStyle-Width="20px"
                    ButtonType="Image" ImageUrl="~/dist/img/editMenu.png">
                    <ControlStyle CssClass=" btn btn-default btn-xs"></ControlStyle>
                </asp:ButtonField>
            </Columns>
            <PagerStyle HorizontalAlign="Center" CssClass="pagination-ys" />
        </asp:GridView>
         <div class="form-group">
            <div class="btn-group btn-group-justified" role="group">
                <div class="btn-group" role="group">
                    <asp:Button ID="btnGuardar" CssClass="btn btn-block btn-primary" runat="server" Text="Guardar Metodo" OnClick="btnGuardar_Click" CausesValidation="true"/>
                </div>
            </div>
        </div>
    </ContentTemplate>
    <Triggers>

    </Triggers>
</asp:UpdatePanel>
