Imports Microsoft.Data
Imports System.Data
Imports Microsoft.Data.SqlClient
Imports System.Xml
Imports mcrLog.NLog




Public Class mcrDB

#Region "Data"

    Private Const sModuleName As String = "mcrDB"

    Private Shared sConnectionString As String = ""                        'Memoria conexio base dades

    Private Shared _dbIntegratedSecurity As Boolean                        'Parametres de conexio DB
    Private Shared _dbSource As String
    Private Shared _dbDatabase As String
    Private Shared _dbTimeout As Integer = 2000
    Private Shared _dbUser As String
    Private Shared _dbPassword As String
    Private Shared _dbSimulation As Boolean = False

    Private Shared _dbConnected As Boolean = False                            'BD conectada. Cadena conexio correcta.


#End Region

#Region "Convert Types"
    Public Shared Function DB_Datetime(ByVal oData As Object) As DateTime
        Try
            If IsDBNull(oData) Then
                Return #1/1/1900 01:00:00 PM#
            Else
                If IsDate(oData) Then
                    Return CDate(oData)
                Else
                    Return #1/1/1900 01:00:00 PM#
                End If
            End If

        Catch ex As Exception
            LogFatal(myApp, sModuleName, "DB_Datetime", ex, "")
            Return #1/1/1900 01:00:00 PM#
        End Try
    End Function

    Public Shared Function DB_Integer(ByVal oData As Object) As Integer
        Try
            If IsDBNull(oData) Then
                Return 0
            Else
                If IsNumeric(oData) Then
                    Return CInt(oData)
                Else
                    Return 0
                End If
            End If
        Catch ex As Exception
            LogFatal(myApp, sModuleName, "DB_Integer", ex, "")
            Return 0
        End Try
    End Function

    Public Shared Function DB_Decimal(ByVal oData As Object) As Decimal
        Try
            If IsDBNull(oData) Then
                Return 0
            Else
                If IsNumeric(oData) Then
                    Return CDec(oData)
                Else
                    Return 0
                End If
            End If
        Catch ex As Exception
            LogFatal(myApp, sModuleName, "DB_Decimal", ex, "")
            Return 0
        End Try
    End Function

    Public Shared Function DB_Short(ByVal oData As Object) As Short
        Try
            If IsDBNull(oData) Then
                Return 0
            Else
                If IsNumeric(oData) Then
                    Return CShort(oData)
                Else
                    Return 0
                End If
            End If
        Catch ex As Exception
            LogFatal(myApp, sModuleName, "DB_Short", ex, "")
            Return 0
        End Try
    End Function
#End Region

