<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.txtlog = New System.Windows.Forms.TextBox()
        Me.btnsetting = New System.Windows.Forms.Button()
        Me.btnonoff = New System.Windows.Forms.Button()
        Me.timerproses = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'txtlog
        '
        Me.txtlog.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtlog.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtlog.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtlog.Location = New System.Drawing.Point(7, 68)
        Me.txtlog.Multiline = True
        Me.txtlog.Name = "txtlog"
        Me.txtlog.ReadOnly = True
        Me.txtlog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtlog.Size = New System.Drawing.Size(553, 291)
        Me.txtlog.TabIndex = 0
        '
        'btnsetting
        '
        Me.btnsetting.BackgroundImage = Global.DDCenter.My.Resources.Resources.settings
        Me.btnsetting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnsetting.Location = New System.Drawing.Point(74, 6)
        Me.btnsetting.Name = "btnsetting"
        Me.btnsetting.Size = New System.Drawing.Size(61, 57)
        Me.btnsetting.TabIndex = 5
        Me.btnsetting.Text = " "
        Me.btnsetting.UseVisualStyleBackColor = True
        '
        'btnonoff
        '
        Me.btnonoff.BackgroundImage = Global.DDCenter.My.Resources.Resources.On_Button
        Me.btnonoff.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnonoff.Location = New System.Drawing.Point(7, 6)
        Me.btnonoff.Name = "btnonoff"
        Me.btnonoff.Size = New System.Drawing.Size(61, 57)
        Me.btnonoff.TabIndex = 4
        Me.btnonoff.Text = " "
        Me.btnonoff.UseVisualStyleBackColor = True
        '
        'timerproses
        '
        Me.timerproses.Interval = 3000
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.DDCenter.My.Resources.Resources.blackwhite
        Me.ClientSize = New System.Drawing.Size(567, 364)
        Me.Controls.Add(Me.btnsetting)
        Me.Controls.Add(Me.btnonoff)
        Me.Controls.Add(Me.txtlog)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DDCenter v1.1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtlog As System.Windows.Forms.TextBox
    Friend WithEvents btnsetting As System.Windows.Forms.Button
    Friend WithEvents btnonoff As System.Windows.Forms.Button
    Friend WithEvents timerproses As System.Windows.Forms.Timer

End Class
