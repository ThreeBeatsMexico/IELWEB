<%@ Page EnableEventValidation="false" Language="C#"  AutoEventWireup="true" CodeBehind="Alumno.aspx.cs" Inherits="IELWEB.Alumnos.Alumno" Theme="IELSkin" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    
    <link href="../STYLES/supertabla.css" rel="stylesheet" />

     <script src="../Scripts/tcal.js" type="text/javascript"></script>
   <style type="text/css">
div.RadUpload .ruBrowse 
    { 
    background-image: url(../Images/CargarFoto.png) !important;
    height: 33px !important;
    width: 33px !important;
    }
   

   </style>

 </head>
     <telerik:RadScriptBlock ID="RadScriptBlock1"  runat="server">
  <script language="javascript" type="text/javascript">
      function MuestraFila(FILA, RADIO) {

          var AspRadio = document.getElementById(RADIO);
          var AspRadio_ListItem = AspRadio.getElementsByTagName('input');
          for (var i = 0; i < AspRadio_ListItem.length; i++) {

              if (AspRadio_ListItem[i].checked) {

                  var radio = AspRadio_ListItem[i].value;
              }
          } 

          if (radio == "1") {

              document.getElementById(FILA).style.display = 'table-row'
              event.preventDefault()

          }
          else {
              document.getElementById(FILA).style.display = 'none';
              event.preventDefault()
          }
      }


 </script>
     <script type="text/javascript">
         //<![CDATA[
         serverID("ajaxManagerID", "<%= RadAjaxManager1.ClientID %>");
         //]]>
    </script>

 <script type="text/javascript">

    <%-- function OnClientFileUploadRemoving(sender, args) {

         var imagen = $find('<%= imgAlumno.ClientID %>');
         imagen.ImageUrl = "../images/users/user4.jpg";
     }--%>


    <%-- function OnClientFilesUploaded() {
                 $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("CHANGEIMG");
               }--%>


    </script>
  </telerik:RadScriptBlock>
 
<body>
    
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    
    </telerik:RadScriptManager>
        
         <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" EnablePageHeadUpdate="false">
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="imgAlumno" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="RadAsyncUpload1" LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>

                <telerik:AjaxSetting AjaxControlID="PanelGenerales">
                <UpdatedControls> 
                    <telerik:AjaxUpdatedControl ControlID="PanelGenerales" LoadingPanelID="RadAjaxLoadingPanel1" /> 
                </UpdatedControls>
            </telerik:AjaxSetting>

                 <telerik:AjaxSetting AjaxControlID="rcNivelAcademico">
                <UpdatedControls> 
                    <telerik:AjaxUpdatedControl ControlID="rcGrado" LoadingPanelID="RadAjaxLoadingPanel1" /> 
                </UpdatedControls>
            </telerik:AjaxSetting>
            </AjaxSettings>


        </telerik:RadAjaxManager>
<asp:Panel  runat="server" ID="pnlGenerales" Width="100%" Height="100%"> 
 <div class="sidebarheader">DATOS DEL ALUMNO</div>


 <table id="tblAlumno" runat="server" style="width: 98%;" border="0" cellpadding="0" cellspacing="15" class="roundedPanel">
