<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MensajeWUC.ascx.cs" Inherits="IELWEB.Common.UserControls.MensajeWUC" %>
<div id="mdlModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="addModalLabel" aria-hidden="true">
    <div runat="server" id="divModal">
        <div class="modal-content">
            <asp:UpdatePanel ID="upAdd" runat="server">
                <ContentTemplate>
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h4 class="modal-title"><span runat="server" id="imgTituloModal"></span>
                            <asp:Label ID="lblTituloModal" runat="server" Text="Label"></asp:Label>
                        </h4>
                    </div>
                    <div class="modal-body">
                        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                    </div>
                    <div class="modal-footer clearfix">
                    </div>
                </ContentTemplate>
                <Triggers>
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
</div>
<!-- /.content -->
