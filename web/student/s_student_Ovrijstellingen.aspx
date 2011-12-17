<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/layout/student.master" CodeFile="s_student_Ovrijstellingen.aspx.cs" Inherits="web_student_s_student_Ovrijstellingen" %>

<asp:Content ID="Content1" ContentPlaceHolderID="page_title" Runat="Server">
Student - Bijlagen toevoegen
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content_title" Runat="Server">
    Bijlage toevoegen
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">
<table>
        <tr>
        <th>Aangevraagde vrijstelling</th><th>Studiepunten</th>
        <th>Gevolgd vak</th><th>Studiepunten</th></tr>
        
        <asp:Repeater ID="rptVrijstellingen" runat="server">
        
        <HeaderTemplate></HeaderTemplate>
        <ItemTemplate>
                <tr>
        <td><%# Eval("ExternVak.ExternvakNaam") %></td>
        <td><%# Eval("ExternVak.ExternvakStudiepunt") %> </td>
        <td> <%# Eval("Vak.vakNaam") %> </td>
        <td> <%# Eval("Vak.vakStudiepunten") %></td>
                </tr>
        
        </ItemTemplate>
        <SeparatorTemplate></SeparatorTemplate>
        </asp:Repeater>
       </table>
</asp:Content>