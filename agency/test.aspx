<%@ Page Title="" Language="C#" MasterPageFile="~/agency/MasterPage.master" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="agency_test" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <asp:UpdatePanel runat="server" ID ="wallPanel" UpdateMode ="Conditional" ChildrenAsTriggers="true">

        <ContentTemplate>
            <asp:FileUpload runat="server" ID="fileUpload"  />
            <asp:Button runat="server" ID="btn" OnClick="btn_Click" Text="Save" />
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btn" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

