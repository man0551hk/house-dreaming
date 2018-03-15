<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="Decrypted.aspx.cs" Inherits="admin_Decrypted" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:TextBox runat="server" ID="origin" Width="200"></asp:TextBox>
    <asp:Button runat="server" ID="convertBtn" Text ="Decrypt" OnClick="convertBtn_Click"/>
    <asp:Button runat="server" ID="encryptBtn" Text ="Encrypt" OnClick="encryptBtn_Click"/>
    <br />
    <asp:Button runat="server" ID="md5encryptBtn" Text ="MD5 Encrypt" OnClick="md5encryptBtn_Click" />
    <asp:Button runat="server" ID="md5decryptBtn" Text="MD5 Decrypt" OnClick="md5decryptBtn_Click" />
    <asp:Literal runat="server" ID ="converted"></asp:Literal>
</asp:Content>