#Region "Samples"

    Private Function SQL_StoredProcedure_NonQuery(ByVal objValue As String) As Boolean
        Dim bResult As Boolean = False
        Dim cnn As SqlConnection = Nothing
        Dim cmd As SqlCommand = Nothing

        Try
            cnn = New SqlConnection(sConnectionString)
            cmd = New SqlCommand("sp_InsertarVariosDatosPrueba", cnn)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@Param1", objValue)

            Dim i As Integer
            cnn.Open()
            i = cmd.ExecuteNonQuery()     'Retorna numero de files afectades

            bResult = True

        Catch ex As Exception
            LogFatal(myApp, sModuleName, "SQL_StoredProcedure_NonQuery", ex, objValue.ToString)
        Finally
            If Not (cnn Is Nothing) Then
                If cnn.State = ConnectionState.Open Then cnn.Close()
            End If
        End Try

        SQL_StoredProcedure_NonQuery = bResult

    End Function

    Private Function SQL_StoredProcedure_Scalar(ByVal objValue As String) As Integer
        Dim iResult As Integer = -1
        Dim cnn As SqlConnection = Nothing
        Dim cmd As SqlCommand = Nothing

        'Retorna id producte insertat.
        Dim storedProc As String = "INSERT INTO Production.ProductCategory (Name) VALUES (@Name); " _
               & "SELECT CAST(scope_identity() AS int);"

        Try
            cnn = New SqlConnection(sConnectionString)
            cmd = New SqlCommand(storedProc, cnn)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@Param1", objValue)

            cnn.Open()
            iResult = CInt(cmd.ExecuteScalar())

        Catch ex As Exception
            LogFatal(myApp, sModuleName, "SQL_StoredProcedure_Scalar", ex, objValue.ToString)
        Finally
            If Not (cnn Is Nothing) Then
                If cnn.State = ConnectionState.Open Then cnn.Close()
            End If
        End Try

        SQL_StoredProcedure_Scalar = iResult

    End Function

    Private Function SQL_returnDataTable_Adapter() As DataTable
        Dim cnn As SqlConnection = Nothing
        Dim cmd As SqlCommand = Nothing
        Dim dt As DataTable = Nothing
        Dim da As New SqlDataAdapter

        Try
            cnn = New SqlConnection(sConnectionString)
            cmd = New SqlCommand("SELECT * FROM HistoricFormules WHERE iStatus = 1", cnn)
            da.SelectCommand = cmd

            cnn.Open()
            da.Fill(dt)     'Si es null, retorna error.

        Catch ex As Exception
            LogFatal(myApp, sModuleName, "SQL_returnDataTable_Adapter", ex, "")
        Finally
            If Not (cnn Is Nothing) Then
                If cnn.State = ConnectionState.Open Then cnn.Close()
            End If
        End Try

        Return dt

    End Function

    Private Function SQL_returnDataTable_DataReader() As DataTable
        Dim cnn As SqlConnection = Nothing
        Dim cmd As SqlCommand = Nothing
        Dim dt As DataTable = Nothing
        Dim dr As SqlDataReader

        Try
            cnn = New SqlConnection(sConnectionString)
            cmd = New SqlCommand("SELECT * FROM HistoricFormules WHERE iStatus = 1", cnn)

            cnn.Open()
            dr = cmd.ExecuteReader()

            If dr.HasRows Then
                dt = New DataTable
                dt.Load(dr)
            End If

        Catch ex As Exception
            LogFatal(myApp, sModuleName, "SQL_returnDataTable_DataReader", ex, "")
        Finally
            If Not (cnn Is Nothing) Then
                If cnn.State = ConnectionState.Open Then cnn.Close()
            End If
        End Try

        Return dt

    End Function

#End Region

