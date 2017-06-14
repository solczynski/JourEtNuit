<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/frontoffice.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="JourEtNuit.Pages.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="landscape">
        <div class="page">
            <div class="page-content">
                <div class="page-title">Titre de la vignette</div>
                <div class="col1">
                    <img src="../images/fullwidth.png" />
                </div>
            </div>
        </div>
        <div class="page">
            <div class="page-content">
                <div class="page-title2">Titre de la vignette</div>
                <div class="col2">
                    <img src="../images/halfwidth.png" />
                    <img src="../images/halfwidth.png" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
