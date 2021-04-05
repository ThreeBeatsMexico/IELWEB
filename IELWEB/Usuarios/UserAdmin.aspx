<%@ Page Title="" Theme="IELSkin" Language="C#" MasterPageFile="~/Startup/App.master" AutoEventWireup="true" CodeBehind="UserAdmin.aspx.cs" Inherits="IELWEB.Usuarios.UserAdmin" %>

<%@ Register Src="~/Usuarios/UserControls/UserFullWUC.ascx" TagPrefix="uc1" TagName="UserFullWUC" %>
<%@ Register Src="~/Common/UserControls/MensajeWUC.ascx" TagPrefix="uc1" TagName="MensajeWUC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPagina" runat="server">
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>Administración
            <small>Usuarios</small>
            </h1>
            <ol class="breadcrumb">
                <li><a href="/Startup/Inicio.aspx"><i class="fa fa-dashboard"></i>Inicio</a></li>
                <li class="active">Usuarios
                </li>
            </ol>
        </section>
        <section class="content">
            <div class="box box-primary">
                <div class="box-header with-border">
                    <h3 class="box-title">Usuarios</h3>
                    <div class="box-tools pull-right">
                        <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    </div>
                </div>
                <div class="box-body">
                    <div class="form-group">
                        <div class="input-group">
                            <span class="input-group-addon">Usuario</span>
                            <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" placeholder="Usuario"></asp:TextBox>
                            <%--<asp:DropDownList ID="ddlSistema" runat="server" CssClass="form-control" AutoPostBack="false"></asp:DropDownList>--%>
                            <span class="input-group-addon">APaterno</span>
                            <asp:TextBox ID="txtAPaterno" runat="server" CssClass="form-control" placeholder="APaterno"></asp:TextBox>
                            <span class="input-group-addon hidden-sm hidden-xs">AMaterno</span>
                            <asp:TextBox ID="txtAMaterno" runat="server" CssClass="form-control hidden-sm hidden-xs" placeholder="AMaterno"></asp:TextBox>
                            <span class="input-group-addon hidden-sm hidden-xs">Nombre</span>
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control hidden-sm hidden-xs" placeholder="Nombre"></asp:TextBox>
                            <span class="input-group-btn">
                                <asp:Button ID="btnBuscarUsuario" runat="server" Text="Buscar" CssClass="btn btn-primary pull-left" OnClick="btnBuscarUsuario_Click" />
                            </span>
                        </div>
                    </div>
                    <asp:UpdatePanel ID="upCrudGrid" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="grdUsuarios" runat="server" HorizontalAlign="Center"
                                AutoGenerateColumns="false"
                                DataKeyNames="IDUSUARIO" CssClass="table table-bordered table-striped table-responsive"
                                EmptyDataText="No se encontraron regisros ..." OnRowCommand="grdUsuarios_RowCommand">
                                <HeaderStyle CssClass="label-primary" />
                                <Columns>
                                    <asp:BoundField DataField="DESCAREA" HeaderText="AREA" SortExpression="DESCAREA" HeaderStyle-CssClass="hidden-xs hidden-sm" ItemStyle-CssClass=" hidden-xs hidden-sm" />
                                    <asp:BoundField DataField="APATERNO" HeaderText="APATERNO" SortExpression="APATERNO" HeaderStyle-CssClass="hidden-xs hidden-sm" ItemStyle-CssClass=" hidden-xs hidden-sm" />
                                    <asp:BoundField DataField="AMATERNO" HeaderText="AMATERNO" SortExpression="AMATERNO" HeaderStyle-CssClass="hidden-xs hidden-sm" ItemStyle-CssClass=" hidden-xs hidden-sm" />
                                    <asp:BoundField DataField="NOMBRE" HeaderText="NOMBRE" SortExpression="NOMBRE" />
                                    <asp:BoundField DataField="USUARIO" HeaderText="USUARIO" SortExpression="USUARIO" />
                                    <asp:ButtonField CommandName="EditUsuario" ItemStyle-Width="20px"
                                        ButtonType="Image" ImageUrl="~/dist/img/editMenu.png">
                                        <ControlStyle CssClass=" btn btn-default btn-xs"></ControlStyle>
                                    </asp:ButtonField>
                                </Columns>
                                <PagerStyle HorizontalAlign="Center" CssClass="pagination-ys" />
                            </asp:GridView>

                            <div class="box-footer clearfix">
                                <asp:Button ID="btnShowAdd" runat="server" Text="Agregar Usuario" CssClass="btn btn btn-primary left" OnClick="btnShowAdd_Click" />
                            </div>

                        </ContentTemplate>
                        <Triggers>
                            <%-- <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />--%>
                            <%--<asp:AsyncPostBackTrigger ControlID="btnShowAdd" EventName="Click" />--%>
                            <%--<asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />--%>
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </section>

        <div id="mdlUser" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="addModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <asp:UpdatePanel ID="udpUser" runat="server">
                        <ContentTemplate>
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                <h4 class="modal-title"><span class="fa fa-user-plus"></span>
                                    <asp:Label ID="lblModalUser" runat="server" Text="Label"></asp:Label>
                                </h4>
                            </div>
                            <uc1:UserFullWUC runat="server" ID="UserFullWUC" />

                            <div class="modal-footer clearfix">
                                <asp:Button ID="btnSaveUsuario" runat="server" CssClass="btn btn-primary pull-left" Text="Guardar" OnClick="btnSaveUsuario_Click" ValidationGroup="AgregarUsuario"></asp:Button>
                                <button type="button" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-times"></i>Cancelar</button>
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="grdUsuarios" />
                            <asp:AsyncPostBackTrigger ControlID="btnShowAdd" />
                            <asp:AsyncPostBackTrigger ControlID="UserFullWUC" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
    <uc1:MensajeWUC runat="server" ID="MensajeWUCUsuario" />
</asp:Content>

