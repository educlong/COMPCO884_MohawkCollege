<%@ Page Title="ActivePurchaseOrder" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ActivePurchaseOrder.aspx.cs" Inherits="Hospital_aspnetWebApp_netFramework_WebForm.views.ActivePurchaseOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <div>Department 
        <asp:DropDownList ID="ddlistDepartment" runat="server" DataSourceID="departmentSqlDataSource"
            DataTextField="department_name" DataValueField="department_id" 
            AutoPostBack="True">
        </asp:DropDownList>
        <asp:SqlDataSource runat="server" ID="departmentSqlDataSource" ConnectionString='<%$ ConnectionStrings:CHDBConnectionString %>' 
            SelectCommand="SELECT [department_id], [department_name] FROM [departments]"></asp:SqlDataSource>
    </div>
    <asp:GridView ID="gvPurchaseOrder" runat="server" AutoGenerateColumns="False" DataKeyNames="purchase_order_id" 
        DataSourceID="purchaseOrderSqlDataSource"
        CssClass="table-condensed table-striped bg-info" AllowPaging="True" AllowSorting="True">
        <Columns>
            <asp:BoundField DataField="order_date" HeaderText="Order Date" SortExpression="order_date" DataFormatString="{0:d}"></asp:BoundField>
            <asp:BoundField DataField="total_amount" HeaderText="Total Amount" SortExpression="total_amount">
                <ItemStyle HorizontalAlign="Right"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="order_status" HeaderText="Order Status" SortExpression="order_status">
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="vendor_name" HeaderText="Vendor Name" SortExpression="vendor_name"></asp:BoundField>
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource runat="server" ID="purchaseOrderSqlDataSource" ConnectionString='<%$ ConnectionStrings:CHDBConnectionString %>' 
        SelectCommand="SELECT purchase_orders.purchase_order_id, purchase_orders.order_date, purchase_orders.department_id, 
                        purchase_orders.total_amount, purchase_orders.order_status, 
                        vendors.vendor_name FROM purchase_orders INNER JOIN vendors ON purchase_orders.vendor_id = vendors.vendor_id 
                        WHERE (purchase_orders.department_id = @department_id) AND (purchase_orders.order_status = @order_status)">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlistDepartment" PropertyName="SelectedValue" Name="department_id" Type="Int32"></asp:ControlParameter>
            <asp:Parameter DefaultValue="ACTIVE" Name="order_status" Type="String"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
