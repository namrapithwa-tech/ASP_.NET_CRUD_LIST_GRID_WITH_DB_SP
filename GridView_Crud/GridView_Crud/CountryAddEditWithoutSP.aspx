<%@ Page Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="CountryAddEditWithoutSP.aspx.cs" Inherits="GridVIew_Crud.CountryAddEditWithoutSP" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div class="container mt-5">
    <h2>
      <asp:Label ID="lblTitle" runat="server" Text="Add Country" />
    </h2>
    <asp:Panel ID="pnlForm" runat="server" CssClass="mt-4">
      <asp:TextBox
        ID="txtCountryName"
        runat="server"
        CssClass="form-control"
        Placeholder="Country Name"
      />
      <asp:TextBox
        ID="txtCountryCode"
        runat="server"
        CssClass="form-control mt-2"
        Placeholder="Country Code"
      />

      <asp:Button
        ID="btnSave"
        runat="server"
        Text="Save"
        CssClass="btn btn-primary mt-3"
        OnClick="btnSave_Click"
      />
      <asp:Button
        ID="btnCancel"
        runat="server"
        Text="Cancel"
        CssClass="btn btn-secondary mt-3"
        OnClick="btnCancel_Click"
      />
    </asp:Panel>
  </div>
</asp:Content>
