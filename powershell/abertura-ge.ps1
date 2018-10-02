param(
  [string]$env = "L"
)

<# 

L = localhost
H = homologacao/hk
D = dev
P = producao

#>

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

$endpath = '/gest-estoque/stock-manager/v1/opening/start'
$finalpath = -join($path, $endpath);

Try
{
    $response = Invoke-RestMethod $finalpath -Method Post -ContentType 'application/json'
    $response.return.code
}
Catch
{
    "-1"
    Break
}