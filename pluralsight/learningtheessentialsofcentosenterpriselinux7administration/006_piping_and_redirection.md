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
```
