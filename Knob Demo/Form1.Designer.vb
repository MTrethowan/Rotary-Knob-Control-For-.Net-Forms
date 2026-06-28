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
        Me.RotaryKnobControl1 = New CustomControls.RotaryKnobControl()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.RockerSwitchControl1 = New CustomControls.RockerSwitchControl()
        Me.RotaryClockControl1 = New CustomControls.RotaryClockControl()
        Me.RotaryDialControl1 = New CustomControls.RotaryDialControl()
        Me.RotaryHexControl1 = New CustomControls.RotaryHexControl()
        Me.RotaryPotControl1 = New CustomControls.RotaryPotControl()
        Me.RoundedPictureBox1 = New CustomControls.RoundedPictureBox(Me.components)
        CType(Me.RoundedPictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RotaryKnobControl1
        '
        Me.RotaryKnobControl1.BackColor = System.Drawing.Color.Transparent
        Me.RotaryKnobControl1.KnobImage = Nothing
        Me.RotaryKnobControl1.Location = New System.Drawing.Point(55, 70)
        Me.RotaryKnobControl1.Maximum = 10.0!
        Me.RotaryKnobControl1.Minimum = 0!
        Me.RotaryKnobControl1.Name = "RotaryKnobControl1"
        Me.RotaryKnobControl1.Size = New System.Drawing.Size(224, 203)
        Me.RotaryKnobControl1.TabIndex = 0
        Me.RotaryKnobControl1.Text = "RotaryKnobControl1"
        Me.RotaryKnobControl1.TickLabels = New String() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10"}
        Me.RotaryKnobControl1.Value = 0!
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(100, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 32)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Value:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(231, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 32)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "0"
        '
        'RockerSwitchControl1
        '
        Me.RockerSwitchControl1.ActiveColor = System.Drawing.Color.LightGray
        Me.RockerSwitchControl1.ActiveImage = Nothing
        Me.RockerSwitchControl1.DeactiveColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.RockerSwitchControl1.DeactiveImage = Nothing
        Me.RockerSwitchControl1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RockerSwitchControl1.Location = New System.Drawing.Point(601, 349)
        Me.RockerSwitchControl1.Name = "RockerSwitchControl1"
        Me.RockerSwitchControl1.Size = New System.Drawing.Size(206, 73)
        Me.RockerSwitchControl1.TabIndex = 3
        Me.RockerSwitchControl1.Text = "Rocker Switch"
        Me.RockerSwitchControl1.UseVisualStyleBackColor = True
        '
        'RotaryClockControl1
        '
        Me.RotaryClockControl1.BackColor = System.Drawing.Color.Transparent
        Me.RotaryClockControl1.KnobImage = Nothing
        Me.RotaryClockControl1.Location = New System.Drawing.Point(329, 70)
        Me.RotaryClockControl1.Maximum = 5.0!
        Me.RotaryClockControl1.Minimum = 0!
        Me.RotaryClockControl1.Name = "RotaryClockControl1"
        Me.RotaryClockControl1.Size = New System.Drawing.Size(213, 203)
        Me.RotaryClockControl1.TabIndex = 4
        Me.RotaryClockControl1.Text = "RotaryClockControl1"
        Me.RotaryClockControl1.TickLabels = New String() {"0", "1", "2", "3", "4", "5"}
        Me.RotaryClockControl1.Value = 0!
        '
        'RotaryDialControl1
        '
        Me.RotaryDialControl1.BackColor = System.Drawing.Color.Transparent
        Me.RotaryDialControl1.KnobImage = Nothing
        Me.RotaryDialControl1.Location = New System.Drawing.Point(587, 70)
        Me.RotaryDialControl1.Maximum = 7.0!
        Me.RotaryDialControl1.Minimum = 0!
        Me.RotaryDialControl1.Name = "RotaryDialControl1"
        Me.RotaryDialControl1.Size = New System.Drawing.Size(210, 217)
        Me.RotaryDialControl1.TabIndex = 5
        Me.RotaryDialControl1.Text = "RotaryDialControl1"
        Me.RotaryDialControl1.TickLabels = New String() {"0", "1", "2", "3", "4", "5", "6", "7"}
        Me.RotaryDialControl1.Value = 0!
        '
        'RotaryHexControl1
        '
        Me.RotaryHexControl1.BackColor = System.Drawing.Color.Transparent
        Me.RotaryHexControl1.KnobImage = Nothing
        Me.RotaryHexControl1.Location = New System.Drawing.Point(66, 297)
        Me.RotaryHexControl1.Maximum = 5.0!
        Me.RotaryHexControl1.Minimum = 0!
        Me.RotaryHexControl1.Name = "RotaryHexControl1"
        Me.RotaryHexControl1.Size = New System.Drawing.Size(195, 187)
        Me.RotaryHexControl1.TabIndex = 6
        Me.RotaryHexControl1.Text = "RotaryHexControl1"
        Me.RotaryHexControl1.TickLabels = New String() {"0", "1", "2", "3", "4", "5"}
        Me.RotaryHexControl1.Value = 0!
        '
        'RotaryPotControl1
        '
        Me.RotaryPotControl1.BackColor = System.Drawing.Color.Transparent
        Me.RotaryPotControl1.KnobImage = Nothing
        Me.RotaryPotControl1.Location = New System.Drawing.Point(329, 297)
        Me.RotaryPotControl1.Maximum = 6.0!
        Me.RotaryPotControl1.Minimum = 0!
        Me.RotaryPotControl1.Name = "RotaryPotControl1"
        Me.RotaryPotControl1.Size = New System.Drawing.Size(199, 149)
        Me.RotaryPotControl1.TabIndex = 7
        Me.RotaryPotControl1.Text = "RotaryPotControl1"
        Me.RotaryPotControl1.TickLabels = New String() {"0", "1", "2", "3", "4", "5", "6"}
        Me.RotaryPotControl1.Value = 0!
        '
        'RoundedPictureBox1
        '
        Me.RoundedPictureBox1.BorderColor = System.Drawing.Color.Blue
        Me.RoundedPictureBox1.BorderWidth = 4
        Me.RoundedPictureBox1.CornerRadius = 20
        Me.RoundedPictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.RoundedPictureBox1.Name = "RoundedPictureBox1"
        Me.RoundedPictureBox1.Size = New System.Drawing.Size(845, 460)
        Me.RoundedPictureBox1.TabIndex = 8
        Me.RoundedPictureBox1.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(16.0!, 31.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(868, 480)
        Me.Controls.Add(Me.RotaryPotControl1)
        Me.Controls.Add(Me.RotaryHexControl1)
        Me.Controls.Add(Me.RotaryDialControl1)
        Me.Controls.Add(Me.RotaryClockControl1)
        Me.Controls.Add(Me.RockerSwitchControl1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.RotaryKnobControl1)
        Me.Controls.Add(Me.RoundedPictureBox1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(6)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Rotary Knob Demo"
        CType(Me.RoundedPictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RotaryKnobControl1 As CustomControls.RotaryKnobControl
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents RockerSwitchControl1 As CustomControls.RockerSwitchControl
    Friend WithEvents RotaryClockControl1 As CustomControls.RotaryClockControl
    Friend WithEvents RotaryDialControl1 As CustomControls.RotaryDialControl
    Friend WithEvents RotaryHexControl1 As CustomControls.RotaryHexControl
    Friend WithEvents RotaryPotControl1 As CustomControls.RotaryPotControl
    Friend WithEvents RoundedPictureBox1 As CustomControls.RoundedPictureBox
End Class
