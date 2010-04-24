<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="MvcContrib.FluentHtml.ModelViewPage<AssaultItemIndexModel>" %>
<%@ Import Namespace="StarDestroyer.Models"%>
<%@ Import Namespace="StarDestroyer.Core.Entities"%>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Assault Inventory
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Available Personnel and Equipment</h2>
    <div id="message"><span><%=Html.Encode(Model.Message) %></span></div>
    <div id="inventoryList">
        <table id="equipmentList">
            <tr>
                <td>
                    <strong>Type</strong>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <%
            foreach (var item in Model.AssaultItems)
            {%>
            <tr>
                <td>
                    <%=Html.Encode(item.Type) %>
                </td>
                <td>
                    
                    <a href="/Inventory/AjaxDetails/<%= item.Id %>/">Details</a>
                </td>
                <td>
                    <%=Html.ActionLink("Edit", "Edit", new { id = item.Id }) %>
                </td>
            </tr>
            <% } %>
        </table>
    </div>
    <div id="details">
        <img src="../../Content/Images/ISD_egvv.jpg" />
    </div>
    
    <script type="text/javascript">
                <%--
                <td>
                    <a href="javascript: ItemDetail(<%= item.Id %>)">Details</a>
                </td>--%>
        function ItemDetail(Id)
        {
            $.post("/Inventory/AjaxDetails/" + Id, 
                function(results){
                $('#details').html(results);
                }
            );
        }
    </script>
</asp:Content>
