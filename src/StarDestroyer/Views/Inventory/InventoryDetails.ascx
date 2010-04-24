<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<AssaultItemDetailModel>" %>
<%@ Import Namespace="StarDestroyer.Models" %>
<ul>
    <li>
        <%
            foreach (var image in Model.Images)
            {%>
        <img src="../../Content/Images/<%= image %>/" />
        <% } %>
    </li>
    <li><strong>Type:</strong><%= Model.Type %></li>
    <li><strong>Description:</strong>Model.Description</li>
    <li><strong>Load Value:</strong>Model.LoadValue</li>
</ul>
