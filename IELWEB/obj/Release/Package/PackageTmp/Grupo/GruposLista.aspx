<%@ Page Title=""  Language="C#" MasterPageFile="~/Startup/App.master" AutoEventWireup="true" CodeBehind="GruposLista.aspx.cs" Inherits="IELWEB.Grupo.GruposLista" Theme="IELSkin" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPagina" runat="server">
   <telerik:RadScriptBlock ID="RadScriptBlock1"  runat="server">
         <script type="text/javascript">
             function refreshGrid() {
                 $find("<%= RadAjaxManager.GetCurrent(Page).ClientID %>").ajaxRequest("RG");
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



 <table style="width: 98%;" border="0" cellpadding="0" cellspacing="15" class="roundedPanel">
<tbody>

    <tr>
        <td>

             <telerik:RadGrid runat="server" ID="RadGrid1" CellSpacing="0" EnableEmbeddedSkins="False" 
            GridLines="None" Skin="IELSkin" style="margin-top: 0px" Width="100%" AutoGenerateColumns="False" onitemcommand="RadGrid1_ItemCommand"  OnSortCommand="RadGrid1_SortCommand" OnPageIndexChanged="RadGrid1_PageIndexChanged" OnPageSizeChanged="RadGrid1_PageSizeChanged" >
          <AlternatingItemStyle Font-Size="8pt" HorizontalAlign="Center"/>
            <MasterTableView DataKeyNames="psIdGrupo,psGrado,psIDGrado,psNombreGrupo,psIDCiclo">
                <Columns>
                    <telerik:GridButtonColumn ButtonType="ImageButton"   CommandName="VerAlumnos" ImageUrl="../IMAGES/AlumnosGrupo.png"  Text="VER ALUMNOS" UniqueName="VerAlumnos" ItemStyle-Width="10px">
                     <ItemStyle Width="10px" />
                     </telerik:GridButtonColumn>
                    <telerik:GridBoundColumn HeaderStyle-HorizontalAlign="Center" ItemStyle-BackColor="#bfd7e1" ItemStyle-Font-Bold="true" 
                        HeaderStyle-Width="90px" HeaderText="ID" UniqueName="ID" DataField="psIDGrupo">
                        <HeaderStyle HorizontalAlign="Center" Width="90px" />
                    </telerik:GridBoundColumn>
                     <telerik:GridBoundColumn HeaderStyle-HorizontalAlign="Center"  
                   HeaderStyle-Width="100px" HeaderText="GRUPO" UniqueName="GRUPO"  DataField="psNombreGrupo" >
                        <HeaderStyle HorizontalAlign="Center" Width="100px" />
                    </telerik:GridBoundColumn>
                     <telerik:GridBoundColumn HeaderStyle-HorizontalAlign="Center" 
                        HeaderStyle-Width="40px"  HeaderText="CICLO" UniqueName="CICLO" DataField="psNombreCiclo">
                        <HeaderStyle HorizontalAlign="Center" Width="40px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn HeaderStyle-HorizontalAlign="Center" 
                        HeaderStyle-Width="90px" HeaderText="GRADO" UniqueName="GRADO" DataField="psGrado">
                        <HeaderStyle HorizontalAlign="Center" Width="90px" />
                    </telerik:GridBoundColumn>
                     <telerik:GridBoundColumn HeaderStyle-HorizontalAlign="Center"  
                   HeaderStyle-Width="100px" HeaderText="NIVEL" UniqueName="NIVEL"  DataField="psNivelAcademico" >
                        <HeaderStyle HorizontalAlign="Center" Width="100px" />
                    </telerik:GridBoundColumn>
                    
                
                 <%--   <telerik:GridButtonColumn ButtonType="ImageButton"   CommandName="EditaGrupo" ImageUrl="../IMAGES/editar.png"  Text="EDITAR GRUPO" UniqueName="EditaGrupo" ItemStyle-Width="10px">
                     <ItemStyle Width="10px" />
                     </telerik:GridButtonColumn>--%>
                    <telerik:GridButtonColumn ButtonType="ImageButton"   CommandName="EliminaGrupo" ImageUrl="../IMAGES/eliminar.png"  Text="ELIMINAR GRUPO" UniqueName="EliminaGrupo" ItemStyle-Width="10px">
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
          <asp:Label ID="lblMessage" runat="server"></asp:Label><telerik:RadButton ID="btnNuevo" runat="server" EnableEmbeddedSkins="false" Height="33px"  OnClick="btnNuevo_Click" Skin="IELSkin" ToolTip="NUEVO GRUPO" Width="33px">
				<Image ImageUrl="../IMAGES/agregar.png" IsBackgroundImage="true"   />
                    
                                             </telerik:RadButton>
        </div>
        </div>

      <telerik:RadWindowManager ID="RadWindowManager1" EnableEmbeddedSkins="false"  CenterIfModal="false" Top="20" Left="20"  runat="server" Skin="IELSkin" Localization-Cancel="Salir" Modal="False">
          <Windows>
       <telerik:RadWindow ID="RadWindow4" runat="server" Width="860" Height="500" Behaviors="Resize,  Close, Maximize, Move"
                ShowContentDuringLoad="true" EnableEmbeddedSkins="false" Skin="IELSkin" Modal="true" VisibleStatusbar="False">
            </telerik:RadWindow>
              </Windows>
    </telerik:RadWindowManager>
</asp:Content>
