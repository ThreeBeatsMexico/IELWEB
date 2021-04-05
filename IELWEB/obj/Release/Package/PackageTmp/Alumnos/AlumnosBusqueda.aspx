<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AlumnosBusqueda.aspx.cs" Inherits="IELWEB.Alumnos.AlumnosBusqueda" Theme="IELSkin" %>
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
		<tr><td class="sidebarheader_lat">NOMBRE</td></tr>
		<tr>
	        <td class="tb_sidebarheader">
    			<telerik:RadTextBox ID="txtNombre" runat="server" EmptyMessage="Nombre" EmptyMessageStyle-Font-Italic="true" EnableEmbeddedSkins="false" Height="20px" Skin="IELSkin" Width="170px">
                </telerik:RadTextBox>
            </td>
	    </tr>
        <tr><td class="sidebarheader_lat">APELLIDO PATERNO</td></tr>
		<tr>
			<td class="tb_sidebarheader">
		    	<telerik:RadTextBox ID="txtAPaterno" runat="server" EmptyMessage="Apellido Paterno..." EmptyMessageStyle-Font-Italic="true" EnableEmbeddedSkins="false" Height="20px" Skin="IELSkin" Width="170px">
        	  </telerik:RadTextBox>
			</td>
		</tr>
         <tr><td class="sidebarheader_lat">APELLIDO MATERNO</td></tr>
		<tr>
			<td class="tb_sidebarheader">
		    	<telerik:RadTextBox ID="txtAMaterno" runat="server" EmptyMessage="Apellido Materno.." EmptyMessageStyle-Font-Italic="true" EnableEmbeddedSkins="false" Height="20px" Skin="IELSkin" Width="170px">
        	  </telerik:RadTextBox>
			</td>
		</tr>
		
		<tr><td class="sidebarheader_lat">FECHA DE EMISION</td></tr>
		<tr>
			<td class="tb_sidebarheader">
				<telerik:RadDatePicker ID="FechaNacimiento" Runat="server" PopupDirection="TopLeft"  EnableEmbeddedSkins="false"  Skin="IELSkin">
                                             <Calendar    EnableEmbeddedSkins="false" EnableWeekends="True" Skin="IELSkin" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False">
                                             </Calendar>
                                             <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" EmptyMessage="Fecha Nacimiento ..." Height="20px" LabelWidth="40%">
                                                 <EmptyMessageStyle Resize="None" />
                                                 <ReadOnlyStyle Resize="None" />
                                                 <FocusedStyle Resize="None" />
                                                 <DisabledStyle Resize="None" />
                                                 <InvalidStyle Resize="None" />
                                                 <HoveredStyle Resize="None" />
                                                 <EnabledStyle Resize="None" />
                                             </DateInput>
                                             <DatePopupButton HoverImageUrl="../IMAGES/Calendar.png" ImageUrl="../IMAGES/Calendar.png" />
                                         </telerik:RadDatePicker>
			</td>
		</tr>
        <tr><td class="sidebarheader_lat">ESTATUS</td></tr>
		<tr>
			<td class="tb_sidebarheader">
				<telerik:RadComboBox ID="ddlEstatus" runat="server"  AutoPostBack="true" EmptyMessage="Estatus" EnableEmbeddedSkins="false" Skin="IELSkin" >
                                         <Items>
                                             <telerik:RadComboBoxItem Text="TODOS" Selected="true" Value="-1" />
                                             <telerik:RadComboBoxItem Text="INSCRITOS" Value="1" />
                                             <telerik:RadComboBoxItem Text="SUSPENDIDOS" Value="0" />
                                         </Items>
                                     </telerik:RadComboBox>
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