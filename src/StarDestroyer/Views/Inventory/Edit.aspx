<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="MvcContrib.FluentHtml.ModelViewPage<AssaultItemEditModel>" %>
<%@ Import Namespace="StarDestroyer.Models"%>
<%@ Import Namespace="MvcContrib.FluentHtml"%>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit <%=Html.Encode(Model.Type) %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<% Html.BeginForm("Save", "Inventory");%>
    <h2>Edit <%=Html.Encode(Model.Type) %></h2>
    <%=this.Hidden(x => x.Id) %>
    <ul class="details">
        <li><span>Type: </span><%=this.TextBox(x => x.Type) %></li>
        <li><span>Description: </span><%=this.TextBox(x => x.Description) %></li>
        <li><span>Load Value: </span><%=this.TextBox(x => x.LoadValue) %></li>
        <li><%=this.SubmitButton("Save") %></li>
    </ul>
<% Html.EndForm();%>
</asp:Content>