<tbody>
<tr><td align="center" rowspan="5" style="background-color:#4e4e4e; font-size:larger" >Foto<br /><br />
    <telerik:RadBinaryImage runat="server" ID="imgAlumno" ImageUrl="../images/users/user4.jpg"
                Width="200px" Height="230px" ResizeMode="Fit" AlternateText="No se ha cargado ninguna imagen"
                CssClass="preview"></telerik:RadBinaryImage><br />
     <telerik:RadAsyncUpload runat="server" ID="AsyncUpload1"  MaxFileInputsCount="1" AllowedFileExtensions="jpg" OnClientFileUploaded="OnClientFilesUploaded" OnFileUploaded="AsyncUpload1_FileUploaded2" DisableChunkUpload="true"  
     HideFileInput="true"  AutoAddFileInputs="false"   Width="90%" Localization-Remove="Eliminar" Localization-Select=""/>

  
  
     
  
               </td>
    <td>Matricula:<br /> <telerik:RadTextBox ID="txtMatricula" ReadOnly="True" runat="server" EmptyMessage="Matricula" EmptyMessageStyle-Font-Italic="true" EnableEmbeddedSkins="false" Height="20px" Skin="IELSkin" Width="170px">
               </telerik:RadTextBox></td>
    <td>Estatus:<br /><telerik:RadComboBox ID="rcEstatus" ReadOnly="True" runat="server" EmptyMessage="Estatus" EnableEmbeddedSkins="false" Skin="IELSkin" Width="170px">
                                         <Items>
                                             <telerik:RadComboBoxItem Text="INSCRITO" Selected="true" Value="1" />
                                             <telerik:RadComboBoxItem Text="NO INSCRITO" Value="0" />
                                         </Items>
                                     </telerik:RadComboBox></td>
     <td>Nivel Academico:<br /> <telerik:RadComboBox ID="rcNivelAcademico" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rcNivelAcademico_SelectedIndexChanged"  EmptyMessage="Nivel Academico" EnableEmbeddedSkins="false" Skin="IELSkin" Width="170px">
                                         <Items>
                                             <telerik:RadComboBoxItem Text="KINDER" Value="0" />
                                             <telerik:RadComboBoxItem Text="PRIMARIA" Value="1" />
                                              <telerik:RadComboBoxItem Text="MATERNAL" Value="2" />
                                         </Items>
                                     </telerik:RadComboBox></td>
    
                   </tr>
    <tr> <td >Grado:<br /><telerik:RadComboBox ID="rcGrado" runat="server" EmptyMessage="Grado" EnableEmbeddedSkins="false" Skin="IELSkin" Width="170px">
                                         <Items>
                                            
                                         </Items>
                                     </telerik:RadComboBox></td>
    <td>Escuela de procedencia:<br /> <telerik:RadTextBox ID="txtEscuelaProcedencia" runat="server" EmptyMessage="Escuela de procedencia" EmptyMessageStyle-Font-Italic="true" EnableEmbeddedSkins="false" Height="20px" Skin="IELSkin" Width="170px">
               </telerik:RadTextBox></td>
         <td>CURP:<br /> <telerik:RadTextBox ID="txtCurp" runat="server" EmptyMessage="C.U.R.P." EmptyMessageStyle-Font-Italic="true" EnableEmbeddedSkins="false" Height="20px" Skin="IELSkin" Width="170px">
               </telerik:RadTextBox></td>
         
   
                   </tr>
    <tr> <td class="auto-style1" >Nombre:<br /> <telerik:RadTextBox ID="txtNombres" runat="server" EmptyMessage="Nombre" EmptyMessageStyle-Font-Italic="true" EnableEmbeddedSkins="false" Height="20px" Skin="IELSkin" Width="170px">
               </telerik:RadTextBox><asp:RequiredFieldValidator ControlToValidate="txtNombres" ErrorMessage="Falta Nombre del Alumno" Text="*" ValidationGroup="vgAlumno" runat="server" Font-Size="Larger" ForeColor="Blue"/></td>
    <td class="auto-style1">A. Paterno:<br /> <telerik:RadTextBox ID="txtPaterno" runat="server" EmptyMessage="Apellido Paterno" EmptyMessageStyle-Font-Italic="true" EnableEmbeddedSkins="false" Height="20px" Skin="IELSkin" Width="170px">
               </telerik:RadTextBox><asp:RequiredFieldValidator ControlToValidate="txtPaterno" ErrorMessage="Falta Apellido Paterno" Text="*" ValidationGroup="vgAlumno" runat="server" Font-Size="Larger" ForeColor="Blue"/></td>
         <td class="auto-style1">A. Materno:<br /> <telerik:RadTextBox ID="txtMaterno" runat="server" EmptyMessage="Apellido Materno" EmptyMessageStyle-Font-Italic="true" EnableEmbeddedSkins="false" Height="20px" Skin="IELSkin" Width="170px">
               </telerik:RadTextBox><asp:RequiredFieldValidator ControlToValidate="txtMaterno" ErrorMessage="Falta Apellido Materno" Text="*" ValidationGroup="vgAlumno" runat="server" Font-Size="Larger" ForeColor="Blue"/></td>
 
                   </tr>
     <tr> <td >Fecha Nacimiento:<br /> <telerik:RadDatePicker ID="FechaNacimiento" Runat="server" DateInput-EmptyMessage="Fecha de Nacimiento"
                EnableEmbeddedSkins="False" Skin="IELSkin"  Width="120px" Height="20px" Culture="es-MX" MinDate="2000-01-01">
        
               <Calendar runat="server" EnableEmbeddedSkins="false"  EnableWeekends="True" Skin="IELSkin" 
                    UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False">
                </Calendar>
                <DateInput runat="server"  DateFormat="dd/MM/yyyy" ReadOnly="True"   DisplayDateFormat="dd/MM/yyyy" 
                    EmptyMessage="F.Nacimiento" Height="20px"  Width="50px" >
                </DateInput>
                <DatePopupButton HoverImageUrl="../IMAGES/Calendar.png" ImageUrl="../IMAGES/Calendar.png" />
         
            </telerik:RadDatePicker><asp:RequiredFieldValidator ControlToValidate="FechaNacimiento" ErrorMessage="Falta Fecha de Nacimiento" Text="*" ValidationGroup="vgAlumno" runat="server" Font-Size="Larger" ForeColor="Blue"/>


          </td>
    <td>Edad (Años - Meses):<br /> <telerik:RadTextBox ID="txtAnos" runat="server" EmptyMessage="Años" EmptyMessageStyle-Font-Italic="true" EnableEmbeddedSkins="false" Height="20px" Skin="IELSkin" Width="50px">
               </telerik:RadTextBox><asp:RequiredFieldValidator ControlToValidate="txtAnos" ErrorMessage="Falta edad en años" Text="*" ValidationGroup="vgAlumno" runat="server" Font-Size="Larger" ForeColor="Blue"/> - <telerik:RadTextBox ID="txtMeses" runat="server" EmptyMessage="Meses" EmptyMessageStyle-Font-Italic="true" EnableEmbeddedSkins="false" Height="20px" Skin="IELSkin" Width="50px">
               </telerik:RadTextBox><asp:RequiredFieldValidator ControlToValidate="txtMeses" ErrorMessage="Falta Edad en Meses" Text="*" ValidationGroup="vgAlumno" runat="server" Font-Size="Larger" ForeColor="Blue"/>
    </td>
          <td>Sexo:<br /> <telerik:RadComboBox ID="rcSexo" runat="server"  EmptyMessage="Sexo" EnableEmbeddedSkins="false" Skin="IELSkin" Width="170px">
                                         <Items>
                                             <telerik:RadComboBoxItem Text="MASCULINO" Value="M" />
                                             <telerik:RadComboBoxItem Text="FEMENINO" Value="F" />
                                         </Items>
                                     </telerik:RadComboBox><asp:RequiredFieldValidator ControlToValidate="rcSexo" ErrorMessage="Falta Sexo" Text="*" ValidationGroup="vgAlumno" runat="server" Font-Size="Larger" ForeColor="Blue"/></td>
                   </tr>
    <tr> <td >Entidad de Nacimiento:<br /> <telerik:RadTextBox ID="txtNacionalidad" runat="server" EmptyMessage="Nacionalidad" EmptyMessageStyle-Font-Italic="true" EnableEmbeddedSkins="false" Height="20px" Skin="IELSkin" Width="170px">
               </telerik:RadTextBox><asp:RequiredFieldValidator ControlToValidate="txtNacionalidad" ErrorMessage="Falta Nacionalidad" Text="*" ValidationGroup="vgAlumno" runat="server" Font-Size="Larger" ForeColor="Blue"/></td>
    <td>Hermanos en la escuela:<br />  <asp:radiobuttonlist id="rbHermanos" runat="server" onchange="MuestraFila('trHermanos','rbHermanos');" RepeatDirection="Horizontal" >
                 <asp:ListItem Text="SI" Value="1"></asp:ListItem>
                 <asp:ListItem Text="NO" Selected="True" Value="0"></asp:ListItem>
             </asp:radiobuttonlist> </td>
          <td id="trHermanos" style="display:none">Grado de Hermanos:<br /> <telerik:RadTextBox ID="txtGradoHermanos" runat="server" EmptyMessage="Grado de los Hermanos" EmptyMessageStyle-Font-Italic="true" EnableEmbeddedSkins="false" Height="20px" Skin="IELSkin" Width="170px">
               </telerik:RadTextBox></td>
  
                   </tr>
    <tr>
               <td>MAIL:<br /> <telerik:RadTextBox ID="txtEmail" runat="server" EmptyMessage="EMail" EmptyMessageStyle-Font-Italic="true" EnableEmbeddedSkins="false" Height="20px" Skin="IELSkin" Width="90%">
               </telerik:RadTextBox><asp:RequiredFieldValidator ControlToValidate="txtEmail" ErrorMessage="Falta Correo Electronico" Text="*" ValidationGroup="vgAlumno" runat="server" Font-Size="Larger" ForeColor="Blue"/></td>
        <td>TUTOR:<br /> <telerik:RadTextBox ID="txtTutor" runat="server" EmptyMessage="Nombre del Tutor" EmptyMessageStyle-Font-Italic="true" EnableEmbeddedSkins="false" Height="20px" Skin="IELSkin" Width="90%">
               </telerik:RadTextBox><asp:RequiredFieldValidator ControlToValidate="txtTutor" ErrorMessage="Falta Tutor" Text="*" ValidationGroup="vgAlumno" runat="server" Font-Size="Larger" ForeColor="Blue"/></td>

        <td >BECA:<br /> <telerik:RadNumericTextBox ID="txtBeca" runat="server" EmptyMessage="Beca" EmptyMessageStyle-Font-Italic="true" EnableEmbeddedSkins="false" Height="20px" Skin="IELSkin" Width="90%">
               </telerik:RadNumericTextBox><asp:RequiredFieldValidator ControlToValidate="txtBeca" ErrorMessage="Falta Beca" Text="*" ValidationGroup="vgAlumno" runat="server" Font-Size="Larger" ForeColor="Blue"/></td>

        <td>FORMA DE PAGO:<br /> <telerik:RadComboBox ID="rcFormaPago" runat="server"  EmptyMessage="Forma de Pago" EnableEmbeddedSkins="false" Skin="IELSkin" Width="170px">
                                         <Items>
                                             <telerik:RadComboBoxItem Text="10 MESES" Value="1" />
                                             <telerik:RadComboBoxItem Text="12 MESES" Value="2" />
                                         </Items>
                                     </telerik:RadComboBox><asp:RequiredFieldValidator ControlToValidate="rcFormaPago" ErrorMessage="Falta Forma de Pago" Text="*" ValidationGroup="vgAlumno" runat="server" Font-Size="Larger" ForeColor="Blue"/></td>

    </tr>
    </tbody>
     </table>
   
  
        <div class="sidebarheader">DOMICILIO</div>


 <table style="width: 98%;" border="0" cellpadding="0" cellspacing="15" class="roundedPanel">
