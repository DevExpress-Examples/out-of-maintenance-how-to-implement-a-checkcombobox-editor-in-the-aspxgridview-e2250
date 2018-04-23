Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxGridView

Partial Public Class _Default
	Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

	End Sub
	Protected Sub ddE_Init(ByVal sender As Object, ByVal e As EventArgs)
		Dim dropdownedit As ASPxDropDownEdit = TryCast(sender, ASPxDropDownEdit)
		Dim grid As ASPxGridView = TryCast(dropdownedit.NamingContainer.NamingContainer, ASPxGridView)

		Dim key As String = grid.UniqueID
		Dim visibleIndex As String = (TryCast(dropdownedit.NamingContainer, GridViewDataItemTemplateContainer)).VisibleIndex & key
		dropdownedit.ClientInstanceName = "dde" & visibleIndex

		dropdownedit.ClientSideEvents.DropDown = String.Format("function(s,e) {{ SynchronizeGridValues(s, e, grid{0});}}", visibleIndex)

		dropdownedit.ClientSideEvents.TextChanged = String.Format("function(s,e) {{SynchronizeGridValues(s, e, grid{0});}}", visibleIndex)
	End Sub
	Protected Sub btn_Init(ByVal sender As Object, ByVal e As EventArgs)
		Dim button As ASPxButton = TryCast(sender, ASPxButton)
		Dim grid As ASPxGridView = TryCast(button.NamingContainer.NamingContainer.NamingContainer.NamingContainer.NamingContainer, ASPxGridView)

		Dim key As String = grid.UniqueID
		Dim visibleIndex As String = (TryCast(button.NamingContainer.NamingContainer.NamingContainer.NamingContainer, GridViewDataItemTemplateContainer)).VisibleIndex & key

		button.ClientSideEvents.Click = String.Format("function(s, e){{dde{0}.HideDropDown();}}", visibleIndex)
	End Sub
	Protected Sub grid_Init(ByVal sender As Object, ByVal e As EventArgs)
		Dim curGrid As ASPxGridView = TryCast(sender, ASPxGridView)
		Dim grid As ASPxGridView = TryCast(curGrid.NamingContainer.NamingContainer.NamingContainer.NamingContainer.NamingContainer, ASPxGridView)

		Dim key As String = grid.UniqueID
		Dim visibleIndex As String = (TryCast(curGrid.NamingContainer.NamingContainer.NamingContainer.NamingContainer, GridViewDataItemTemplateContainer)).VisibleIndex & key
		curGrid.ClientInstanceName = "grid" & visibleIndex

		curGrid.ClientSideEvents.SelectionChanged = String.Format("function(s,e) {{ OnGridSelectionChanged(s, e, dde{0});}}", visibleIndex)
	End Sub
End Class
