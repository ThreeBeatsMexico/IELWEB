<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PagosLista.aspx.cs" Inherits="IELWEB.Pagos.PagosLista" Theme="IELSkin" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head" runat="server">
    <title></title>
     <link href="../STYLES/supertabla.css" rel="stylesheet" />
    <script type="text/javascript" language="javascript">
        function openWin(URL, Token, Titulo, Window) {
            var owd = window.$find(Window);
            owd.set_title(Titulo);
            radopen(URL + "?Token=" + Token, Window);
            owd.show();
            //owd.maximize();
        }
        function openWin2(URL, Titulo, Window) {
            var owd = window.$find(Window);
            owd.set_title(Titulo);
            radopen(URL, Window);
        }

        function openPrint(URL, Token, Titulo) {

            var xn = window.open(URL + "?Token=" + Token, Titulo, "top=0,left=0width=700,height=550,resizable=yes,scrollbars=yes");
            xn.focus();

        }
    </script>
    
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
          
    <telerik:RadCodeBlock runat="server" ID="RadCodeBlock1">
        <script type="text/javascript">
            function setTabStrip(PanelID, Url, Token) {
                var splitterPageWnd = window.parent;
                var splitterObject = splitterPageWnd.setTabStrip(PanelID, Url, Token);
            }

            function refreshGrid() {
               
                $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("RG");
            }
        </script>
    </telerik:RadCodeBlock>

     <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" OnAjaxRequest="manager_AjaxRequest" >
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadGrid1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="RadAjaxLoadingPanel1">
                    </telerik:AjaxUpdatedControl>
                    
                </UpdatedControls>
            </telerik:AjaxSetting>
            
        </AjaxSettings>
        </telerik:RadAjaxManager>
        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
        </telerik:RadAjaxLoadingPanel>

 
 
<telerik:RadAjaxPanel ID="radajaxpanel1" runat="server">

 <div  class="sidebarheader">PAGOS DEL ALUMNO<br /><asp:Label ID="lblAlumnoInfo" runat="server"></asp:Label></div>


 <table style="width: 98%;" border="0" cellpadding="0" cellspacing="15" class="roundedPanel">
