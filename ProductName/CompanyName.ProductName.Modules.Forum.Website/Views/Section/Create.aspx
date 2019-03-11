<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CompanyName.ProductName.Modules.Forum.Website.ViewData.CreateSectionViewData>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Fields</legend>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Subject) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Subject) %>
                <%: Html.ValidationMessageFor(model => model.Subject) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Enabled) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Enabled) %>
                <%: Html.ValidationMessageFor(model => model.Enabled) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.GroupId)%>
            </div>
            <div class="editor-field">
                <%: Html.DropDownListFor(model => model.GroupId, new SelectList(Model.Groups, "Id", "Subject")) %>
                <%: Html.ValidationMessageFor(model => model.GroupId) %>
            </div>
            
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% } %>

</asp:Content>

