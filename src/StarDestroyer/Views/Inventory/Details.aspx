<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<AssaultItemDetailModel>" %>
<%@ Import Namespace="StarDestroyer.Models"%>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Assault Item Details for <%=Html.Encode(Model.Type) %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details for <%=Html.Encode(Model.Type) %></h2>
    
    <ul class="details">
        <%foreach (var i in Model.Images) { %>
        <li><img src="<%=string.Format("../../Content/Images/{0}", i) %>" /></li>
        <% } %>
    </ul>
    <ul class="details">
        <li><span>Description: </span><%=Html.Encode(Model.Description) %></li>
        <li><span>Load Value: </span><%=Html.Encode(Model.LoadValue) %></li>
    </ul>
    
    <p class="clear"><%=Html.ActionLink("Return to Inventory List", "Index", new {message = string.Empty}) %></p>
</asp:Content>