<tbody>

    <tr> <td colspan="2" style="height: 10px" >Calle:<br /> <telerik:RadTextBox ID="txtCalle" runat="server" EmptyMessage="Calle" EmptyMessageStyle-Font-Italic="true" EnableEmbeddedSkins="false" Height="20px" Skin="IELSkin" Width="90%">
               </telerik:RadTextBox><asp:RequiredFieldValidator ControlToValidate="txtCalle" ErrorMessage="Falta Calle" Text="*" ValidationGroup="vgAlumno" runat="server" Font-Size="Larger" ForeColor="Blue"/></td>
    <td style="height: 10px">Numero:<br /> <telerik:RadTextBox ID="txtNumero" runat="server" EmptyMessage="Numero" EmptyMessageStyle-Font-Italic="true" EnableEmbeddedSkins="false" Height="20px" Skin="IELSkin" Width="170px">
               </telerik:RadTextBox><asp:RequiredFieldValidator ControlToValidate="txtNumero" ErrorMessage="Falta Numero" Text="*" ValidationGroup="vgAlumno" runat="server" Font-Size="Larger" ForeColor="Blue"/></td>
          <td style="height: 10px">Colonia:<br /> <telerik:RadTextBox ID="txtColonia" runat="server" EmptyMessage="Colonia" EmptyMessageStyle-Font-Italic="true" EnableEmbeddedSkins="false" Height="20px" Skin="IELSkin" Width="170px">
               </telerik:RadTextBox><asp:RequiredFieldValidator ControlToValidate="txtColonia" ErrorMessage="Falta Colonia" Text="*" ValidationGroup="vgAlumno" runat="server" Font-Size="Larger" ForeColor="Blue"/></td>
  
                   </tr>

     <tr> <td >Delegacion:<br /> <telerik:RadTextBox ID="txtDelegacion" runat="server" EmptyMessage="Delegacion" EmptyMessageStyle-Font-Italic="true" EnableEmbeddedSkins="false" Height="20px" Skin="IELSkin" Width="170px">
               </telerik:RadTextBox><asp:RequiredFieldValidator ControlToValidate="txtDelegacion" ErrorMessage="Falta Delegacion" Text="*" ValidationGroup="vgAlumno" runat="server" Font-Size="Larger" ForeColor="Blue"/></td>
    <td>Telefono:<br /> <telerik:RadTextBox ID="txtTelefono" runat="server" EmptyMessage="Telefono" EmptyMessageStyle-Font-Italic="true" EnableEmbeddedSkins="false" Height="20px" Skin="IELSkin" Width="170px">
               </telerik:RadTextBox><asp:RequiredFieldValidator ControlToValidate="txtTelefono" ErrorMessage="Falta Telefono" Text="*" ValidationGroup="vgAlumno" runat="server" Font-Size="Larger" ForeColor="Blue"/></td>
          <td>Codigo Postal:<br /> <telerik:RadTextBox ID="txtCodigoPostal" runat="server" EmptyMessage="Codigo Postal" EmptyMessageStyle-Font-Italic="true" EnableEmbeddedSkins="false" Height="20px" Skin="IELSkin" Width="170px">
               </telerik:RadTextBox><asp:RequiredFieldValidator ControlToValidate="txtCodigoPostal" ErrorMessage="Falta Codigo Postal" Text="*" ValidationGroup="vgAlumno" runat="server" Font-Size="Larger" ForeColor="Blue"/></td>
          <td>Estado:<br /> <telerik:RadTextBox ID="txtEstado" runat="server" EmptyMessage="Estado" EmptyMessageStyle-Font-Italic="true" EnableEmbeddedSkins="false" Height="20px" Skin="IELSkin" Width="170px">
               </telerik:RadTextBox><asp:RequiredFieldValidator ControlToValidate="txtEstado" ErrorMessage="Falta Estado" Text="*" ValidationGroup="vgAlumno" runat="server" Font-Size="Larger" ForeColor="Blue"/></td>
  
                   </tr>
    </tbody>
     </table>
    <div class="sidebarheader">DATOS DEL PADRE O TUTOR</div>


 <table style="width: 98%;" border="0" cellpadding="0" cellspacing="15" class="roundedPanel">
