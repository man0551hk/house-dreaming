<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HeaderMenu.ascx.cs" Inherits="MasterPageControl_HeaderMenu" %>
<%@ Import Namespace="HouseDreaming"%>

<li><a href="<%=GetLangPrefix() %>/" class="hvr-bounce-to-bottom"><asp:Literal ID="Literal1" runat = "server" meta:resourceKey="homeMenu"></asp:Literal></a></li>
<li><a href="<%=GetLangPrefix() %>/search/" class="hvr-bounce-to-bottom"><asp:Literal ID="Literal2" runat = "server" meta:resourceKey="searchMenu"></asp:Literal></a></li>
<li><a href="<%=CommonFunc.GetAgencyDomain() %>login/" class="hvr-bounce-to-bottom"><asp:Literal ID="Literal3" runat = "server" meta:resourceKey="agentMenu"></asp:Literal></a></li>
<li><a href="<%=GetUrl("tc") %>" class="hvr-bounce-to-bottom">繁</a></li>
<li><a href="<%=GetUrl("sc") %>" class="hvr-bounce-to-bottom">简</a></li>
<li><a href="<%=GetUrl("en") %>" class="hvr-bounce-to-bottom">En</a></li>