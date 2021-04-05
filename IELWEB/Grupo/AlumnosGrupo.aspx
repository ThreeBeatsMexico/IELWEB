<%@ Page Title=""  Language="C#" MasterPageFile="~/Startup/App.master" AutoEventWireup="true" CodeBehind="AlumnosGrupo.aspx.cs" Inherits="IELWEB.Grupo.AlumnosGrupo" Theme="IELSkin" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPagina" runat="server">

  
     <telerik:RadAjaxManagerProxy ID="AjaxManagerProxy1" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="btnAgregaAlumnoGrupo">
            <UpdatedControls>
                 <telerik:AjaxUpdatedControl ControlID="rcAlumno" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        </AjaxSettings>
        </telerik:RadAjaxManagerProxy>

    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default" />
   
   <telerik:RadScriptBlock ID="RadScriptBlock1"  runat="server">
         <script type="text/javascript">
             function refreshGrid() {
                 $find("<%= RadAjaxManager.GetCurrent(Page).ClientID %>").ajaxRequest("RG");
             }
             function openWin(URL, Token, Window) {
                 
                
                 radopen(URL + "?Token=" + Token, Window);
                 owd.show();
                 owd.maximize();
             }
              </script>
     </telerik:RadScriptBlock>


     <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>Administración
            <small>Grupos</small>
            </h1>
            <ol class="breadcrumb">
                <li><a href="/Startup/Inicio.aspx"><i class="fa fa-dashboard"></i>Inicio</a></li>
                <li class="active">Grupos
                </li>
            </ol>
        </section>
        <section class="content">
            <div class="box box-primary">
                <div class="box-header with-border">
                    <h3 class="box-title">Grupos</h3>
                    <div class="box-tools pull-right">
                        <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    </div>
                </div>
                <div class="box-body">




      <div class="sidebarheader">BUSCAR ALUMNO</div>


 <table id="tblAgregaAlumnoGrupo" runat="server" style="width: 98%;" border="0" cellpadding="0" cellspacing="15" class="roundedPanel">
<tbody>
   <tr>               
       <td> <telerik:RadComboBox ID="rcAlumno" runat="server" AutoPostBack="false" 
                EmptyMessage="Introduce el alumno a buscar..." Filter="Contains" AllowCustomText="true"  EnableLoadOnDemand="true" EnableEmbeddedSkins="false" Width="100%" Skin="IELSkin">
                <Items>
                    
                </Items>
            </telerik:RadComboBox>
       </td>
       <td>
<telerik:RadButton ID="btnAgregaAlumnoGrupo" runat="server" EnableEmbeddedSkins="false" Height="33px"  OnClick="btnAgregaAlumno_Click" Skin="IELSkin" ToolTip="AGREGAR ALUMNO" Width="33px">
				<Image ImageUrl="../IMAGES/NuevoAlumno.png" IsBackgroundImage="true"/></telerik:RadButton>

       </td>
       </tr>
    <br />

    </tbody>
   
     </table>
    
    
     <div  class="sidebarheader">ALUMNOS DEL GRUPO <asp:Label ID="lblGrupoInfo" runat="server"></asp:Label></div>
 
 <table style="width: 98%;" border="0" cellpadding="0" cellspacing="15" class="roundedPanel">
<tbody>

    <tr>
        <td>
           
    
              <telerik:RadGrid runat="server" ID="RadGrid1" CellSpacing="0" EnableEmbeddedSkins="False" 
            GridLines="None" Skin="IELSkin" style="margin-top: 0px" Width="100%" AutoGenerateColumns="False" onitemcommand="RadGrid1_ItemCommand" >
          <AlternatingItemStyle Font-Size="8pt" HorizontalAlign="Center"/>
            <MasterTableView DataKeyNames="sIdAlumno,sNumeroMatricula">
                <Columns>
                    <%--<telerik:GridButtonColumn ButtonType="ImageButton"   CommandName="VerPagos" ImageUrl="../IMAGES/imgFichaAlumno.png"  Text="VER PAGOS" UniqueName="VerPagos" ItemStyle-Width="10px">
                     <ItemStyle Width="10px" />
                     </telerik:GridButtonColumn>--%>
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
                   
                  <%--  <telerik:GridButtonColumn ButtonType="ImageButton"   CommandName="EditaAlumno" ImageUrl="../IMAGES/imgEditaAlumno.png"  Text="EDITAR ALUMNO" UniqueName="EditaAlumno" ItemStyle-Width="10px">
                     <ItemStyle Width="10px" />
                     </telerik:GridButtonColumn>--%>
                   <telerik:GridButtonColumn ButtonType="ImageButton"   CommandName="VerPagos" ImageUrl="../IMAGES/pagos.png"  Text="VER PAGOS" UniqueName="VerPagos" ItemStyle-Width="10px">
                     <ItemStyle Width="10px" />
                     </telerik:GridButtonColumn>
                   
                   
                     
                </Columns>
            </MasterTableView>
            <PagerStyle AlwaysVisible="true" Mode="NextPrev" />
            <HeaderStyle Font-Size="8pt"  />
            <ItemStyle Font-Size="8pt" HorizontalAlign="Center" />
        </telerik:RadGrid>
               







        
      
      </td>
    </tr>
 
</tbody></table>
      
</div>
                </div>
            </section>
         </div>

    <div style="height: 800px; width:100%;">
    <div style="height: 36px; background-image: url('../Images/boxdatos.png'); background-repeat: repeat-x; width:98%; text-align:right">
          <asp:Label ID="lblMessage" runat="server"></asp:Label><telerik:RadButton ID="RadButton1" runat="server" EnableEmbeddedSkins="false" Height="33px"  OnClick="btnCancelar_Click" Skin="IELSkin" ToolTip="CANCELAR" Width="33px">
				<Image ImageUrl="../IMAGES/Cancelar.png" IsBackgroundImage="true"/></telerik:RadButton>
        </div>
        </div>

      <telerik:RadWindowManager ID="RadWindowManager1" EnableEmbeddedSkins="false"  CenterIfModal="false" Top="20" Left="20"  runat="server" Skin="IELSkin" Localization-Cancel="Salir" Modal="False">
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
      
</asp:Content>


    