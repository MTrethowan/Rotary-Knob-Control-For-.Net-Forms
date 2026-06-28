' ==============================================================================
'  Knob Demo
' ==============================================================================
'  
'  Project:      CustomControls
'  Description:  A demo application showcasing the customizable rotary knob control for
'                Windows Forms in C# and VB.NET applications.
'  
'  Author:       Mike Trethowan
'  Created:      2026-06-12
'  Modified:     2026-06-12
'  Version:      1.0.0
'  
'  Copyright (c) 2026 Mike Trethowan. All rights reserved.
'  
'  License:      MIT License(Or your chosen license)
'                See LICENSE file in the project root for full license information.
'  
'  Dependencies: .NET Framework 4.8.1+
'                System.Windows.Forms
'                System.Drawing
'  
'  Notes:        This demonstrates control supports mouse drag, click, And scroll wheel interaction.
'                Custom knob images can be provided with rotation offset And size adjustment.
'                Mouse wheel works on hover without requiring focus click.
'  
'  Change Log:
'    v1.0.0 - 2026-06-12- Initial release
'             - Basic rotary knob functionality
'             - Custom image support
'             - Mouse wheel support
'             - Configurable value ranges
' ==============================================================================


Public Class Form1
    Private Sub RotaryKnobControl1_ValueChanged(sender As Object, e As EventArgs) Handles RotaryKnobControl1.ValueChanged
        Label2.Text = RotaryKnobControl1.Value.ToString()
    End Sub

    Private Sub RotaryDialControl2_ValueChanged(sender As Object, e As EventArgs)

    End Sub
End Class
