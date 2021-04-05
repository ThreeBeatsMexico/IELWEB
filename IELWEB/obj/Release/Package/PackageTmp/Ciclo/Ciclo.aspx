<%@ Page Title=""  Language="C#" MasterPageFile="~/Startup/App.master" AutoEventWireup="true" CodeBehind="Ciclo.aspx.cs" Inherits="IELWEB.Ciclo.Ciclo" Theme="IELSkin" %>

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
                    <h3 class="box-title">CICLO</h3>
                    <div class="box-tools pull-right">
                        <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    </div>
                </div>
                <div class="box-body">

    <div id="content">

        <asp:Panel  runat="server" ID="pnlGenerales" Width="100%" Height="100%"> 

              <div class="sidebarheader">CICLO</div>

 <table id="tblCiclo" runat="server" style="width: 98%;" border="0" cellpadding="0" cellspacing="15" class="roundedPanel">
<tbody>
   <tr>               
       <td>Nombre: <telerik:RadTextBox ID="txtIDCiclo" runat="server" Style="visibility:hidden"></telerik:RadTextBox><br /> <telerik:RadTextBox ID="txtCiclo" runat="server" EmptyMessage="Identificador" EmptyMessageStyle-Font-Italic="true" EnableEmbeddedSkins="false" Height="20px" Skin="IELSkin" Width="170px">
               </telerik:RadTextBox><asp:RequiredFieldValidator ControlToValidate="txtCiclo" ErrorMessage="Falta Identificador del Ciclo" Text="*" ValidationGroup="vgCiclo" runat="server" Font-Size="Larger" ForeColor="Blue"/></td>
    <td>inica en:<br /> 
        <telerik:RadDatePicker ID="FechaInicial" Runat="server" DateInput-EmptyMessage="Fecha de Inicio" EnableEmbeddedSkins="False" Skin="IELSkin"  Width="120px" Height="20px" Culture="es-MX" MinDate="2000-01-01">
          <Calendar runat="server" EnableEmbeddedSkins="false"  EnableWeekends="True" Skin="IELSkin" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"></Calendar>
             <DateInput runat="server"  DateFormat="dd/MM/yyyy" ReadOnly="True"   DisplayDateFormat="dd/MM/yyyy" EmptyMessage="Fecha de Inicio" Height="20px"  Width="50px"></DateInput>
               <DatePopupButton HoverImageUrl="../IMAGES/Calendar.png" ImageUrl="../IMAGES/Calendar.png" /></telerik:RadDatePicker>
                 <asp:RequiredFieldValidator ControlToValidate="FechaInicial" ErrorMessage="Falta Fecha de Inicio" Text="*" ValidationGroup="vgCiclo" runat="server" Font-Size="Larger" ForeColor="Blue"/></td>

    <td>termina en:<br /> 
        <telerik:RadDatePicker ID="FechaFinal" Runat="server" DateInput-EmptyMessage="Fecha de Termino" EnableEmbeddedSkins="False" Skin="IELSkin"  Width="120px" Height="20px" Culture="es-MX" MinDate="2000-01-01">
          <Calendar runat="server" EnableEmbeddedSkins="false"  EnableWeekends="True" Skin="IELSkin" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"></Calendar>
             <DateInput runat="server"  DateFormat="dd/MM/yyyy" ReadOnly="True"   DisplayDateFormat="dd/MM/yyyy" EmptyMessage="Fecha Final" Height="20px"  Width="50px"></DateInput>
               <DatePopupButton HoverImageUrl="../IMAGES/Calendar.png" ImageUrl="../IMAGES/Calendar.png" /></telerik:RadDatePicker>
                 <asp:RequiredFieldValidator ControlToValidate="FechaFinal" ErrorMessage="Falta Fecha de Termino" Text="*" ValidationGroup="vgCiclo" runat="server" Font-Size="Larger" ForeColor="Blue"/></td>
 
    </tr>

     <tr> <td>MONTO INSCRIPCION:<br /> 
         <telerik:RadNumericTextBox ID="txtInscripcion" runat="server" EmptyMessage="Monto Inscripcion" EmptyMessageStyle-Font-Italic="true" EnableEmbeddedSkins="false" Height="20px" Skin="IELSkin" Width="170px">
               </telerik:RadNumericTextBox><asp:RequiredFieldValidator ControlToValidate="txtInscripcion" ErrorMessage="Falta Monto Inscripcion" Text="*" ValidationGroup="vgCiclo" runat="server" Font-Size="Larger" ForeColor="Blue"/></td>
    <td>MONTO COLEGIATURA:<br /> <telerik:RadNumericTextBox ID="txtColegiatura" runat="server" EmptyMessage="Monto Colegiatura" EmptyMessageStyle-Font-Italic="true" EnableEmbeddedSkins="false" Height="20px" Skin="IELSkin" Width="170px">
               </telerik:RadNumericTextBox><asp:RequiredFieldValidator ControlToValidate="txtColegiatura" ErrorMessage="Falta Monto Colegiatura" Text="*" ValidationGroup="vgCiclo" runat="server" Font-Size="Larger" ForeColor="Blue"/></td>
         <td>ACTIVO<br /> <asp:CheckBox ID="chkEstatus" runat="server" EmptyMessage="Marcar Como Activo" EmptyMessageStyle-Font-Italic="true" EnableEmbeddedSkins="false" Height="20px" Skin="IELSkin" Width="170px">
               </asp:CheckBox></td>
 
                   </tr>

    </tbody>
     </table>

           


        </div>
                    </div>

                <div class="box-footer">
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

                </div>



                </section>
         </div>

        

</asp:Content>
