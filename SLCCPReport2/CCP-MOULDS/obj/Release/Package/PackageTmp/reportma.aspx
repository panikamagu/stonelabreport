<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="reportma.aspx.cs" Inherits="CCP_MOULDS.reportma" %>

<%@ Register Assembly="Syncfusion.EJ.Web" Namespace="Syncfusion.JavaScript.Web" TagPrefix="ej" %>

<%@ Register Assembly="Syncfusion.EJ" Namespace="Syncfusion.JavaScript.Models" TagPrefix="ej" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
       <script src="Scripts/ej/web/ej.web.all.min.js"></script>
    <script src="Scripts/ej/WebForms/WebForms.js"></script>
     <div class="container">
           <div>
            <h2>รายงาน MA History  
                </h2>
        </div>
           <div class="control">
            <div class="row"> <span style="font-size: 12px; color: #CC0000">(ควรเลือกไม่เกิน 1 เดือน)</span>
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

        //bind below onClick action to button
        function onClick() {

            //create instance for datePicker.
            // only after control creation we can get dateObj otherwise it throws exception.
            var dateObj = $("#datePicker").ejDatePicker('instance');
            dateObj.option('locale'); //returns the culture in string
            dateObj.option('dateFormat');// returns the date Format in string

            ////set value using date object
            //dateObj.option('value', new Date());

          
                        }

                        function onClick1() {

                            //create instance for datePicker.
                         
                            var dateObj1 = $("#datePicker1").ejDatePicker('instance');
                            dateObj1.option('locale'); //returns the culture in string
                            dateObj1.option('dateFormat');// returns the date Format in string

                            ////set value using date object
                            //dateObj.option('value', new Date());


                        }
  
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
            <asp:Button ID="btn_search" runat="server" Height="31px" OnClick="btn_en_Click" Width="133px" Text="ค้นหา" CssClass="btn btn-primary" />
        </div> 
         <br />
         <div>
             <ej:TreeGrid runat="server" ID="TreeGridControlDefault"
                 ChildMapping="Children" TreeColumnIndex="1" AllowTextWrap="True" DetailsRowHeight="150"
                 AllowSorting="True" AllowSearching="True" AllowFiltering="True" OnServerExcelExporting="TreeGridControlDefault_ServerExcelExporting"
                 OnServerPdfExporting="TreeGridControlDefault_ServerPdfExporting" ActionComplete="actionComplete" IdMapping="Id" ParentIdMapping="ParentId" IsResponsive="true"
                 AllowSelection="False">

	<%--  <EditSettings AllowEditing="true" EditMode="DialogEditing"/>   --%>
     <ToolbarSettings ShowToolbar="true" ToolbarItems="add,edit,cancel,excelExport,pdfExport">
            </ToolbarSettings>	
     <columns>
		    <ej:TreeGridColumn HeaderText="เลขที่ครุภัณฑ์" Field="InternalSerial" Width="100" AllowEditing="false"/>
			<ej:TreeGridColumn HeaderText="หมายเหตุของ Tool" Field="ToolName" Width="200" AllowEditing="false"/>
			<ej:TreeGridColumn HeaderText="ชื่อ Tool" Field="ToolRemark" Width="200" AllowEditing="false"/>
			<ej:TreeGridColumn HeaderText="วันที่ทำจริง" Field="Actualdate"  Format="{0:MM-dd-yyyy HH:mm:ss}" Width="120" AllowEditing="false"/>
            <ej:TreeGridColumn HeaderText="ผู้ที่ Submit" Field="SubmitBy" Width="80" AllowEditing="false"/>
            <ej:TreeGridColumn HeaderText="รายการผ่าน" Field="NumPass" Width="80" AllowEditing="false"/>
            <ej:TreeGridColumn HeaderText="Delay" Field="Delay" Width="45" AllowEditing="false"/>
            <ej:TreeGridColumn HeaderText="Remark" Field="Remark" Width="60" AllowEditing="true"/>
          <ej:TreeGridColumn HeaderText="RemarkText" Field="RemarkText"  AllowEditing="true"/>
		</columns>            
	</ej:TreeGrid>


            


<script> 



    function actionComplete(args) {
        if (args.requestType == "addNewRow") {
            args.model.columns[0].allowEditing = false;
            args.model.columns[1].allowEditing = false;

        }
    }
    function actionBegin(args) {
        if (args.requestType = "add") {
            args.model.columns[0].allowEditing = true;
            args.model.columns[1].allowEditing = true;
        }

      
    } 
</script>

         </div>

         <div>

      


         </div>
         <div>
             <script type="text/javascript"> 
                 function clickme() {
                     var treeObj = $("#TreeGridContainer").ejTreeGrid("instance"),
                         //to get the checked items collection 
                         checkedItems = treeObj.model.columns[7];
                     alert(checkedItems);
                 }     
</script> 
         </div>

         </div>

</asp:Content>


