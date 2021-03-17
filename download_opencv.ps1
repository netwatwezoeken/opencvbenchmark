$uri = "https://github.com/opencv/opencv/releases/download/4.5.1/opencv-4.5.1-vc14_vc15.exe"

function Download($uri, $outFile) {
    Write-Host "Downloading ${uri} to ${outFile}"
    if (!(Test-Path $outFile)) {
        $wc = New-Object System.Net.Webclient
		$wc.Downloadfile($uri, $outFile)
    }
}

$newDirectory = Join-Path -Path $PSScriptRoot -ChildPath "opencv_files"

New-Item opencv_files -Type directory -Force -ErrorAction Stop | Out-Null
cd $newDirectory

[Net.ServicePointManager]::SecurityProtocol = @([Net.SecurityProtocolType]::Tls,[Net.SecurityProtocolType]::Tls11,[Net.SecurityProtocolType]::Tls12)

$filename = [System.IO.Path]::GetFileName($uri)
$outFile = Join-Path -Path $pwd -ChildPath $filename
Download $uri $outFile
&./$filename  -o".\" -y
Write-Host "Please wait for the extraction to complete"
cd ..