<tbody>

    
     <tr> <td colspan="2">Nombre del Padre o Tutor:<br /> <telerik:RadTextBox ID="txtNombrePadreTutor" runat="server" EmptyMessage="Cotizacion" EmptyMessageStyle-Font-Italic="true" EnableEmbeddedSkins="false" Height="20px" Skin="IELSkin" Width="100%">
               </telerik:RadTextBox></td>
    <td>Ocupacion:<br /> <telerik:RadTextBox ID="txtOcupacionPadre" runat="server" EmptyMessage="Ocupacion " EmptyMessageStyle-Font-Italic="true" EnableEmbeddedSkins="false" Height="20px" Skin="IELSkin" Width="170px">
               </telerik:RadTextBox></td>
          <td>Sueldo:<br /> <telerik:RadTextBox ID="txtSueldoPadre" runat="server" EmptyMessage="Sueldo" EmptyMessageStyle-Font-Italic="true" EnableEmbeddedSkins="false" Height="20px" Skin="IELSkin" Width="170px">
               </telerik:RadTextBox></td>
  
                   </tr>
     
     <tr> <td >Tel. Particular:<br /> <telerik:RadTextBox ID="txtTelPadre" runat="server" EmptyMessage="Tel. Particular" EmptyMessageStyle-Font-Italic="true" EnableEmbeddedSkins="false" Height="20px" Skin="IELSkin" Width="170px">
               </telerik:RadTextBox></td>
    <td>Tel. Trabajo:<br /> <telerik:RadTextBox ID="txtTelPadreTrabajo" runat="server" EmptyMessage="Tel. Trabajo" EmptyMessageStyle-Font-Italic="true" EnableEmbeddedSkins="false" Height="20px" Skin="IELSkin" Width="170px">
               </telerik:RadTextBox></td>
          <td>Tel. Celular:<br /> <telerik:RadTextBox ID="txtTelPadreCelular" runat="server" EmptyMessage="Tel. Celular" EmptyMessageStyle-Font-Italic="true" EnableEmbeddedSkins="false" Height="20px" Skin="IELSkin" Width="170px">
               </telerik:RadTextBox></td>
  <td >Fecha de Nacimiento:<br /> <telerik:RadDatePicker ID="FechaNacimientoPadre" Runat="server" 
                EnableEmbeddedSkins="False" Skin="IELSkin"  Width="120px" Height="20px" Culture="es-MX" MinDate="1900-01-01">
                <Calendar runat="server" EnableEmbeddedSkins="false"  EnableWeekends="True" Skin="IELSkin" 
                    UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False">
                </Calendar>
                <DateInput runat="server" ReadOnly="True"  DateFormat="dd/MM/yyyy"  DisplayDateFormat="dd/MM/yyyy" 
                    EmptyMessage="F.Nacimiento" Height="20px"  Width="50px" AutoPostBack="false">
                </DateInput>
                <DatePopupButton HoverImageUrl="../IMAGES/Calendar.png" ImageUrl="../IMAGES/Calendar.png" />
            </telerik:RadDatePicker></td>
                   </tr>

    <tr> 
    <td>Entidad Federativa:<br /> <telerik:RadTextBox ID="txtNacionalidadPadre" runat="server" EmptyMessage="Nacionalidad" EmptyMessageStyle-Font-Italic="true" EnableEmbeddedSkins="false" Height="20px" Skin="IELSkin" Width="170px">
               </telerik:RadTextBox></td>
         
  
                   </tr>
    </tbody>
     </table>

     <div class="sidebarheader">DATOS DE LA MADRE O TUTORA</div>


 <table style="width: 98%;" border="0" cellpadding="0" cellspacing="15" class="roundedPanel">
