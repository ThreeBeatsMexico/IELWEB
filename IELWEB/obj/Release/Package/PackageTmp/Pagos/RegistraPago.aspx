<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistraPago.aspx.cs" Inherits="IELWEB.Pagos.RegistraPago" Theme="IELSkin" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>REGISTRA PAGO</title>
    
    <link href="../STYLES/supertabla.css" rel="stylesheet" />
 </head>


 
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    
    </telerik:RadScriptManager>
        <telerik:RadAjaxManager ID="RadAjaxManagerX" runat="server"></telerik:RadAjaxManager>
        <telerik:RadScriptBlock ID="RadScriptBlock1"  runat="server">
         <script type="text/javascript">
             function refreshGrid() {
                 //alert("entra despues de alert");
                 var windowrefresh = window.parent;
                 var win = windowrefresh.refreshGrid()
                 this.close();
               
             }
             function openWin(URL, Token, Window) {
                 
                
                 radopen(URL + "?Token=" + Token, Window);
                 owd.show();
                 owd.maximize();
             }

             
              </script>
     </telerik:RadScriptBlock>

      <div id="content">

        <asp:Panel  runat="server" ID="pnlGenerales" Width="100%" Height="100%"> 
 <div class="sidebarheader"><asp:label id="lblConcepto" runat="server"></asp:label></div>


 <table id="tblPago" runat="server" style="width: 98%;" border="0" cellpadding="0" cellspacing="15" class="roundedPanel">
<tbody>
   <tr>               
       <td>MONTO:<br /><telerik:RadTextBox ID="txtMonto"  Width="100px" runat="server"></telerik:RadTextBox></td>
       <td>MEDIO DE PAGO:<br />  <telerik:RadComboBox ID="rcMedioPago" runat="server" EmptyMessage="Medio de Pago" EnableEmbeddedSkins="false" Skin="IELSkin" Width="200px">
                                         <Items>
                                           <telerik:RadComboBoxItem Text="EFECTIVO" Value="1" />
                                             <telerik:RadComboBoxItem Text="CHEQUE" Value="2" />
                                             <telerik:RadComboBoxItem Text="TRANFERENCIA" Value="3" />
                                             <telerik:RadComboBoxItem Text="DEPOSITO" Value="4" />
                                             <telerik:RadComboBoxItem Text="OTRO" Value="5" />
                                             
                                         </Items>
                                     </telerik:RadComboBox></td> 
        <td>REFERENCIA:<br /><telerik:RadTextBox ID="txtReferencia" Width="150px" runat="server" ></telerik:RadTextBox></td>  

        <td>TIPO DE PAGO:<br />  <asp:radiobuttonlist id="rbTipoPago" runat="server" RepeatDirection="Horizontal" >
                 <asp:ListItem Text="ABONO" Value="2" Selected="True"></asp:ListItem>
                 <asp:ListItem Text="FINAL" Value="1"></asp:ListItem>
             </asp:radiobuttonlist></td>  

       <td align="center">REGISTRAR<br />
				<telerik:RadButton ID="btnRegistrar" runat="server" EnableEmbeddedSkins="false" Height="33px"  OnClick="btnRegistrar_Click" Skin="IELSkin" ToolTip="Registrar" Width="33px">
				<Image ImageUrl="../IMAGES/accept.png" IsBackgroundImage="true"   />
                    
                                             </telerik:RadButton>
				<asp:Label ID="lblMensaje" runat="server" style="font-size:12px; font-family:Calibri; color:Red"></asp:Label>
			</td>


   </tr>

   

    </tbody>
     </table>
            </asp:Panel>
          </div>
          <div style="width:100%;">
    <div style="height: 36px; background-image: url('../Images/boxdatos.png'); background-repeat: repeat-x; width:98%; text-align:right">
         
        </div>
        </div>

       <telerik:RadWindowManager ID="RadWindowManager3" EnableEmbeddedSkins="false"  CenterIfModal="false" Top="5" Left="20"  runat="server" Skin="IELSkin" Localization-Cancel="Salir" Modal="False">
          <Windows>
       <telerik:RadWindow ID="RadWindow4" runat="server" Width="860" Height="500" Behaviors="Resize,  Close, Maximize, Move"
                ShowContentDuringLoad="true" EnableEmbeddedSkins="false" Skin="IELSkin" Modal="true" VisibleStatusbar="False">
            </telerik:RadWindow>
               <telerik:RadWindow ID="RadWindow1" runat="server" Width="200" Height="200" Behaviors="Resize, Close, Maximize, Move"
                ShowContentDuringLoad="true" EnableEmbeddedSkins="false" Skin="IELSkin" VisibleStatusbar="False">
            </telerik:RadWindow>
            <telerik:RadWindow ID="RadWindow2" runat="server" Width="400" Height="200" Behaviors="Resize, Close, Maximize, Move"
                ShowContentDuringLoad="true" EnableEmbeddedSkins="false" Skin="IELSkin" VisibleStatusbar="False">
            </telerik:RadWindow>
              </Windows>
    </telerik:RadWindowManager>   
    </form>
   
</body>
</html>

