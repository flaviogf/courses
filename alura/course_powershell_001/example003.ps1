Get-ChildItem -Recurse -File C:\Users\flavio\dev\dotfiles | Where-Object Name -Like "*rc*" | Select-Object Name, Length
