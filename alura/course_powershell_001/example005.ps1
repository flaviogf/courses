Get-ChildItem C:\Users\flavio\dev\dotfiles | Where-Object Name -Like "*rc*" | Select-Object Name, { "{0:N2} KB" -f ($_.Length / 1KB) }
