Imports System.IO
Imports System.Security.Cryptography
Imports System.Net
Imports System.Threading
Imports System.Diagnostics
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Management
Imports System.Environment
Imports Microsoft.VisualBasic.Devices



Public Class FareScanner
    Private KnownMaliciousHashes As New List(Of String)()
    Private scanCancellationTokenSource As CancellationTokenSource
    Private Timer1 As New System.Windows.Forms.Timer()

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Scan_Setup()
        Connections_Setup()
        SystemInformation_Setup()
    End Sub

    'Setup
#Region "Load Setups"
    Private Sub Scan_Setup()
        PopulateDrives()
        ProgressBar.Value = 0
        ProgressBar.Minimum = 0
        ProgressBar.Step = 1
    End Sub

    Private Sub Connections_Setup()
        ShowConnections()
        Timer1.Interval = 30000
        AddHandler Timer1.Tick, AddressOf Timer1_Tick
        Timer1.Start()
        ListViewSetup()
    End Sub

    Private Sub SystemInformation_Setup()
        SystemDisplayBox.Clear()

        ' Append each item to the RichTextBox with a newline after each
        SystemDisplayBox.AppendText(GetComputerInfo() & Environment.NewLine)
        SystemDisplayBox.AppendText(GetOSInfo() & Environment.NewLine)
        SystemDisplayBox.AppendText(GetCPUInfo() & Environment.NewLine)
        SystemDisplayBox.AppendText(GetRAMInfo() & Environment.NewLine)
        SystemDisplayBox.AppendText(GetGPUInfo() & Environment.NewLine)
        SystemDisplayBox.AppendText(GetDiskInfo() & Environment.NewLine)
    End Sub

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)
        CenterToScreen()
    End Sub
#End Region

    'System Information
#Region "System Information"
    Public Function GetComputerInfo() As String
        Dim computerName As String = Environment.MachineName
        Dim userName As String = Environment.UserName
        Return $"Computer Name: {computerName}, Logged In User: {userName}"
    End Function

    Public Function GetOSInfo() As String
        Dim osInfo As OperatingSystem = Environment.OSVersion
        Dim osName As String = My.Computer.Info.OSFullName
        Dim osVersion As String = osInfo.VersionString
        Return $"OS: {osName}, Version: {osVersion}"
    End Function

    Public Function GetCPUInfo() As String
        Dim searcher As New ManagementObjectSearcher("select * from Win32_Processor")
        Dim cpuName As String = ""
        Dim cpuUsage As Integer = 0

        For Each item As ManagementObject In searcher.Get()
            cpuName = item("Name").ToString()
            cpuUsage = Convert.ToInt32(item("LoadPercentage"))
        Next

        Return $"CPU: {cpuName}, Usage: {cpuUsage}%"
    End Function

    Public Function GetRAMInfo() As String
        Dim totalRam As ULong = My.Computer.Info.TotalPhysicalMemory
        Dim availableRam As ULong = My.Computer.Info.AvailablePhysicalMemory
        Dim usedRam As ULong = totalRam - availableRam

        Return $"Total RAM: {FormatBytes(totalRam)}, Used RAM: {FormatBytes(usedRam)}, Available RAM: {FormatBytes(availableRam)}"
    End Function

    Private Function FormatBytes(bytes As ULong) As String
        Return (bytes / 1024 / 1024).ToString("N2") & " MB"
    End Function

    Public Function GetGPUInfo() As String
        Dim searcher As New ManagementObjectSearcher("select * from Win32_VideoController")
        Dim gpuName As String = ""

        For Each item As ManagementObject In searcher.Get()
            gpuName = item("Name").ToString()
        Next

        Return $"GPU: {gpuName}"
    End Function

    Public Function GetDiskInfo() As String
        Dim totalDiskSpace As ULong = My.Computer.FileSystem.Drives.First().TotalSize
        Dim availableDiskSpace As ULong = My.Computer.FileSystem.Drives.First().AvailableFreeSpace
        Dim usedDiskSpace As ULong = totalDiskSpace - availableDiskSpace

        Return $"Total Disk Space: {FormatBytes(totalDiskSpace)}, Used Disk Space: {FormatBytes(usedDiskSpace)}, Available Disk Space: {FormatBytes(availableDiskSpace)}"
    End Function
#End Region

    'Display Connections
