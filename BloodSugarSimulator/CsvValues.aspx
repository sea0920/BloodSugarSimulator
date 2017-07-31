<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CsvValues.aspx.cs" Inherits="BloodSugarSimulator.CsvValues" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <table>
        <tr>
            <th>
                Input Type
                </th>
            <th>
                ID
                </th>
            <th>
                TimeStamp
                </th>
            <th>
                Name
                </th>
            <th>
                DateTime
                </th>
        </tr>
    <asp:Repeater runat="server" ID="rptInput" OnItemDataBound="rptInput_OnItemDataBound">
        <ItemTemplate runat="server">
            <tr>
                <td>
                    <asp:Literal runat="server" ID="ltlInputType" />
                 </td>
                <td>
                    <asp:Literal runat="server" ID="ltlID" />
                 </td>
                <td>
                    <asp:Literal runat="server" ID="ltlTimeStamp" />
                 </td>
                <td>
                    <asp:Literal runat="server" ID="ltlName" />
                 </td>
                <td>
                    <asp:Literal runat="server" ID="ltlDateTime" />
                 </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
    </table>
    <hr />

    <table>
        <tr>
            <th>
                ID
                </th>
            <th>
                Exercise
                </th>
            <th>
                Exercise Index
                </th>
        </tr>
    <asp:Repeater runat="server" ID="rptExerciseDB" OnItemDataBound="rptExerciseDB_OnItemDataBound">
        <ItemTemplate runat="server">
            <tr>
                <td>
                    <asp:Literal runat="server" ID="ltlID" />
                 </td>
                <td>
                    <asp:Literal runat="server" ID="ltlExercise" />
                 </td>
                <td>
                    <asp:Literal runat="server" ID="ltlExerciseIndex" />
                 </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
    </table>
    <hr />

    <table>
        <tr>
            <th>
                ID
                </th>
            <th>
                Exercise
                </th>
            <th>
                Glycemic Index
                </th>
        </tr>
    <asp:Repeater runat="server" ID="rptFoodDB" OnItemDataBound="rptFoodDB_OnItemDataBound">
        <ItemTemplate runat="server">
            <tr>
                <td>
                    <asp:Literal runat="server" ID="ltlID" />
                 </td>
                <td>
                    <asp:Literal runat="server" ID="ltlName" />
                 </td>
                <td>
                    <asp:Literal runat="server" ID="ltlGlycemicIndex" />
                 </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
    </table>
</asp:Content>