<tbody>

    
     <tr> <td colspan="2" >Nombre de la Madre o Tutor:<br /> <telerik:RadTextBox ID="txtNombreMadreTutor" runat="server" EmptyMessage="Nombre de la Madre" EmptyMessageStyle-Font-Italic="true" EnableEmbeddedSkins="false" Height="20px" Skin="IELSkin" Width="100%">
               </telerik:RadTextBox></td>
    <td>Ocupacion:<br /> <telerik:RadTextBox ID="txtOcupacionMadre" runat="server" EmptyMessage="Ocupacion" EmptyMessageStyle-Font-Italic="true" EnableEmbeddedSkins="false" Height="20px" Skin="IELSkin" Width="170px">
               </telerik:RadTextBox></td>
          <td>Sueldo:<br /> <telerik:RadTextBox ID="txtSueldoMadre" runat="server" EmptyMessage="Sueldo" EmptyMessageStyle-Font-Italic="true" EnableEmbeddedSkins="false" Height="20px" Skin="IELSkin" Width="170px">
               </telerik:RadTextBox></td>
  
                   </tr>
     
     <tr> <td >Tel. Particular:<br /> <telerik:RadTextBox ID="txtTelMadre" runat="server" EmptyMessage="Telefono particular" EmptyMessageStyle-Font-Italic="true" EnableEmbeddedSkins="false" Height="20px" Skin="IELSkin" Width="170px">
               </telerik:RadTextBox></td>
    <td>Tel. Trabajo:<br /> <telerik:RadTextBox ID="txtTelMadreTrabajo" runat="server" EmptyMessage="Telefono del Trabajo" EmptyMessageStyle-Font-Italic="true" EnableEmbeddedSkins="false" Height="20px" Skin="IELSkin" Width="170px">
               </telerik:RadTextBox></td>
          <td>Tel. Celular:<br /> <telerik:RadTextBox ID="txtTelMadreCel" runat="server" EmptyMessage="Telefono Celular" EmptyMessageStyle-Font-Italic="true" EnableEmbeddedSkins="false" Height="20px" Skin="IELSkin" Width="170px">
               </telerik:RadTextBox></td>
  <td >Fecha de Nacimiento:<br /> <telerik:RadDatePicker ID="FechaNacimientoMadre" Runat="server" 
                EnableEmbeddedSkins="False" Skin="IELSkin"  Width="120px" Height="20px" Culture="es-MX" MinDate="1900-01-01">
                <Calendar runat="server" EnableEmbeddedSkins="false"  EnableWeekends="True" Skin="IELSkin" 
                    UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False">
                </Calendar>
                <DateInput ReadOnly="True" runat="server"  DateFormat="dd/MM/yyyy"  DisplayDateFormat="dd/MM/yyyy" 
                    EmptyMessage="F.Nacimiento" Height="20px"  Width="50px" AutoPostBack="false">
                </DateInput>
                <DatePopupButton HoverImageUrl="../IMAGES/Calendar.png" ImageUrl="../IMAGES/Calendar.png" />
            </telerik:RadDatePicker></td>
                   </tr>

    <tr> 
    <td>Entidad Federativa:<br /> <telerik:RadTextBox ID="txtNacionalidadMadre" runat="server" EmptyMessage="NAcionalidad " EmptyMessageStyle-Font-Italic="true" EnableEmbeddedSkins="false" Height="20px" Skin="IELSkin" Width="170px">
               </telerik:RadTextBox></td>
        
  
                   </tr>
     <tr> <td colspan="2">Nombre de algún familiar o vecino de confianza:<br /> <telerik:RadTextBox ID="txtNombreVecino" runat="server" EmptyMessage="Nombre Familiar o Vecino de Confianza" EmptyMessageStyle-Font-Italic="true" EnableEmbeddedSkins="false" Height="20px" Skin="IELSkin" Width="100%">
               </telerik:RadTextBox></td>
    <td>Tel Particular:<br /> <telerik:RadTextBox ID="txtTelVecino" runat="server" EmptyMessage="Tel. Particular" EmptyMessageStyle-Font-Italic="true" EnableEmbeddedSkins="false" Height="20px" Skin="IELSkin" Width="170px">
               </telerik:RadTextBox></td>
          <td>Tel Celular:<br /> <telerik:RadTextBox ID="txtTelVecinoCel" runat="server" EmptyMessage="Tel. Celular" EmptyMessageStyle-Font-Italic="true" EnableEmbeddedSkins="false" Height="20px" Skin="IELSkin" Width="170px">
               </telerik:RadTextBox></td>
  
                   </tr>
    </tbody>
     </table>

     <div class="sidebarheader">DATOS DE SALUD</div>


 <table style="width: 98%;" border="0" cellpadding="0" cellspacing="15" class="roundedPanel">
