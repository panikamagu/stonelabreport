<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MAremark.aspx.cs" Inherits="CCP_MOULDS.MAremark" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <script src="Scripts/ej/web/ej.web.all.min.js"></script>
    <script src="Scripts/ej/WebForms/WebForms.js"></script>
     <div class="container">
           <div>
            <h2>กรอกหมายเหตุ MA ล่าช้า</h2>   
               <asp:Label ID="lblST" runat="server" Text=""></asp:Label>
                      <asp:Label ID="lblEN" runat="server" Text=""></asp:Label>
        </div>
           <div class="control">
            <div class="row">
                  <div class="col-md-5">          
                      <br />
                      <label>DocId</label>
                      <asp:Label ID="DocId" runat="server" Text="DocId"></asp:Label>
                      <br />
                       <label>เลขที่ครุภัณฑ์</label> <asp:Label ID="TInternalSerial" runat="server" Text="InternalSerial"></asp:Label>
                        <br />
                       <label>หมายเหตุของ Tool</label><asp:Label ID="TToolRemark" runat="server" Text="ToolRemark"></asp:Label>
                     
                        <br />
                       <label>ชื่อ Tool</label> <asp:Label ID="TToolName" runat="server" Text="ToolName"></asp:Label>
                        <br />
                       <label>วันที่ทำจริง</label> <asp:Label ID="TActualdate" runat="server" Text="Actualdate"></asp:Label>
                        <br />
                        <label>ผู้ที่ Submit</label> <asp:Label ID="TSubmitBy" runat="server" Text="SubmitBy"></asp:Label>
                        <br />
                        <br />
                       <label>Remark</label> 
                      <br />
                      <asp:TextBox ID="TRemark" runat="server" TextMode="MultiLine" Placeholder="กรุณากรอกหมายเหตุ" Height="143px" Width="444px"></asp:TextBox>

                      <br />
                      <br />
        
       <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="กลับไปยังหน้ารายงาน" Height="33px" Width="167px" CssClass="btn btn-primary" />
      
        <asp:Button ID="Button2" runat="server" Height="33px" OnClick="Button2_Click" Text="SAVE" Width="100px" CssClass="btn btn-success" />
        <asp:Label ID="lbl_save" runat="server" style="color: #000066; font-weight: 700"></asp:Label>


                      <br />

                </div>

                </div>
               </div>


         </div>
</asp:Content>
