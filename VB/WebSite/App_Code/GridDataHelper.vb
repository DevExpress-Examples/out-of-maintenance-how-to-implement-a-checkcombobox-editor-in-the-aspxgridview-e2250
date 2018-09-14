Option Infer On

Imports System.Collections.Generic
Imports System.Collections.Specialized
Imports System.Linq

Public Class GridDataHelper
    Public Shared Function GetData() As List(Of GridDataModel)
        Return Enumerable.Range(0, 100).Select(Function(x) New GridDataModel With { _
            .ID = x, _
            .Browsers = If((x Mod 5 + 1) <> 5, GetBrowserNameByID(x) & ";" & GetBrowserNameByID(x + 1), GetBrowserNameByID(x + 1) & ";" & GetBrowserNameByID(x)) _
        }).ToList()
    End Function
    Private Shared Function GetBrowserNameByID(ByVal id As Integer) As String
        Return If((id Mod 5 + 1) = 1, "Chrome", If((id Mod 5 + 1) = 2, "Firefox", If((id Mod 5 + 1) = 3, "IE", If((id Mod 5 + 1) = 4, "Opera", "Safari"))))
    End Function
    Public Shared Sub UpdateRow(ByVal keys As OrderedDictionary, ByVal newValues As OrderedDictionary, ByVal dataSource As List(Of GridDataModel))
        dataSource.Find(Function(x) x.ID = DirectCast(keys(0), Integer)).Browsers = DirectCast(newValues("Browsers"), String)
    End Sub
    Public Shared Sub InsertRow(ByVal newValues As OrderedDictionary, ByVal dataSource As List(Of GridDataModel))
        Dim newKey = dataSource.Max(Function(x) x.ID) + 1
        dataSource.Add(New GridDataModel() With { _
            .ID = newKey, _
            .Browsers = DirectCast(newValues("Browsers"), String) _
        })
    End Sub
    Public Shared Sub DeleteRow(ByVal keys As OrderedDictionary, ByVal dataSource As List(Of GridDataModel))
        Dim item = dataSource.Find(Function(x) x.ID = DirectCast(keys(0), Integer))
        dataSource.Remove(item)
    End Sub
End Class
Public Class GridDataModel
    Public Property ID() As Integer
    Public Property Browsers() As String
End Class