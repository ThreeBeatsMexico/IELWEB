<%@ Page Title="" Theme="IELSkin" Language="C#" MasterPageFile="~/Startup/App.master" AutoEventWireup="true" CodeBehind="Configuracion.aspx.cs" Inherits="IELWEB.Common.Configuracion" %>

<%@ Register Src="~/Common/UserControls/ConfiguracionWUC.ascx" TagPrefix="uc1" TagName="ConfiguracionWUC" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPagina" runat="server">
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>Administración
            <small>Configuración Aplicación</small>
            </h1>
            <ol class="breadcrumb">
                <li><a href="/Startup/Inicio.aspx"><i class="fa fa-dashboard"></i>Inicio</a></li>
                <li class="active">Configuración
                </li>
            </ol>
        </section>
        <section class="content">
            <div class="box box-primary">
                <div class="box-header with-border">
                    <h3 class="box-title">Configuración</h3>
                    <div class="box-tools pull-right">
                        <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    </div>
                </div>
                <div class="box-body">
                     <asp:UpdatePanel ID="upCrudGrid" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="grdConfiguracion" runat="server" HorizontalAlign="Center"
                                AutoGenerateColumns="false"
                                DataKeyNames="psIDCONFIGAPP" CssClass="table table-striped table-bordered table-condensed table-responsive"
                                EmptyDataText="No se encontraron regisros ..." OnRowCommand="grdConfiguracion_RowCommand">
                                <HeaderStyle CssClass="label-primary" />
                                <Columns>
                                    <asp:BoundField DataField="psIDCONFIGAPP" HeaderText="ID" SortExpression="psIDCONFIGAPP" />
                                    <asp:BoundField DataField="psDESCRIPCION" HeaderText="NOMBRE" SortExpression="psDESCRIPCION" />
                                    <asp:BoundField DataField="psVALOR" HeaderText="VALOR" SortExpression="psVALOR" />
                                    <asp:CheckBoxField DataField ="psACTIVO" HeaderText ="ACTIVO" SortExpression ="psACTIVO" />
                                    <asp:ButtonField CommandName="editRecord" ControlStyle-CssClass="btn btn-primary"
                                        ButtonType="Button" Text="Editar" HeaderText="EDITAR">
                                        <ControlStyle CssClass="btn btn-primary"></ControlStyle>
                                    </asp:ButtonField>
                                </Columns>
                                <PagerStyle HorizontalAlign="Center" CssClass="pagination-ys" />
                            </asp:GridView>

                            <div class="box-footer clearfix">
                                <asp:Button ID="btnShowAdd" runat="server" Text="Agregar Configuración" CssClass="btn btn btn-primary left" OnClick="btnShowAdd_Click" />
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
        <!--************* MODAL CACATALOGOS **************-->
        <div id="mdlConfiguracion" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="addConfigLabel" aria-hidden="true">
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
                            <uc1:ConfiguracionWUC runat="server" ID="ConfiguracionWUC" />
                            <div class="modal-footer clearfix">
                                <asp:Button ID="btnAdd" OnClick="Add_Click" runat="server" CssClass="btn btn-primary pull-left" Text="Agregar"></asp:Button>
                                <button type="button" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-times"></i>Cancelar</button>
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="grdConfiguracion" />
                            <asp:AsyncPostBackTrigger ControlID="btnShowAdd" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
        <!-- /.content -->
    </div>
</asp:Content>
