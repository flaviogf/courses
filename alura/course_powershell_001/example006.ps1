$columns = "Name", { "{0:N2}" -f ($_.Length / 1KB) }

gci C:\Users\flavio\dev\dotfiles |
? Name -Like "*rc" |
select $columns 
