<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/layout/student.master" CodeFile="s_upload_bijlagen.aspx.cs" Inherits="web_student_s_upload_bijlagen" %>


<asp:Content ID="Content1" ContentPlaceHolderID="page_title" Runat="Server">
Student - Bijlagen toevoegen
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content_title" Runat="Server">
    Bijlage toevoegen
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">

<asp:Repeater ID="rptVrijstellingen" runat="server">
        
        <HeaderTemplate></HeaderTemplate>
        <ItemTemplate>
        <h2><%# Eval("ExternVak.ExternvakNaam") %></h2>
        
         <asp:HiddenField ID="hiddenid" Value='<%# Eval("ExternVak.pk_externvakID") %>' runat="server" />
       
        <h4>Selecteer een bestand om te uploaden:</h4>
       Gelieve het bestand de naam te geven van het overeenkomstige vak om de verwerking 
           vlot te laten verlopen.
           
           <br /><br />  <br />
           <asp:FileUpload id="FileUpload1"                 
           runat="server">
           </asp:FileUpload>
           <br />
            <asp:CheckBox id="CBupload" EnableViewState="true" runat="server" /><asp:Label id="lblUpload" runat="server"> Geleverd aan Mevrouw Van Orlé</asp:Label>
           <hr />
            </ItemTemplate>
        <SeparatorTemplate><hr /></SeparatorTemplate>
        </asp:Repeater>
       <asp:Label id="UploadStatusLabel" runat="server" ForeColor="Red"></asp:Label>
      <br />
      <br />
        <asp:Button id="UploadButton" 
           Text="volgende > "
           OnClick="UploadButton_Click"
           runat="server">
       </asp:Button>  
       
</asp:Content>


