<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PagosBusqueda.aspx.cs" Inherits="IELWEB.Pagos.PagosBusqueda" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    
    <link href="../STYLES/supertabla.css" rel="stylesheet" />
 </head>

   <script language="javascript" type="text/javascript">
       function setUrl(PanelID, Url, Token) {
           var splitterPageWnd = window.parent;
           var splitterObject = splitterPageWnd.setUrl(PanelID, Url, Token);
       }

       function setTabStrip(PanelID, Url, Token) {
           var splitterPageWnd = window.parent;
           var splitterObject = splitterPageWnd.setTabStrip(PanelID, Url, Token);
       }

    </script>
 
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    
    </telerik:RadScriptManager>
     <div style="height:100%" >
          <asp:Panel ID="BusquedaPane" runat="server"  ShowContentDuringLoad="false" CssClass="outerMultiPage"  Height="700px" >
             
	<table border="0" width="100%" cellpadding="0" cellspacing="0">
      
		<tr><td class="sidebarheader_lat">MATRICULA</td></tr>
        <tr>
        	<td class="tb_sidebarheader">
	            <telerik:RadTextBox ID="txtMatricula" runat="server" EmptyMessage="Numero Matricula" EmptyMessageStyle-Font-Italic="true" EnableEmbeddedSkins="false" Height="20px" Skin="IELSkin" Width="170px">
               </telerik:RadTextBox>
	       </td>
		</tr>
		
		
        <tr><td class="sidebarheader_lat">BUSCAR</td></tr>
		<tr>
			<td align="center"><br /><br />
				<telerik:RadButton ID="RadButton1" runat="server" EnableEmbeddedSkins="false" Height="33px"  OnClick="btnBuscar_Click" Skin="IELSkin" ToolTip="Buscar" Width="33px">
				<Image ImageUrl="../IMAGES/buscar.png" IsBackgroundImage="true"   />
                    
                                             </telerik:RadButton>
				<asp:Label ID="lblMensaje" runat="server" style="font-size:12px; font-family:Calibri; color:Red"></asp:Label>
			</td>
		</tr>
</table>
     
              </asp:Panel>
    </div>
     
    </form>
   
</body>
</html>