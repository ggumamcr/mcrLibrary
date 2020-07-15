Public Class frmDBInfo

#Region "Data"
    Private sModuleName As String = "frmLogin"

#End Region


#Region "Load-Start"
    Private Sub frmInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dbIntegratedSecurity As Boolean = True                       'Parametres de conexio DB
        Dim dbSource As String = ""
        Dim dbDatabase As String = ""
        Dim dbTimeout As Integer = 5000
        Dim dbUser As String = ""
        Dim dbPassword As String = ""
        Dim bConnected As Boolean = False
        Dim bSimulation As Boolean = False

        Try
            Call mcrDB.dbGetConnectionParameters(dbSource, dbDatabase, dbIntegratedSecurity, dbUser, dbPassword, dbTimeout, bConnected, bSimulation)

            txtServer.Text = dbSource
            txtDatabase.Text = dbDatabase
            txtTimeOut.Text = CStr(dbTimeout)

            If dbIntegratedSecurity Then
                radIntegratedSecurity.Checked = True
                radUserPassword.Checked = False
                txtPassword.Text = ""
                txtUser.Text = ""
            Else
                radIntegratedSecurity.Checked = False
                radUserPassword.Checked = True
                txtUser.Text = dbUser
                txtPassword.Text = dbPassword
            End If

            chkConnected.Checked = CBool(IIf(bConnected, True, False))
            chkSimulation.Checked = CBool(IIf(bSimulation, True, False))

        Catch ex As Exception
            mcrLog.NLog.LogFatal(myApp, sModuleName, "frmInfo_Load", ex, "")
        End Try
    End Sub

#End Region


End Class