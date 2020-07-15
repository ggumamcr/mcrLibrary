<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDBLogin
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDBLogin))
        Me.boxTimeOut = New System.Windows.Forms.GroupBox()
        Me.txtTimeOut = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.boxDataBase = New System.Windows.Forms.GroupBox()
        Me.cmbDatabase = New System.Windows.Forms.ComboBox()
        Me.btnDatabaseList = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.boxLoginMode = New System.Windows.Forms.GroupBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtUser = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.radUserPassword = New System.Windows.Forms.RadioButton()
        Me.radIntegratedSecurity = New System.Windows.Forms.RadioButton()
        Me.boxSeverName = New System.Windows.Forms.GroupBox()
        Me.lbStatusDB = New System.Windows.Forms.Label()
        Me.cmbServerName = New System.Windows.Forms.ComboBox()
        Me.btnServerList = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnTestConnection = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnAccept = New System.Windows.Forms.Button()
        Me.btnAdvancedOptions = New System.Windows.Forms.Button()
        Me.boxTimeOut.SuspendLayout()
        Me.boxDataBase.SuspendLayout()
        Me.boxLoginMode.SuspendLayout()
        Me.boxSeverName.SuspendLayout()
        Me.SuspendLayout()
        '
        'boxTimeOut
        '
        Me.boxTimeOut.Controls.Add(Me.txtTimeOut)
        Me.boxTimeOut.Controls.Add(Me.Label3)
        Me.boxTimeOut.Location = New System.Drawing.Point(93, 484)
        Me.boxTimeOut.Name = "boxTimeOut"
        Me.boxTimeOut.Size = New System.Drawing.Size(338, 61)
        Me.boxTimeOut.TabIndex = 25
        Me.boxTimeOut.TabStop = False
        Me.boxTimeOut.Text = "Select connection timeout:"
        '
        'txtTimeOut
        '
        Me.txtTimeOut.Location = New System.Drawing.Point(243, 29)
        Me.txtTimeOut.Name = "txtTimeOut"
        Me.txtTimeOut.Size = New System.Drawing.Size(75, 20)
        Me.txtTimeOut.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(31, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "TimeOut (seconds)"
        '
        'boxDataBase
        '
        Me.boxDataBase.Controls.Add(Me.cmbDatabase)
        Me.boxDataBase.Controls.Add(Me.btnDatabaseList)
        Me.boxDataBase.Controls.Add(Me.Label4)
        Me.boxDataBase.Location = New System.Drawing.Point(93, 401)
        Me.boxDataBase.Name = "boxDataBase"
        Me.boxDataBase.Size = New System.Drawing.Size(338, 61)
        Me.boxDataBase.TabIndex = 24
        Me.boxDataBase.TabStop = False
        Me.boxDataBase.Text = "Select DataBase:"
        '
        'cmbDatabase
        '
        Me.cmbDatabase.FormattingEnabled = True
        Me.cmbDatabase.Location = New System.Drawing.Point(119, 26)
        Me.cmbDatabase.Name = "cmbDatabase"
        Me.cmbDatabase.Size = New System.Drawing.Size(170, 21)
        Me.cmbDatabase.TabIndex = 16
        '
        'btnDatabaseList
        '
        Me.btnDatabaseList.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnDatabaseList.Location = New System.Drawing.Point(295, 22)
        Me.btnDatabaseList.Name = "btnDatabaseList"
        Me.btnDatabaseList.Size = New System.Drawing.Size(37, 27)
        Me.btnDatabaseList.TabIndex = 15
        Me.btnDatabaseList.Text = "..."
        Me.btnDatabaseList.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(31, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Database name:"
        '
        'boxLoginMode
        '
        Me.boxLoginMode.Controls.Add(Me.txtPassword)
        Me.boxLoginMode.Controls.Add(Me.Label5)
        Me.boxLoginMode.Controls.Add(Me.txtUser)
        Me.boxLoginMode.Controls.Add(Me.Label6)
        Me.boxLoginMode.Controls.Add(Me.radUserPassword)
        Me.boxLoginMode.Controls.Add(Me.radIntegratedSecurity)
        Me.boxLoginMode.Location = New System.Drawing.Point(93, 235)
        Me.boxLoginMode.Name = "boxLoginMode"
        Me.boxLoginMode.Size = New System.Drawing.Size(338, 145)
        Me.boxLoginMode.TabIndex = 23
        Me.boxLoginMode.TabStop = False
        Me.boxLoginMode.Text = "Config Session connection "
        '
        'txtPassword
        '
        Me.txtPassword.Enabled = False
        Me.txtPassword.Location = New System.Drawing.Point(155, 111)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(163, 20)
        Me.txtPassword.TabIndex = 13
        Me.txtPassword.UseSystemPasswordChar = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(80, 114)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Password:"
        '
        'txtUser
        '
        Me.txtUser.Enabled = False
        Me.txtUser.Location = New System.Drawing.Point(155, 85)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(163, 20)
        Me.txtUser.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(80, 88)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(32, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "User:"
        '
        'radUserPassword
        '
        Me.radUserPassword.AutoSize = True
        Me.radUserPassword.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.radUserPassword.Location = New System.Drawing.Point(34, 62)
        Me.radUserPassword.Name = "radUserPassword"
        Me.radUserPassword.Size = New System.Drawing.Size(117, 17)
        Me.radUserPassword.TabIndex = 1
        Me.radUserPassword.Text = "User and Password"
        Me.radUserPassword.UseVisualStyleBackColor = True
        '
        'radIntegratedSecurity
        '
        Me.radIntegratedSecurity.AutoSize = True
        Me.radIntegratedSecurity.Checked = True
        Me.radIntegratedSecurity.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.radIntegratedSecurity.Location = New System.Drawing.Point(34, 39)
        Me.radIntegratedSecurity.Name = "radIntegratedSecurity"
        Me.radIntegratedSecurity.Size = New System.Drawing.Size(161, 17)
        Me.radIntegratedSecurity.TabIndex = 0
        Me.radIntegratedSecurity.TabStop = True
        Me.radIntegratedSecurity.Text = "Integrated Windows Security"
        Me.radIntegratedSecurity.UseVisualStyleBackColor = True
        '
        'boxSeverName
        '
        Me.boxSeverName.Controls.Add(Me.lbStatusDB)
        Me.boxSeverName.Controls.Add(Me.cmbServerName)
        Me.boxSeverName.Controls.Add(Me.btnServerList)
        Me.boxSeverName.Controls.Add(Me.Label2)
        Me.boxSeverName.Controls.Add(Me.btnTestConnection)
        Me.boxSeverName.Controls.Add(Me.Label1)
        Me.boxSeverName.Location = New System.Drawing.Point(12, 12)
        Me.boxSeverName.Name = "boxSeverName"
        Me.boxSeverName.Size = New System.Drawing.Size(520, 145)
        Me.boxSeverName.TabIndex = 21
        Me.boxSeverName.TabStop = False
        '
        'lbStatusDB
        '
        Me.lbStatusDB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbStatusDB.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbStatusDB.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbStatusDB.Location = New System.Drawing.Point(191, 100)
        Me.lbStatusDB.Name = "lbStatusDB"
        Me.lbStatusDB.Size = New System.Drawing.Size(323, 27)
        Me.lbStatusDB.TabIndex = 15
        Me.lbStatusDB.Text = "-"
        Me.lbStatusDB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbServerName
        '
        Me.cmbServerName.FormattingEnabled = True
        Me.cmbServerName.Location = New System.Drawing.Point(67, 64)
        Me.cmbServerName.Name = "cmbServerName"
        Me.cmbServerName.Size = New System.Drawing.Size(253, 21)
        Me.cmbServerName.TabIndex = 14
        '
        'btnServerList
        '
        Me.btnServerList.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnServerList.Location = New System.Drawing.Point(326, 60)
        Me.btnServerList.Name = "btnServerList"
        Me.btnServerList.Size = New System.Drawing.Size(40, 27)
        Me.btnServerList.TabIndex = 13
        Me.btnServerList.Text = "..."
        Me.btnServerList.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(64, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Select the Server Name"
        '
        'btnTestConnection
        '
        Me.btnTestConnection.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnTestConnection.Location = New System.Drawing.Point(15, 100)
        Me.btnTestConnection.Name = "btnTestConnection"
        Me.btnTestConnection.Size = New System.Drawing.Size(145, 27)
        Me.btnTestConnection.TabIndex = 11
        Me.btnTestConnection.Text = "Test Connection"
        Me.btnTestConnection.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(12, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Server:"
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCancel.Location = New System.Drawing.Point(384, 171)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(145, 27)
        Me.btnCancel.TabIndex = 20
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnAccept
        '
        Me.btnAccept.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAccept.Enabled = False
        Me.btnAccept.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAccept.Location = New System.Drawing.Point(233, 171)
        Me.btnAccept.Name = "btnAccept"
        Me.btnAccept.Size = New System.Drawing.Size(145, 27)
        Me.btnAccept.TabIndex = 19
        Me.btnAccept.Text = "Accept"
        Me.btnAccept.UseVisualStyleBackColor = True
        '
        'btnAdvancedOptions
        '
        Me.btnAdvancedOptions.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAdvancedOptions.Location = New System.Drawing.Point(27, 171)
        Me.btnAdvancedOptions.Name = "btnAdvancedOptions"
        Me.btnAdvancedOptions.Size = New System.Drawing.Size(145, 27)
        Me.btnAdvancedOptions.TabIndex = 22
        Me.btnAdvancedOptions.Text = "Show Advanced Options"
        Me.btnAdvancedOptions.UseVisualStyleBackColor = True
        '
        'frmDBLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(539, 566)
        Me.Controls.Add(Me.boxTimeOut)
        Me.Controls.Add(Me.boxDataBase)
        Me.Controls.Add(Me.boxLoginMode)
        Me.Controls.Add(Me.boxSeverName)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnAccept)
        Me.Controls.Add(Me.btnAdvancedOptions)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmDBLogin"
        Me.Text = "Login DB"
        Me.boxTimeOut.ResumeLayout(False)
        Me.boxTimeOut.PerformLayout()
        Me.boxDataBase.ResumeLayout(False)
        Me.boxDataBase.PerformLayout()
        Me.boxLoginMode.ResumeLayout(False)
        Me.boxLoginMode.PerformLayout()
        Me.boxSeverName.ResumeLayout(False)
        Me.boxSeverName.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents boxTimeOut As System.Windows.Forms.GroupBox
    Friend WithEvents txtTimeOut As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents boxDataBase As System.Windows.Forms.GroupBox
    Friend WithEvents cmbDatabase As System.Windows.Forms.ComboBox
    Friend WithEvents btnDatabaseList As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents boxLoginMode As System.Windows.Forms.GroupBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtUser As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents radUserPassword As System.Windows.Forms.RadioButton
    Friend WithEvents radIntegratedSecurity As System.Windows.Forms.RadioButton
    Friend WithEvents boxSeverName As System.Windows.Forms.GroupBox
    Friend WithEvents cmbServerName As System.Windows.Forms.ComboBox
    Friend WithEvents btnServerList As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnTestConnection As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnAccept As System.Windows.Forms.Button
    Friend WithEvents btnAdvancedOptions As System.Windows.Forms.Button
    Friend WithEvents lbStatusDB As System.Windows.Forms.Label
End Class
