Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports mcrLog.NLog

Public Class frmDBLogin

#Region "Data"
    Private sModuleName As String = "frmLogin"
    Private bTestConnection As Boolean = False
    Private bShowAdvanced As Boolean = False
#End Region

#Region "Load-Unload"

    Private Sub frmDBLogin_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim dbIntegratedSecurity As Boolean = True                       'Parametres de conexio DB
        Dim dbSource As String = ""
        Dim dbDatabase As String = ""
        Dim dbTimeout As Integer = 5000
        Dim dbUser As String = ""
        Dim dbPassword As String = ""
        Dim bConnected As Boolean
        Dim bsimulation As Boolean

        Try
            Call mcrDB.dbGetConnectionParameters(dbSource, dbDatabase, dbIntegratedSecurity, dbUser, dbPassword, dbTimeout, bConnected, bSimulation)

            cmbServerName.Text = dbSource
            cmbDatabase.Text = dbDatabase
            txtTimeOut.Text = CStr(dbTimeout)

            If dbIntegratedSecurity Then
                radIntegratedSecurity.Checked = True
                radUserPassword.Checked = False
                txtPassword.Enabled = False
                txtUser.Enabled = False
                txtPassword.Text = ""
                txtUser.Text = ""
            Else
                radIntegratedSecurity.Checked = False
                radUserPassword.Checked = True
                txtPassword.Enabled = True
                txtUser.Enabled = True
                txtUser.Text = dbUser
                txtPassword.Text = dbPassword
            End If

            If mcrDB.dbConnected Then
                lbStatusDB.Text = "Connected"
                lbStatusDB.ForeColor = Drawing.Color.Green
            Else
                lbStatusDB.Text = "Disconnected"
                lbStatusDB.ForeColor = Drawing.Color.Red
            End If

        Catch ex As Exception
           logFatal(myApp, sModuleName, "frmDBLogin_Load", ex, "")
        End Try
    End Sub


    Private Sub btnAccept_Click(sender As System.Object, e As System.EventArgs) Handles btnAccept.Click
        Dim dbIntegratedSecurity As Boolean = True                       'Parametres de conexio DB
        Dim dbSource As String = ""
        Dim dbDatabase As String = ""
        Dim dbTimeout As Integer = 5000
        Dim dbUser As String = ""
        Dim dbPassword As String = ""
        Dim bSimulation As Boolean

        Try
            If bTestConnection Then
                If radIntegratedSecurity.Checked Then
                    dbIntegratedSecurity = True
                    dbPassword = ""
                    dbUser = ""
                Else
                    dbIntegratedSecurity = False
                    dbPassword = txtPassword.Text
                    dbUser = txtUser.Text
                End If

                dbSource = cmbServerName.Text.Trim
                dbDatabase = cmbDatabase.Text.Trim
                dbTimeout = CInt(txtTimeOut.Text)

                bSimulation = mcrDB.dbSimulation

                mcrDB.dbSetConnectionParameters(dbSource, dbDatabase, dbIntegratedSecurity, dbUser, dbPassword, dbTimeout, True, bSimulation)

                Me.Close()
            End If

        Catch ex As Exception
           logFatal(myApp, sModuleName, "btnAccept_Click", ex, "")
        End Try

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            Me.Close()
        Catch ex As Exception
           logFatal(myApp, sModuleName, "btnCancel_Click", ex, "")
        End Try
    End Sub

#End Region

