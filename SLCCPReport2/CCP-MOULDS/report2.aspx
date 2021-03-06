﻿<%@ Page Async="True" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="report2.aspx.cs" Inherits="CCP_MOULDS.report2" %>

<%@ Register Assembly="Syncfusion.EJ.Web" Namespace="Syncfusion.JavaScript.Web" TagPrefix="ej" %>

<%@ Register Assembly="Syncfusion.EJ" Namespace="Syncfusion.JavaScript.Models" TagPrefix="ej" %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <script src="Scripts/ej/web/ej.web.all.min.js"></script>
    <script src="Scripts/ej/WebForms/WebForms.js"></script>
    <div class="container">
        <div>
            <h2>รายงานการที่ยังไม่ได้ซ่อม เกินเวลา 
                <asp:Label ID="lbldays" runat="server" Text=""></asp:Label> &nbsp;วัน</h2>
        </div>
        <div class="control">
            <div class="row">
                <span style="font-size: 12px; color: #CC0000">(ควรเลือกไม่เกิน 1 เดือน)</span>
                <div class="col-md-1">          
                     <label>วันที่</label> 
                    </div>
                <div class="col-md-3">
                      <ej:DatePicker runat="server" ID="datePicker1" DateFormat="yyyy-MM-dd">
    </ej:DatePicker>
                    <asp:Label ID="lbl_DateSt" runat="server" Visible="False"></asp:Label>
                </div>
          </div>
            <br />
            <div class="row">
                <div class="col-md-1">
                     <label>ถึง</label>
                </div>
                <div class="col-md-3">
                    
                     <ej:DatePicker runat="server" ID="datePicker" DateFormat="yyyy-MM-dd">
    </ej:DatePicker>
                    <asp:Label ID="lbl_DateEn" runat="server" Visible="False"></asp:Label>

                         <script>

        ////bind below onClick action to button
        //function onClick() {

        //    //create instance for datePicker.
        //    // only after control creation we can get dateObj otherwise it throws exception.
        //    var dateObj = $("#datePicker").ejDatePicker('instance');
        //    dateObj.option('locale'); //returns the culture in string
        //    dateObj.option('dateFormat');// returns the date Format in string

        //    ////set value using date object
        //    //dateObj.option('value', new Date());

          
        //                }

        //                function onClick1() {

        //                    //create instance for datePicker.
                         
        //                    var dateObj1 = $("#datePicker1").ejDatePicker('instance');
        //                    dateObj1.option('locale'); //returns the culture in string
        //                    dateObj1.option('dateFormat');// returns the date Format in string

        //                    ////set value using date object
        //                    //dateObj.option('value', new Date());


        //                }
  
    </script>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-1">
                    <label>แผนก</label>
                </div>
                <div class="col-md-3">
                    <ej:ComboBox ID="cmb_dep" AllowCustom="true" DataTextField="Ptext" runat="server" Placeholder="เลือกทั้งหมด"></ej:ComboBox>
                </div>
            </div>
            <br />
        </div>
  
        <div>
      
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="ค้นหา" Height="33px" Width="100px" CssClass="btn btn-primary" />
      
        &nbsp;<asp:Label ID="lbl_mess" runat="server" style="color: #000099; font-weight: 700; font-size: small"></asp:Label>
      
        </div>
    </div>

            <div style="font-size: large">
                 </div>
               <br />
               <br />
              <asp:Label ID="lbl_num" runat="server"></asp:Label>
              <br />
              <br />
      
    <div>
        <%-- <ClientSideEvents RowDataBound="rowDataBound" />--%>       <%--   <ej:Column Field="MOULDTHICKNESS" HeaderText="ความหนาMOULD" Width="130" />--%>
  
  
        <ej:Grid ID="Grid1" runat="server" AllowScrolling="true" AllowFiltering="True" AllowPaging="false" AllowSorting="True" AllowTextWrap="True" OnServerEditRow="Grid1_ServerEditRow" OnServerExcelExporting="Grid1_ServerExcelExporting" OnServerPdfExporting="Grid1_ServerPdfExporting" OnServerWordExporting="Grid1_ServerWordExporting" Width="2500px">
        
             <ScrollSettings Width="800"/>     
            <%--Height="100"  AllowScrolling="true"--%>
            <textwrapsettings wrapmode="Content" />
            <ClientSideEvents ActionBegin="actionBegin" ActionComplete="complete" EndAdd="endAdd" EndDelete="endDelete" EndEdit="endEdit" />
            <%-- <ClientSideEvents RowDataBound="rowDataBound" />--%>
            <EditSettings AllowAdding="True" AllowDeleting="True" AllowEditing="true" EditMode="Normal" />
            <ToolbarSettings ShowToolbar="true" ToolbarItems="excelExport,wordExport,pdfExport">
            </ToolbarSettings>
            <Columns>
                <ej:Column AllowEditing="false" Field="RepairJobId" HeaderText="เลขที่ใบแจ้งซ่อม" IsPrimaryKey="true" />
                <ej:Column AllowEditing="false" Field="InternalSerial" HeaderText="รหัส QRCode" />
                <ej:Column AllowEditing="false" Field="ToolName" HeaderText="ชื่ออุปกรณ์" />
                <ej:Column AllowEditing="false" Field="Problem" HeaderText="อาการเสีย" />
                <ej:Column AllowEditing="false" Field="InformByFullname" HeaderText="ชื่อผู้แจ้งซ่อม" />
                <ej:Column AllowEditing="false" Field="InformDate" Format="{0:MM-dd-yyyy}" HeaderText="วันที่แจ้งซ่อม" />
                <ej:Column AllowEditing="false" Field="Remark" HeaderText="หมายเหตุของ Tool" />
                <ej:Column AllowEditing="false" Field="RepairTagId" HeaderText="TagId" />
                <ej:Column AllowEditing="false" Field="RepairDangerTagId" HeaderText="DangerTagId" />
                <ej:Column AllowEditing="false" Field="ReturnDate" Format="{0:MM-dd-yyyy}" HeaderText="วันที่ซ่อมเสร็จ" />
                <ej:Column AllowEditing="false" Field="RepairType" HeaderText="สถานะใบแจ้งซ่อม" />
                <ej:Column AllowEditing="false" Field="RatingScore" HeaderText="คะแนนประเมิน" />
                <ej:Column AllowEditing="false" Field="UserComment" HeaderText="ประเมิน" />
                <ej:Column AllowEditing="false" Field="CommentBy" HeaderText="ผู้ประเมิน" />
                <ej:Column AllowEditing="false" Field="FailureCode" HeaderText="รหัสอาการเสีย" />
                <ej:Column AllowEditing="false" Field="FailureDescriptionEng" HeaderText="รายละเอียดอาการเสียEN" />
                <ej:Column AllowEditing="false" Field="FailureDescriptionTha" HeaderText="รายละเอียดอาการเสียTH" />
                <ej:Column AllowEditing="false" Field="RepairCode" HeaderText="รหัสการซ่อม" />
                <ej:Column AllowEditing="false" Field="RepairDescriptionEng" HeaderText="รายละเอียดอาการซ่อมEN" />
                <ej:Column AllowEditing="false" Field="RepairDescriptionTha" HeaderText="รายละเอียดอาการซ่อมTH" />
                <ej:Column AllowEditing="false" Field="RootCause" HeaderText="สาเหตุ"/>
                <ej:Column AllowEditing="false" Field="Solution" HeaderText="วิธีแก้ไข" />
                <ej:Column AllowEditing="false" Field="Engineer" HeaderText="ชื่อช่าง" />
            <ej:Column AllowEditing="true" Field="RemarkText" HeaderText="RemarkText" Width="100"/>
                <%--   <ej:Column Field="MOULDTHICKNESS" HeaderText="ความหนาMOULD" Width="130" />--%><%--     Format="{0:C}"--%>
            </Columns>
            <%--    <ScrollSettings Height="250" Width="500"></ScrollSettings>--%>
        </ej:Grid>



        <%--     Format="{0:C}"--%>

        <script type="text/javascript">
            //function rowDataBound(args) {

            //    if (args.data.TRN22.includes("ราคาขึ้นต่ำ"))
            //    { }
            //        else {
            //        if (args.data.TRN22.includes("บาท"))
            //            args.row.css("backgroundColor", "#FFFFCC").css("color", "blue").css("size", "16");/*custom css applied to the row */
            //    }
            //}
            function actionBegin(args) {
                if (args.requestType == "beginEdit") {
                    this.columns[1].visible = true
                    this.columns[2].visible = true
                    this.columns[3].visible = true
                    this.columns[4].visible = true
                    this.columns[5].visible = true
                    this.columns[6].visible = true
                    this.columns[7].visible = true
                    this.columns[8].visible = true
                }
            }
         
        </script>
        <br />
        <asp:Button ID="Button2" runat="server" Height="33px" OnClick="Button2_Click" Text="SAVE" Width="100px" CssClass="btn btn-success" />
        <asp:Label ID="lbl_save" runat="server" style="color: #000066; font-weight: 700"></asp:Label>
    </div>
</asp:Content>

