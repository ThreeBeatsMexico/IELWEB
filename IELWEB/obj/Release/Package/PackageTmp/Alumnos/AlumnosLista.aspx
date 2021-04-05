<%@ Page Title=""  Language="C#" AutoEventWireup="true" CodeBehind="AlumnosLista.aspx.cs" Inherits="IELWEB.Alumnos.AlumnosLista" Theme="IELSkin" %>

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
            owd.maximize();
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
        </script>
    </telerik:RadCodeBlock>

     <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" >
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

 
 


 <div  class="sidebarheader">A L U M N O S</div>


 <table style="width: 98%;" border="0" cellpadding="0" cellspacing="15" class="roundedPanel">
<tbody>

    <tr>
        <td>
           
              <telerik:RadGrid runat="server" ID="RadGrid1" CellSpacing="0" EnableEmbeddedSkins="False" AllowMultiRowSelection="true"  onpageindexchanged="RadGrid1_PageIndexChanged"
              onpagesizechanged="RadGrid1_PageSizeChanged" onsortcommand="RadGrid1_SortCommand" gridlines="None" Skin="IELSkin" style="margin-top: 0px" Width="100%" AutoGenerateColumns="False" onitemcommand="RadGrid1_ItemCommand" >
                   <ClientSettings>
                                     <Scrolling AllowScroll="false" />
                                    <Selecting AllowRowSelect="true" />
                                </ClientSettings>
          <AlternatingItemStyle Font-Size="8pt" HorizontalAlign="Center"/>
            <MasterTableView DataKeyNames="sIdAlumno,sNumeroMatricula">
                <Columns>
                 <telerik:GridClientSelectColumn UniqueName="ClientSelectColumn">
                     <ItemStyle Width="5px" HorizontalAlign="Center" />
                </telerik:GridClientSelectColumn>
                    <telerik:GridButtonColumn ButtonType="ImageButton"   CommandName="VerFicha" ImageUrl="../IMAGES/imgFichaAlumno.png"  Text="VER FICHA" UniqueName="VerFicha" ItemStyle-Width="10px">
                     <ItemStyle Width="10px" />
                     </telerik:GridButtonColumn>
                    <telerik:GridBoundColumn HeaderStyle-HorizontalAlign="Center" ItemStyle-BackColor="#bfd7e1" ItemStyle-Font-Bold="true" 
                        HeaderStyle-Width="90px" HeaderText="MATRICULA" UniqueName="MATRICULA" DataField="sNumeroMatricula">
                        <HeaderStyle HorizontalAlign="Center" Width="90px" />
                    </telerik:GridBoundColumn>
                     <telerik:GridBoundColumn HeaderStyle-HorizontalAlign="Center" 
                        HeaderStyle-Width="40px"  HeaderText="NOMBRE" UniqueName="NOMBRE" DataField="sNOMBRES">
                        <HeaderStyle HorizontalAlign="Center" Width="40px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn HeaderStyle-HorizontalAlign="Center" 
                        HeaderStyle-Width="90px" HeaderText="PATERNO" UniqueName="PATERNO" DataField="sAPaterno">
                        <HeaderStyle HorizontalAlign="Center" Width="90px" />
                    </telerik:GridBoundColumn>
                     <telerik:GridBoundColumn HeaderStyle-HorizontalAlign="Center"  
                   HeaderStyle-Width="100px" HeaderText="MATERNO" UniqueName="MATERNO"  DataField="sAMaterno" >
                        <HeaderStyle HorizontalAlign="Center" Width="100px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn HeaderStyle-HorizontalAlign="Center" 
                        HeaderStyle-Width="90px" HeaderText="F NACIMIENTO" UniqueName="FNACIMIENTO" DataField="sFechaNacimiento" >
                        <HeaderStyle HorizontalAlign="Center" Width="90px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn HeaderStyle-HorizontalAlign="Center" 
                        HeaderStyle-Width="90px" HeaderText="ESTADO" UniqueName="ESTADO" DataField="sEstado" >
                        <HeaderStyle HorizontalAlign="Center" Width="90px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridButtonColumn ButtonType="ImageButton"   CommandName="EditaAlumno" ImageUrl="../IMAGES/imgEditaAlumno.png"  Text="EDITAR ALUMNO" UniqueName="EditaAlumno" ItemStyle-Width="10px">
                     <ItemStyle Width="10px" />
                     </telerik:GridButtonColumn>
                     <telerik:GridButtonColumn ButtonType="ImageButton"   CommandName="generaCredencial" ImageUrl="../IMAGES/generaCred.png"  Text="CREDENCIAL" UniqueName="generaCredencial" ItemStyle-Width="10px">
                     <ItemStyle Width="10px" />
                     </telerik:GridButtonColumn>
                   <%-- <telerik:GridButtonColumn ButtonType="ImageButton"   CommandName="EliminaAlumno" ImageUrl="../IMAGES/imgDelAlumno.png"  Text="ELIMINAR ALUMNO" UniqueName="EliminaAlumno" ItemStyle-Width="10px">
                     <ItemStyle Width="10px" />
                     </telerik:GridButtonColumn>--%>
                   
                   
                     
                </Columns>
            </MasterTableView>
            <PagerStyle Mode="Slider" AlwaysVisible="true" PagerTextFormat="{4} Pagina {0} de {1}, registros {2} al {3} de {5}"/>
				
				<ClientSettings>
				     <ClientMessages PagerTooltipFormatString="Pagina {0} de {1}" />
                </ClientSettings>
                                <HeaderStyle Font-Size="8pt" Height="8" />
                                <ItemStyle Font-Size="8pt" HorizontalAlign="Center" />
            </telerik:RadGrid>








        
      
      </td>
    </tr>
 
</tbody></table>
                                                                                            

<div style="height: 37px; background-image: url('../Images/boxdatos.png'); background-repeat: repeat-x; width:98%; text-align:right">
    <table><tr align="right">
        <td>
<telerik:RadButton ID="btnNuevo" runat="server" EnableEmbeddedSkins="false" Height="33px"  OnClick="btnNuevo_Click" Skin="IELSkin" ToolTip="NUEVO ALUMNO" Width="33px">
				<Image ImageUrl="../IMAGES/NuevoAlumno.png" IsBackgroundImage="true"   />
                    
                                             </telerik:RadButton>
        </td>
        <td>
 <telerik:RadButton ID="btnImprimeCredenciales" runat="server" EnableEmbeddedSkins="false" Height="33px"  OnClick="btnImprimeCredenciales_Click" Skin="IELSkin" ToolTip="GENERA CREDENCIALES" Width="33px">
				<Image ImageUrl="../IMAGES/credencial.png" IsBackgroundImage="true"   />
                    
                                             </telerik:RadButton>
        </td>
           </tr></table>
          

    
        </div>


         <telerik:RadWindowManager ID="RadWindowManager1"  EnableEmbeddedSkins="false" Skin="IELSkin" runat="server" Modal="True">
        <Windows>
            <telerik:RadWindow ID="RadWindow1" runat="server" Width="400" Height="200" Behaviors="Resize, Close, Maximize, Move"
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