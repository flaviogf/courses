$nameExpression = @{Label="Name"; Expression="Name"}
$lengthExpression = @{Label="Length"; Expression={"{0:N2} KB" -f ($_.Length / 1KB)}}

$columns = @($nameExpression, $lengthExpression)

gci C:\Users\flavio\dev\dotfiles |
? Name -Like "*rc*" |
select $columns
