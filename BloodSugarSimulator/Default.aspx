<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BloodSugarSimulator._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Select a menu</h1>
    <ul style="font-size: 20px">
        <li><a href="./CsvValues.aspx">CSV Values</a></li>
        <li><a href="./TextOutput.aspx">Text Output</a></li>
        <li><a href="./GraphicOutput.aspx">Graphic Output</a></li>
    </ul>

</asp:Content>