#Region "Connections"
    Private Sub ListViewSetup()
        ListViewConnections.Columns.Add("Local Address", 150)
        ListViewConnections.Columns.Add("Remote Address", 150)
        ListViewConnections.Columns.Add("State", 100)
        ListViewConnections.Columns.Add("PID", 50)
        ListViewConnections.Columns.Add("Application", 200)
        ListViewConnections.View = View.Details
    End Sub

    Private Sub ShowConnections()
        ListViewConnections.Items.Clear()

        Dim netstatOutput As String = RunNetstat()
        Dim connections As List(Of NetworkConnection) = ParseNetstatOutput(netstatOutput)

        For Each conn In connections
            Dim processName As String = "Unknown"

            Try
                Dim proc As Process = Process.GetProcessById(conn.PID)
                processName = proc.ProcessName
            Catch ex As Exception
                ' Process may no longer be running
            End Try

            Dim lvi As New ListViewItem(conn.LocalAddress)
            lvi.SubItems.Add(conn.RemoteAddress)
            lvi.SubItems.Add(conn.State)
            lvi.SubItems.Add(conn.PID.ToString())
            lvi.SubItems.Add(processName)

            ListViewConnections.Items.Add(lvi)
        Next
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs)
        ShowConnections()
    End Sub

    Private Function RunNetstat() As String
        Dim psi As New ProcessStartInfo("netstat", "-ano")
        psi.RedirectStandardOutput = True
        psi.UseShellExecute = False
        psi.CreateNoWindow = True

        Dim process As New Process()
        process.StartInfo = psi
        process.Start()

        Dim output As String = process.StandardOutput.ReadToEnd()
        process.WaitForExit()

        Return output
    End Function

    Private Function ParseNetstatOutput(output As String) As List(Of NetworkConnection)
        Dim connections As New List(Of NetworkConnection)()
        Dim lines() As String = output.Split(New String() {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)

        Dim regex As New Regex("\s*(TCP|UDP)\s+([\d\.]+:\d+)\s+([\d\.]+:\d+)\s+(\S+)\s+(\d+)")
        For Each line In lines
            Dim match As Match = regex.Match(line)
            If match.Success Then
                Dim conn As New NetworkConnection() With {
                    .Protocol = match.Groups(1).Value,
                    .LocalAddress = match.Groups(2).Value,
                    .RemoteAddress = match.Groups(3).Value,
                    .State = match.Groups(4).Value,
                    .PID = Convert.ToInt32(match.Groups(5).Value)
                }
                connections.Add(conn)
            End If
        Next

        Return connections
    End Function
#End Region

    'Scan System
#Region "ScannerRegion"
    ' Populate the CheckedListBox with available drives
    Private Sub PopulateDrives()
        Dim drives As DriveInfo() = DriveInfo.GetDrives()
        checkedListDrives.Items.Clear()

        For Each drive In drives
            If drive.IsReady Then
                checkedListDrives.Items.Add(drive.Name, False)
            End If
        Next
    End Sub

    Private Async Sub btnScanDrives_Click(sender As Object, e As EventArgs) Handles btnScanDrives.Click
        lstResults.Items.Clear()
        ProgressBar.Value = 0

        ' Initialize the cancellation token source
        scanCancellationTokenSource = New CancellationTokenSource()

        Dim allFiles As New List(Of String)()

        ' Collect all files from the selected drives
        For Each selectedDrive As String In checkedListDrives.CheckedItems
            allFiles.AddRange(GetAllFiles(selectedDrive))
        Next

        ' Set ProgressBar maximum to the total number of files
        ProgressBar.Maximum = allFiles.Count

        ' Scan each file asynchronously and update the ProgressBar
        Try
            Await Task.Run(Sub()
                               For Each file As String In allFiles
                                   ' Check if the scan was aborted
                                   If scanCancellationTokenSource.Token.IsCancellationRequested Then
                                       Exit For
                                   End If

                                   ' Scan the file
                                   ScanFile(file)

                                   ' Update ProgressBar on UI thread
                                   Invoke(Sub() ProgressBar.PerformStep())
                               Next
                           End Sub, scanCancellationTokenSource.Token)

            If Not scanCancellationTokenSource.Token.IsCancellationRequested Then
                MessageBox.Show("Scanning complete!")
            Else
                MessageBox.Show("Scanning aborted!")
            End If
        Catch ex As OperationCanceledException
            MessageBox.Show("Scanning aborted!")
        End Try
    End Sub

    ' Button to scan a specific directory chosen by the user
    Private Async Sub btnScanDirectory_Click(sender As Object, e As EventArgs) Handles btnScanDirectory.Click
        lstResults.Items.Clear()
        ProgressBar.Value = 0

        Using folderDialog As New FolderBrowserDialog()
            If folderDialog.ShowDialog() = DialogResult.OK Then
                Dim directoryPath As String = folderDialog.SelectedPath

                ' Initialize the cancellation token source
                scanCancellationTokenSource = New CancellationTokenSource()

                ' Collect all files from the selected directory
                Dim allFiles As List(Of String) = GetAllFiles(directoryPath)

                ' Set ProgressBar maximum to the total number of files
                ProgressBar.Maximum = allFiles.Count

                ' Scan each file asynchronously and update the ProgressBar
                Try
                    Await Task.Run(Sub()
                                       For Each file As String In allFiles
                                           ' Check if the scan was aborted
                                           If scanCancellationTokenSource.Token.IsCancellationRequested Then
                                               Exit For
                                           End If

                                           ' Scan the file
                                           ScanFile(file)

                                           ' Update ProgressBar on UI thread
                                           Invoke(Sub() ProgressBar.PerformStep())
                                       Next
                                   End Sub, scanCancellationTokenSource.Token)

                    If Not scanCancellationTokenSource.Token.IsCancellationRequested Then
                        MessageBox.Show("Scanning complete!")
                    Else
                        MessageBox.Show("Scanning aborted!")
                    End If
                Catch ex As OperationCanceledException
                    MessageBox.Show("Scanning aborted!")
                End Try
            End If
        End Using
    End Sub

    ' Button to abort the current scan
    Private Sub btnAbort_Click(sender As Object, e As EventArgs) Handles btnAbort.Click
        If scanCancellationTokenSource IsNot Nothing Then
            ' Cancel the scan
            scanCancellationTokenSource.Cancel()
        End If
    End Sub

    ' Recursive method to collect all files from a directory or drive
    Private Function GetAllFiles(path As String) As List(Of String)
        Dim files As New List(Of String)()

        Try
            ' Add all files from the current directory
            files.AddRange(Directory.GetFiles(path))

            ' Recursively get files from subdirectories
            For Each dir As String In Directory.GetDirectories(path)
                Try
                    files.AddRange(GetAllFiles(dir))
                Catch ex As UnauthorizedAccessException
                    ' Handle access denied errors for directories
                    Invoke(Sub() lstResults.Items.Add($"Access denied to directory: {dir}"))
                Catch ex As IOException
                    ' Handle directory in use errors
                    Invoke(Sub() lstResults.Items.Add($"Directory in use by another process: {dir}"))
                End Try
            Next
        Catch ex As UnauthorizedAccessException
            ' Handle access denied errors for the main directory
            Invoke(Sub() lstResults.Items.Add($"Access denied to directory: {path}"))
        Catch ex As IOException
            ' Handle directory in use errors for the main directory
            Invoke(Sub() lstResults.Items.Add($"Directory in use by another process: {path}"))
        End Try

        Return files
    End Function

    ' Method to scan a single file and compare its hash
    Private Sub ScanFile(file As String)
        Try
            Dim fileHash As String = ComputeSHA256Hash(file)

            ' Compare the file hash to known malicious hashes
            If KnownMaliciousHashes.Contains(fileHash) Then
                Invoke(Sub() lstResults.Items.Add($"Malicious file detected: {file}"))
            Else
                Invoke(Sub() lstResults.Items.Add($"File scanned: {file} (Safe)"))
            End If
        Catch ex As UnauthorizedAccessException
            ' Handle access denied errors
            Invoke(Sub() lstResults.Items.Add($"Access denied to file: {file}"))
        Catch ex As IOException
            ' Handle file in use errors
            Invoke(Sub() lstResults.Items.Add($"File in use by another process: {file}"))
        End Try
    End Sub

    ' Function to compute the SHA256 hash of a file
    Private Function ComputeSHA256Hash(filePath As String) As String
        Using sha256 As SHA256 = SHA256.Create()
            ' Wrap file reading with Try...Catch to handle file access errors
            Try
                Using stream As FileStream = File.OpenRead(filePath)
                    Dim hash As Byte() = sha256.ComputeHash(stream)
                    Return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant()
                End Using
            Catch ex As UnauthorizedAccessException
                ' Handle access denied
                Throw
            Catch ex As IOException
                ' Handle file in use
                Throw
            End Try
        End Using
    End Function
#End Region

#Region "MenuStrip"
    Private Sub AboutToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem1.Click
        About.Show()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub
#End Region
End Class

Public Class NetworkConnection
    Public Property Protocol As String
    Public Property LocalAddress As String
    Public Property RemoteAddress As String
    Public Property State As String
    Public Property PID As Integer
End Class
