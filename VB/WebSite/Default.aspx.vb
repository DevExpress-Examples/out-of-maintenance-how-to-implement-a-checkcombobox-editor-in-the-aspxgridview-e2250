Imports System
Imports System.Web
Imports DevExpress.Web.ASPxGridView
Imports DevExpress.Web
Imports System.Collections.Generic
Imports DevExpress.Web.Data
Imports System.ComponentModel

Partial Public Class _Default
    Inherits System.Web.UI.Page

    Public Property dataSource() As List(Of GridDataModel)
        Get
            If HttpContext.Current.Session("gridData") Is Nothing Then
                HttpContext.Current.Session("gridData") = GridDataHelper.GetData()
            End If
            Return CType(HttpContext.Current.Session("gridData"), List(Of GridDataModel))
        End Get
        Set(ByVal value As List(Of GridDataModel))
            HttpContext.Current.Session("gridData") = value
        End Set
    End Property
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
        grid.DataSource = dataSource
        grid.DataBind()
    End Sub

    Protected Sub grid1_RowUpdating(ByVal sender As Object, ByVal e As ASPxDataUpdatingEventArgs)
        GridDataHelper.UpdateRow(e.Keys, e.NewValues, dataSource)
        CancelEdit(TryCast(sender, ASPxGridView), e)
    End Sub

    Protected Sub grid_RowDeleting(ByVal sender As Object, ByVal e As ASPxDataDeletingEventArgs)
        GridDataHelper.DeleteRow(e.Keys, dataSource)
        CancelEdit(TryCast(sender, ASPxGridView), e)
    End Sub

    Protected Sub grid_RowInserting(ByVal sender As Object, ByVal e As ASPxDataInsertingEventArgs)
        GridDataHelper.InsertRow(e.NewValues, dataSource)
        CancelEdit(TryCast(sender, ASPxGridView), e)
    End Sub
    Protected Sub CancelEdit(ByVal grid As ASPxGridView, ByVal e As CancelEventArgs)
        grid.CancelEdit()
        e.Cancel = True
    End Sub
End Class
