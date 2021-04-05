<%@ Page Title="" Theme="IELSkin" Language="C#" MasterPageFile="~/Startup/App.master" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="IELWEB.Administracion.Usuario" %>
<asp:content ContentPlaceHolderID="ContenidoPagina" id="cntMain" runat="Server">
<div id="content">
<table style="width: 100%;" >
<tbody class="supertabla">
<th colspan="2">U S U A R I O</th>
<tr> <td style="width: 74px">Usuario:</td>
                    <td style="width: 449px"><asp:textbox id="txtUSER_LOGIN" maxlength="50" 
                            CssClass="caja" runat="server" width="150px"></asp:textbox>
                    </td>    </tr>
<tr><td style="width: 74px">Nombre:</td>
                    <td style="width: 449px"><asp:textbox id="txtNOMBRE" maxlength="50" CssClass="caja" 
                            runat="server" width="288px"></asp:textbox></td></tr>


                           <tr><td style="width: 74px">Contraseña:</td>
                    <td style="width: 449px"><asp:textbox id="txtUSER_PASSWORD" maxlength="50"  CssClass="caja" runat="server" width="150"></asp:textbox></td></tr>
              

<%--<tr><td style="border-right: 1px dotted silver; text-align: left; vertical-align: top; ">
             <asp:DropDownList ID="ddlImage" runat="server"  Width="300px" 
                 AutoPostBack="True" onselectedindexchanged="ddlImage_SelectedIndexChanged">
                </asp:DropDownList>
        </td>
                <td style="border-right: 1px dotted silver; text-align: left; vertical-align: top; ">
            <asp:Image ID="Image1" runat="server" Width="107px" Height="106px" />
        </td>
               
               
               </tr>--%>
    <tr>
                    <td style="width: 74px">Activo:</td>
                    <td style="width: 449px"><asp:checkbox id="chkACTIVO" runat="server">           
                        </asp:checkbox></td>
                </tr>


<%--<tr><td style="width: 74px">Examinar:</td>

<td style="border-right: 1px dotted silver; text-align: left; vertical-align: top; "><asp:FileUpload ID="FileUpload1"  runat="server" /> <asp:ImageButton ImageUrl="~/Images/image_up.png" ID="btnUploadImage" runat="server" Text="Upload Image" 
CausesValidation="False" onclick="btnUploadImage_Click" /> 
</td>
</tr>--%>
<tr>
                    <td style="width: 74px">Administracion:</td>
                    <td style="width: 449px"><asp:checkbox id="chkADMINISTRACION" runat="server">           
                        </asp:checkbox></td>
                </tr>
<tr>
                    <td style="width: 74px">Alumnos:</td>
                    <td style="width: 449px"><asp:checkbox id="chkALUMNOS" runat="server">
                        </asp:checkbox></td>
                </tr>
<%--<tr>
                    <td style="width: 74px">Profesores:</td>
                    <td style="width: 449px"><asp:checkbox id="chkPROFESORES" runat="server">
                        </asp:checkbox></td>
                </tr>--%>
<tr>
                    <td style="width: 74px">Cobranza:</td>
                    <td style="width: 449px"><asp:checkbox id="chkCOBRANZA" runat="server">
                        </asp:checkbox></td>
                </tr>
                <%--<tr>
                    <td style="width: 74px">Blog:</td>
                    <td style="width: 449px"><asp:checkbox id="chkBLOG" runat="server">
                        </asp:checkbox></td>
                </tr>--%>
                <tr>
                    <td style="width: 74px">Pago:</td>
                    <td style="width: 449px"><asp:checkbox id="chkPAGO" runat="server">
                        </asp:checkbox></td>
                </tr>
                
<tr><td colspan=2>
    <asp:label id="lblMensaje" runat="server" text=""></asp:label>
    <div style="height: 35px; background-image: url('../Images/boxdatos.png'); background-repeat: repeat-x;"><div id="mainmenuSUB">
            <ul>
                <li><asp:LinkButton id="btnGrabar" onclick="btnGrabar_Click" runat="server" tooltip="Clic aqui para grabar">GRABAR</asp:LinkButton></li>
                <li><asp:LinkButton id="btnCancelar" onclick="btnCancelar_Click" runat="server" tooltip="Clic aqui para cancelar">CANCELAR</asp:LinkButton></li>
            </ul>
        </div>
     </div>
    </td>
        </tr>
</tbody>
</table>
<asp:label id="Label1" runat="server" text=""></asp:label>
</div>
<div class="clearingdiv">&nbsp;</div>
</asp:content>
