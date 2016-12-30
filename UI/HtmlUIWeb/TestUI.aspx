<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestUI.aspx.cs" Inherits="HtmlUIWeb.TestUI" %>
<%@ Register TagPrefix="ns" Namespace="NeuroSystem.UI.HtmlUIWidgets.AspUI.Html.Widgets" Assembly="NeuroSystem.UI.HtmlUIWidgets" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2016.2.607.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>

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
