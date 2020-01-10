<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Liga.aspx.cs" Inherits="FussballLiga.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<!DOCTYPE html>

<script runat="server">
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<body style="padding:25px">
    <table>
          <tr>
            <th style="padding:0 15px 0 15px;"> Mannschaft </th>
            <th style="padding:0 15px 0 15px;"> Siege </th>
            <th style="padding:0 15px 0 15px;"> Niederlagen </th>
            <th style="padding:0 15px 0 15px;"> Unentschieden </th>
            <th style="padding:0 15px 0 15px;"> Heimtore </th>
            <th style="padding:0 15px 0 15px;"> Auswaertstore </th>
            <th style="padding:0 15px 0 15px;"> Differenz </th>
          </tr>
        <asp:Repeater ID="LigaTabelle" runat="server">
            <ItemTemplate>
                    <tr><td style="padding:0 15px 0 15px;"><asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>' /></td>
                    <td style="padding:0 15px 0 15px;"><asp:Label ID="lblSiege" runat="server" Text='<%# Eval("Siege") %>' /></td>
                    <td style="padding:0 15px 0 15px;"><asp:Label ID="lblNiederlagen" runat="server" Text='<%# Eval("Niederlagen") %>' /></td>
                    <td style="padding:0 15px 0 15px;"><asp:Label ID="lblUnentschieden" runat="server" Text='<%# Eval("Unentschieden") %>' /></td>     
                    <td style="padding:0 15px 0 15px;"><asp:Label ID="lblHeimtore" runat="server" Text='<%# Eval("HTore") %>' /></td>
                    <td style="padding:0 15px 0 15px;"><asp:Label ID="lblAuswaertstore" runat="server" Text='<%#  Eval("ATore") %>' /></td> 
                    <td style="padding:0 15px 0 15px;"><asp:Label ID="lblDifferenz" runat="server" Text='<%# Eval("Differenz") %>' /></td></tr>          
            </ItemTemplate>
        </asp:Repeater>
    </table></br>
    <asp:Label Font-Size="Large" Text="Mannschaft hinzufuegen" runat="server"/><br/>
    <asp:TextBox id="MannschaftName" runat="server" />
    <asp:Button id="MannschaftHinzufuegen" Text="Mannschaft Hinzufuegen" runat="server" ValidationGroup="Sichern"  OnClick="MannschaftHinzufuegen_Click"/>   
    <asp:CustomValidator ID="Dupli" runat="server" ControlToValidate="MannschaftName" ValidationGroup="Sichern" ErrorMessage="Name bereits vorhanden" ForeColor="Red" Display="Dynamic" OnServerValidate="Dupli_ServerValidate"></asp:CustomValidator>
    <div style="height: 20px;">
    <asp:Label Font-Size="Large" Text="Speichern" runat="server"/><br/>
    <asp:Button id="Speichern" Text="Speichern" runat="server" OnClick="Speichern_Click"/>
</body>
</html>
</asp:Content>