<tbody>

    
     <tr> <td >Peso:<br /> <telerik:RadTextBox ID="txtPeso" runat="server" EmptyMessage="Peso.." EmptyMessageStyle-Font-Italic="true" EnableEmbeddedSkins="false" Height="20px" Skin="IELSkin" Width="170px">
               </telerik:RadTextBox></td>
    <td>Talla:<br /> <telerik:RadTextBox ID="txtTalla" runat="server" EmptyMessage="Talla..." EmptyMessageStyle-Font-Italic="true" EnableEmbeddedSkins="false" Height="20px" Skin="IELSkin" Width="170px">
               </telerik:RadTextBox></td>
          <td colspan="2">Tipo de Sangre:<br /> <telerik:RadTextBox ID="txtTipoSangre" runat="server" EmptyMessage="Tipo de Sangre..." EmptyMessageStyle-Font-Italic="true" EnableEmbeddedSkins="false" Height="20px" Skin="IELSkin" Width="100%">
               </telerik:RadTextBox></td>
  
                   </tr>
     <tr> <td colspan="3" >Indique si el alumno toma algun Medicamento: </td>
         <td>   
             <asp:radiobuttonlist id="rbMedicamento" runat="server" onchange="MuestraFila('trMedicamento','rbMedicamento');" RepeatDirection="Horizontal" >
                 <asp:ListItem Text="SI" Value="1"></asp:ListItem>
                 <asp:ListItem Text="NO" Selected="True" Value="0"></asp:ListItem>
             </asp:radiobuttonlist>
            </td>          
          </tr>
    
         <tr id="trMedicamento" runat="server" style="display:none">
              <td colspan="2" >Indique el Nombre del Medicamento: <br />
        <telerik:RadTextBox ID="txtNombreMedicamento" runat="server" EmptyMessage="Nombre del Medicamento" EmptyMessageStyle-Font-Italic="true" EnableEmbeddedSkins="false" Height="20px" Skin="IELSkin" Width="100%">
               </telerik:RadTextBox></td>

        <td colspan="2" >Indique la dosis: <br />
        <telerik:RadTextBox ID="txtDosisMedicamento" runat="server" EmptyMessage="Dosis del Medicamento" EmptyMessageStyle-Font-Italic="true" EnableEmbeddedSkins="false" Height="20px" Skin="IELSkin" Width="100%">
               </telerik:RadTextBox></td>
              

         </tr>
    
    
   
     <tr> <td colspan="3" >Indique si el alumno es apto para realizar Educacion Fisica: </td>
         <td>
               <asp:radiobuttonlist id="rbEFisica" runat="server" RepeatDirection="Horizontal" >
                 <asp:ListItem Text="SI" Value="1"></asp:ListItem>
                 <asp:ListItem Text="NO" Selected="True" Value="0"></asp:ListItem>
             </asp:radiobuttonlist>

         </td>
         </tr>
     
     <tr> <td colspan="3" >Indique si el alumno presenta alguna Enfermedad: </td>
         <td>  <asp:radiobuttonlist id="rbEnfermedad" runat="server" onchange="MuestraFila('trEnfermedad1','rbEnfermedad');MuestraFila('trEnfermedad2','rbEnfermedad');" RepeatDirection="Horizontal" >
                 <asp:ListItem Text="SI" Value="1"></asp:ListItem>
                 <asp:ListItem Text="NO" Selected="True" Value="0"></asp:ListItem>
             </asp:radiobuttonlist></td>
         </tr>
   
        <tr id="trEnfermedad1" runat="server" style="display:none"> <td colspan="4" >Indique que enfermedad presenta el alumno: <br />
        <telerik:RadTextBox ID="txtNombreEnfermedad" runat="server" EmptyMessage="Nombre de la Enfermedad" EmptyMessageStyle-Font-Italic="true" EnableEmbeddedSkins="false" Height="20px" Skin="IELSkin" Width="100%">
               </telerik:RadTextBox></td>

         </tr>
         <tr id="trEnfermedad2" runat="server" style="display:none"> <td colspan="4" >Indique como actuar si se presenta alguna crisis debido a esta enfermedad: <br />
        <telerik:RadTextBox ID="txtProcedimientoEnfermedad" runat="server" EmptyMessage="En caso de crisis por enfermedad.." EmptyMessageStyle-Font-Italic="true" EnableEmbeddedSkins="false"  TextMode="MultiLine" Height="50px" Skin="IELSkin" Width="100%">
               </telerik:RadTextBox></td>

         </tr>

    

     <tr> <td colspan="3">Indique si el alumno presenta alguna Alergia: </td>
         <td><asp:radiobuttonlist id="rbAlergia" runat="server" onchange="MuestraFila('trAlergia1','rbAlergia');MuestraFila('trAlergia2','rbAlergia');" RepeatDirection="Horizontal" >
                 <asp:ListItem Text="SI" Value="1"></asp:ListItem>
                 <asp:ListItem Text="NO" Selected="True" Value="0"></asp:ListItem>
             </asp:radiobuttonlist></td>
         </tr>
           <tr id="trAlergia1" runat="server" style="display:none"> <td colspan="4" >Indique que alergia presenta el alumno: <br />
        <telerik:RadTextBox ID="txtNombreAlergia" runat="server" EmptyMessage="Nombre de la Alergia" EmptyMessageStyle-Font-Italic="true" EnableEmbeddedSkins="false" Height="20px" Skin="IELSkin" Width="100%">
               </telerik:RadTextBox></td>

         </tr>
         <tr id="trAlergia2" runat="server" style="display:none"> <td colspan="4" >Indique como actuar si se presenta alguna crisis debido a esta alergia: <br />
        <telerik:RadTextBox ID="txtProcedimientoAlergia" runat="server" EmptyMessage="En caso de crisis por Alergia.." EmptyMessageStyle-Font-Italic="true" EnableEmbeddedSkins="false"  TextMode="MultiLine" Height="50px" Skin="IELSkin" Width="100%">
               </telerik:RadTextBox></td></tr>

   

     <tr> <td colspan="3" >Indique si el alumno presenta Certificado Médico: </td>
         <td>
             <asp:radiobuttonlist id="rbCertificado" runat="server" onchange="MuestraFila('trEnfermedadCert','rbCertificado');" RepeatDirection="Horizontal" >
                 <asp:ListItem Text="SI" Value="1"></asp:ListItem>
                 <asp:ListItem Text="NO" Selected="True" Value="0"></asp:ListItem>
             </asp:radiobuttonlist>

         </td>
         </tr>

   
        <tr id="trEnfermedadCert" runat="server" style="display:none">
            <td colspan="3">Indique si se menciona Enfermedad en el Certificado: </td>
            <td>
          <asp:radiobuttonlist id="rbEnfermedadCert" runat="server" onchange="MuestraFila('trMensajeCert','rbEnfermedadCert');" RepeatDirection="Horizontal" >
                 <asp:ListItem Text="SI" Selected="True" Value="0"></asp:ListItem>
                 <asp:ListItem Text="NO" Value="1"></asp:ListItem>
             </asp:radiobuttonlist>     </td>
        </tr>


   
         <tr id="trMensajeCert" runat="server" style="display:none"> <td colspan="4" >EL ALUMNO(A) PADECE UNA ENFERMEDAD Y NO SE INDICA EN EL CERTIFICADO SEGUN SUS RESPUESTAS ANTERIORES
