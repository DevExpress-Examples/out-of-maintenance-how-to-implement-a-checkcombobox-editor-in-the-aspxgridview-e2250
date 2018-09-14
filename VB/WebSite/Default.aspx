<%@ Page Language="vb" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>GridCheckComboBox Emulation</title>
    <script type="text/javascript">
        var textSeparator = ";";
        function OnListBoxSelectionChanged(listBox, args) {
            if (args.index == 0)
                args.isSelected ? listBox.SelectAll() : listBox.UnselectAll();
            UpdateSelectAllItemState();
            UpdateText();
        }
        function UpdateSelectAllItemState() {
            IsAllSelected() ? checkListBox.SelectIndices([0]) : checkListBox.UnselectIndices([0]);
        }
        function IsAllSelected() {
            var selectedDataItemCount = checkListBox.GetItemCount() - (checkListBox.GetItem(0).selected ? 0 : 1);
            return checkListBox.GetSelectedItems().length == selectedDataItemCount;
        }
        function UpdateText() {
            var selectedItems = checkListBox.GetSelectedItems();
            checkComboBox.SetText(GetSelectedItemsText(selectedItems));
        }
        function SynchronizeListBoxValues(dropDown, args) {            
            checkListBox.UnselectAll();
            var texts = dropDown.GetText().split(textSeparator);
            var values = GetValuesByTexts(texts);
            checkListBox.SelectValues(values);
            UpdateSelectAllItemState();
            UpdateText(); // for remove non-existing texts
        }
        function GetSelectedItemsText(items) {
            var texts = [];
            for (var i = 0; i < items.length; i++)
                if (items[i].index != 0)
                    texts.push(items[i].text);
            return texts.join(textSeparator);
        }
        function GetValuesByTexts(texts) {
            var actualValues = [];
            var item;
            for (var i = 0; i < texts.length; i++) {
                item = checkListBox.FindItemByText(texts[i]);
                if (item != null)
                    actualValues.push(item.value);
            }
            return actualValues;
        }
        function onEditClick(s, e) {
            grid.StartEditRow(grid.GetFocusedRowIndex());
        }
        function onInsertClick(s, e) {
            grid.AddNewRow();
        }
        function onDeleteClick(s, e) {
            grid.DeleteRow(grid.GetFocusedRowIndex());
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <dx:ASPxButton runat="server" ID="ASPxButton1" Text="Edit Focused Row" AutoPostBack="false">
                <ClientSideEvents Click="onEditClick"/>
            </dx:ASPxButton>
            <dx:ASPxButton runat="server" ID="ASPxButton2" Text="Add New Row" AutoPostBack="false">
                <ClientSideEvents Click="onInsertClick"/>
            </dx:ASPxButton>
            <dx:ASPxButton runat="server" ID="ASPxButton3" Text="Delete Focused Row" AutoPostBack="false">
                <ClientSideEvents Click="onDeleteClick"/>
            </dx:ASPxButton>
            <dx:ASPxGridView ID="grid" ClientInstanceName="grid" runat="server" AutoGenerateColumns="False" KeyFieldName="ID"
                OnRowUpdating="grid1_RowUpdating" OnRowDeleting="grid_RowDeleting" OnRowInserting="grid_RowInserting">
                <SettingsBehavior AllowFocusedRow="true"/>
                <Columns>
                    <dx:GridViewDataTextColumn FieldName="ID" ReadOnly="True" VisibleIndex="0">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataDropDownEditColumn FieldName="Browsers" VisibleIndex="1">
                        <PropertiesDropDownEdit ClientInstanceName="checkComboBox" AnimationType="None" Width="285px">
                            <DropDownWindowStyle BackColor="#EDEDED" />
                                <DropDownWindowTemplate>
                                    <dx:ASPxListBox Width="100%" ID="listBox" ClientInstanceName="checkListBox" SelectionMode="CheckColumn"
                                        runat="server" Height="180">
                                        <Border BorderStyle="None" />
                                        <BorderBottom BorderStyle="Solid" BorderWidth="1px" BorderColor="#DCDCDC" />
                                        <Items>
                                            <dx:ListEditItem Text="(Select all)" />
                                            <dx:ListEditItem Text="Chrome" Value="1" />
                                            <dx:ListEditItem Text="Firefox" Value="2" />
                                            <dx:ListEditItem Text="IE" Value="3" />
                                            <dx:ListEditItem Text="Opera" Value="4" />
                                            <dx:ListEditItem Text="Safari" Value="5" />
                                        </Items>
                                        <ClientSideEvents SelectedIndexChanged="OnListBoxSelectionChanged" />
                                    </dx:ASPxListBox>
                                    <table style="width: 100%">
                                        <tr>
                                            <td style="padding: 4px">
                                                <dx:ASPxButton ID="ASPxButton1" AutoPostBack="False" runat="server" Text="Close" Style="float: right">
                                                    <ClientSideEvents Click="function(s, e){ checkComboBox.HideDropDown(); }" />
                                                </dx:ASPxButton>
                                            </td>
                                        </tr>
                                    </table>
                                </DropDownWindowTemplate>
                                <ClientSideEvents Init="SynchronizeListBoxValues" TextChanged="SynchronizeListBoxValues" DropDown="SynchronizeListBoxValues" />
                        </PropertiesDropDownEdit>                        
                    </dx:GridViewDataDropDownEditColumn>
                </Columns>                
            </dx:ASPxGridView>            
        </div>
    </form>
</body>
</html>