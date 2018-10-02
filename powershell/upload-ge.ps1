param(
  [string]$env = "L",
  [string]$filepath = "mopl.csv",
  [string]$fullpath = ""
)

<# 

L = localhost
H = homologacao/hk
D = dev
P = producao

#>

if (-not ([string]::IsNullOrEmpty($fullpath))) 
{
    $Uri = $fullpath;
} 
else 
{
    if ($env.ToUpper() -eq "L") { 
        $path = 'http://localhost:8080'
    }
    elseif ($env.ToUpper() -eq "H") {
        $path = 'https://cpt.paas.santanderbr.pre.corp'
    }
    elseif ($env.ToUpper() -eq "D") {
        $path = 'https://cpt.paas.isbanbr.dev.corp'
    }
    elseif ($env.ToUpper() -eq "P") {
        $path = 'https://cpt.paas.santanderbr.corp'
    }

    $endpath = '/gest-estoque/stock-manager/v1/stocksale/upload'
    $Uri = -join($path, $endpath);
}

$InFile = $filepath
$ContentType = "multipart/form-data"

if (-not (Test-Path $InFile))
{
    $errorMessage = ("Arquivo {0} não localizado ou falha na leitura." -f $InFile)
    $exception =  New-Object System.Exception $errorMessage
	$errorRecord = New-Object System.Management.Automation.ErrorRecord $exception, 'MultipartFormDataUpload', ([System.Management.Automation.ErrorCategory]::InvalidArgument), $InFile
	$PSCmdlet.ThrowTerminatingError($errorRecord)
}

if (-not $ContentType)
{
    Add-Type -AssemblyName System.Web

    $mimeType = [System.Web.MimeMapping]::GetMimeMapping($InFile)
            
    if ($mimeType)
    {
        $ContentType = $mimeType
    }
    else
    {
        $ContentType = "application/octet-stream"
    }
}	
	
$fileName = Split-Path $InFile -leaf
$boundary = [guid]::NewGuid().ToString()
$fileBin = [System.IO.File]::ReadAllBytes($InFile)
$enc = [System.Text.Encoding]::GetEncoding("iso-8859-1")

$template = @'
--{0}
Content-Disposition: form-data; name="file"; filename="{1}"
Content-Type: {2}

{3}
--{0}--

'@

$body = $template -f $boundary, $fileName, $ContentType, $enc.GetString($fileBin)

Try
{
    $response = Invoke-WebRequest -Uri $Uri -Method Put -ContentType "multipart/form-data; boundary=$boundary" -Body $body
    if($response.StatusCode -eq 200){
        "0"
    }
}
Catch
{
    "-1"
    Break
}