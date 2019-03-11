<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CompanyName.ProductName.Modules.Forum.Website.ViewData.SectionViewData>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>

    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">Subject</div>
        <div class="display-field"><%: Model.Subject %></div>
        
        <div class="display-label">Enabled</div>
        <div class="display-field"><%: Model.Enabled %></div>
        
        <div class="display-label">GroupSubject</div>
        <div class="display-field"><%: Model.GroupSubject %></div>
        
    </fieldset>

    <div>
        <%: Html.ActionLink("Back to List", "Index", Model.GroupId) %>
    </div>

</asp:Content>

