<%@ Page Title=""  Language="C#" MasterPageFile="~/Startup/App.master" AutoEventWireup="true" CodeBehind="PagosAlumno.aspx.cs" Inherits="IELWEB.Pagos.PagosAlumno" Theme="IELSkin" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPagina" runat="server">
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

             function openAlert(Msg, Metodo) {
                 radAlert(msg);
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


     <div  class="sidebarheader">PAGOS: <asp:Label ID="lblNombreAlumno" runat="server"></asp:Label></div>


 <table style="width: 98%;" border="0" cellpadding="0" cellspacing="15" class="roundedPanel">
<tbody>

    <tr>
        <td>
           
              <telerik:RadGrid runat="server" ID="RadGrid1" CellSpacing="0" EnableEmbeddedSkins="False" 
            GridLines="None" Skin="IELSkin" style="margin-top: 0px" Width="100%" AutoGenerateColumns="False" OnItemDataBound="RadGrid1_ItemDataBound" onitemcommand="RadGrid1_ItemCommand" >
          <AlternatingItemStyle Font-Size="8pt" HorizontalAlign="Center"/>
            <MasterTableView DataKeyNames="psIDPago,psIDAlumno,psEstado" >
                <Columns>
                    <telerik:GridButtonColumn ButtonType="ImageButton"   CommandName="RegistraPago" ImageUrl="../IMAGES/registrapago.png"  Text="REGISTRAR PAGO" UniqueName="RegistraPago" ItemStyle-Width="10px">
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
            </MasterTableView>
            <PagerStyle AlwaysVisible="true" Mode="NextPrev" />
            <HeaderStyle Font-Size="8pt"  />
            <ItemStyle Font-Size="8pt" HorizontalAlign="Center" />
        </telerik:RadGrid>








        
      
      </td>
    </tr>
 
</tbody></table>


                    </div></div>


            <div class="box-footer">

<div style="height: 800px; width:100%;">
    <div style="height: 36px; background-image: url('../Images/boxdatos.png'); background-repeat: repeat-x; width:98%; text-align:right">
          <asp:Label ID="lblMessage" runat="server"></asp:Label><telerik:RadButton ID="RadButton1" runat="server" EnableEmbeddedSkins="false" Height="33px"  OnClick="btnCancelar_Click" Skin="IELSkin" ToolTip="CANCELAR" Width="33px">
				<Image ImageUrl="../IMAGES/Cancelar.png" IsBackgroundImage="true"/></telerik:RadButton>
        </div>
        </div>
            </div>


        </section>
         

      </div>

   

      <telerik:RadWindowManager ID="RadWindowManager2" EnableEmbeddedSkins="false"  CenterIfModal="false" Top="20" Left="20"  runat="server" Skin="IELSkin" Localization-Cancel="Salir" Modal="False">
          <Windows>
               <telerik:RadWindow ID="RadWindow1" runat="server" Width="800" Height="200" Behaviors="Resize, Close, Maximize, Move"
                ShowContentDuringLoad="true" EnableEmbeddedSkins="false" Skin="IELSkin" VisibleStatusbar="False">
            </telerik:RadWindow>
       <telerik:RadWindow ID="RadWindow4" runat="server" Width="860" Height="500" Behaviors="Resize,  Close, Maximize, Move"
                ShowContentDuringLoad="true" EnableEmbeddedSkins="false" Skin="IELSkin" Modal="true" VisibleStatusbar="False">
            </telerik:RadWindow>
              </Windows>
    </telerik:RadWindowManager>
 
</asp:Content>
