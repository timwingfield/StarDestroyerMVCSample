<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<List<ProductListingModel>>" %>

<%@ Import Namespace="StarDestroyer.Models" %>
<%@ Import Namespace="StarDestroyer.Helpers.HTML" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Product Catalog
</asp:Content>
<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server">

    <script type="text/javascript">
        jQuery(document).ready(function() {
            jQuery("#list").jqGrid({
                url: '/Product/List/',
                datatype: 'json',
                mtype: 'GET',
                colNames: ['Name', 'Price', 'In Stock?'],
                colModel: [
          { name: 'Name', index: 'Name', width: 300, align: 'left' },
          { name: 'Price', index: 'Price', width: 40, align: 'left' },
          { name: 'InStock', index: 'InStock', width: 100, align: 'left'}],
                pager: jQuery('#pager'),
                rowNum: 5,
                rowList: [5, 10, 20, 50],
                sortname: 'Name',
                sortorder: "asc",
                viewrecords: true,
                imgpath: '/content/images',
                caption: 'Products'
            });
        }); 

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Product Catalog</h2>
    <%= Html.Table("Products", Model, null) %>
    <div id="jQGridExample">
        <table id="list" class="scroll" cellpadding="0" cellspacing="0">
        </table>
        <div id="pager" class="scroll" style="text-align: center;">
        </div>
    </div>
</asp:Content>
