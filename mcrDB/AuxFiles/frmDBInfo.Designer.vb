<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDBInfo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDBInfo))
        Me.boxLoginMode = New System.Windows.Forms.GroupBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtUser = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.radUserPassword = New System.Windows.Forms.RadioButton()
        Me.radIntegratedSecurity = New System.Windows.Forms.RadioButton()
        Me.boxTimeOut = New System.Windows.Forms.GroupBox()
        Me.txtTimeOut = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtServer = New System.Windows.Forms.TextBox()
        Me.txtDatabase = New System.Windows.Forms.TextBox()
        Me.chkConnected = New System.Windows.Forms.CheckBox()
        Me.chkSimulation = New System.Windows.Forms.CheckBox()
        Me.boxLoginMode.SuspendLayout()
        Me.boxTimeOut.SuspendLayout()
        Me.SuspendLayout()
        '
        'boxLoginMode
        '
        Me.boxLoginMode.Controls.Add(Me.txtPassword)
        Me.boxLoginMode.Controls.Add(Me.Label5)
        Me.boxLoginMode.Controls.Add(Me.txtUser)
        Me.boxLoginMode.Controls.Add(Me.Label6)
        Me.boxLoginMode.Controls.Add(Me.radUserPassword)
        Me.boxLoginMode.Controls.Add(Me.radIntegratedSecurity)
        Me.boxLoginMode.Location = New System.Drawing.Point(12, 75)
        Me.boxLoginMode.Name = "boxLoginMode"
        Me.boxLoginMode.Size = New System.Drawing.Size(338, 145)
        Me.boxLoginMode.TabIndex = 24
        Me.boxLoginMode.TabStop = False
        Me.boxLoginMode.Text = "Config Session connection "
        '
        'txtPassword
        '
        Me.txtPassword.Enabled = False
        Me.txtPassword.Location = New System.Drawing.Point(155, 111)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.ReadOnly = True
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
        Me.txtUser.ReadOnly = True
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
        Me.radUserPassword.Enabled = False
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
        Me.radIntegratedSecurity.Enabled = False
        Me.radIntegratedSecurity.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.radIntegratedSecurity.Location = New System.Drawing.Point(34, 39)
        Me.radIntegratedSecurity.Name = "radIntegratedSecurity"
        Me.radIntegratedSecurity.Size = New System.Drawing.Size(161, 17)
        Me.radIntegratedSecurity.TabIndex = 0
        Me.radIntegratedSecurity.TabStop = True
        Me.radIntegratedSecurity.Text = "Integrated Windows Security"
        Me.radIntegratedSecurity.UseVisualStyleBackColor = True
        '
        'boxTimeOut
        '
        Me.boxTimeOut.Controls.Add(Me.txtTimeOut)
        Me.boxTimeOut.Controls.Add(Me.Label3)
        Me.boxTimeOut.Location = New System.Drawing.Point(12, 226)
        Me.boxTimeOut.Name = "boxTimeOut"
        Me.boxTimeOut.Size = New System.Drawing.Size(338, 61)
        Me.boxTimeOut.TabIndex = 26
        Me.boxTimeOut.TabStop = False
        Me.boxTimeOut.Text = "Select connection timeout:"
        '
        'txtTimeOut
        '
        Me.txtTimeOut.Enabled = False
        Me.txtTimeOut.Location = New System.Drawing.Point(243, 29)
        Me.txtTimeOut.Name = "txtTimeOut"
        Me.txtTimeOut.ReadOnly = True
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
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(12, 38)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 13)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "Database name:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Server:"
        '
        'txtServer
        '
        Me.txtServer.Enabled = False
        Me.txtServer.Location = New System.Drawing.Point(103, 6)
        Me.txtServer.Name = "txtServer"
        Me.txtServer.ReadOnly = True
        Me.txtServer.Size = New System.Drawing.Size(247, 20)
        Me.txtServer.TabIndex = 14
        '
        'txtDatabase
        '
        Me.txtDatabase.Enabled = False
        Me.txtDatabase.Location = New System.Drawing.Point(103, 35)
        Me.txtDatabase.Name = "txtDatabase"
        Me.txtDatabase.ReadOnly = True
        Me.txtDatabase.Size = New System.Drawing.Size(247, 20)
        Me.txtDatabase.TabIndex = 29
        '
        'chkConnected
        '
        Me.chkConnected.AutoSize = True
        Me.chkConnected.Enabled = False
        Me.chkConnected.Location = New System.Drawing.Point(16, 318)
        Me.chkConnected.Name = "chkConnected"
        Me.chkConnected.Size = New System.Drawing.Size(78, 17)
        Me.chkConnected.TabIndex = 30
        Me.chkConnected.Text = "Connected"
        Me.chkConnected.UseVisualStyleBackColor = True
        '
        'chkSimulation
        '
        Me.chkSimulation.AutoSize = True
        Me.chkSimulation.Enabled = False
        Me.chkSimulation.Location = New System.Drawing.Point(272, 318)
        Me.chkSimulation.Name = "chkSimulation"
        Me.chkSimulation.Size = New System.Drawing.Size(74, 17)
        Me.chkSimulation.TabIndex = 31
        Me.chkSimulation.Text = "Simulation"
        Me.chkSimulation.UseVisualStyleBackColor = True
        '
        'frmDBInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(366, 347)
        Me.Controls.Add(Me.chkSimulation)
        Me.Controls.Add(Me.chkConnected)
        Me.Controls.Add(Me.txtDatabase)
        Me.Controls.Add(Me.txtServer)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.boxTimeOut)
        Me.Controls.Add(Me.boxLoginMode)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmDBInfo"
        Me.Text = "Database Connection Info"
        Me.boxLoginMode.ResumeLayout(False)
        Me.boxLoginMode.PerformLayout()
        Me.boxTimeOut.ResumeLayout(False)
        Me.boxTimeOut.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents boxLoginMode As System.Windows.Forms.GroupBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtUser As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents radUserPassword As System.Windows.Forms.RadioButton
    Friend WithEvents radIntegratedSecurity As System.Windows.Forms.RadioButton
    Friend WithEvents boxTimeOut As System.Windows.Forms.GroupBox
    Friend WithEvents txtTimeOut As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtServer As System.Windows.Forms.TextBox
    Friend WithEvents txtDatabase As System.Windows.Forms.TextBox
    Friend WithEvents chkConnected As System.Windows.Forms.CheckBox
    Friend WithEvents chkSimulation As System.Windows.Forms.CheckBox
End Class
