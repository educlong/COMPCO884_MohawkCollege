<%@ Page Title="Medications" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="Medications.aspx.cs" Inherits="Hospital_aspnetWebApp_netFramework_WebForm.views.Medications" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <br />
    <asp:GridView ID="gvMedications" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="medication_id" DataSourceID="medicationsSqlDataSource"
        CssClass="table-condensed table-striped bg-info" AllowPaging="True" AllowSorting="True">
        <Columns>
            <asp:CommandField ShowEditButton="True" />
            <asp:BoundField DataField="medication_description" HeaderText="Description" SortExpression="medication_description"></asp:BoundField>
            <asp:BoundField DataField="medication_cost" HeaderText="Cost" SortExpression="medication_cost">
            <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="package_size" HeaderText="Package Size" SortExpression="package_size"></asp:BoundField>
            <asp:BoundField DataField="strength" HeaderText="Strength" SortExpression="strength"></asp:BoundField>
            <asp:BoundField DataField="sig" HeaderText="Sig" SortExpression="sig"></asp:BoundField>
            <asp:BoundField DataField="units_used_ytd" HeaderText="Units Used YTD" SortExpression="units_used_ytd" DataFormatString="{0:n0}">
            <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="last_prescribed_date" HeaderText="Last Prescribed" SortExpression="last_prescribed_date" DataFormatString="{0:d}"></asp:BoundField>
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource runat="server" ID="medicationsSqlDataSource" ConnectionString='<%$ ConnectionStrings:CHDBConnectionString %>' 
        DeleteCommand="DELETE FROM [medications] WHERE [medication_id] = @medication_id" 
        InsertCommand="INSERT INTO [medications] ([medication_id], [medication_description], [medication_cost], [package_size], [strength], 
                        [sig], [units_used_ytd], [last_prescribed_date]) 
                        VALUES (@medication_id, @medication_description, @medication_cost, @package_size, @strength, @sig, @units_used_ytd, 
                        @last_prescribed_date)" 
        SelectCommand="SELECT * FROM [medications]" 
        UpdateCommand="UPDATE [medications] SET [medication_description] = @medication_description, [medication_cost] = @medication_cost, 
                        [package_size] = @package_size, [strength] = @strength, [sig] = @sig, [units_used_ytd] = @units_used_ytd, 
                        [last_prescribed_date] = @last_prescribed_date WHERE [medication_id] = @medication_id">
        <DeleteParameters>
            <asp:Parameter Name="medication_id" Type="Int32"></asp:Parameter>
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="medication_id" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="medication_description" Type="String"></asp:Parameter>
            <asp:Parameter Name="medication_cost" Type="Decimal"></asp:Parameter>
            <asp:Parameter Name="package_size" Type="String"></asp:Parameter>
            <asp:Parameter Name="strength" Type="String"></asp:Parameter>
            <asp:Parameter Name="sig" Type="String"></asp:Parameter>
            <asp:Parameter Name="units_used_ytd" Type="Int32"></asp:Parameter>
            <asp:Parameter DbType="Date" Name="last_prescribed_date"></asp:Parameter>
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="medication_description" Type="String"></asp:Parameter>
            <asp:Parameter Name="medication_cost" Type="Decimal"></asp:Parameter>
            <asp:Parameter Name="package_size" Type="String"></asp:Parameter>
            <asp:Parameter Name="strength" Type="String"></asp:Parameter>
            <asp:Parameter Name="sig" Type="String"></asp:Parameter>
            <asp:Parameter Name="units_used_ytd" Type="Int32"></asp:Parameter>
            <asp:Parameter DbType="Date" Name="last_prescribed_date"></asp:Parameter>
            <asp:Parameter Name="medication_id" Type="Int32"></asp:Parameter>
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>
