<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="Country.aspx.cs" Inherits="BCA_Project.Country" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <div class="d-flex justify-content-between align-items-center mb-4">
            <h2>Country List</h2>
            <a href="CountryAddEdit.aspx" class="btn btn-success">Add Country</a>
        </div>
        <div class="table-responsive">
            <table class="table table-bordered">
                
                <tbody>
                <asp:GridView ID="gvCountry" runat="server" AutoGenerateColumns="False" 
                    CssClass="table table-striped">
                <Columns>
                    <asp:BoundField DataField="CountryID" HeaderText="Country ID" />
                    <asp:BoundField DataField="CountryName" HeaderText="Country Name" />
                    <asp:BoundField DataField="CountryCode" HeaderText="Country Code" />
                <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>
                    <a href='CountryAddEdit.aspx?CountryID=<%# Eval("CountryID") %>' 
                        class='btn btn-primary btn-sm'>Edit</a>
                    <a href='Country.aspx?CountryID=<%# Eval("CountryID") %>' 
                        class='btn btn-danger btn-sm'>Delete</a>
                </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
                </tbody>
            </table>
        </div>
    </div>
</asp:Content>