#Region "Connexion"
    Public Shared Function dbConnect() As Boolean

        Dim con As New SqlClient.SqlConnection
        Dim strCon As String = "(NULL)"

        Dim bResult As Boolean = False

        Try

            If _dbIntegratedSecurity Then
                strCon = "Data Source= " & _dbSource & "; " & _
                         "Initial Catalog= " & _dbDatabase & "; " & _
                         "Integrated Security = True; " & _
                         "Connect Timeout= " & _dbTimeout
            Else
                strCon = "Data Source= " & _dbSource & "; " & _
                         "Initial Catalog= " & _dbDatabase & "; " & _
                         "User id= " & _dbUser & "; " & _
                         "Password= " & _dbPassword & "; " & _
                         "Connect Timeout= " & _dbTimeout
            End If

            LogDebug(myApp, sModuleName, "dbConnect", "Database Connection Start " + strCon)

            If _dbSimulation Then
                'Nothing
            Else
                con.ConnectionString = strCon
                con.Open()
            End If

            LogInfo(myApp, sModuleName, "dbConnect", "Database Connection OK " + strCon)

            sConnectionString = strCon                'Memoria conexio base dades
            bResult = True

        Catch ex As Exception
            LogFatal(myApp, sModuleName, "dbConnect", ex, "(" & _dbSource & ") - (" & _dbDatabase & ")")
            bResult = False

        Finally
            If Not _dbSimulation Then
                If con.State = ConnectionState.Open Then
                    _dbConnected = True
                    con.Close()
                    bResult = True
                Else
                    bResult = False
                End If
            End If

            dbConnect = bResult
        End Try


    End Function

    Public Shared Sub dbDisconnect()

        Dim con As New SqlClient.SqlConnection
        Dim strCon As String = "(NULL)"

        Try

            LogInfo(myApp, sModuleName, "dbDisconnect", "Database Stop")

            If _dbSimulation Then
                'Nothing
            Else
                strCon = sConnectionString
                con.ConnectionString = strCon
                con.Close()
            End If

            _dbConnected = False

            LogInfo(myApp, sModuleName, "dbDisconnect", "Database Stop OK")

        Catch ex As Exception
            LogFatal(myApp, sModuleName, "dbDisconnect", ex, "")

        End Try

    End Sub

    Public Shared Sub dbGetConnectionParameters(ByRef dbSource As String, ByRef dbDatabase As String, _
                                         ByRef dbIntegratedSecurity As Boolean, _
                                         ByRef dbUser As String, ByRef dbPassword As String, _
                                         ByRef dbTimeout As Integer, ByRef bConnected As Boolean, ByRef bSimulation As Boolean)
        Try

            dbSource = _dbSource
            dbDatabase = _dbDatabase

            dbIntegratedSecurity = _dbIntegratedSecurity

            dbUser = _dbUser
            dbPassword = _dbPassword

            dbTimeout = _dbTimeout

            bConnected = _dbConnected

            bSimulation = _dbSimulation

        Catch ex As Exception
            LogFatal(myApp, sModuleName, "dbGetConnectionParameters", ex, "")
        End Try
    End Sub

    Public Overloads Shared Sub dbSetConnectionParameters(ByVal dbSource As String, ByVal dbDatabase As String, _
                                        ByVal dbIntegratedSecurity As Boolean, _
                                        ByVal dbUser As String, ByVal dbPassword As String, _
                                        ByVal dbTimeout As Integer, ByVal bTryConnect As Boolean, ByVal bSimulation As Boolean)
        Try


            _dbSource = dbSource
            _dbDatabase = dbDatabase

            _dbIntegratedSecurity = dbIntegratedSecurity

            _dbUser = dbUser
            _dbPassword = dbPassword

            _dbTimeout = dbTimeout

            _dbSimulation = bSimulation

            If bTryConnect Then
                'dbConnect(dbSource, dbDatabase, dbIntegratedSecurity, dbTimeout, dbUser, dbPassword)
                dbConnect()
            End If

        Catch ex As Exception
            LogFatal(myApp, sModuleName, "dbSetConnectionParameters", ex, "")
        End Try
    End Sub

    Public Overloads Shared Sub dbSetConnectionParameters(ByVal sConnectionString As String, ByVal dbTimeout As Integer, ByVal bTryConnect As Boolean, ByVal bSimulation As Boolean)
        Dim sSource As String
        Dim sDatabase As String
        Dim sIntegratedSecurity As String

        Dim iStart As Integer, iEnd As Integer, iLen As Integer, sSubString As String, sMatch As String

        Try
            'TODO 9 Asignar base dades en funcio de DataSource complerts
            'Data Source=JAC2014\SQL2012;Initial Catalog=mcrScada;Integrated Security=True

            sMatch = "Data Source="
            iStart = sConnectionString.IndexOf(sMatch)
            sSubString = sConnectionString.Substring(iStart + 1)
            iEnd = sSubString.IndexOf(";")
            iLen = sMatch.Length
            sSource = sConnectionString.Substring(iStart + iLen, iEnd - iStart - iLen + 1)
            _dbSource = sSource

            sMatch = "Initial Catalog="
            iStart = sConnectionString.IndexOf(sMatch)
            sSubString = sConnectionString.Substring(iStart + 1)
            iEnd = sSubString.IndexOf(";")
            iLen = sMatch.Length
            sDatabase = sConnectionString.Substring(iStart + iLen, iEnd - iStart - iLen + 1)
            _dbDatabase = sDatabase

            sMatch = "Integrated Security="
            iStart = sConnectionString.IndexOf(sMatch)
            sSubString = sConnectionString.Substring(iStart + 1)
            iEnd = sSubString.IndexOf(";")
            iLen = sMatch.Length
            sIntegratedSecurity = sConnectionString.Substring(iStart + iLen, iEnd - iStart - iLen + 1)
            If sIntegratedSecurity.ToUpper = "TRUE" Then
                _dbIntegratedSecurity = True
            Else
                _dbIntegratedSecurity = False
            End If

            '_dbUser = dbUser
            '_dbPassword = dbPassword

            _dbTimeout = dbTimeout

            _dbSimulation = bSimulation

            If bTryConnect Then
                dbConnect()
            End If

        Catch ex As Exception
            LogFatal(myApp, sModuleName, "dbSetConnectionParameters", ex, "")
        End Try
    End Sub
    Public Shared Function dbConnected() As Boolean
        Return _dbConnected
    End Function

    Public Shared Function dbSimulation() As Boolean
        Return _dbSimulation
    End Function

    Public Shared Function dbGetConnectionString() As String
        Dim strCon As String

        Try
            If _dbIntegratedSecurity Then
                strCon = "Data Source= " & _dbSource & "; " & _
                         "Initial Catalog= " & _dbDatabase & "; " & _
                         "Integrated Security = True; " & _
                         "Connect Timeout= " & _dbTimeout
            Else
                strCon = "Data Source= " & _dbSource & "; " & _
                         "Initial Catalog= " & _dbDatabase & "; " & _
                         "User id= " & _dbUser & "; " & _
                         "Password= " & _dbPassword & "; " & _
                         "Connect Timeout= " & _dbTimeout
            End If

            Return strCon

        Catch ex As Exception
            LogFatal(myApp, sModuleName, "dbGetConnectionString", ex, "(" & _dbSource & ") - (" & _dbDatabase & ")")
            Return ""
        End Try

    End Function
