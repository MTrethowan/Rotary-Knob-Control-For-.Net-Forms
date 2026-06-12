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
        Me.RotaryKnobControl1 = New CustomControls.RotaryKnobControl()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'RotaryKnobControl1
        '
        Me.RotaryKnobControl1.BackColor = System.Drawing.Color.Transparent
        Me.RotaryKnobControl1.KnobImage = Nothing
        Me.RotaryKnobControl1.Location = New System.Drawing.Point(97, 103)
        Me.RotaryKnobControl1.Maximum = 10.0!
        Me.RotaryKnobControl1.Minimum = 0!
        Me.RotaryKnobControl1.Name = "RotaryKnobControl1"
        Me.RotaryKnobControl1.Size = New System.Drawing.Size(150, 150)
        Me.RotaryKnobControl1.TabIndex = 0
        Me.RotaryKnobControl1.Text = "RotaryKnobControl1"
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
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(16.0!, 31.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(357, 274)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.RotaryKnobControl1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Rotary Knob Demo"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RotaryKnobControl1 As CustomControls.RotaryKnobControl
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
End Class
