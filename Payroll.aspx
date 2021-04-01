<%@ Page Title="Payroll" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Payroll.aspx.cs" Inherits="LAB06___Travis_Thaxter.Payroll" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <p>
        Worker First Name: <asp:TextBox ID="txtFirstName" runat="server" ToolTip="Enter the worker's first name." /> 
        <asp:RegularExpressionValidator ControlToValidate="txtFirstName" ErrorMessage="First name must be at least 2 latin alphabetic characters." runat="server" ValidationExpression="^[a-zA-Z]{2}[a-zA-Z]*$" ForeColor="#CC3300" />
        <asp:RequiredFieldValidator ControlToValidate="txtFirstName" ErrorMessage="You must enter a first name." runat="server" ForeColor="#CC3300" />
    </p>
    <p>
        Worker Last Name: <asp:TextBox ID="txtLastName" runat="server" ToolTip="Enter the worker's last name." /> 
        <asp:RegularExpressionValidator ControlToValidate="txtLastName" ErrorMessage="Last name must be at least 2 latin alphabetic characters." runat="server" ValidationExpression="^[a-zA-Z]{2}[a-zA-Z]*$" ForeColor="#CC3300" />
        <asp:RequiredFieldValidator ControlToValidate="txtLastName" ErrorMessage="You must enter a last name." runat="server" ForeColor="#CC3300" />
    </p>
    <p>
        Messages Sent: <asp:TextBox ID="txtMessagesSent" runat="server" ToolTip="Enter the messages sent by the worker." /> 
        <asp:RegularExpressionValidator ControlToValidate="txtMessagesSent" ErrorMessage="Input must be a whole number." runat="server" ValidationExpression="^\d+$" ForeColor="#CC3300" />
        <asp:RangeValidator ControlToValidate="txtMessagesSent" ErrorMessage="Input must be in range 1 to 20000." runat="server" MinimumValue="1" MaximumValue="20000" Type ="Integer" ForeColor="#CC3300"  />
        <asp:RequiredFieldValidator ControlToValidate="txtMessagesSent" ErrorMessage="This field cannot be left blank." runat="server" ForeColor="#CC3300" />
    </p>
    <p>
        <asp:RadioButtonList ID="rblWorkerType" runat="server" ToolTip="Select your worker classification">
            <asp:ListItem Selected="True" Value="Regular" >Regular Worker (Plebeians)</asp:ListItem>
            <asp:ListItem Value="Senior">Senior Worker (Important)</asp:ListItem>
        </asp:RadioButtonList>
    </p>
    <p><asp:Label ID="lblError" runat="server" /></p>
    <p>
        <asp:Button ID="btnCalculate" runat="server" Text="Calculate" OnClick="BtnCalculate_Click" />
        <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="BtnClear_Click" CausesValidation="false" />
    </p>
    <p><asp:Label ID="lblPay" runat="server" /></p>
</asp:Content>
