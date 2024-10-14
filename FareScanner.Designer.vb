<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FareScanner
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FareScanner))
        lstResults = New ListBox()
        btnScanDrives = New Button()
        btnScanDirectory = New Button()
        checkedListDrives = New CheckedListBox()
        ProgressBar = New ProgressBar()
        btnAbort = New Button()
        TabControl1 = New TabControl()
        TabPage1 = New TabPage()
        TabPage2 = New TabPage()
        ListViewConnections = New ListView()
        TabPage3 = New TabPage()
        SystemDisplayBox = New RichTextBox()
        MenuStrip1 = New MenuStrip()
        FileToolStripMenuItem = New ToolStripMenuItem()
        ExitToolStripMenuItem = New ToolStripMenuItem()
        ViewToolStripMenuItem = New ToolStripMenuItem()
        ScannerToolStripMenuItem = New ToolStripMenuItem()
        ConnectionsToolStripMenuItem = New ToolStripMenuItem()
        SystemInformationToolStripMenuItem = New ToolStripMenuItem()
        SystemTempsToolStripMenuItem = New ToolStripMenuItem()
        AboutToolStripMenuItem = New ToolStripMenuItem()
        SettingsToolStripMenuItem = New ToolStripMenuItem()
        VisitWebsiteToolStripMenuItem = New ToolStripMenuItem()
        AboutToolStripMenuItem1 = New ToolStripMenuItem()
        TabControl1.SuspendLayout()
        TabPage1.SuspendLayout()
        TabPage2.SuspendLayout()
        TabPage3.SuspendLayout()
        MenuStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' lstResults
        ' 
        lstResults.FormattingEnabled = True
        lstResults.ItemHeight = 15
        lstResults.Location = New Point(6, 6)
        lstResults.Name = "lstResults"
        lstResults.ScrollAlwaysVisible = True
        lstResults.Size = New Size(720, 424)
        lstResults.TabIndex = 1
        ' 
        ' btnScanDrives
        ' 
        btnScanDrives.Location = New Point(132, 436)
        btnScanDrives.Name = "btnScanDrives"
        btnScanDrives.Size = New Size(594, 23)
        btnScanDrives.TabIndex = 2
        btnScanDrives.Text = "Scan System"
        btnScanDrives.UseVisualStyleBackColor = True
        ' 
        ' btnScanDirectory
        ' 
        btnScanDirectory.Location = New Point(132, 506)
        btnScanDirectory.Name = "btnScanDirectory"
        btnScanDirectory.Size = New Size(594, 23)
        btnScanDirectory.TabIndex = 4
        btnScanDirectory.Text = "Scan a Specific Directory"
        btnScanDirectory.UseVisualStyleBackColor = True
        ' 
        ' checkedListDrives
        ' 
        checkedListDrives.FormattingEnabled = True
        checkedListDrives.Location = New Point(6, 436)
        checkedListDrives.Name = "checkedListDrives"
        checkedListDrives.Size = New Size(120, 94)
        checkedListDrives.TabIndex = 5
        ' 
        ' ProgressBar
        ' 
        ProgressBar.Location = New Point(6, 535)
        ProgressBar.Name = "ProgressBar"
        ProgressBar.Size = New Size(720, 23)
        ProgressBar.TabIndex = 6
        ' 
        ' btnAbort
        ' 
        btnAbort.Location = New Point(651, 465)
        btnAbort.Name = "btnAbort"
        btnAbort.Size = New Size(75, 23)
        btnAbort.TabIndex = 7
        btnAbort.Text = "Abort Scan"
        btnAbort.UseVisualStyleBackColor = True
        ' 
        ' TabControl1
        ' 
        TabControl1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        TabControl1.Controls.Add(TabPage1)
        TabControl1.Controls.Add(TabPage2)
        TabControl1.Controls.Add(TabPage3)
        TabControl1.Location = New Point(12, 27)
        TabControl1.Name = "TabControl1"
        TabControl1.SelectedIndex = 0
        TabControl1.Size = New Size(740, 594)
        TabControl1.TabIndex = 8
        ' 
        ' TabPage1
        ' 
        TabPage1.Controls.Add(lstResults)
        TabPage1.Controls.Add(ProgressBar)
        TabPage1.Controls.Add(btnAbort)
        TabPage1.Controls.Add(btnScanDirectory)
        TabPage1.Controls.Add(checkedListDrives)
        TabPage1.Controls.Add(btnScanDrives)
        TabPage1.Location = New Point(4, 24)
        TabPage1.Name = "TabPage1"
        TabPage1.Padding = New Padding(3)
        TabPage1.Size = New Size(732, 566)
        TabPage1.TabIndex = 0
        TabPage1.Text = "Scan"
        TabPage1.UseVisualStyleBackColor = True
        ' 
        ' TabPage2
        ' 
        TabPage2.Controls.Add(ListViewConnections)
        TabPage2.Location = New Point(4, 24)
        TabPage2.Name = "TabPage2"
        TabPage2.Padding = New Padding(3)
        TabPage2.Size = New Size(732, 566)
        TabPage2.TabIndex = 1
        TabPage2.Text = "Connections"
        TabPage2.UseVisualStyleBackColor = True
        ' 
        ' ListViewConnections
        ' 
        ListViewConnections.Location = New Point(6, 6)
        ListViewConnections.Name = "ListViewConnections"
        ListViewConnections.Size = New Size(707, 554)
        ListViewConnections.TabIndex = 0
        ListViewConnections.UseCompatibleStateImageBehavior = False
        ' 
        ' TabPage3
        ' 
        TabPage3.Controls.Add(SystemDisplayBox)
        TabPage3.Location = New Point(4, 24)
        TabPage3.Name = "TabPage3"
        TabPage3.Padding = New Padding(3)
        TabPage3.Size = New Size(732, 566)
        TabPage3.TabIndex = 2
        TabPage3.Text = "System Information"
        TabPage3.UseVisualStyleBackColor = True
        ' 
        ' SystemDisplayBox
        ' 
        SystemDisplayBox.Location = New Point(6, 6)
        SystemDisplayBox.Name = "SystemDisplayBox"
        SystemDisplayBox.Size = New Size(720, 554)
        SystemDisplayBox.TabIndex = 1
        SystemDisplayBox.Text = ""
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.Items.AddRange(New ToolStripItem() {FileToolStripMenuItem, ViewToolStripMenuItem, AboutToolStripMenuItem, SettingsToolStripMenuItem})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Size = New Size(764, 24)
        MenuStrip1.TabIndex = 9
        MenuStrip1.Text = "MenuStrip1"
        ' 
        ' FileToolStripMenuItem
        ' 
        FileToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {ExitToolStripMenuItem})
        FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        FileToolStripMenuItem.Size = New Size(37, 20)
        FileToolStripMenuItem.Text = "File"
        ' 
        ' ExitToolStripMenuItem
        ' 
        ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        ExitToolStripMenuItem.Size = New Size(180, 22)
        ExitToolStripMenuItem.Text = "Exit"
        ' 
        ' ViewToolStripMenuItem
        ' 
        ViewToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {ScannerToolStripMenuItem, ConnectionsToolStripMenuItem, SystemInformationToolStripMenuItem, SystemTempsToolStripMenuItem})
        ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        ViewToolStripMenuItem.Size = New Size(44, 20)
        ViewToolStripMenuItem.Text = "View"
        ' 
        ' ScannerToolStripMenuItem
        ' 
        ScannerToolStripMenuItem.Name = "ScannerToolStripMenuItem"
        ScannerToolStripMenuItem.Size = New Size(178, 22)
        ScannerToolStripMenuItem.Text = "Scanner"
        ' 
        ' ConnectionsToolStripMenuItem
        ' 
        ConnectionsToolStripMenuItem.Name = "ConnectionsToolStripMenuItem"
        ConnectionsToolStripMenuItem.Size = New Size(178, 22)
        ConnectionsToolStripMenuItem.Text = "Connections"
        ' 
        ' SystemInformationToolStripMenuItem
        ' 
        SystemInformationToolStripMenuItem.Name = "SystemInformationToolStripMenuItem"
        SystemInformationToolStripMenuItem.Size = New Size(178, 22)
        SystemInformationToolStripMenuItem.Text = "System Information"
        ' 
        ' SystemTempsToolStripMenuItem
        ' 
        SystemTempsToolStripMenuItem.Name = "SystemTempsToolStripMenuItem"
        SystemTempsToolStripMenuItem.Size = New Size(178, 22)
        SystemTempsToolStripMenuItem.Text = "System Temps"
        ' 
        ' AboutToolStripMenuItem
        ' 
        AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        AboutToolStripMenuItem.Size = New Size(52, 20)
        AboutToolStripMenuItem.Text = "About"
        ' 
        ' SettingsToolStripMenuItem
        ' 
        SettingsToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {VisitWebsiteToolStripMenuItem, AboutToolStripMenuItem1})
        SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        SettingsToolStripMenuItem.Size = New Size(61, 20)
        SettingsToolStripMenuItem.Text = "Settings"
        ' 
        ' VisitWebsiteToolStripMenuItem
        ' 
        VisitWebsiteToolStripMenuItem.Name = "VisitWebsiteToolStripMenuItem"
        VisitWebsiteToolStripMenuItem.Size = New Size(180, 22)
        VisitWebsiteToolStripMenuItem.Text = "Visit Website"
        ' 
        ' AboutToolStripMenuItem1
        ' 
        AboutToolStripMenuItem1.Name = "AboutToolStripMenuItem1"
        AboutToolStripMenuItem1.Size = New Size(180, 22)
        AboutToolStripMenuItem1.Text = "About"
        ' 
        ' FareScanner
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(764, 626)
        Controls.Add(TabControl1)
        Controls.Add(MenuStrip1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MainMenuStrip = MenuStrip1
        MaximizeBox = False
        Name = "FareScanner"
        Text = "FareScanner"
        TabControl1.ResumeLayout(False)
        TabPage1.ResumeLayout(False)
        TabPage2.ResumeLayout(False)
        TabPage3.ResumeLayout(False)
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents lstResults As ListBox
    Friend WithEvents btnScanDrives As Button
    Friend WithEvents btnScanDirectory As Button
    Friend WithEvents checkedListDrives As CheckedListBox
    Friend WithEvents ProgressBar As ProgressBar
    Friend WithEvents btnAbort As Button
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents ListViewConnections As ListView
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ScannerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ConnectionsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SystemInformationToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SystemTempsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents SystemDisplayBox As RichTextBox
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VisitWebsiteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem1 As ToolStripMenuItem

End Class
