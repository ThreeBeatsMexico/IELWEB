<%@ Page Title="" Theme="IELSkin" Language="C#" MasterPageFile="~/Startup/App.master" AutoEventWireup="true" CodeBehind="RolesLista.aspx.cs" Inherits="IELWEB.Roles.RolesLista" %>

<%@ Register Src="~/Roles/UserControls/AddMenuWUC.ascx" TagPrefix="uc1" TagName="AddMenuWUC" %>
<%@ Register Src="~/Roles/UserControls/AddSubMenuWUC.ascx" TagPrefix="uc1" TagName="AddSubMenuWUC" %>





<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPagina" runat="server">

     <style>
      .example-modal .modal {
        position: relative;
        top: auto;
        bottom: auto;
        right: auto;
        left: auto;
        display: block;
        z-index: 1;
      }
      .example-modal .modal {
        background: transparent!important;
      }
    </style>


    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript">
        $("[src*=plus]").live("click", function () {
            $(this).closest("tr").after("<tr class='label-default'><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
            $(this).attr("src", "../dist/img/minus.png");
            var valor = $(this)[0].id;
            $('#<%=hdIndice.ClientID%>').val(valor);
            
           
        });
        $("[src*=minus]").live("click", function () {
            $(this).attr("src", "../dist/img/plus.png");
            $(this).closest("tr").next().remove();
        });
    </script>
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>ROLES LATINO
            <small>Lista de Roles x App</small>
            </h1>
            <ol class="breadcrumb">
                <li><a href="/Startup/Inicio.aspx"><i class="fa fa-dashboard"></i>Inicio</a></li>
                <li class="active">Roles</li>
            </ol>
        </section>

        <section class="content">
            <div class="box box-primary">
                <div class="box-header with-border">
                    <h3 class="box-title">ROLES POR APLICACION</h3>
                    <div class="box-tools pull-right">
                        <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    </div>
                </div>

                <div class="box-body">
                    
                    <asp:UpdatePanel ID="upRolesxApp" runat="server">
                        <ContentTemplate>

                            <div class="form-group col-lg-5">
                                <label for="lblforddlNumeroPoliza">APLICACION</label>
                                <asp:DropDownList ID="ddlApps" runat="server" OnSelectedIndexChanged="ddlApps_SelectedIndexChanged" required="required" AutoPostBack="true" CssClass="form-control" placeholder="Selecciona una Aplicación ...">
                                </asp:DropDownList>

                            </div>
                            <%-- </ContentTemplate>
                    </asp:UpdatePanel>


                    <asp:UpdatePanel ID="upRol" runat="server">
                        <ContentTemplate>--%>
                            <div class="form-group col-lg-5">
                                <label for="lblforddlNumeroPoliza">ROLES</label>
                                <asp:DropDownList ID="ddlRoles" runat="server" OnSelectedIndexChanged="ddlRoles_SelectedIndexChanged"  AutoPostBack="true" CssClass="form-control" placeholder="Selecciona un Rol ...">
                                </asp:DropDownList>
                            </div>



                            <div class="form-group col-lg-2">
                                <label for="lblforddlNumeroPoliza">AGREGAR</label>
                                <%--<div class="btn btn-default btn-file"><i class="fa fa-paperclip"></i>AGREGAR <asp:FileUpload ID="FileUpload1" runat="server" /> </div>--%>

                                <asp:Button ID="btnAddRol" CausesValidation="true" OnClick="btnAgregaRol_Click" runat="server" Text="ADD ROL" class="btn btn-block btn-primary fa fa-fw fa-plus-circle"></asp:Button>

                            </div>

                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
           
            <div id="dvPermisosMenu" class="box box-default">
                <div class="box-header with-border">
                    <div id="dvLabelAppRolSelected"></div>
                    <h3 class="box-title">PERMISOS POR MENU Y SUBMENU</h3>
                    <div class="box-tools pull-right">
                        <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    </div>
                </div>

                <div class="box-body">
                    <asp:UpdatePanel ID="upCrudGrid" runat="server">
                        <ContentTemplate>

                             <asp:Panel runat="server" ID="pnlGrids" Style="display: none">

                            <p class="text-center text-blue text-bold">
                                <asp:Label runat="server" ID="lblTitulo"></asp:Label>
                            </p>
                                 <asp:HiddenField ID="hdIndice" runat="server" />
                            <asp:GridView ID="gvMenu" runat="server" HorizontalAlign="Center"
                                OnRowCommand="gvMenu_RowCommand" AutoGenerateColumns="false" AllowPaging="true"
                                DataKeyNames="IDPERMISOSMENU" CssClass="table table-striped table-bordered table-condensed"
                                 OnRowDataBound="gvMenu_RowDataBound"  EmptyDataText="No se encontraron regisros ...">
                                <Columns>

                                    <asp:TemplateField>
                                        <ItemTemplate>
                                           <%-- <asp:ImageButton ID="btnMas" runat="server"  ImageUrl="../dist/img/plus.png" OnCommand="btnMas_Command" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />--%>
                                            <img alt="" style="cursor: pointer" id="imgPlus" runat="server" src="../dist/img/plus.png" />
                                            <asp:Panel ID="pnlSubmenu" runat="server" Style="display: none">
                                                <asp:GridView ID="gvSubMenu" runat="server" OnRowCommand="gvSubMenu_RowCommand" AutoGenerateColumns="false" CssClass="table table-hover table-bordered" EmptyDataText="No se encontraron regisros para este Menu..."
                                                    DataKeyNames="IDPERMISOSXSUBMENU,IDPERMISOSMENU">
                                                    <HeaderStyle CssClass="label-info" />
                                                    <Columns>
                                                        <asp:BoundField DataField="IDPERMISOSXSUBMENU" HeaderText="IDSUBMENU" HeaderStyle-Width="10%" Visible="false" SortExpression="IDPERMISOSXSUBMENU" />
                                                        <asp:BoundField DataField="IDPERMISOSMENU" HeaderText="IDMENU" HeaderStyle-Width="10%" Visible="false" SortExpression="IDPERMISOSMENU" />
                                                        <asp:BoundField DataField="IDAPLICACION" HeaderText="IDAPLICACION" HeaderStyle-Width="10%" Visible="false" SortExpression="IDAPLICACION" />
                                                        <asp:BoundField DataField="NOMBRESUBMENU" HeaderText="SUB-MENU" HeaderStyle-Width="20%" SortExpression="NOMBRESUBMENU" />
                                                        <asp:BoundField DataField="TIPOOBJETO" HeaderText="TIPOOBEJETO" HeaderStyle-Width="20%" Visible="true" SortExpression="TIPOOBJETO" />
                                                        <asp:BoundField DataField="URL" HeaderText="URL" HeaderStyle-Width="30%" SortExpression="URL" />
                                                        <asp:BoundField DataField="IMAGEN" HeaderText="IMAGEN" HeaderStyle-Width="10%" SortExpression="IMAGEN" />
                                                        <asp:BoundField DataField="ORDENSUBMENU" HeaderText="ORDEN-SUBMENU" HeaderStyle-Width="10%" SortExpression="ORDENSUBMENU" />
                                                        <asp:BoundField DataField="TOOLTIP" HeaderText="TOOLTIP" HeaderStyle-Width="10%" SortExpression="TOOLTIP" />
                                                        <asp:BoundField DataField="ACTIVO" HeaderText="ACTIVO" HeaderStyle-Width="10%" SortExpression="ACTIVO" />
                                                        <asp:TemplateField HeaderText="" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="imgEditaSubMenu" runat="server" CommandName="EditSubMenu" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ImageUrl="../dist/img/editSubMenu.png" ToolTip="EDITAR SUB-MENU" CausesValidation="false" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="imgEliminaSubMenu" runat="server" CommandName="DelSubMenu" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ImageUrl="../dist/img/delSubMenu.png" OnClientClick="return confirm('Estas seguro de eliminar este SubMenu ?')" ToolTip="ELIMINAR SUB-MENU" CausesValidation="false" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </asp:Panel>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="IDPERMISOSMENU" HeaderText="ID" HeaderStyle-Width="10%" Visible="false" SortExpression="IDPERMISOSMENU" />
                                    <asp:BoundField DataField="IDROL" HeaderText="ID" HeaderStyle-Width="10%" Visible="false" SortExpression="IDROL" />
                                    <asp:BoundField DataField="IDAPLICACION" HeaderText="ID" HeaderStyle-Width="10%" Visible="false" SortExpression="IDAPLICACION" />
                                    <asp:BoundField DataField="NOMBREMENU" HeaderText="MENU" HeaderStyle-Width="20%" SortExpression="NOMBREMENU" />
                                    <asp:BoundField DataField="TIPOOBJETO" HeaderText="TIPOOBEJETO" HeaderStyle-Width="20%" Visible="true" SortExpression="TIPOOBJETO" />
                                    <asp:BoundField DataField="URL" HeaderText="URL" HeaderStyle-Width="30%" SortExpression="URL" />
                                    <asp:BoundField DataField="IMAGEN" HeaderText="IMAGEN" HeaderStyle-Width="10%" SortExpression="IMAGEN" />
                                    <asp:BoundField DataField="ORDENMENU" HeaderText="ORDEN" HeaderStyle-Width="10%" SortExpression="ORDENMENU" />
                                    <asp:BoundField DataField="TOOLTIP" HeaderText="TOOLTIP" HeaderStyle-Width="10%" SortExpression="TOOLTIP" />
                                    <asp:BoundField DataField="ACTIVO" HeaderText="ACTIVO" HeaderStyle-Width="10%" SortExpression="ACTIVO" />
                                    <asp:TemplateField HeaderText="" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgNuevoMenu" runat="server" CommandName="AddSubMenu" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"  ImageUrl="../dist/img/addSubMenu.png" ToolTip="AGREGAR SUBMENU" CausesValidation="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgEditaMenu" runat="server" CommandName="EditMenu" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ImageUrl="../dist/img/editMenu.png" ToolTip="EDITAR MENU" CausesValidation="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgEliminaMenu" runat="server" CommandName="DelMenu" ImageUrl="../dist/img/delMenu.png" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" OnClientClick="return confirm('Estas seguro de eliminar este Menu ?')" ToolTip="ELIMINAR MENU" CausesValidation="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>
                                <PagerStyle HorizontalAlign="Center" CssClass="pagination-ys" />
                            </asp:GridView>
                            <div class="box-footer clearfix">
                                <asp:Button ID="btnAddMenu" CssClass="btn btn btn-primary left" OnClick="btnAddMenu_Click" runat="server" Text="AGREGAR MENU" />
                            </div>

                                  </asp:Panel>
                        </ContentTemplate>
                        <Triggers>
                        </Triggers>


                    </asp:UpdatePanel>



                    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                        <ProgressTemplate>
                            <div class="overlay">
                                <i class="fa fa-refresh fa-spin"></i>
                                <img src="" alt="Loading.. Please wait!" />
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>

                </div>
            </div>
           











        </section>

        <!--************* MODAL ROL**************-->
        <div id="mdlAddRol" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="addModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content primary">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                <h4 class="modal-title"><i class="fa fa-desktop"></i>
                                    <asp:Label ID="Label1" runat="server" Text="AGREGAR ROL"></asp:Label>
                                </h4>
                            </div>
                            <div class="modal-body">
                            <div class="form-group">
                                <div class="input-group">
                                    <span class="input-group-addon"><span class="fa fa-user-secret"></span></span>
                                    <asp:TextBox ID="txtNombreRol" runat="server" CssClass="form-control" placeholder="nombre del rol"></asp:TextBox>
                                </div>
                            </div>
                                </div>
                            <div class="modal-footer clearfix">
                                <asp:Button ID="btnSaveRol" runat="server" OnClick="btnSaveRol_Click" CssClass="btn btn-primary pull-left" Text="Guardar"></asp:Button>
                                <button type="button" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-times"></i>Cancelar</button>
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlRoles" />

                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
        <!-- /.content -->

        <!--************* MODAL MENU **************-->
        <div id="mdlMenu" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="addModalLabel" aria-hidden="true">
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

                            <uc1:AddMenuWUC runat="server" ID="AddMenuWUC" />
                            <div class="modal-footer clearfix">
                                <asp:Button ID="btnSaveAddMenu" runat="server" OnClick="btnSaveAddMenu_Click" CssClass="btn btn-primary pull-left" Text="Guardar"></asp:Button>
                                <button type="button" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-times"></i>Cancelar</button>
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="gvMenu" />
                            <asp:AsyncPostBackTrigger ControlID="btnAddMenu" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
        <!-- /.content -->

        <!--************* MODAL SUB MENU **************-->
        <div id="mdlSubMenu" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="addModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                <h4 class="modal-title"><i class="fa fa-desktop"></i>
                                    <asp:Label ID="lblSubMenuTitle" runat="server" Text="Label"></asp:Label>
                                </h4>
                            </div>

                            <uc1:AddSubMenuWUC runat="server" id="AddSubMenuWUC" />
                            <div class="modal-footer clearfix">
                                <asp:Button ID="btnSaveAddSubMenu" runat="server" OnClick="btnSaveAddSubMenu_Click" CssClass="btn btn-primary pull-left" Text="Guardar"></asp:Button>
                                <button type="button" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-times"></i>Cancelar</button>
                            </div>
                        </ContentTemplate>
                        <Triggers>
                           
                            <asp:AsyncPostBackTrigger ControlID="gvMenu" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
        <!-- /.content -->

          <!--************* MODAL SUB MENU **************-->
       <%-- <div id="mdlMensaje" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="addModalLabel" aria-hidden="true">--%>
            <%-- <div class="example-modal" id="mdlMensaje">
            <div class="modal modal-success">
              <div class="modal-dialog">
                <div class="modal-content">
                  <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">×</span></button>
                    <h4 class="modal-title">Mensaje</h4>
                  </div>
                  <div class="modal-body">
                    <p><asp:Label ID="lblMensajeOk" runat="server"></asp:Label></p>
                  </div>
                  <div class="modal-footer">
                    <button type="button" class="btn btn-outline center-block" data-dismiss="modal">Ok</button>
                    
                  </div>
                </div><!-- /.modal-content -->
              </div><!-- /.modal-dialog -->
            </div><!-- /.modal -->
          </div>--%>
    <%--    </div>--%>
        <!-- /.content -->




       





















    </div>
</asp:Content>
