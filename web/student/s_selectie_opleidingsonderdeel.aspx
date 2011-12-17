<%@ Page Title="" Language="C#" MasterPageFile="~/layout/student.master" AutoEventWireup="true"
    CodeFile="s_selectie_opleidingsonderdeel.aspx.cs" Inherits="web_student_s_selectie_opleidingsonderdeel" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="page_title" runat="Server">
    Student - Selectie opleidingsonderdeel
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content_title" runat="Server">
    Selectie opleidingsonderdeel
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="Server">
    <table id="tabel">
        <asp:Repeater ID="rptVrijstellingen" runat="server">
            <HeaderTemplate>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <th>
                        <%# Eval("Vak.vakNaam") %>
                        (<%# Eval("Vak.vakStudiepunten") %>)
                    </th>
                    <th>
                    </th>
                    <th>
                    </th>
                    <th>
                    </th>
                    <th>
                    </th>
                </tr>
                <tr>
                    <td>
                        EVK
                    </td>
                    <td>
                        SP
                    </td>
                    <td>
                        Rapport
                    </td>
                    <td>
                        ECTS
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="EVK" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="SP" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:DropDownList ID="dropRapport" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:FileUpload ID="FileUpload1" runat="server"></asp:FileUpload>
                    </td>
                    <td>
                        <asp:HiddenField ID="hiddenid" Value='<%# Eval("Vak.pk_vakID") %>' runat="server" />
                    </td>
                    <td>
                        <asp:Button ID="plus" Text="+" runat="server" /></asp:Button>
                    </td>
                </tr>
            </ItemTemplate>
            <SeparatorTemplate>
            </SeparatorTemplate>
        </asp:Repeater>
    </table>
    <asp:Label ID="UploadStatusLabel" runat="server" ForeColor="Red"></asp:Label>
    <br />
    <br />
    <asp:Button ID="UploadButton" Text="volgende > " OnClick="UploadButton_Click" runat="server">
    </asp:Button>
</asp:Content>
