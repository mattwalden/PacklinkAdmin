Imports System.Data.SqlClient

Public Class frmParts
    'Private PlinkVB
    Private myConn As SqlConnection
    Private myCmd As SqlCommand
    Private myReader As SqlDataReader
    Private results As String





    Private Sub frmParts_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        With txtParts
            .AutoCompleteCustomSource = GetPartsAutoComplete()
            .AutoCompleteMode = AutoCompleteMode.SuggestAppend
            .AutoCompleteSource = AutoCompleteSource.CustomSource

        End With

    End Sub

    Private Function GetPartsAutoComplete() As AutoCompleteStringCollection

        Dim partsList As New AutoCompleteStringCollection

        Using myConn = New SqlConnection(My.Settings.DbConnectionString)
            myCmd = New SqlCommand("select * from PacklinkDB.dbo.Sorted_Parts_List", myConn)
            myConn.Open()
            myReader = myCmd.ExecuteReader()
            While myReader.Read()
                partsList.Add(myReader.GetSqlString(0))
            End While
        End Using
        Return partsList
    End Function

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub


End Class