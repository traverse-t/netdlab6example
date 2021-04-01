<%@ Page Title="Summary" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Summary.aspx.cs" Inherits="LAB06___Travis_Thaxter.Summary" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <p>Total Workers: <asp:Label ID="lblTotalWorkers" runat="server" /></p>
    <p>Total Messages: <asp:Label ID="lblCumulativeMessages" runat="server" /></p>
    <p>Cumulative Worker Pay: <asp:Label ID="lblCumulativePay" runat="server" /></p>
    <p>Average Worker Pay: <asp:Label ID="lblAveragePay" runat="server" /></p>
</asp:Content>
