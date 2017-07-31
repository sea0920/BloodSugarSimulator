<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GraphicOutput.aspx.cs" Inherits="BloodSugarSimulator.GraphicOutput" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <script src="https://code.highcharts.com/highcharts.js"></script>
    <script src="https://code.highcharts.com/modules/exporting.js"></script>

    <asp:Repeater runat="server" ID="rptDays" OnItemDataBound="rptDays_OnItemDataBound">
        <ItemTemplate runat="server">
            <div id="container_<asp:Literal runat="server" ID="ltlContainerId" />" style="min-width: 310px; height: 400px; margin: 0 auto"></div>
            <script type="text/javascript">
                Highcharts.chart('container_<asp:Literal runat="server" ID="ltlContainerId2" />', {
                    chart: {
                        type: 'area'
                    },
                    title: {
                        text: 'Blood Sugar and Glycation on <asp:Literal runat="server" ID="ltlDay" />'
                    },
                    xAxis: {
                        title: {
                            text: 'Hour'
                        },
                        allowDecimals: false,
                        labels: {
                            formatter: function () {
                                return Math.floor(this.value / 60);
                            }
                        }
                    },
                    yAxis: {
                        title: {
                            text: 'Blood Sugar / Glycation'
                        },
                        labels: {
                            formatter: function () {
                                return this.value;
                            }
                        }
                    },
                    tooltip: {
                        pointFormat: '{series.name} is <b>{point.y}</b><br/> at the minute {point.x}'
                    },
                    plotOptions: {
                        area: {
                            pointStart: 0,
                            marker: {
                                enabled: false,
                                symbol: 'circle',
                                radius: 2,
                                states: {
                                    hover: {
                                        enabled: true
                                    }
                                }
                            }
                        }
                    },
                    series: [{
                        name: 'Blood Sugar',
                        data: [<asp:Literal runat="server" ID="ltlBloodSugarCsv" />]
                    }, {
                        name: 'Glycation',
                        data: [<asp:Literal runat="server" ID="ltlGlycationCsv" />]
                    }]
                });
            </script>
        </ItemTemplate>
    </asp:Repeater>
    
</asp:Content>
