<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestUI.aspx.cs" Inherits="HtmlUIWeb.TestUI" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2016.2.607.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>
<%@ Register TagPrefix="ns" Namespace="NeuroSystem.Workflow.UserData.UI.Html.ASP.UI.Html.Widgets" Assembly="NeuroSystem.Workflow.UserData.UI.Html.ASP" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
    <div>
        <ns:NsPanel ID="panel" runat="server"/>
    </div>
    </form>
</body>
</html>
