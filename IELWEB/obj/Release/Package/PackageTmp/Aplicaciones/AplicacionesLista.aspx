<%@ Page Title="" Theme="IELSkin" Language="C#" MasterPageFile="~/Startup/App.master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="AplicacionesLista.aspx.cs" Inherits="IELWEB.Aplicaciones.AplicacionesLista" Theme="IELSkin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPagina" runat="server">
    <%-- <link href="/EJEMPLO/Styles/bootstrap.css" rel="stylesheet" />--%>
    <script type="text/javascript">
        function ShowHidePassword() {
            var txt = $('#<%=txtAddPassword.ClientID%>');
            if (txt.prop("type") == "password") {
                txt.prop("type", "text");
                $("label[for='chkMuestraPass']").text("OCULTAR PASSWORD");
            }
            else {
                txt.prop("type", "password");
                $("label[for='chkMuestraPass']").text("MOSTRAR PASSWORD");
            }
        }

        function ShowHidePassword2() {
            var txt = $('#<%=txtPassword.ClientID%>');
            if (txt.prop("type") == "password") {
                txt.prop("type", "text");
                $("label[for='chkShowPass']").text("OCULTAR PASSWORD");
            }
            else {
                txt.prop("type", "password");
                $("label[for='chkShowPass']").text("MOSTRAR PASSWORD");
            }
        }


    </script>
    <%-- #showHide {
  width: 15px;
  height: 15px;
  float: left;
}
#showHideLabel {
  float: left;
  padding-left: 5px;
}--%>

    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>APLICACIONES IEL
            <small>Lista de Aplicaciones</small>
            </h1>
            <ol class="breadcrumb">
                <li><a href="/Startup/Inicio.aspx"><i class="fa fa-dashboard"></i>Inicio</a></li>
                <li class="active">Aplicaciones</li>
            </ol>
        </section>

        <!-- Main content -->

        <section class="content">
            <div class="box box-primary">
                <div class="box-header with-border">
                    <h3 class="box-title">Aplicaciones</h3>
                    <div class="box-tools pull-right">
                        <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    </div>
                </div>
                <!-- /.box-header -->
                <div class="box-body">
                    <!---->
                    <asp:UpdatePanel ID="upCrudGrid" runat="server">
                        <ContentTemplate>




                            <%--    <h3 style="text-align: center;">ASP.NET GridVIew: CRUD using Twitter Bootstrap Modal Popup</h3>
            <p style="text-align: center;">Demo by Priya Darshini - Tutorial @ <a href="http://www.programming-free.com/2013/09/gridview-crud-bootstrap-modal-popup.html">Programmingfree</a></p>--%>
                            <!-- Placing GridView in UpdatePanel-->

                            <asp:GridView ID="GridView1" runat="server" HorizontalAlign="Center"
                                OnRowCommand="GridView1_RowCommand" AutoGenerateColumns="false"
                                DataKeyNames="IDAPLICACION" CssClass="table table-striped table-bordered table-condensed table-responsive"
                                EmptyDataText="No se encontraron regisros ...">
                                <HeaderStyle CssClass="label-primary" />
                                <Columns>
                                    <asp:BoundField DataField="IDAPLICACION" HeaderText="ID" SortExpression="IDAPLICACION" />
                                    <asp:BoundField DataField="DESCRIPCION" HeaderText="DESCRIPCION" SortExpression="DESCRIPCION" />
                                   <%-- <asp:ButtonField CommandName="detailsss" ControlStyle-CssClass="btn btn-primary"
                                        ButtonType="Button" Text="Ver" HeaderText="DETALLE">
                                        <ControlStyle CssClass="btn btn-primary"></ControlStyle>
                                    </asp:ButtonField>
                                    <asp:ButtonField CommandName="editRecordsss" ControlStyle-CssClass="btn btn-primary"
                                        ButtonType="Button" Text="Editar" HeaderText="EDITAR">
                                        <ControlStyle CssClass="btn btn-primary"></ControlStyle>
                                    </asp:ButtonField>--%>
                                    <asp:TemplateField HeaderText="" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgEditAplicacion" runat="server" CommandName="editRecord" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ImageUrl="../dist/img/editMenu.png" ToolTip="EDITAR APLICACION" CausesValidation="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgViewAplicacion" runat="server" CommandName="detail" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ImageUrl="../dist/img/search.png"  ToolTip="VER APLICACION" CausesValidation="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <PagerStyle HorizontalAlign="Center" CssClass="pagination-ys" />
                            </asp:GridView>
                            <div class="box-footer clearfix">
                                <asp:Button ID="btnAdd" runat="server" Text="AGREGAR APLICACION" CssClass="btn btn btn-primary left" OnClick="btnAdd_Click" />
                            </div>

                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />

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

                <!--************* MODAL DETALLE **************-->
                <div id="detailModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                <h4 class="modal-title"><i class="fa fa-desktop"></i>DETALLE APLICACION</h4>
                            </div>
                            <div class="modal-body">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <asp:DetailsView ID="DetailsView1" runat="server" CssClass="table table-bordered table-hover" BackColor="White" ForeColor="Black" FieldHeaderStyle-Wrap="false" FieldHeaderStyle-Font-Bold="true" FieldHeaderStyle-BackColor="LavenderBlush" FieldHeaderStyle-ForeColor="Black" BorderStyle="Groove" AutoGenerateRows="False">
                                            <Fields>
                                                <asp:BoundField DataField="IDAPLICACION" HeaderText="ID" />
                                                <asp:BoundField DataField="DESCRIPCION" HeaderText="NOMBRE" />
                                                <asp:BoundField DataField="PASSWORD" HeaderText="PASSWORD" />
                                            </Fields>
                                        </asp:DetailsView>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="RowCommand" />
                                        <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
                                    </Triggers>
                                </asp:UpdatePanel>
                                <div class="modal-footer clearfix">
                                    <button type="button" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-times"></i>Cancelar</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!--************* TERMINA MODAL DETALLE **************-->

                <!--************* MODAL EDICION **************-->
                <div id="editModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="editModalLabel" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                <h4 class="modal-title"><i class="fa fa-desktop"></i>EDITAR APLICACION</h4>
                            </div>
                            <asp:UpdatePanel ID="upEdit" runat="server">
                                <ContentTemplate>
                                    <div class="modal-body">
                                        <div class="form-group">
                                            <div class="input-group">
                                                <span class="input-group-addon">ID:</span>
                                                <asp:Label ID="lblIDAplicacion" runat="server" CssClass="form-control"></asp:Label>
                                                <%--<input name="email_to" type="email" class="form-control" placeholder="Nombre de Aplicacion">--%>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="input-group">
                                                <span class="input-group-addon">NOMBRE:</span>
                                                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" placeholder="Nombre de Aplicacion"></asp:TextBox>
                                                <%--<input name="email_to" type="email" class="form-control" placeholder="Nombre de Aplicacion">--%>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="input-group">
                                                <span class="input-group-addon">PASSWORD:</span>
                                                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Password de Aplicacion" TextMode="Password"></asp:TextBox>
                                                <%--<input name="email_to" type="email" class="form-control" placeholder="Password de Aplicacion">--%>
                                            </div>
                                            <div class="form-group">
                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        <asp:CheckBox ID="chkShowPassword" runat="server" onclick="ShowHidePassword2();" />
                                                        <label for='chkShowPassword'>MOSTRAR PASSWORD</label>
                                                    </span>
                                                    <%--<input name="email_to" type="email" class="form-control" placeholder="Password de Aplicacion">--%>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="modal-footer clearfix">
                                        <asp:Label ID="lblResult" Visible="false" runat="server"></asp:Label>
                                        <asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" CssClass="btn btn-primary pull-left" Text="Guardar"></asp:Button>
                                        <button type="button" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-times"></i>Cancelar</button>
                                    </div>

                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="RowCommand" />
                                    <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
                <!--************* TERMINA MODAL EDICION **************-->

                <!--************* MODAL AGREGAR **************-->
                <div id="addModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="addModalLabel" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                <h4 class="modal-title"><i class="fa fa-desktop"></i>AGREGAR APLICACION</h4>
                            </div>
                            <asp:UpdatePanel ID="upAdd" runat="server">
                                <ContentTemplate>
                                    <div class="modal-body">
                                        <div class="form-group">
                                            <div class="input-group">
                                                <span class="input-group-addon">NOMBRE:</span>
                                                <asp:TextBox ID="txtAddDescripcion" runat="server" CssClass="form-control" placeholder="Nombre de Aplicacion"></asp:TextBox>
                                                <%--<input name="email_to" type="email" class="form-control" placeholder="Nombre de Aplicacion">--%>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="input-group">
                                                <span class="input-group-addon">PASSWORD:</span>
                                                <asp:TextBox ID="txtAddPassword" runat="server" CssClass="form-control" placeholder="Password de Aplicacion" TextMode="Password"></asp:TextBox>
                                                <%--<input name="email_to" type="email" class="form-control" placeholder="Password de Aplicacion">--%>
                                            </div>
                                            <div class="form-group">
                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        <asp:CheckBox ID="chkMuestraPass" runat="server" onclick="ShowHidePassword();" />
                                                        <label for='chkMuestraPass'>MOSTRAR PASSWORD</label>
                                                    </span>
                                                    <%--<input name="email_to" type="email" class="form-control" placeholder="Password de Aplicacion">--%>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="modal-footer clearfix">
                                        <asp:Button ID="btnAddRecord" OnClick="btnAddRecord_Click" runat="server" CssClass="btn btn-primary pull-left" Text="Agregar"></asp:Button>
                                        <button type="button" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-times"></i>Cancelar</button>
                                    </div>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnAddRecord" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
                <!--************* TERMINA MODAL AGREGAR **************-->

                <!--************* MODAL ELIMINAR **************-->
                <div id="deleteModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="delModalLabel" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                <h4 class="modal-title"><i class="fa fa-desktop"></i>ELIMINAR APLICACION</h4>
                            </div>
                            <asp:UpdatePanel ID="upDel" runat="server">
                                <ContentTemplate>
                                    <div class="modal-body">
                                        Estas seguro que deseas eliminar la aplicación?
                            <asp:HiddenField ID="hfApp" runat="server" />
                                    </div>
                                    <div class="modal-footer clearfix">
                                        <asp:Button ID="btnDelete" OnClick="btnDelete_Click" runat="server" CssClass="btn btn-primary pull-left" Text="Eliminar"></asp:Button>
                                        <button type="button" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-times"></i>Cancelar</button>
                                    </div>

                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnDelete" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
                <!--************* TERMINA MODAL ELIMINAR **************-->

            </div>
        </section>
        <!-- /.content -->


        <!-- /.content-wrapper -->

    </div>
</asp:Content>
