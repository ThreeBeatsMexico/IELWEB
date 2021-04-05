<%@ Page Title="" Theme="IELSkin" Language="C#" MasterPageFile="~/Startup/App.master" AutoEventWireup="true" CodeBehind="AppsList.aspx.cs" Inherits="IELWEB.Aplicaciones.AppsList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPagina" runat="server">
        <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
          <h1>APLICACIONES LATINO <small>APPS LIST</small>
          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>APPSS</a></li>
            <li class="active">APPS LIST</li>
          </ol>
        </section>
        <!-- Main content -->
        <section class="content">
 <div class="box box-info">
                <div class="box-header with-border">
                    <h3 class="box-title">Aplicaciones</h3>
                    <div class="box-tools pull-right">
                        <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    </div>
                </div>
                <!-- /.box-header -->
             <div class="box-body">
                   <div class="input-group input-group-sm">
                     <asp:TextBox ID="txtSearch" runat="server"  class="form-control input-sm" 
                            style="margin-top: 5px;"></asp:TextBox>
                    <span class="input-group-btn">
                         <asp:Button ID="btnSearch" runat="server" Text="Go!" class="btn btn-info btn-flat"/>
                     
                    </span>
                  </div>
                      <div >
                            <asp:Button ID="btnAdd" runat="server" Text="Add New" class="btn btn-primary"/>&nbsp;

                            <asp:Button ID="btnDelete" runat="server" Text="Delete" class="btn btn-primary" 
                            OnClientClick="return confirm('Do you really want to delete the employee?');" />&nbsp;

                            <asp:Label ID="Label1" runat="server" Text="Search by name : "></asp:Label>

                           

                           

                        </div>

                        <div>


                             <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <contenttemplate>

                                    <asp:GridView ID="GridView1" runat="server" OnPageIndexChanged="gvAplicaciones_PageIndexChanged" OnPageIndexChanging="gvAplicaciones_PageIndexChanging" AutoGenerateColumns="False" EmptyDataText="No Record"
         class="table table-striped table-bordered table-condensed" 
         AllowPaging="True" OnRowCommand="GridView1_RowCommand" >
         <Columns>
             <asp:BoundField DataField="IDAPLICACION" HeaderText="ID" SortExpression="IDAPLICACION" />
             <asp:BoundField DataField="DESCRIPCION" HeaderText="DESCRIPCION" SortExpression="DESCRIPCION" />
             <asp:BoundField DataField="PASSWORD" HeaderText="PASSWORD" SortExpression="PASSWORD"/>
               <asp:ButtonField CommandName="EDITAR" 
                         ControlStyle-CssClass="btn btn-info" ButtonType="Button" 
                         Text="EDITAR" HeaderText="EDITAR"/>
             <asp:TemplateField HeaderText="EDITAR | BORRAR">
                 <ItemTemplate>
                     <asp:LinkButton ID="LinkButton2" runat="server" CommandName="select"
                     CommandArgument='<%# Eval("IDAPLICACION") %>'>Edit</asp:LinkButton>&nbsp;&nbsp;|&nbsp;
                     <asp:CheckBox ID="chkDelete" runat="server" AutoPostBack="True" />
                     <asp:HiddenField ID="hfEmpId" runat="server" value='<%# Eval("IDAPLICACION") %>'/>
                 </ItemTemplate>
             </asp:TemplateField>
         </Columns>
         <PagerStyle CssClass="pagination-ys" />
     </asp:GridView>                             
                                </contenttemplate>
                                <Triggers>                                             
                                    <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />     
                                    <asp:AsyncPostBackTrigger ControlID="btnDelete" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>  
                            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
        <ProgressTemplate>
              <div class="overlay">
                <i class="fa fa-refresh fa-spin"></i>
                  <img src="" alt="Loading.. Please wait!"/>
            </div>

        
        </ProgressTemplate>
    </asp:UpdateProgress>
                         </div>













    
                    
                    
                    
                            </div>
       <div class="box-footer clearfix">
                   
 
                </div>


     </div>
            
            
  <div class="modal fade" id="NuevaAplicacion-modal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none ;">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h4 class="modal-title"><i class="fa fa-desktop"></i> AGREGAR APLICACION</h4>
                        </div>
                  <asp:UpdatePanel ID="UpdatePanel2" runat="server">
		  <ContentTemplate>
                            <div class="modal-body">
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
                                        <span class="input-group-addon"> <asp:CheckBox ID="chkShowPassword" runat="server" Text=" MOSTRAR PASSWORD" /></span>
                                        <%--<input name="email_to" type="email" class="form-control" placeholder="Password de Aplicacion">--%>
                                    </div>
                                          </div>
                                </div>


                            </div>
                            <div class="modal-footer clearfix">

                                <button type="button" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-times"></i> Cancelar</button>
                                <%-- <asp:Button runat="server" ID="AddAplicacion" CssClass="btn btn-primary pull-left" OnClick="AddAplicacion_Click" Text="Guardar"><i class="fa fa-envelope"></i></asp:Button>--%>
                                <asp:Button id="btnSave" OnClick="btnSave_Click"  runat="server"  CssClass="btn btn-primary pull-left" Text="Guardar"></asp:Button>
                            </div>
                  </ContentTemplate>
		  <Triggers>
		     <asp:AsyncPostBackTrigger ControlID="GridView1"  EventName="RowCommand" /> 
		  </Triggers>
		  </asp:UpdatePanel>

                
                    </div>
                    <!-- /.modal-content -->
                </div>
                <!-- /.modal-dialog -->
            </div>







































         

        </section><!-- /.content -->
      </div><!-- /.content-wrapper -->
</asp:Content>