#End Region

#Region "Display forms"
    Public Shared Sub dbDisplayLoginForm()

        Try
            'Dim frm As New frmLogin

            'frm.MdiParent = frmMain
            'frm.ShowDialog()
            'frm.BringToFront()

            Dim frm As New frmDBLogin
            'frm.ShowDialog()

        Catch ex As Exception
            LogFatal(myApp, sModuleName, "dbDisplayLoginForm", ex, "")
        End Try

    End Sub

    Public Shared Sub dbDisplayInfoForm(ByVal frmMain As Windows.Forms.Form)

        Try
            Dim frm As New frmDBInfo

            'frm.MdiParent = frmMain
            'frm.Show()
            'frm.BringToFront()

            'frm.Show()
        Catch ex As Exception
            LogFatal(myApp, sModuleName, "dbDisplayInfoForm", ex, "")
        End Try

    End Sub

#End Region

#Region "Commands"

#Region "dbGetValue Sample"
    Private Sub dbGetValue_Sample()
        Dim cmd As New SqlCommand
        Dim oResult As Object

        Try
            'Prepare Command
            cmd.CommandText = "Select stationName from Stations WHERE idStation=1"
            cmd.CommandType = CommandType.Text

            'Execute Command
            oResult = dbGetValue(cmd, "stationName")
            If Not IsNothing(oResult) Then
                Debug.Print("Process Value")
            Else
                Debug.Print("No Value")
            End If

        Catch ex As Exception
            LogFatal(myApp, sModuleName, "dbGetValue_Sample", ex, "")
        End Try
    End Sub
#End Region
    Public Shared Function dbGetValue(ByVal cmd As SqlCommand, ByVal sField As String) As Object
        Dim cnn As New SqlConnection
        Dim oResult As Object

        Try
            'Prepare parameters
            cnn.ConnectionString = sConnectionString
            cmd.Connection = cnn

            'Execute command
            cnn.Open()
            oResult = cmd.ExecuteScalar()

            Return oResult

        Catch ex As Exception
            LogFatal(myApp, sModuleName, "dbGetValue", ex, cmd.CommandText)
            Return Nothing

        Finally
            If Not (cnn Is Nothing) Then
                If cnn.State = ConnectionState.Open Then cnn.Close()
            End If

            cnn.Dispose()
        End Try

    End Function

#Region "dbGetRow_Sample"
    Private Sub dbGetRow_Sample()
        Dim cmd As New SqlCommand
        Dim dRow As DataRow = Nothing

        Try
            'Prepare Command
            cmd.CommandText = "Select stationName from Stations WHERE idStation=1"
            cmd.CommandType = CommandType.Text

            'Execute Command
            dRow = dbGetRow(cmd)
            If Not IsNothing(cmd) Then
                Debug.Print("Process Row")
            Else
                Debug.Print("No Value")
            End If

        Catch ex As Exception
            LogFatal(myApp, sModuleName, "dbGetValue_Sample", ex, "")
        End Try
    End Sub
#End Region
    Public Shared Function dbGetRow(ByVal cmd As SqlCommand) As DataRow
        Dim cnn As New SqlConnection
        Dim dt As DataTable
        Dim dr As SqlDataReader
        Dim dRow As DataRow = Nothing

        Try
            'Prepare parameters
            cnn.ConnectionString = sConnectionString
            cmd.Connection = cnn

            'Execute command
            cnn.Open()
            dr = cmd.ExecuteReader()

            'Verify values in reader
            If dr.HasRows Then
                dt = New DataTable
                dt.Load(dr)

                'Get the first row in dataTable
                If Not IsNothing(dt) Then
                    'Hi ha una produccio activa a la base de dades. Tancar dosificacio activa
                    dRow = dt.Rows(0)
                End If

            End If
            Return dRow

        Catch ex As Exception
            LogFatal(myApp, sModuleName, "dbGetRow", ex, cmd.CommandText)
            Return Nothing

        Finally
            If Not (cnn Is Nothing) Then
                If cnn.State = ConnectionState.Open Then cnn.Close()
            End If

            cnn.Dispose()
        End Try

    End Function

