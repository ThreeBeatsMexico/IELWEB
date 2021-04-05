<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CatalogosWUC.ascx.cs" Inherits="IELWEB.Common.UserControls.CatalogosWUC" %>


<div class="box box-primary">
    <div class="box-header with-border">
        <h3 class="box-title">Agregar Elemento</h3>
        <div class="box-tools pull-right">
            <div class="form-group">
                <div class="input-group">
                    <span class="input-group-addon">Descripción:</span>
                    <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" placeholder="Descripción"></asp:TextBox>
                    <span class="input-group-btn">
                        <asp:Button ID="btnAddCatEspecifico" runat="server" Text="Agregar" CssClass="btn btn-success pull-left" OnClick="btnAddCatEspecifico_Click" />
                    </span>
                </div>
            </div>
        </div>
    </div>
    <div class="clearfix"></div>


    <!-- /.box-header -->
    <div class="box-body">
        <asp:GridView ID="grdAdmonCatalogos" runat="server" HorizontalAlign="Center" OnRowCommand="grdAdmonCatalogos_RowCommand"
            AutoGenerateColumns="false"
            DataKeyNames="ID" CssClass="table table-striped table-bordered table-condensed table-responsive"
            EmptyDataText="No se encontraron regisros ...">
            <HeaderStyle CssClass="label-primary" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                <asp:BoundField DataField="DESCRIPCION" HeaderText="DESCRIPCION" SortExpression="DESCRIPCION" />
            </Columns>
            <PagerStyle HorizontalAlign="Center" CssClass="pagination-ys" />
        </asp:GridView>
    </div>
</div>
