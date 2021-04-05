<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddMenuWUC.ascx.cs" Inherits="IELWEB.Roles.UserControls.AddMenuWUC" %>
<div class="modal-body box box-primary">

    
    <div class="form-group">
        <label>NOMBRE MENÚ</label>
    <div class="input-group">
        <span class="input-group-addon"><span class="fa fa-list-alt"></span></span>
        <asp:TextBox ID="txtNombreMenu" runat="server" CssClass="form-control" placeholder="Nombre Menu"></asp:TextBox>
         <span class="input-group-addon">ID:</span>
        <asp:TextBox ID="txtIDMenu" runat="server" CssClass="form-control" placeholder="ID MENU" Enabled="false"></asp:TextBox>
    </div>
     </div>

    <div class="form-group">
              <label>TIPO DE OBJETO</label>
        <div class="input-group">
            <span class="input-group-addon"><span class="fa fa-clipboard"></span></span>
            <asp:TextBox ID="txtTipoObjeto" runat="server" CssClass="form-control"  placeholder="Tipo Objeto"></asp:TextBox>
        </div>
    </div>
    <div class="form-group">
              <label>URL</label>
        <div class="input-group">
            <span class="input-group-addon"><span class="fa fa-link"></span></span>
            <asp:TextBox ID="txtUrl" runat="server" CssClass="form-control" placeholder="Ruta"></asp:TextBox>
        </div>
    </div>
    <div class="form-group">
              <label>IMAGEN</label>
        <div class="input-group">
            <span class="input-group-addon"><span class="fa fa-image"></span></span>
            <asp:TextBox ID="txtImagen" runat="server" CssClass="form-control" placeholder="Imagen"></asp:TextBox>
        </div>
    </div>
    <div class="form-group">
              <label>ORDEN DEL MENÚ</label>
        <div class="input-group">
            <span class="input-group-addon"><span class="fa fa-list-ol"></span></span>
            <asp:TextBox ID="txtOrdenMenu" runat="server" CssClass="form-control" placeholder="Orden del Menu"></asp:TextBox>
        </div>
    </div>
    <div class="form-group">
              <label>TEXTO DEL TOOLTIP</label>
        <div class="input-group">
            <span class="input-group-addon"><span class="fa fa-comment"></span></span>
            <asp:TextBox ID="txtToolTip" runat="server" CssClass="form-control" placeholder="Tooltip"></asp:TextBox>
        </div>
    </div>

     <div class="form-group">
              <label>ACTIVO</label>
        <div class="input-group">
            <span class="input-group-addon"><span class="fa fa-comment"></span></span>
           <asp:CheckBox ID="chkActivo" runat="server" Text="ACTIVO" />
        </div>
    </div>
</div>
