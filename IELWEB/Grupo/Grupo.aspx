<%@ Page Title="" Theme="IELSkin" Language="C#" MasterPageFile="~/Startup/App.master" AutoEventWireup="true" CodeBehind="Grupo.aspx.cs" Inherits="IELWEB.Grupo.Grupo" Theme="IELSkin" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPagina" runat="server">
      <telerik:RadScriptBlock ID="RadScriptBlock1"  runat="server">
         <script type="text/javascript">
             function refreshGrid() {
                 $find("<%= RadAjaxManager.GetCurrent(Page).ClientID %>").ajaxRequest("RG");
             }
              </script>
     </telerik:RadScriptBlock>
    
    <div id="content">

        <asp:Panel  runat="server" ID="pnlGenerales" Width="100%" Height="100%"> 
 <div class="sidebarheader">GRUPO</div>


 <table id="tblCiclo" runat="server" style="width: 98%;" border="0" cellpadding="0" cellspacing="15" class="roundedPanel">
<tbody>
   <tr>               
       <td>NIVEL ACADEMICO:<br /><telerik:RadComboBox ID="rcNivelAcademico" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rcNivelAcademico_SelectedIndexChanged"  EmptyMessage="Nivel Academico" EnableEmbeddedSkins="false" Skin="IELSkin" Width="170px">
                                         <Items>
                                             <telerik:RadComboBoxItem Text="KINDER" Value="0" />
                                             <telerik:RadComboBoxItem Text="PRIMARIA" Value="1" />
                                         </Items>
                                     </telerik:RadComboBox>
           <asp:RequiredFieldValidator ControlToValidate="rcNivelAcademico" ErrorMessage="Falta Nivel Academico" Text="*" ValidationGroup="vgGrupo" runat="server" Font-Size="Larger" ForeColor="Blue"/></td>

        <td>Ciclo:<br /><telerik:RadComboBox ID="rcCiclo" runat="server" EmptyMessage="Ciclo" EnableEmbeddedSkins="false" Skin="IELSkin" AutoPostBack="false" Width="170px">
                                       
                                     </telerik:RadComboBox>
                 <asp:RequiredFieldValidator ControlToValidate="rcCiclo" ErrorMessage="Falta Ciclo" Text="*" ValidationGroup="vgGrupo" runat="server" Font-Size="Larger" ForeColor="Blue"/></td>

   <td>Grado:<br /><telerik:RadComboBox ID="rcGrado" runat="server" EmptyMessage="Grado" EnableEmbeddedSkins="false" Skin="IELSkin" Width="170px">
                                        
                                     </telerik:RadComboBox>
                 <asp:RequiredFieldValidator ControlToValidate="rcGrado" ErrorMessage="Falta Grado" Text="*" ValidationGroup="vgGrupo" runat="server" Font-Size="Larger" ForeColor="Blue"/></td>

    <td>Grupo:<telerik:RadTextBox ID="txtIDGrupo" runat="server" Style="visibility:hidden"></telerik:RadTextBox><br /> 
       <telerik:RadComboBox ID="rcGrupo" runat="server" EmptyMessage="Grupo" EnableEmbeddedSkins="false" Skin="IELSkin" Width="170px">
                                         <Items>
                                           <telerik:RadComboBoxItem Text="A" Value="A" />
                                             <telerik:RadComboBoxItem Text="B" Value="B" />
                                             <telerik:RadComboBoxItem Text="C" Value="C" />
                                             <telerik:RadComboBoxItem Text="D" Value="D" />
                                             <telerik:RadComboBoxItem Text="E" Value="E" />
                                             
                                         </Items>
                                     </telerik:RadComboBox>
                 <asp:RequiredFieldValidator ControlToValidate="rcGrupo" ErrorMessage="Falta Grado" Text="*" ValidationGroup="vgGrupo" runat="server" Font-Size="Larger" ForeColor="Blue"/></td>  </tr>

   

    </tbody>
     </table>

             <div style="height: 4%; background-image: url('../Images/boxdatos.png'); background-repeat: repeat-x; width:98%; text-align:right">
         <table style="width: 98%;" border="0" cellpadding="0" cellspacing="15">
<tbody>

      <tr> 
          <td >  <asp:Label runat="server" ID="Label2" ForeColor="White"> </asp:Label> </td>
          <td > <telerik:RadButton ID="btnGuardar" runat="server" ValidationGroup="vgCiclo" EnableEmbeddedSkins="false" Height="33px"  OnClick="btnGrabar_Click" Skin="IELSkin" ToolTip="GUARDAR" Width="33px">
				<Image ImageUrl="../IMAGES/Guardar.png" IsBackgroundImage="true"/></telerik:RadButton></td>
          <td > <telerik:RadButton ID="RadButton1" runat="server" EnableEmbeddedSkins="false" Height="33px"  OnClick="btnCancelar_Click" Skin="IELSkin" ToolTip="CANCELAR" Width="33px">
				<Image ImageUrl="../IMAGES/Cancelar.png" IsBackgroundImage="true"/></telerik:RadButton></td>

          </tr>
    
    </tbody>
     </table>
        </div>
            </asp:Panel>

         <asp:ValidationSummary
ShowMessageBox="true"
ShowSummary="false"
HeaderText="Algunos campos son obligatorios, favor de validar:"
EnableClientScript="true"
runat="server"/>


         <telerik:RadWindowManager ID="RadWindowManager1" EnableEmbeddedSkins="false"  CenterIfModal="false" Top="20" Left="20"  runat="server" Skin="IELSkin" Localization-Cancel="Salir" Modal="False">
          <Windows>
       <telerik:RadWindow ID="RadWindow4" runat="server" Width="860" Height="500" Behaviors="Resize,  Close, Maximize, Move"
                ShowContentDuringLoad="true" EnableEmbeddedSkins="false" Skin="IELSkin" Modal="true" VisibleStatusbar="False">
            </telerik:RadWindow>
              </Windows>
    </telerik:RadWindowManager>
    

        

</asp:Content>

