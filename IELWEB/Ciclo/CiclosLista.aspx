<%@ Page Title=""  Language="C#" MasterPageFile="~/Startup/App.master" AutoEventWireup="true" CodeBehind="CiclosLista.aspx.cs" Inherits="IELWEB.Ciclo.CiclosLista" Theme="IELSkin" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPagina" runat="server">
   <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>Administración
            <small>Ciclos</small>
            </h1>
            <ol class="breadcrumb">
                <li><a href="/Startup/Inicio.aspx"><i class="fa fa-dashboard"></i>Inicio</a></li>
                <li class="active">Ciclos
                </li>
            </ol>
        </section>
        <section class="content">
            <div class="box box-primary">
                <div class="box-header with-border">
                    <h3 class="box-title">Ciclos</h3>
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
            GridLines="None" Skin="IELSkin" style="margin-top: 0px" Width="100%" AutoGenerateColumns="False" onitemcommand="RadGrid1_ItemCommand" >
          <AlternatingItemStyle Font-Size="8pt" HorizontalAlign="Center"/>
            <MasterTableView DataKeyNames="psIdCiclo">
                <Columns>
                   <%-- <telerik:GridButtonColumn ButtonType="ImageButton"   CommandName="VerFicha" ImageUrl="../IMAGES/imgFichaAlumno.png"  Text="VER FICHA" UniqueName="VerFicha" ItemStyle-Width="10px">
                     <ItemStyle Width="10px" />
                     </telerik:GridButtonColumn>--%>
                    <telerik:GridBoundColumn HeaderStyle-HorizontalAlign="Center" ItemStyle-BackColor="#bfd7e1" ItemStyle-Font-Bold="true" 
                        HeaderStyle-Width="90px" HeaderText="ID" UniqueName="ID" DataField="psIDCiclo">
                        <HeaderStyle HorizontalAlign="Center" Width="90px" />
                    </telerik:GridBoundColumn>
                     <telerik:GridBoundColumn HeaderStyle-HorizontalAlign="Center" 
                        HeaderStyle-Width="40px"  HeaderText="NOMBRE" UniqueName="NOMBRE" DataField="psNombreCiclo">
                        <HeaderStyle HorizontalAlign="Center" Width="40px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn HeaderStyle-HorizontalAlign="Center" 
                        HeaderStyle-Width="90px" HeaderText="INICIO" UniqueName="INICIO" DataField="psFechaInicial">
                        <HeaderStyle HorizontalAlign="Center" Width="90px" />
                    </telerik:GridBoundColumn>
                     <telerik:GridBoundColumn HeaderStyle-HorizontalAlign="Center"  
                   HeaderStyle-Width="100px" HeaderText="FIN" UniqueName="FIN"  DataField="psFechaFinal" >
                        <HeaderStyle HorizontalAlign="Center" Width="100px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn HeaderStyle-HorizontalAlign="Center" 
                        HeaderStyle-Width="90px" HeaderText="ESTADO" UniqueName="ESTADO" DataField="psEstatusdesc" >
                        <HeaderStyle HorizontalAlign="Center" Width="90px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridButtonColumn ButtonType="ImageButton"   CommandName="EditaCiclo" ImageUrl="../IMAGES/editar.png"  Text="EDITAR ALUMNO" UniqueName="EditaCiclo" ItemStyle-Width="10px">
                     <ItemStyle Width="10px" />
                     </telerik:GridButtonColumn>
                    <telerik:GridButtonColumn ButtonType="ImageButton"   CommandName="EliminaCiclo" ImageUrl="../IMAGES/eliminar.png"  Text="ELIMINAR ALUMNO" UniqueName="EliminaCiclo" ItemStyle-Width="10px">
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

            <div class="box-footer">

 <div style="height: 800px; width:100%;">
    <div style="height: 36px; background-image: url('../Images/boxdatos.png'); background-repeat: repeat-x; width:98%; text-align:right">
          <asp:Label ID="lblMessage" runat="server"></asp:Label><telerik:RadButton ID="btnNuevo" runat="server" EnableEmbeddedSkins="false" Height="33px"  OnClick="btnNuevo_Click" Skin="IELSkin" ToolTip="NUEVO CICLO" Width="33px">
				<Image ImageUrl="../IMAGES/agregar.png" IsBackgroundImage="true"   />
                    
                                             </telerik:RadButton>
        </div>
        </div>
            </div>

            </section>
       </div>
   
</asp:Content>