#Region "Button-Options"

    Private Sub btnTestConnection_Click(sender As System.Object, e As System.EventArgs) Handles btnTestConnection.Click

        Try

            If dbConnectTest() Then
                lbStatusDB.Text = "Connected"
                lbStatusDB.ForeColor = Drawing.Color.Green
                bTestConnection = True
                btnAccept.Enabled = True
            Else
                lbStatusDB.Text = "Disconnected"
                lbStatusDB.ForeColor = Drawing.Color.Red
                bTestConnection = False
                btnAccept.Enabled = False
            End If

        Catch ex As Exception
           logFatal(myApp, sModuleName, "btnTestConnection_Click", ex, "")
        End Try
    End Sub

    Private Function dbConnectTest() As Boolean
        Dim con As New SqlClient.SqlConnection
        Dim strCon As String = "(NULL)"

        Dim bResult As Boolean = False

        Try

            If radIntegratedSecurity.Checked Then
                strCon = "Data Source= " & cmbServerName.Text & "; " &
                         "Initial Catalog= " & cmbDatabase.Text & "; " &
                         "Integrated Security = True; " &
                         "Connect Timeout= " & txtTimeOut.Text
            Else
                strCon = "Data Source= " & cmbServerName.Text & "; " &
                         "Initial Catalog= " & cmbDatabase.Text & "; " &
                         "User id= " & txtUser.Text & "; " &
                         "Password= " & txtPassword.Text & "; " &
                         "Connect Timeout= " & txtTimeOut.Text
            End If

            con.ConnectionString = strCon
            con.Open()

            bResult = True

        Catch ex As Exception
           logFatal(myApp, sModuleName, "dbConnectTest", ex, "")
            bResult = False

        Finally
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            dbConnectTest = bResult
        End Try

    End Function

    Private Sub btnAdvancedOptions_Click(sender As System.Object, e As System.EventArgs) Handles btnAdvancedOptions.Click

        Try
            If bShowAdvanced Then
                'Hide advanced options
                bShowAdvanced = False
                btnAdvancedOptions.Text = "Show advanced options"
                Me.Height = 260
            Else
                'Show advanced options
                bShowAdvanced = True
                btnAdvancedOptions.Text = "Hide advanced options"
                Me.Height = 600
            End If
        Catch ex As Exception
           logFatal(myApp, sModuleName, "btnAdvancedOptions_Click", ex, "")
        End Try

    End Sub

    Private Sub btnServerList_Click(sender As System.Object, e As System.EventArgs) Handles btnServerList.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            ' Retrieve the enumerator instance and then the data.
            Dim instance As SqlDataSourceEnumerator = SqlDataSourceEnumerator.Instance
            Dim table As System.Data.DataTable = instance.GetDataSources()
            Dim sInstance As String, sServer As String, sSQL As String

            ' Display the contents of the table.
            cmbServerName.Items.Clear()

            For Each row As DataRow In table.Rows
                sServer = CStr(row("ServerName"))
                If Not IsDBNull(row("InstanceName")) Then
                    sSQL = CStr(row("InstanceName"))
                    sInstance = sServer & "\" & sSQL
                Else
                    sInstance = sServer
                End If
                cmbServerName.Items.Add(sInstance)
            Next

        Catch ex As Exception
           logFatal(myApp, sModuleName, "btnServerList_Click", ex, "")
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub radIntegratedSecurity_Click(sender As Object, e As System.EventArgs) Handles radIntegratedSecurity.Click

        Try
            txtPassword.Enabled = False
            txtUser.Enabled = False
            txtPassword.Text = ""
            txtUser.Text = ""

        Catch ex As Exception
           logFatal(myApp, sModuleName, "radIntegratedSecurity_Click", ex, "")
        End Try

    End Sub

    Private Sub radUserPassword_Click(sender As System.Object, e As System.EventArgs) Handles radUserPassword.Click

        Try
            txtPassword.Enabled = True
            txtUser.Enabled = True

        Catch ex As Exception
           logFatal(myApp, sModuleName, "radUserPassword_Click", ex, "")
        End Try

    End Sub

    Private Sub txtTimeOut_LostFocus(sender As Object, e As System.EventArgs) Handles txtTimeOut.LostFocus
        Dim iValue As Integer

        Try

            iValue = CInt(txtTimeOut.Text)
            If (iValue < 2) Then txtTimeOut.Text = "2"
            If (iValue > 60) Then txtTimeOut.Text = "60"

        Catch ex As Exception
           logFatal(myApp, sModuleName, "txtTimeOut_LostFocus", ex, "")
        End Try
    End Sub



    Private Sub btnDatabaseList_Click(sender As System.Object, e As System.EventArgs) Handles btnDatabaseList.Click
        Dim sLlista() As String, iNum As Integer

        Try
            Me.Cursor = Cursors.WaitCursor
            sLlista = dataBaseList()
            iNum = sLlista.Length

            cmbDatabase.Items.Clear()

            For i = 1 To iNum
                cmbDatabase.Items.Add(sLlista(i - 1))
            Next

        Catch ex As Exception
           logFatal(myApp, sModuleName, "btnDatabaseList_Click", ex, "")
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Function dataBaseList() As String()

        ' Las bases de dades sistema SQL Server
        Dim aBasesSys() As String = {"master", "model", "msdb", "tempdb"}
        Dim aBases() As String
        Dim dt As New DataTable
        Dim sCon As String

        If radIntegratedSecurity.Checked Then
            sCon = "Data Source= " & cmbServerName.Text & "; " &
                   "Initial Catalog= master; " &
                   "Integrated Security = True; " &
                   "Connect Timeout= " & txtTimeOut.Text
        Else
            sCon = "Data Source= " & cmbServerName.Text & "; " &
                   "Initial Catalog= master;" &
                   "User id= " & txtUser.Text & "; " &
                   "Password= " & txtPassword.Text & "; " &
                   "Connect Timeout= " & txtTimeOut.Text
        End If

        Dim sel As String = "SELECT name FROM sysdatabases"

        Try
            Dim da As New SqlDataAdapter(sel, sCon)
            da.Fill(dt)
            ReDim aBases(dt.Rows.Count - 1)

            Dim k As Integer = -1
            For i As Integer = 0 To dt.Rows.Count - 1
                Dim s As String = dt.Rows(i).Item("name").ToString()
                ' Solo asignar las bases que no son del sistema
                If Array.IndexOf(aBasesSys, s) = -1 Then
                    k += 1
                    aBases(k) = s
                End If
            Next

            If k = -1 Then Return Nothing
            ReDim Preserve aBases(k)
            Return aBases

        Catch ex As Exception
           logFatal(myApp, sModuleName, "dataBaseList", ex, "")
            Return Nothing
        End Try

    End Function


#End Region



End Class