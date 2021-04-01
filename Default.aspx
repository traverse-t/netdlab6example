<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LAB06___Travis_Thaxter._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Incorporeal Incorporated</h1>
        <p class="lead">We here at Incorporeal Incorporated ensure the utmost of integrity in all aspects of our business.</p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <asp:LoginView runat="server" ViewStateMode="Disabled">
                <AnonymousTemplate>
                    <a href="Account/Login.aspx" class="btn btn-primary">Login</a>
                    <a href="Account/Register.aspx" class="btn btn-primary">Register</a>
                </AnonymousTemplate>
                <LoggedInTemplate>
                    <a href="Payroll" class="btn btn-primary">Payroll</a>
                    <a href="Summary" class="btn btn-primary">Summary</a>
                    <a href="EmployeeList" class="btn btn-primary">Employee List</a>
                </LoggedInTemplate>
            </asp:LoginView>
        </div>
    </div>

</asp:Content>
