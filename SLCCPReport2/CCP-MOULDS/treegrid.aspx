<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="treegrid.aspx.cs" Inherits="CCP_MOULDS.treegrid" %>

<%@ Register Assembly="Syncfusion.EJ.Web" Namespace="Syncfusion.JavaScript.Web" TagPrefix="ej" %>

<%@ Register Assembly="Syncfusion.EJ" Namespace="Syncfusion.JavaScript.Models" TagPrefix="ej" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
       <script src="Scripts/ej/web/ej.web.all.min.js"></script>
    <script src="Scripts/ej/WebForms/WebForms.js"></script>

       <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />

     <ej:TreeGrid runat="server" ID="TreeGridControlDefault" ChildMapping="Children"
            TreeColumnIndex="1" BeginEdit="beginEdit" EndEdit="endEdit">
            <EditSettings AllowEditing="true" AllowAdding="true" AllowDeleting="true" EditMode="DialogEditing" />
            <ToolbarSettings ShowToolbar="true" ToolbarItems="add,edit,delete,update,cancel,expandAll,collapseAll,search" />
            <Columns>
                <ej:TreeGridColumn HeaderText="Task Id" Field="TaskId" Width="45" />
                <ej:TreeGridColumn HeaderText="Task Name" Field="TaskName" />
                <ej:TreeGridColumn HeaderText="Start Date" Field="StartDate" />
                <ej:TreeGridColumn HeaderText="End Date" Field="EndDate" />
                <ej:TreeGridColumn HeaderText="Duration" Field="Duration" />
                <ej:TreeGridColumn HeaderText="Progress" Field="Progress" />
              
            </Columns>
            <SelectionSettings SelectionMode="Row" EnableSelectAll="true" EnableHierarchySelection="true" />
        </ej:TreeGrid>

  
    <script type="text/javascript">
        function beginEdit(args) {
            if (args.columnIndex == 1)
                args.cancel = true;
        }

        function endEdit(args) {
            //To perform actions after editing
            alert("F");
        }
</script>

</asp:Content>
