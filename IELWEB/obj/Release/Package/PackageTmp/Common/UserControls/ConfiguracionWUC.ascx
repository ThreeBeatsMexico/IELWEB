<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ConfiguracionWUC.ascx.cs" Inherits="IELWEB.Common.UserControls.ConfiguracionWUC" %>
<div class="modal-body">
    <div class="form-group">
        <div class="input-group">
              <span class="input-group-addon">ID:</span>
            <asp:TextBox ID="txtIdConfiguracion" runat="server" CssClass="form-control" placeholder="ID" Enabled ="False"></asp:TextBox>
            <span class="input-group-addon">Descipción:</span>
            <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" placeholder="Descripción"></asp:TextBox>
             <span class="input-group-addon">Activo:</span>
            <asp:CheckBox ID="chkActivo" runat="server" CssClass="form-control" />
        </div>
    </div>
    <div class="form-group">
        <div class="input-group">
            <span class="input-group-addon">Valor:</span>
            <asp:TextBox ID="txtValor" runat="server" CssClass="form-control" placeholder="Valor de configuración" TextMode="MultiLine"></asp:TextBox>
        </div>
    </div>
</div>
