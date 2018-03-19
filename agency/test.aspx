<%@ Page Title="" Language="C#" MasterPageFile="~/agency/MasterPage.master" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="agency_test" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <asp:FileUpload ID="fileUploadImage" runat="server"></asp:FileUpload>
            <asp:Button ID="btnUpload" runat="server" Text="Upload Image" OnClick="btn_Click" />
            <br />
            <asp:Button ID="btnProcessData" runat="server" Text="Process Data" OnClick ="btnProcessData_Click" /><br />
            <asp:Label ID="lblMessage" runat="server" Text="Image uploaded successfully."  Visible="false"></asp:Label><br />
            <asp:UpdateProgress ID="UpdateProgress1" runat="server"  AssociatedUpdatePanelID="UpdatePanel1">
                <ProgressTemplate>
                    Please wait image is getting uploaded....
                </ProgressTemplate>
            </asp:UpdateProgress>
            <br />
            <b>Please view the below image uploaded</b><br />
            <asp:Image ID="img" runat="server"  Width="100" Height="100" ImageAlign="Middle" />
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnUpload"  />
            <asp:AsyncPostBackTrigger ControlID="btnProcessData" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