<tbody>

    <tr>
        <td>
           
               <telerik:RadGrid runat="server" ID="RadGrid1" CellSpacing="0" EnableEmbeddedSkins="False"  OnSortCommand="RadGrid1_SortCommand" 
            GridLines="None" Skin="IELSkin" style="margin-top: 0px" Width="100%" AutoGenerateColumns="False" OnItemDataBound="RadGrid1_ItemDataBound"  OnDetailTableDataBind="RadGrid1_DetailTableDataBind" onitemcommand="RadGrid1_ItemCommand" >
         
            <MasterTableView DataKeyNames="psIDPago,psIDAlumno,psEstado"   Name="Master" >
                <Columns>
                    <telerik:GridButtonColumn ButtonType="ImageButton"   CommandName="RegistrarPago" ImageUrl="../IMAGES/registrapago.png"  Text="REGISTRAR PAGO" UniqueName="RegistraPago" ItemStyle-Width="10px">
                     <ItemStyle Width="10px" />
                     </telerik:GridButtonColumn>
                    <telerik:GridBoundColumn HeaderStyle-HorizontalAlign="Center" Visible="false" ItemStyle-BackColor="#bfd7e1" ItemStyle-Font-Bold="true" 
                        HeaderStyle-Width="10px" HeaderText="ID" UniqueName="ID" DataField="psIDPago">
                        <HeaderStyle HorizontalAlign="Center" Width="10px" />
                    </telerik:GridBoundColumn>
                     <telerik:GridBoundColumn HeaderStyle-HorizontalAlign="Center" 
                        HeaderStyle-Width="90px"  HeaderText="CONCEPTO" UniqueName="CONCEPTO" DataField="psConcepto">
                        <HeaderStyle HorizontalAlign="Center" Width="90px" />
                    </telerik:GridBoundColumn>
                     <telerik:GridBoundColumn HeaderStyle-HorizontalAlign="Center" 
                        HeaderStyle-Width="40px"  HeaderText="ESTATUS" UniqueName="ESTATUS" DataField="psEstado">
                        <HeaderStyle HorizontalAlign="Center" Width="40px" />
                    </telerik:GridBoundColumn>
                     
                </Columns>
                <DetailTables>
                                       <telerik:GridTableView DataKeyNames="psIDPago"  Name="Pagos" AutoGenerateColumns="false">   
                                      <Columns>
                                        <telerik:GridBoundColumn HeaderText="FECHA" DataField="psFechaTransaccion" 
                                            HeaderStyle-Width="20px" HeaderStyle-HorizontalAlign="Center" UniqueName="psFechaTransaccion">
                                        <HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
                                        </telerik:GridBoundColumn>
                                          <telerik:GridBoundColumn HeaderText="CONCEPTO" DataField="psConcepto" 
                                            HeaderStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" UniqueName="psConcepto">
                                        <HeaderStyle HorizontalAlign="Center" Width="200px"></HeaderStyle>
                                        </telerik:GridBoundColumn>
                                          <telerik:GridBoundColumn HeaderText="MONTO" DataField="psMonto" 
                                            HeaderStyle-Width="30px" HeaderStyle-HorizontalAlign="Center" UniqueName="psMonto">
                                        <HeaderStyle HorizontalAlign="Center" Width="30px"></HeaderStyle>
                                        </telerik:GridBoundColumn>
                                           <telerik:GridBoundColumn HeaderText="MEDIO PAGO" DataField="psFormaPago" 
                                            HeaderStyle-Width="60px" HeaderStyle-HorizontalAlign="Center" UniqueName="psFormaPago">
                                        <HeaderStyle HorizontalAlign="Center" Width="60px"></HeaderStyle>
                                        </telerik:GridBoundColumn>
                                           <telerik:GridBoundColumn HeaderText="REFERENCIA" DataField="psReferencia" 
                                            HeaderStyle-Width="60px" HeaderStyle-HorizontalAlign="Center" UniqueName="psReferencia">
                                        <HeaderStyle HorizontalAlign="Center" Width="60px"></HeaderStyle>
                                        </telerik:GridBoundColumn>
                                      </Columns>
                                   </telerik:GridTableView>
                                    </DetailTables>
            </MasterTableView>
            <PagerStyle AlwaysVisible="true" Mode="NextPrev" />
            <HeaderStyle Font-Size="8pt"  />
            <ItemStyle Font-Size="8pt"  HorizontalAlign="Center" />
        </telerik:RadGrid>








        
      
      </td>
    </tr>
 
</tbody></table>
                                                                                            
</telerik:RadAjaxPanel>
<div style="height: 37px; background-image: url('../Images/boxdatos.png'); background-repeat: repeat-x; width:98%; text-align:right">
          <telerik:RadButton ID="btnNuevo" runat="server" EnableEmbeddedSkins="false" Height="33px"  OnClick="btnNuevo_Click" Skin="IELSkin" ToolTip="IMPRIMIR RECIBO" Width="33px">
				<Image ImageUrl="../IMAGES/Recibo.png" IsBackgroundImage="true"   />
                    
                                             </telerik:RadButton>
        </div>


         <telerik:RadWindowManager ID="RadWindowManager1"   EnableEmbeddedSkins="false" Skin="IELSkin" Top="10" Left="25" runat="server" CenterIfModal="false"  Modal="True">
        <Windows>
            <telerik:RadWindow ID="RadWindowPago" runat="server"  Width="800" Height="200"  Behaviors="Close, Move"
                ShowContentDuringLoad="true" EnableEmbeddedSkins="false" Skin="IELSkin" VisibleStatusbar="False">
            </telerik:RadWindow>
            <telerik:RadWindow ID="RadWindow2" runat="server" Width="800" Height="600" Behaviors="Resize, Close, Maximize, Move"
                ShowContentDuringLoad="true" EnableEmbeddedSkins="false" Skin="IELSkin" VisibleStatusbar="False">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
   
      </form>
   

  </body>
 </html>
