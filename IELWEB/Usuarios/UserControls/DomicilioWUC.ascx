<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DomicilioWUC.ascx.cs" Inherits="IELWEB.Usuarios.UserControls.DomicilioWUC" %>
<%@ Register Src="~/Common/UserControls/MensajeWUC.ascx" TagPrefix="uc1" TagName="MensajeWUC" %>
<%--<div class="box box-primary">
    <div class="box-header with-border">
        <h3 class="box-title">Domicilio</h3>
    </div>
    <div class="box-body">--%>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div class="form-group">
            <div class="input-group">
                <span class="input-group-addon">ID</span>
                <asp:TextBox ID="txtIdDomicilio" runat="server" CssClass="form-control" placeholder="Id Domicilio" Enabled="false"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <div class="input-group">
                <span class="input-group-addon"><span class="glyphicon glyphicon-road"></span></span>
                <asp:TextBox ID="txtCalle" runat="server" CssClass="form-control" placeholder="Calle"></asp:TextBox>
            </div>
            <asp:RequiredFieldValidator ID="reqCalle" runat="server" CssClass="text-danger small pull-left" ErrorMessage="Agregue una calle" ControlToValidate="txtCalle" ValidationGroup="AgregarDomicilio"></asp:RequiredFieldValidator>
        </div>
        <div class="clearfix"></div>
        <div class="form-group">
            <div class="input-group">
                <span class="input-group-addon"><span class="glyphicon glyphicon-home"></span></span>
                <asp:TextBox ID="txtNumeroExterior" runat="server" CssClass="form-control" placeholder="Numero Exterior"></asp:TextBox>
                <span class="input-group-addon"><span class="glyphicon glyphicon-home"></span></span>
                <asp:TextBox ID="txtNumerointerior" runat="server" CssClass="form-control" placeholder="Numero Interior"></asp:TextBox>
            </div>
            <asp:RequiredFieldValidator ID="reqNumeroExterior" runat="server" CssClass="text-danger small pull-left" ErrorMessage="Agregue un número exterior" ControlToValidate="txtNumeroExterior" ValidationGroup="AgregarDomicilio"></asp:RequiredFieldValidator>
        </div>
        <div class="clearfix"></div>
        <div class="form-group">
            <div class="input-group">
                <span class="input-group-addon"><span>CP</span></span>
                <asp:TextBox ID="txtCP" runat="server" MaxLength="5" CssClass="form-control" placeholder="Codigo Postal" OnTextChanged="txtCP_TextChanged" onkeypress="return IsNumeric(event, 'errorCP');" AutoPostBack="true"></asp:TextBox>
            </div>
            <span id="errorCP" style="display: none" class="text-danger small pull-left">*Solo números*</span>
            <asp:RequiredFieldValidator ID="reqCP" runat="server" CssClass="text-danger small pull-left" ErrorMessage="Agregue un CP" ControlToValidate="txtCP" ValidationGroup="AgregarDomicilio"></asp:RequiredFieldValidator>
        </div>
        <div class="clearfix"></div>
        <div class="form-group">
            <div class="input-group">
                <span class="input-group-addon"><span class="glyphicon glyphicon-road"></span></span>
                <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
            <asp:RequiredFieldValidator ID="reqEstado" runat="server" CssClass="text-danger small pull-left" ErrorMessage="Seleccione un estado" ControlToValidate="ddlEstado" InitialValue="0" ValidationGroup="AgregarDomicilio"></asp:RequiredFieldValidator>
        </div>
        <div class="clearfix"></div>
        <div class="form-group">
            <div class="input-group">
                <span class="input-group-addon"><span class="glyphicon glyphicon-road"></span></span>
                <asp:DropDownList ID="ddlMunicipio" runat="server" CssClass="form-control"></asp:DropDownList>
                <span class="input-group-addon"><span class="glyphicon glyphicon-road"></span></span>
                <asp:DropDownList ID="ddlColonia" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
            <asp:RequiredFieldValidator ID="reqMunicipio" runat="server" CssClass="text-danger small pull-left" ErrorMessage="Seleccione un municipio" ControlToValidate="ddlMunicipio" InitialValue="0" ValidationGroup="AgregarDomicilio"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="reqColonia" runat="server" CssClass="text-danger small pull-left" ErrorMessage="--Seleccione una colonia" ControlToValidate="ddlColonia" InitialValue="0" ValidationGroup="AgregarDomicilio"></asp:RequiredFieldValidator>
        </div>
        <div class="clearfix"></div>
        <div class="form-group">
            <div class="btn-group btn-group-justified" role="group">
                <div class="btn-group" role="group">
                    <asp:Button ID="btnAgregarDomicilio" CssClass="btn btn-block btn-success" runat="server" Text="Guardar Domicilio" ValidationGroup="AgregarDomicilio" OnClick="btnAgregarDomicilio_Click" />
                </div>
                <div class="btn-group" role="group">
                    <asp:Button ID="btnCancelarDomicilios" CssClass="btn btn-group btn-danger" runat="server" Text="Cancelar" OnClick="btnCancelarDomicilios_Click" />
                </div>
            </div>
        </div>
        <asp:GridView ID="grdDomicilio" runat="server" HorizontalAlign="Center"
            AutoGenerateColumns="false"
            DataKeyNames="IDDOMICILIO,IDUSUARIO" CssClass="table table-striped table-bordered table-condensed table-responsive"
            EmptyDataText="No se encontraron regisros ..." OnRowCommand="grdDomicilio_RowCommand">
            <HeaderStyle CssClass="label-primary" />
            <Columns>
                <asp:BoundField DataField="IDDOMICILIO" HeaderText="ID" SortExpression="IDDOMICILIO" HeaderStyle-CssClass="hidden-xs" ItemStyle-CssClass="hidden-xs" />
                <asp:BoundField DataField="CALLE" HeaderText="CALLE" SortExpression="CALLE" />
                <asp:BoundField DataField="NUMEXT" HeaderText="NUMEXT" SortExpression="NUMEXT" />
                <asp:BoundField DataField="NUMINT" HeaderText="NUMINT" SortExpression="NUMINT" HeaderStyle-CssClass="hidden-xs" ItemStyle-CssClass="hidden-xs" />
                
                <asp:BoundField DataField="MUNICIPIO" HeaderText="MUNICIPIO" SortExpression="MUNICIPIO" HeaderStyle-CssClass="hidden-xs" ItemStyle-CssClass="hidden-xs" />
                <asp:BoundField DataField="COLONIA" HeaderText="COLONIA" SortExpression="COLONIA" />
                <asp:BoundField DataField="CP" HeaderText="CP" SortExpression="CP" HeaderStyle-CssClass="hidden-xs" ItemStyle-CssClass="hidden-xs" />
                <asp:ButtonField CommandName="EditDomicilio" ItemStyle-Width="20px"
                    ButtonType="Image" ImageUrl="~/dist/img/editMenu.png">
                    <ControlStyle CssClass=" btn btn-default btn-xs"></ControlStyle>
                </asp:ButtonField>
                <asp:ButtonField CommandName="DeleteDomicilio" ItemStyle-Width="20px"
                    ButtonType="Image" ImageUrl="~/dist/img/delMenu.png">
                    <ControlStyle CssClass=" btn btn-default btn-xs"></ControlStyle>
                </asp:ButtonField>
            </Columns>
            <PagerStyle HorizontalAlign="Center" CssClass="pagination-ys" />
        </asp:GridView>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="txtCP" EventName="TextChanged" />
        <asp:AsyncPostBackTrigger ControlID="btnAgregarDomicilio" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="grdDomicilio" />
    </Triggers>
</asp:UpdatePanel>
<%--<uc1:MensajeWUC runat="server" ID="MensajeWUC" />--%>