DEBE SOLICITAR EL TRAMITE DE UN CERTIFICADO NUEVO DONDE SE MENCIONE LA ENFERMEDAD, PARA EL BIENESTAR Y SALUD DEL ALUMNO(A). <br /></td> </tr>

    
    </tbody>
     </table>

     <div class="sidebarheader">DATOS DE SEGURIDAD</div>


 <table style="width: 98%;" border="0" cellpadding="0" cellspacing="15" class="roundedPanel">
<tbody>

      <tr> <td colspan="4" >En caso de accidente indique Nombre y telefono con quien la escuela se debe comunicar: </td>
          </tr>
    <tr> <td colspan="3">Nombre: <br /> <telerik:RadTextBox ID="txtNombreAccidente" runat="server" EmptyMessage="Nombre" EmptyMessageStyle-Font-Italic="true" EnableEmbeddedSkins="false" Height="20px" Skin="IELSkin" Width="100%">
               </telerik:RadTextBox> </td>
        <td>Telefono: <br /> <telerik:RadTextBox ID="txtTelAccidente" runat="server" EmptyMessage="Telefono" EmptyMessageStyle-Font-Italic="true" EnableEmbeddedSkins="false" Height="20px" Skin="IELSkin" Width="100%">
               </telerik:RadTextBox> </td>
         </tr>
     <tr> <td colspan="4" >Indique el nombre de la Institucion Medica donde sera atendido el Alumno en caso necesario: <br />
        <telerik:RadTextBox ID="txtIstitucion" runat="server" EmptyMessage="Nombre de Institucion Medica" EmptyMessageStyle-Font-Italic="true" EnableEmbeddedSkins="false" Height="20px" Skin="IELSkin" Width="100%">
               </telerik:RadTextBox></td>

         </tr>
    <tr> <td colspan="3" >Indique si el alumno tiene médico particular: </td>
         <td>   
             <asp:radiobuttonlist id="rbMedicoParticular" runat="server" onchange="MuestraFila('trMedicoParticular','rbMedicoParticular');" RepeatDirection="Horizontal" >
                 <asp:ListItem Text="SI" Value="1"></asp:ListItem>
                 <asp:ListItem Text="NO" Selected="True" Value="0"></asp:ListItem>
             </asp:radiobuttonlist>
                      
          </tr>
    
         <tr id="trMedicoParticular" runat="server" style="display:none">
              <td colspan="2" >Indique el Nombre del Médico: <br />
        <telerik:RadTextBox ID="txtNombreMedico" runat="server" EmptyMessage="Nombre del Medico" EmptyMessageStyle-Font-Italic="true" EnableEmbeddedSkins="false" Height="20px" Skin="IELSkin" Width="100%">
               </telerik:RadTextBox></td>
             <td >Telefono del Médico: <br />
        <telerik:RadTextBox ID="txtTelefonoMedico" runat="server" EmptyMessage="Telefono del Medico" EmptyMessageStyle-Font-Italic="true" EnableEmbeddedSkins="false" Height="20px" Skin="IELSkin" Width="137px">
               </telerik:RadTextBox></td>

        <td>Indique la cedula del Médico: <br />
        <telerik:RadTextBox ID="txtCedulaMedico" runat="server" EmptyMessage="Cedula del Medico" EmptyMessageStyle-Font-Italic="true" EnableEmbeddedSkins="false" Height="20px" Skin="IELSkin" Width="137px">
               </telerik:RadTextBox></td>
              

         </tr>

     <tr> <td colspan="3" > Para poder actuar de manera rápida y eficiente en caso de ser necesario dentro
