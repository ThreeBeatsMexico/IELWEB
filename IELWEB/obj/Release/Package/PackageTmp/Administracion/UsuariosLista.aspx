<%@ Page Title="" Theme="IELSkin" Language="C#" MasterPageFile="~/Startup/App.master" AutoEventWireup="true" CodeBehind="UsuariosLista.aspx.cs" Inherits="IELWEB.Administracion.UsuariosLista" %>


<asp:content ContentPlaceHolderID="ContenidoPagina" id="cntMain" runat="Server">
   
<div id="content" style="text-align: right">
<h1>Usuarios del Sistema</h1>


<table style="width: 100%;">
   
   <tbody  style="width:100%" >
<tr>
        
        <td style="text-align: left; vertical-align: top; width: 100%;"><asp:label id="lblMessage" runat="server" text=""></asp:label>


        
            <asp:gridview autogeneratecolumns="False" id="grdLista" CssClass="supertabla" runat="server" 
                width="100%" >
                <columns>
                                
                             
                 <asp:TemplateField>
                 <ItemTemplate>
                 <a href="Usuario.aspx?id=<%# Eval("psIDUsuario")%>">
                 
                 <img src="../Images/editar.png" style="border-style: none" /></a>
                 </ItemTemplate>
                 <ItemStyle  Width="16"/>
                 <HeaderTemplate>Editar</HeaderTemplate>
                 </asp:TemplateField>
                 <asp:BoundField DataField="psIDUsuario" HeaderText="USUARIO" />
                 <asp:BoundField DataField="psNombreUsuario" HeaderText="NOMBRE COMPLETO" />
                   
                </columns>
            </asp:gridview>
        </td>
    </tr>
    <tr>
   
    <td>
    <div style="height: 35px; background-image: url('../Images/boxdatos.png'); background-repeat: repeat-x;"><div id="mainmenuSUB">
            <ul>
                <li><asp:LinkButton ID="Button1" runat="server" onclick="Button1_Click">NUEVO</asp:LinkButton></li>
            </ul>
        </div>
     </div>
    </td>
        </tr>
</tbody></table>
                                                                                            
</div>
<div class="clearingdiv">&nbsp;</div>
 
</asp:content>