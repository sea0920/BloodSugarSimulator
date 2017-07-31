<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TextOutput.aspx.cs" Inherits="BloodSugarSimulator.TextOutput" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <table>
        <tr>
            <td>
                <table>
                    <tr>
                        <th>
                            DateTime
                        </th>
                        <th>
                            Blood Sugar
                        </th>
                    </tr>
                <asp:Repeater runat="server" ID="rptBloodSugar" OnItemDataBound="rptBloodSugar_OnItemDataBound">
                    <ItemTemplate runat="server">
                        <tr>
                            <td style="padding:0 20px 0 0">
                                <asp:Literal runat="server" ID="ltlDateTime" />
                             </td>
                            <td style="padding:0 20px 0 0">
                                <asp:Literal runat="server" ID="ltlLevel" />
                             </td>
                            
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                </table>
            </td>
            <td>
                <table>
                    <tr>
                        <th>
                            Glycation
                            </th>
                    </tr>
                <asp:Repeater runat="server" ID="rptGlycation" OnItemDataBound="rptGlycation_OnItemDataBound">
                    <ItemTemplate runat="server">
                        <tr>
                            <td style="padding:0 20px 0 0">
                                <asp:Literal runat="server" ID="ltlLevel" />
                             </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                </table>

            </td>
        </tr>
    </table>
    
</asp:Content>
