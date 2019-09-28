<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Sample.Default" %>

<%@ Register TagPrefix="ej" Namespace="Syncfusion.JavaScript.Models" Assembly="Syncfusion.EJ" %>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
     <div>
        <h2>รายงาน MOULD</h2>
     </div>
  <div>
        <%--  <ej:ComboBox ID="cb_Group" runat="server" DataTextField="textg" Placeholder="ทั้งหมด"></ej:ComboBox>--%>
        <br />
        <br />

        <div>
            <asp:Label ID="Label1" runat="server" Text="โรงงาน" Width="60px"></asp:Label>
            <%-- ,wordExport,pdfExport--%>&nbsp;
            <asp:DropDownList ID="cb_Plant1" runat="server" CssClass="form-control" Font-Size="Medium" Height="32px" Width="300px" OnSelectedIndexChanged="cb_Plant1_SelectedIndexChanged" >
            </asp:DropDownList>
          
            
        </div>
        <div>

        </div>

         <br />

         <div>

        </div>
        <div>
<asp:Label ID="Label2" runat="server" Text="ประเภท" Width="60px"></asp:Label>
            <%--     Format="{0:C}"--%>&nbsp;<asp:DropDownList ID="cb_Group1" runat="server" CssClass="form-control" Font-Size="Medium" Height="32px" Width="300px" AutoPostBack="True" OnSelectedIndexChanged="cb_Group1_SelectedIndexChanged" >
            </asp:DropDownList>
        </div>
         <div>
            
            <br />
            
            <ej:Button ID="btn_Find" CssClass="btn btn-info" runat="server" Text="ค้นหา" OnClick="btn_Find_Click" Size="Medium" Width="100">
            </ej:Button>

            &nbsp;<asp:Label ID="lbl_error"  runat="server" ForeColor="#000099"></asp:Label>

             <asp:Button ID="btn_Add" runat="server" Height="45px" OnClick="btn_Add_Click" Text="+" Width="50px" Visible="False" />
&nbsp;</div>
         <div>

        </div>
        <br />
        <strong>
        <asp:Panel ID="Panel1" runat="server" Visible="False">

            <table style="width:100%;">
                <tr>
                    <td><strong>ประเภท
                        <asp:Label ID="lbl_Idgroup" runat="server" Visible="False"></asp:Label>
                        </strong></td>
                    <td><strong>รหัสMOULD</strong></td>
                    <td><strong>รายละเอียดMOULD</strong></td>
                    <td><strong>ขนาดMOULD</strong></td>
                    <td><strong>ความหนาMOULD</strong></td>
                    <td><strong>จำนวนMOULD</strong></td>
                    <td><strong>รหัส</strong></td>
                    <td><strong>PLANT</strong></td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td><strong>
                        <asp:TextBox ID="txt_group" runat="server" Enabled="False" Height="25px" style="font-size: 10pt" Width="130px"></asp:TextBox>
                        </strong></td>
                    </strong>
                    <td>
                        <asp:Label ID="lbl_idmould" runat="server" style="font-size: 10pt" Text="-" Width="120px"></asp:Label>
                    </td>
                    <strong>
                    <td><strong>
                        <asp:TextBox ID="txt_DetailM" runat="server" Height="25px" style="font-size: 11pt" Width="300px"></asp:TextBox>
                        </strong></td>
                    <td><strong>
                        <asp:TextBox ID="txt_sizeM" runat="server" Height="25px" style="font-size: 11pt" Width="130px"></asp:TextBox>
                        </strong></td>
                    <td><strong>
                        <asp:TextBox ID="txt_THICKM" runat="server" Height="25px" style="font-size: 11pt" Width="140px"></asp:TextBox>
                        </strong></td>
                    <td><strong>
                        <asp:TextBox ID="txt_qtym" runat="server" Height="25px" style="font-size: 11pt" Width="130px"></asp:TextBox>
                        </strong></td>
                    <td><strong>
                        <asp:TextBox ID="txt_PlantId" runat="server" Enabled="False" Height="25px" style="font-size: 10pt" Width="60px"></asp:TextBox>
                        </strong></td>
                    <td><strong>
                        <asp:TextBox ID="txt_Plant" runat="server" Enabled="False" Height="25px" style="font-size: 10pt" Width="110px"></asp:TextBox>
                        </strong></td>
                    <td><strong>
                        <asp:Button ID="btn_Add_a" runat="server" Height="30px" OnClick="btn_Add_a_Click" Text="Add" Width="60px" />
                        </strong></td>
                    </strong>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td><strong>
                        <asp:Button ID="btn_Cancel" runat="server" Height="30px" OnClick="btn_Cancel_Click" Text="Cancel" Width="60px" />
                        </strong></td>
                </tr>
            </table>
        </asp:Panel>
        <br />
        <br />
        <%-- <script>
       function click(args) {
           var gridObj = $("#<%= Grid.ClientID %>").data("ejGrid");
              gridObj.print();
           }
       </script>
    </asp:Content>--%>
        <ej:Grid ID="FlatGrid" runat="server"  OnServerWordExporting="FlatGrid_ServerWordExporting" OnServerPdfExporting="FlatGrid_ServerPdfExporting" OnServerExcelExporting="FlatGrid_ServerExcelExporting" AllowFiltering="True" AllowSorting="True" >
            
              <EditSettings AllowAdding="True" AllowDeleting="True"></EditSettings>
               <ToolbarSettings ShowToolbar="true" ToolbarItems="excelExport"></ToolbarSettings> 
             
           <Columns>
                <ej:Column Field="GROUPMOULDNAME" HeaderText="ประเภท" Width="120" />
                <ej:Column Field="MOULDID" HeaderText="รหัสMOULD" Width="100"/>
                <ej:Column Field="MOULDDESCRIPTION" HeaderText="รายละเอียดMOULD" Width="250"/>
                <ej:Column Field="MOULDSIZE" HeaderText=" ขนาดMOULD" Width="120" />
                <ej:Column Field="MOULDTHICKNESS" HeaderText="ความหนาMOULD" Width="130"/> 
             <%--     Format="{0:C}"--%>
                     <ej:Column Field="MOULDEA" HeaderText="จำนวนMOULD" Width="120"/>
                         <ej:Column Field="PLANTID" HeaderText="รหัสPLANT"  Width="100"/>
                         <ej:Column Field="PLANTNAME" HeaderText="PLANT"  Width="100"/>
                     
            </Columns>

        </ej:Grid>
     </div>
     </strong>
