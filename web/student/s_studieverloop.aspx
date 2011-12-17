<%@ Page Title="" Language="C#" MasterPageFile="~/layout/student.master" AutoEventWireup="true"
    CodeFile="s_studieverloop.aspx.cs" Inherits="web_student_s_studieverloop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="page_title" runat="Server">
    Studieverloop
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content_title" runat="Server">
    Studieverloop
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="Server">
    <asp:Repeater ID="_rptStudieverloop" runat="server" 
        onitemcommand="_rptStudieverloop_ItemCommand">
    <HeaderTemplate>
        <table>
            <tr>
                <td>Academiejaar</td>
                <td>Schoolgegevens</td>
                <td>opleiding</td>
                <td>rapport uploaden</td>
            </tr>
    </HeaderTemplate>
    
    
    <ItemTemplate>
        <tr>
            <td>
                <asp:DropDownList ID="_dropJaar" runat="server">
                    <asp:ListItem Value="2010-2011">2010-2011</asp:ListItem>
                    <asp:ListItem Value="2009-2010">2009-2010</asp:ListItem>
                    <asp:ListItem Value="2008-2009">2008-2009</asp:ListItem>
                    <asp:ListItem Value="2007-2008">2007-2008</asp:ListItem>
                    <asp:ListItem Value="2006-2007">2006-2007</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td><asp:TextBox ID="_txtSchool" runat="server"></asp:TextBox></td>
            <td>
                <asp:TextBox ID="_txtOpleiding" runat="server"></asp:TextBox>
            </td>
            <td><asp:FileUpload ID="_FileUpload" runat="server"></asp:FileUpload></td>
        </tr>
    </ItemTemplate>

    <FooterTemplate>
         </table>
    </FooterTemplate>
         </asp:Repeater>
    <asp:Label ID="_lblFeedback" runat="server" Text=""></asp:Label>
    
    <br />
    <br />
    <div class="clear">
        <div class="buttons">
        <asp:Button ID="btnNext_goedkeuring" class="BtnNext" runat="server" Text="volgende" 
                onclick="btnNext_goedkeuring_Click" />
    </div>
    </div>
</asp:Content>