#Region "dbGetDataTable Sample"
    Private Sub dbGetDataTable_Sample()
        Dim cmd As New SqlCommand, dt As New DataTable

        Try
            'Prepare Command
            cmd.CommandText = "Select * from Stations"
            cmd.CommandType = CommandType.Text                   '.StoredProcedure
            'cmd.Parameters.AddWithValue("Hola", 1)

            'Execute Command
            dt = dbGetDataTable(cmd)
            If dt.Rows.Count > 0 Then
                Debug.Print("Process Rows")
            Else
                Debug.Print("No Rows")
            End If

        Catch ex As Exception
            LogFatal(myApp, sModuleName, "dbGetDataTable_Sample", ex, "")
        End Try

    End Sub
#End Region
    Public Shared Function dbGetDataTable(ByVal cmd As SqlCommand) As DataTable
        Dim sqlDTable As New DataTable
        Dim cnn As SqlConnection = Nothing
        Dim sqlDAdapter As New SqlDataAdapter

        Try
            'Prepare parameters
            cnn = New SqlConnection(sConnectionString)
            cmd.Connection = cnn
            sqlDAdapter.SelectCommand = cmd

            'Execute command
            'TODO 9 Perque es diferent process dataTable a dataReader, en quan a operacions despres del open (aqui servir sqldataadapter i a exemple reader no).
            cnn.Open()
            sqlDAdapter.Fill(sqlDTable)

            'Return DataTable
            Return sqlDTable

        Catch ex As Exception
            LogFatal(myApp, sModuleName, "dbGetDataTable", ex, cmd.CommandText)
            Return Nothing

        Finally
            If Not (cnn Is Nothing) Then
                If cnn.State = ConnectionState.Open Then cnn.Close()
            End If

            sqlDAdapter.Dispose()
            cnn.Dispose()
        End Try

    End Function

#Region "dbGetDadaReader Sample"

    Private Sub dbGetDataReader_Sample()
        Dim cmd As New SqlCommand, dt As New DataTable

        Try
            'Prepare Command
            cmd.CommandText = "Select * from Stations"
            cmd.CommandType = CommandType.Text                   '.StoredProcedure
            'cmd.Parameters.AddWithValue("Hola", 1)

            'Execute Command
            dt = dbGetDataReader(cmd)
            If dt.Rows.Count > 0 Then
                Debug.Print("Process Rows")
            Else
                Debug.Print("No Rows")
            End If

        Catch ex As Exception
            LogFatal(myApp, sModuleName, "dbGetDataReader_Sample", ex, "")
        End Try

    End Sub

#End Region
    Public Shared Function dbGetDataReader(ByVal cmd As SqlCommand) As DataTable
        Dim cnn As SqlConnection = Nothing
        Dim dr As SqlDataReader
        Dim dt As DataTable = Nothing

        Try
            'Prepare parameters
            cnn = New SqlConnection(sConnectionString)
            cmd.Connection = cnn

            'Execute command
            cnn.Open()
            dr = cmd.ExecuteReader()

            If dr.HasRows Then
                dt = New DataTable
                dt.Load(dr)
                Return dt
            Else
                dt = New DataTable
                Return dt
            End If

        Catch ex As Exception
            LogFatal(myApp, sModuleName, "dbGetDataReader", ex, cmd.CommandText)
            Return Nothing

        Finally
            If Not (cnn Is Nothing) Then
                If cnn.State = ConnectionState.Open Then cnn.Close()
            End If

            dt.Dispose()
            cnn.Dispose()
        End Try



    End Function

#Region "dbGetXMLReader Sample"

    Private Sub dbGetXMLReader_Sample()
        Dim cmd As New SqlCommand, xr As XmlReader

        Try
            'Prepare Command
            cmd.CommandText = "Select * from Stations"
            cmd.CommandType = CommandType.Text                   '.StoredProcedure
            'cmd.Parameters.AddWithValue("Hola", 1)

            'Execute Command
            xr = dbGetxmlReader(cmd)
            If True Then
                Debug.Print("Process Rows")
            Else
                Debug.Print("No Rows")
            End If

        Catch ex As Exception
            LogFatal(myApp, sModuleName, "dbGetXMLReader_Sample", ex, "")
        End Try

    End Sub

