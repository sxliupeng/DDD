<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<CompanyName.ProductName.Modules.Forum.Website.ViewModels.RegisterViewModel>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>蜘蛛侠论坛真诚欢迎您的加入...</legend>

            <div class="editor-label">
                <%: Html.LabelFor(model => model.MemberName) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.MemberName)%>
                <%: Html.ValidationMessageFor(model => model.MemberName)%>
            </div>

            <div class="editor-label">
                <%: Html.LabelFor(model => model.Password) %>
            </div>
            <div class="editor-field">
                <%: Html.PasswordFor(model => model.Password) %>
                <%: Html.ValidationMessageFor(model => model.Password) %>
            </div>

            <div class="editor-label">
                <%: Html.LabelFor(model => model.ConfirmPassword) %>
            </div>
            <div class="editor-field">
                <%: Html.PasswordFor(model => model.ConfirmPassword)%>
                <%: Html.ValidationMessageFor(model => model.ConfirmPassword) %>
            </div>

            <p>
                <input type="submit" value="确定" />
            </p>
        </fieldset>

        <%: Html.ValidationSummary(true) %>
    <% } %>

</body>
</html>

