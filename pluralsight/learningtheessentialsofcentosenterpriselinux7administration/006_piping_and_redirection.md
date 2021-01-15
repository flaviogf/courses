# Piping and Redirection

- noclobber
- CTRL+r

```sh
> newfile

ls > newfile

df -h > newfile

df -h 1> newfile

df -h 1>> newfile

less newfile

cat newfile

set -o

set -o noclobber

date +%F 1> newfile2

date +%F 1>| newfile2

date +%F 1>> newfile2

set +o noclobber

cat /etcw 2> newfile3

find /etc -type l

find /etc -type l 2> /dev/null

find /etc -type l &> err.txt

df -hlT > diskfree

mail -s "Disk Free" tux < diskfree
```