del instituto, le solicitamos autorice al personal docente de la escuela a trasladar a
su hijo(a) al servicio médico más cercano. La escuela se compromete a
comunicarle de inmediato para que se traslade al lugar en donde se atiende a su
hijo(a). </td>
         <td>   
             <asp:radiobuttonlist id="rbAutorizacion" runat="server" onchange="MuestraFila('trProcedimientoAccidente','rbAutorizacion');"  RepeatDirection="Horizontal" >
                 <asp:ListItem Text="SI" Value="0"></asp:ListItem>
                 <asp:ListItem Text="NO" Value="1"></asp:ListItem>
             </asp:radiobuttonlist>
    </td>                  
          </tr>
    
     <tr id="trProcedimientoAccidente" runat="server" style="display:none"> <td colspan="4" > Ha denegado la autorizacion de trasladar a su hijo en caso de accidente, por favor indique lo que usted desea
que se haga en caso de algún percance. Le recordamos que el instituto cuenta
con servicio médico y seguro escolar. <br />
        <telerik:RadTextBox ID="txtProcedimientoAccidente" runat="server" EmptyMessage="En caso de Accidente.." EmptyMessageStyle-Font-Italic="true" EnableEmbeddedSkins="false"  TextMode="MultiLine" Height="50px" Skin="IELSkin" Width="100%">
               </telerik:RadTextBox></td></tr>
    </tbody>
     </table>


         
     
                


    <div style="height: 100%; background-image: url('../Images/boxdatos.png'); background-repeat: repeat-x; width:98%; text-align:right">
         <table style="width: 98%;" border="0" cellpadding="0" cellspacing="15">
<tbody>

      <tr> 
          <td >  <asp:Label runat="server" ID="lblMensaje" ForeColor="White"> </asp:Label> </td>
          <td > <telerik:RadButton ID="btnGuardar" runat="server" ValidationGroup="vgAlumno" EnableEmbeddedSkins="false" Height="33px"  OnClick="btnGrabar_Click" Skin="IELSkin" ToolTip="GUARDAR" Width="33px">
				<Image ImageUrl="../IMAGES/Guardar.png" IsBackgroundImage="true"/></telerik:RadButton></td>
          <td > <telerik:RadButton ID="btnCancelar" runat="server" EnableEmbeddedSkins="false" Height="33px"  OnClick="btnCancelar_Click" Skin="IELSkin" ToolTip="CANCELAR" Width="33px">
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

        <telerik:RadAjaxLoadingPanel runat="server" ID="RadAjaxLoadingPanel1" Skin="Metro"></telerik:RadAjaxLoadingPanel>
      </form>
   

  </body>
 </html>
