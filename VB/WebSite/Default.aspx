<%@ Page Language="vb" AutoEventWireup="true"  CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.3, Version=9.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.3, Version=9.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
	<title>GridCheckComboBox Emulation</title>
	<script type="text/javascript">
		var textSeparator = ",";

		function OnGridSelectionChanged(Grid, args, checkComboBox) {
			UpdateText(Grid, checkComboBox);
		}
		var _checkComboBox;
		function UpdateText(checkGrid, checkComboBox) {
			_checkComboBox = checkComboBox;
			checkGrid.GetSelectedFieldValues('CategoryID;CategoryName', OnGetSelectedFieldValues);
		}
		function OnGetSelectedFieldValues(items) {
			var texts = [];
			for (var i = 0; i < items.length; i++)
				texts.push(items[i][0]);
			texts.join(textSeparator);
			_checkComboBox.SetText(texts);
		}

		function SynchronizeGridValues(dropDown, args, checkGrid) {
			var values = dropDown.GetText().split(textSeparator); 
			checkGrid.UnselectAllRowsOnPage();
			checkGrid.SelectRowsByKey(values);
			//UpdateText(checkGrid, dropDown);  // for remove non-existing texts
		}
	</script>
</head>
<body>
	<form id="form1" runat="server">
		<div>
			<dx:ASPxGridView ID="grid1" runat="server" AutoGenerateColumns="False" DataSourceID="AccessDataSource1">
				<Columns>
					<dx:GridViewDataTextColumn FieldName="CategoryID" ReadOnly="True" VisibleIndex="0">
						<EditFormSettings Visible="False" />
					</dx:GridViewDataTextColumn>
					<dx:GridViewDataTextColumn Caption="test" VisibleIndex="1">
						<DataItemTemplate>
							<dx:ASPxGridView ID="grid2" runat="server" AutoGenerateColumns="False" DataSourceID="AccessDataSource1">
								<Columns>
									<dx:GridViewDataTextColumn FieldName="CategoryID" ReadOnly="True" VisibleIndex="0">
										<EditFormSettings Visible="False" />
									</dx:GridViewDataTextColumn>
									<dx:GridViewDataTextColumn Caption="test" VisibleIndex="1">
										<DataItemTemplate>
											<dx:ASPxDropDownEdit ID="ddE" runat="server" OnInit="ddE_Init">
												<DropDownWindowTemplate>
													<dx:ASPxGridView ID="grid" runat="server" AutoGenerateColumns="False" KeyFieldName="CategoryID"
														DataSourceID="AccessDataSource1" SettingsBehavior-AllowMultiSelection="True"
														OnInit="grid_Init">
														<Columns>
															<dx:GridViewCommandColumn ShowSelectCheckbox="True" VisibleIndex="0">
															</dx:GridViewCommandColumn>
															<dx:GridViewDataTextColumn FieldName="CategoryID" VisibleIndex="1">
															</dx:GridViewDataTextColumn>
															<dx:GridViewDataTextColumn FieldName="CategoryName" VisibleIndex="2">
															</dx:GridViewDataTextColumn>
														</Columns>
														<SettingsPager Mode="ShowAllRecords" />
													</dx:ASPxGridView>
													<table style="width: 100%"><tr><td align="right">
														<dx:ASPxButton ID="btn" runat="server" Text="close" AutoPostBack="false" OnInit="btn_Init">
														</dx:ASPxButton>
													</td></tr></table>
												</DropDownWindowTemplate>
											</dx:ASPxDropDownEdit>
										</DataItemTemplate>
									</dx:GridViewDataTextColumn>
								</Columns>
								<SettingsPager Mode="ShowAllRecords" />
							</dx:ASPxGridView>
						</DataItemTemplate>
					</dx:GridViewDataTextColumn>
				</Columns>
				<SettingsPager Mode="ShowAllRecords" />
			</dx:ASPxGridView>
			<asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="~/App_Data/nwind.mdb"
				SelectCommand="SELECT [CategoryID], [CategoryName] FROM [Categories]"></asp:AccessDataSource>
		</div>
	</form>
</body>
</html>