#End Region
    Public Shared Function dbGetxmlReader(ByVal cmd As SqlCommand) As XmlReader
        Dim cnn As SqlConnection = Nothing

        Try
            'TODO 9 Test com funciona ExecuteXMLReader
            Return Nothing

            'Prepare parameters
            cnn = New SqlConnection(sConnectionString)
            cmd.Connection = cnn

            'Execute command
            cnn.Open()
            Return cmd.ExecuteXmlReader

        Catch ex As Exception
            LogFatal(myApp, sModuleName, "dbGetxmlReader", ex, cmd.CommandText)
            Return Nothing

        Finally
            If Not (cnn Is Nothing) Then
                If cnn.State = ConnectionState.Open Then cnn.Close()
            End If

            cnn.Dispose()
        End Try

    End Function

#Region "dbExecNonQuery_Sample()"
    Private Sub dbExecNonQuery_Sample()
        Dim cmd As New SqlCommand, dt As New DataTable
        Dim iNumRegisters As Integer = -1

        Try
            'Prepare Command
            cmd.CommandText = "Select * from Stations WHERE PEPE = 9"
            cmd.CommandType = CommandType.Text                   '.StoredProcedure

            'cmd = New SqlCommand("sp_InsertarVariosDatosPrueba")
            'cmd.Parameters.AddWithValue("@Param1", objValue)

            'Execute Command
            If dbExecNonQuery(cmd, iNumRegisters) Then
                Debug.Print("Process Rows")
            Else
                Debug.Print("No Rows")
            End If


        Catch ex As Exception
            LogFatal(myApp, sModuleName, "dbExecNonQuery_Sample", ex, "")
        End Try
    End Sub
#End Region
    Public Shared Function dbExecNonQuery(ByVal cmd As SqlCommand, Optional ByRef iNumRegisters As Integer = 0) As Boolean
        Dim cnn As New SqlConnection

        'NonQuery: Useful for Insert, Update, Delete -> Return number of rows affected in ExecuteQuery.

        Try
            'Prepare parameters
            cnn.ConnectionString = sConnectionString
            cmd.Connection = cnn

            'Execute command
            cnn.Open()
            iNumRegisters = cmd.ExecuteNonQuery()

            Return True

        Catch ex As Exception
            LogFatal(myApp, sModuleName, "dbExecNonQuery", ex, cmd.CommandText)
            Return False

        Finally
            If Not (cnn Is Nothing) Then
                If cnn.State = ConnectionState.Open Then cnn.Close()
            End If

            cnn.Dispose()
        End Try

    End Function

#Region "dbExecReader_Sample"
    Private Sub dbExecReader_Sample()
        Dim cmd As New SqlCommand, dr As SqlDataReader

        Try
            'Prepare Command
            cmd.CommandText = "Select * from Stations"
            cmd.CommandType = CommandType.Text                   '.StoredProcedure

            'Execute Command
            dr = dbExecReader(cmd)
            If Not IsNothing(dr) Then
                Debug.Print("Process Data")
            Else
                Debug.Print("No Data")
            End If

        Catch ex As Exception
            LogFatal(myApp, sModuleName, "dbExecReader_Sample", ex, "")
        End Try

    End Sub
#End Region
    Public Shared Function dbExecReader(ByVal cmd As SqlCommand) As SqlDataReader
        Dim cnn As New SqlConnection
        Dim dr As SqlDataReader

        'Reader: Fills object sqlDataReader

        Try
            'Prepare parameters
            cnn.ConnectionString = sConnectionString
            cmd.Connection = cnn

            'Execute command
            cnn.Open()
            dr = cmd.ExecuteReader()

            Return dr

        Catch ex As Exception
            LogFatal(myApp, sModuleName, "dbExecReader", ex, cmd.CommandText)
            Return Nothing

        Finally
            If Not (cnn Is Nothing) Then
                If cnn.State = ConnectionState.Open Then cnn.Close()
            End If

            cnn.Dispose()
        End Try

    End Function

