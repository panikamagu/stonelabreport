<%@ Page Async="True" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Data.aspx.cs" Inherits="CCP_MOULDS.Data" %>

<%@ Register Assembly="Syncfusion.EJ.Web" Namespace="Syncfusion.JavaScript.Web" TagPrefix="ej" %>

<%@ Register Assembly="Syncfusion.EJ" Namespace="Syncfusion.JavaScript.Models" TagPrefix="ej" %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <script src="Scripts/ej/web/ej.web.all.min.js"></script>
    <script src="Scripts/ej/WebForms/WebForms.js"></script>
    <div class="container">
        <div>
            <h2>ค่าขนส่งต่อระยะทาง
                </h2>
        </div>
        <div class="control">
            <div class="row">
                <div class="col-md-1">
                    <label>จังหวัด</label>
                </div>
                <div class="col-md-3">

                    <ej:ComboBox ID="cmb_Province" AllowCustom="true" DataTextField="Ptext" runat="server" OnValueSelect="cmb_Province_ValueSelect1" Placeholder="กรุณาเลือกจังหวัด"></ej:ComboBox>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-1">
                    <label>อำเภอ</label>
                </div>
                <div class="col-md-3">
                    <ej:ComboBox ID="cmb_ampure" AllowCustom="true" DataValueField="Avalue" DataTextField="Atext" runat="server" OnValueSelect="cmb_ampure_ValueSelect"  Placeholder="กรุณาเลือกอำเภอ"></ej:ComboBox>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-1">
                    <label>ตำบล</label>
                </div>
                <div class="col-md-3">

                    <ej:ComboBox ID="cmb_district" AllowCustom="true" DataValueField="Dvalue" DataTextField="Dtext" runat="server" OnValueSelect="cmb_district_ValueSelect"  Placeholder="กรุณาเลือกตำบล" Enabled="False"></ej:ComboBox>
                </div>
            </div>
        </div>
        <br />
        <div>
             <ej:Button ID="ButtonLarge" runat="server" Type="Button" Text="ค้นหา" Size="Small" ShowRoundedCorner="true" ContentType="TextAndImage" PrefixIcon="e-icon e-search" OnClick="ButtonLarge_Click" Visible="False"></ej:Button>
            &nbsp;<asp:Label ID="Label5" runat="server" style="color: #000099; font-size: small">หมายเหตุ จังหวัดชลบุรี สามารถเลือกระดับตำบล จังหวัดอื่นๆ เลือกได้เพียงระดับอำเภอเท่านั้น</asp:Label>
             <asp:Label ID="lbl_PriceY4" runat="server" Visible="False"></asp:Label>
             <asp:Label ID="lbl_PriceY3" runat="server" Visible="False"></asp:Label>
            <br />
             <asp:Label ID="l_IDprovince" runat="server" Text="0" Visible="False"></asp:Label>
             <asp:Label ID="l_IDampur" runat="server" Text="0" Visible="False"></asp:Label>
             <asp:Label ID="l_IDdistrict" runat="server" Text="0" Visible="False"></asp:Label>
            <br />        
        </div>
    </div>
     <br />
            <div style="font-size: large">
                 <strong>
                 <asp:Label ID="Label3" runat="server" Text="จังหวัด" CssClass="auto-style2"></asp:Label>
                 </strong>&nbsp;<strong><asp:Label ID="lbl_Province" runat="server" Text="-" CssClass="auto-style2"></asp:Label>
                 </strong>&nbsp;<strong><asp:Label ID="Label2" runat="server" Text="อำเภอ" CssClass="auto-style2"></asp:Label>
                 </strong>&nbsp;<strong><asp:Label ID="lbl_Ampure" runat="server" Text="-" CssClass="auto-style2"></asp:Label>
                  </strong>&nbsp;<strong><asp:Label ID="Label4" runat="server" Text="ตำบล" CssClass="auto-style2"></asp:Label>
                 </strong>&nbsp;<strong><asp:Label ID="lbl_Dictrict" runat="server" Text="-" CssClass="auto-style2"></asp:Label>
                 <span class="auto-style2">&nbsp; </span>
                 <asp:Label ID="Label1" runat="server" Text="ระยะทาง " CssClass="auto-style2"></asp:Label>
                <asp:Label ID="lbl_distance" runat="server" Text="0" CssClass="auto-style2"></asp:Label>
                 <span class="auto-style2">&nbsp;KM.</span></strong></div>
             
              <br />
      
    <div>
    <asp:Panel ID="Panel1" runat="server" Height="250px" ScrollBars="Auto" HorizontalAlign="Center"> 
       <%-- AllowTextWrap="true"
      <div id="scroll"></div> --%>
        <ej:Grid ID="Grid1" runat="server" AllowPaging="false" OnServerExcelExporting="Grid1_ServerExcelExporting" OnServerPdfExporting="Grid1_ServerPdfExporting" OnServerWordExporting="Grid1_ServerWordExporting" Width="1100" ><%--Height="100"  AllowScrolling="true"--%>
            <textwrapsettings wrapmode="Content" />
            <ClientSideEvents RowDataBound="rowDataBound" />
            <%--   <EditSettings AllowAdding="True" AllowDeleting="True" AllowEditing="True" />--%>
            <ToolbarSettings ShowToolbar="true" ToolbarItems="excelExport,wordExport,pdfExport">
            </ToolbarSettings>
            <Columns>
                 <ej:Column Field="TRN22" HeaderText="ค่าขนส่งรถ 22 ล้อ ราคาต่อ กม. By CCP"   />
                <ej:Column Field="TRN10" HeaderText="ค่าขนส่งรถ 10 ล้อ ราคาต่อ กม. By CCP" />
                <ej:Column Field="TRN6" HeaderText="ค่าขนส่งรถ 6 ล้อ ราคาต่อ กม. By กันยง"  />
                <ej:Column Field="TRN4" HeaderText="ค่าขนส่งรถ 4 ล้อใหญ่ ราคาต่อ กม. By กันยง" />
                <%--   <ej:Column Field="MOULDTHICKNESS" HeaderText="ความหนาMOULD" Width="130" />--%>
                <%--     Format="{0:C}"--%>
            </Columns>
               <%--    <ScrollSettings Height="250" Width="500"></ScrollSettings>--%>
        </ej:Grid>

  

        </asp:Panel>

        <script type="text/javascript">
            function rowDataBound(args) {

                if (args.data.TRN22.includes("ราคาขึ้นต่ำ"))
                { }
                    else {
                    if (args.data.TRN22.includes("บาท"))
                        args.row.css("backgroundColor", "#FFFFCC").css("color", "blue").css("size", "16");/*custom css applied to the row */
                }
            }

         
        </script>
        <br />
    </div>
</asp:Content>