</asp:Content>
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
     <%-- <script>
       function click(args) {
           var gridObj = $("#<%= Grid.ClientID %>").data("ejGrid");
              gridObj.print();
           }
       </script>
    </asp:Content>--%>
      <%--</asp:Content>--%>

   <%-- <asp:Content ID="ScriptContent" runat="server" ContentPlaceHolderID="ScriptSection">--%>
    
  <%-- </asp:Content>--%>

    <%-- <ToolbarSettings ShowToolbar="true" ToolbarItems="printGrid">
               <CustomToolbarItem>
                    <ej:CustomToolbarItem TemplateID="#Refresh" />
                </CustomToolbarItem>
           </ToolbarSettings>
            <ClientSideEvents ToolbarClick="onToolBarClick" ActionBegin="action" />--%>
 <%--<script id="Refresh" type="text/x-jsrender">
        <a class="e-toolbaricons refresh" />
    </script>
    <script type="text/javascript">
        function onToolBarClick(sender) {
            if(sender.itemName == "Refresh")
                this.refreshContent();
        }
        function action(args) {
        if(args.requestType == "print")
            this.model.allowScrolling = true;
        }
    </script>
<style type="text/css" class="cssStyles">
        .refresh {
            background-position: -76px 3px;
        }
        .e-toolbaricons {
            background-image: url("Themes/common-images/icons-gray.png");
        }
         .Expand:hover, .Collapse:hover, .refresh:hover {
            background-image: url("Themes/common-images/icons-white.png");
        }
    </style>--%>

 <%--<div>
         
        <ej:Grid ID="Grid" runat="server" AllowPaging="True" AllowSorting="True" AllowGrouping="True" OnServerWordExporting="Grid_ServerWordExporting" OnServerPdfExporting="Grid_ServerPdfExporting" OnServerExcelExporting="Grid_ServerExcelExporting">
            <ToolbarSettings ShowToolbar="true" ToolbarItems="excelExport,wordExport,pdfExport"></ToolbarSettings>
            <Columns>
                <ej:Column Field="OrderID" HeaderText="Order ID" Width="75" TextAlign="Right"/>
                <ej:Column Field="CustomerID" Width="80"/>
                <ej:Column Field="Freight" HeaderText="Freight" Format="{0:C}" TextAlign="Right"  Width="75"/>
                <ej:Column Field="OrderDate" Format="{0:MM/dd/yyyy}"  Width="80" TextAlign="Right"/>
                <ej:Column Field="ShipCity" HeaderText="Ship City" Width="110"/>
           </Columns>   
         </ej:Grid>
     </div>--%>
<%--</asp:Content>--%>