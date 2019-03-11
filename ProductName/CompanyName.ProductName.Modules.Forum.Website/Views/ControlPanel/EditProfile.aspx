<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ControlPanel.Master" Inherits="System.Web.Mvc.ViewPage<CompanyName.ProductName.Modules.Forum.Website.ViewModels.EditUserProfileViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	EditProfile
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>EditProfile</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Fields</legend>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.NickName) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.NickName) %>
                <%: Html.ValidationMessageFor(model => model.NickName) %>
            </div>
            
            <p>
                <input type="submit" value="确定" />
            </p>
        </fieldset>

    <% } %>

</asp:Content>