#Region "dbExecScalar_Sample"
    Private Sub dbExecScalar_Sample()
        Dim cmd As New SqlCommand, oResult As Object

        Try
            'Prepare Command
            cmd.CommandText = "Select * from Stations"
            cmd.CommandType = CommandType.Text                   '.StoredProcedure

            'Execute Command
            oResult = dbExecScalar(cmd)
            If Not IsNothing(oResult) Then
                Debug.Print("Process Object")
            Else
                Debug.Print("No Data")
            End If

        Catch ex As Exception
            LogFatal(myApp, sModuleName, "dbExecScalar_Sample", ex, "")
        End Try

    End Sub
#End Region
    Public Shared Function dbExecScalar(ByVal cmd As SqlCommand) As Object
        Dim cnn As New SqlConnection
        Dim oResult As Object

        'Scalar: Useful for read only one value (SUM, CNT, ...). Only returns first item of first register.
        '        If stored procedure, returns value, then it must be the newId for insert register.
        '        cmd pot ser un stored procedure o un sql

        Try
            'Prepare parameters
            cnn.ConnectionString = sConnectionString
            cmd.Connection = cnn

            'Execute command
            cnn.Open()
            oResult = cmd.ExecuteScalar()

            Return oResult

        Catch ex As Exception
            LogFatal(myApp, sModuleName, "dbExecScalar", ex, cmd.CommandText)
            Return Nothing

        Finally
            If Not (cnn Is Nothing) Then
                If cnn.State = ConnectionState.Open Then cnn.Close()
            End If
            cnn.Dispose()
        End Try

    End Function



#End Region

#Region "Tools"
    Private Sub Backup()
        'TODO 9 Backup database
        'Dim sBackup As String = "BACKUP DATABASE " & Me.txtBase.Text & _
        '              " TO DISK = N'" & Me.txtBackup.Text & _
        '              "' WITH NOFORMAT, NOINIT, NAME =N'" & Me.txtBase.Text & _
        '              "' -Full Database Backup',SKIP, STATS = 10"

        'Dim csb As New SqlConnectionStringBuilder
        'csb.DataSource = Me.txtServidor.Text
        'csb.InitialCatalog = Me.txtBase.Text
        'csb.IntegratedSecurity = True

        'Using con As New SqlConnection(csb.ConnectionString)
        '    Try
        '        con.Open()

        '        Dim cmdBackUp As New SqlCommand(sBackup, con)

        '        cmdBackUp.ExecuteNonQuery()

        'MessageBox.Show("Se ha creado un BackUp de La base de datos satisfactoria
        '                "Copia de seguridad de base de datos", _
        '                MessageBoxButtons.OK, MessageBoxIcon.Information)

        '        con.Close()

        '    Catch ex As Exception
        '        MessageBox.Show(ex, _
        '                        "Error al copiar la base de datos", _
        '                        MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    End Try
        'End Using
    End Sub

    'Private Sub btnRestore_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRestore.Click
    '    'Me.btnRestore.Enabled = False
    '    'Me.btnRestore.Text = "Restaurando..."
    '    'Me.btnRestore.Refresh()

    '    'Dim sBackup As String = "RESTORE DATABASE " & Me.txtBase.Text & _
    '    '                        " FROM DISK = '" & Me.txtBackup.Text & "'" & _
    '    '                        " WITH REPLACE"

    '    'Dim csb As New SqlConnectionStringBuilder
    '    'csb.DataSource = Me.txtServidor.Text
    '    '' Es mejor abrir la conexión con la base Master
    '    'csb.InitialCatalog = "master"
    '    'csb.IntegratedSecurity = True

    '    'Using con As New SqlConnection(csb.ConnectionString)
    '    '    Try
    '    '        con.Open()

    '    '        Dim cmdBackUp As New SqlCommand(sBackup, con)
    '    '        cmdBackUp.ExecuteNonQuery()
    '    '        MessageBox.Show("Se ha restaurado la copia de la base de datos.", _
    '    '                        "Restaurar base de datos", _
    '    '                        MessageBoxButtons.OK, MessageBoxIcon.Information)

    '    '        con.Close()
    '    '    Catch ex As Exception
    '    '        MessageBox.Show(ex, _
    '    '                        "Error al restaurar la base de datos", _
    '    '                        MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    '    End Try
    '    'End Using

    '    'Me.btnRestore.Text = "Restaurar copia"
    '    'Me.btnRestore.Enabled = True
    '    'Me.btnRestore.Refresh()

    'End Sub
#End Region

End Class
