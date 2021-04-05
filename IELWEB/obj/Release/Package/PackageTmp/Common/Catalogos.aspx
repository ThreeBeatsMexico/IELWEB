<%@ Page Title="" Theme="IELSkin" Language="C#" MasterPageFile="~/Startup/App.master" AutoEventWireup="true" CodeBehind="Catalogos.aspx.cs" Inherits="IELWEB.Common.Catalogos" %>

<%@ Register Src="~/Common/UserControls/CatGeneralesWUC.ascx" TagPrefix="uc1" TagName="CatGeneralesWUC" %>
<%@ Register Src="~/Common/UserControls/CatalogosWUC.ascx" TagPrefix="uc1" TagName="CatalogosWUC" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPagina" runat="server">
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>Administracion
            <small>Catálogos</small>
            </h1>
            <ol class="breadcrumb">
                <li><a href="/Startup/Inicio.aspx"><i class="fa fa-dashboard"></i>Inicio</a></li>
                <li class="active">Catalogos</li>
            </ol>
        </section>
        <!-- Main content -->

        <section class="content">
            <div class="box box-primary">
                <div class="box-header with-border">
                    <h3 class="box-title">Catálogos</h3>
                    <div class="box-tools pull-right">
                        <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    </div>
                </div>
                <!-- /.box-header -->
                <div class="box-body">
                    <div class="row col-lg-12">
                        <asp:UpdatePanel ID="upCrudGrid" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="grdCatGenerales" runat="server" HorizontalAlign="Center" OnRowCommand="GridView1_RowCommand"
                                    AutoGenerateColumns="false"
                                    DataKeyNames="psIDCATGENERALES" CssClass="table table-bordered table-striped table-responsive"
                                    EmptyDataText="No se encontraron regisros ...">
                                    <HeaderStyle CssClass="label-primary" />
                                    <Columns>
                                        <asp:BoundField DataField="psIDCATGENERALES" HeaderText="ID" SortExpression="psIDCATGENERALES" HeaderStyle-CssClass="hidden-xs hidden-sm" ItemStyle-CssClass ="hidden-xs hidden-sm" />
                                        <asp:BoundField DataField="psNOMBRECATALOGO" HeaderText="NOMBRE" SortExpression="psNOMBRECATALOGO" />
                                        <asp:BoundField DataField="psIDCATALOGO" HeaderText="COLUMNAID" SortExpression="psIDCATALOGO" HeaderStyle-CssClass="hidden-xs hidden-sm" ItemStyle-CssClass ="hidden-xs hidden-sm" />
                                        <asp:BoundField DataField="psDESCRIPCION" HeaderText="DESCRIPCION" SortExpression="psDESCRIPCION"  HeaderStyle-CssClass="hidden-xs hidden-sm" ItemStyle-CssClass ="hidden-xs hidden-sm" />
                                        <asp:BoundField DataField="psFILTRO" HeaderText="FILTRO" SortExpression="psFILTRO" HeaderStyle-CssClass="hidden-xs hidden-sm" ItemStyle-CssClass ="hidden-xs hidden-sm" />
                                        <asp:ButtonField CommandName="AdmonCatalogo" ControlStyle-CssClass="btn btn-primary"
                                            ButtonType="Image" ImageUrl="~/dist/img/tools.png" Text="Administrar" ItemStyle-Width="20px">
                                            <ControlStyle CssClass="btn btn-default btn-xs"></ControlStyle>
                                        </asp:ButtonField>
                                        <asp:ButtonField CommandName="editRecord" ControlStyle-CssClass="btn btn-primary" ItemStyle-Width="20px"
                                            ButtonType="Image" ImageUrl="~/dist/img/editMenu.png" Text="Editar">
                                            <ControlStyle CssClass=" btn btn-default btn-xs"></ControlStyle>
                                        </asp:ButtonField>

                                    </Columns>
                                    <PagerStyle HorizontalAlign="Center" CssClass="pagination-ys" />
                                </asp:GridView>

                                <div class="box-footer clearfix">
                                    <asp:Button ID="btnShowAdd" runat="server" Text="Agregar Catalogo" CssClass="btn btn btn-primary left" OnClick="btnShowAdd_Click" />
                                </div>

                            </ContentTemplate>
                            <Triggers>
                                <%-- <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />--%>
                                <%--<asp:AsyncPostBackTrigger ControlID="btnShowAdd" EventName="Click" />--%>
                                <%--<asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />--%>
                            </Triggers>
                        </asp:UpdatePanel>
                        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                            <ProgressTemplate>
                                <div class="modal overlay">
                                    <i class="fa fa-refresh fa-spin"></i>
                                    <img src="" alt="Loading.. Please wait!" />
                                </div>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    </div>
                </div>


            </div>
        </section>
        <!--************* MODAL CACATALOGOS **************-->
        <div id="mdlCatalogo" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="addModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <asp:UpdatePanel ID="upAdd" runat="server">
                        <ContentTemplate>
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                <h4 class="modal-title"><i class="fa fa-desktop"></i>
                                    <asp:Label ID="lblTituloModal" runat="server" Text="Label"></asp:Label>
                                </h4>
                            </div>

                            <uc1:CatGeneralesWUC runat="server" ID="CatGeneralesWUC" />
                            <div class="modal-footer clearfix">
                                <asp:Button ID="btnAdd" OnClick="Add_Click" runat="server" CssClass="btn btn-primary pull-left" Text="Agregar"></asp:Button>
                                <button type="button" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-times"></i>Cancelar</button>
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="grdCatGenerales" />
                            <asp:AsyncPostBackTrigger ControlID="btnShowAdd" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
        <!-- /.content -->


        <!--************* MODAL ADMON CATALOGOS**************-->
        <div id="mdlAdmon" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="admonModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <asp:UpdatePanel ID="udpAdmonCatalogos" runat="server">
                        <ContentTemplate>
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                <h4 class="modal-title"><i class="fa fa-desktop"></i>
                                    <asp:Label ID="lblAdministrar" runat="server" Text=""></asp:Label>
                                </h4>
                            </div>
                            <uc1:CatalogosWUC runat="server" ID="CatalogosWUC" />

                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="grdCatGenerales" />
                            <asp:AsyncPostBackTrigger ControlID="btnShowAdd" />
                            <asp:AsyncPostBackTrigger ControlID="CatalogosWUC" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>

    </div>
</asp:Content>

