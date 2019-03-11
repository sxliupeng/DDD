<%@ control language="C#" inherits="System.Web.Mvc.ViewUserControl" %>
<%@ import namespace="CompanyName.ProductName.Modules.Forum.Website" %>

<script type="text/javascript">
    function toggle(e) {
        //获取onclick事件
        e = e || window.event;

        //获取tab的title元素
        var title = e.target || e.srcElement;
        if (title == null) return;

        //获取tab的subtab元素，并设置展开或折叠样式
        var parent = title.parentElement || title.parentNode;
        var subTab = null;
        for (var i = 0; i < parent.childNodes.length; i++) {
            if (parent.childNodes[i].tagName == 'UL') {
                subTab = parent.childNodes[i];
            }
        }
        if (subTab == null) return;

        //下面仅仅通过判断subtab是展开或折叠来决定应该要展开还是折叠
        if (subTab.className.indexOf('show') > 0) {
            title.className = title.className.replace('expand', 'collapse');
            subTab.className = subTab.className.replace('show', 'hide');
        }
        else if (subTab.className.indexOf('hide') > 0) {
            title.className = title.className.replace('collapse', 'expand');
            subTab.className = subTab.className.replace('hide', 'show');
        }

    }
</script>

<div class="navbarcontainer">
    <div class="navbar">
        <div class="tab">
            <div class="title expand" onclick="toggle(event)">
                基本资料
            </div>
            <ul class="subtab show">
                <li class="itemContainer">
                    <div class="item">
                        <%: Html.ActionLink("控制面板首页", "Index", "ControlPanel")%>
                    </div>
                </li>
                <li class="itemContainer">
                    <div class="item">
                        <%: Html.ActionLink("基本资料", "EditProfile", "ControlPanel")%>
                    </div>
                </li>
                <li class="lastItemContainer">
                    <div class="item">
                        <%: Html.ActionLink("修改头像", "EditAvatar", "ControlPanel")%>
                    </div>
                </li>
            </ul>
        </div>
        <div class="tab">
            <div class="title expand" onclick="toggle(event)">
                帖子管理
            </div>
            <ul class="subtab show">
                <li class="itemContainer">
                    <div class="item">
                        <%: Html.ActionLink("我发表的帖子", "MyThreads", "ThreadManage")%>
                    </div>
                </li>
                <li class="itemContainer">
                    <div class="item">
                        <%: Html.ActionLink("我回复的帖子", "MyReplyThreads", "ThreadManage")%>
                    </div>
                </li>
                <li class="itemContainer">
                    <div class="item">
                        <%: Html.ActionLink("我未结的帖子", "MyOpenThreads", "ThreadManage")%>
                    </div>
                </li>
                <li class="lastItemContainer">
                    <div class="item">
                        <%: Html.ActionLink("我已结的帖子", "MyCloseThreads", "ThreadManage")%>
                    </div>
                </li>
            </ul>
        </div>
    </div>
</div>
