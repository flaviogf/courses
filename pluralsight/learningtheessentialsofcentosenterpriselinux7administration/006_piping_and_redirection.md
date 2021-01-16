# Piping and Redirection

- noclobber
- CTRL+r
- unnamed pipe |
- named pipe

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

cat > newfile4 <<END
this is little
file that we can create
even with scripts
END

ls | wc -l

head -n1 /etc/passwd

cut -f7 -d: /etc/passwd

cut -f7 -d: /etc/passwd | sort

cut -f7 -d: /etc/passwd | sort | uniq

cut -f7 -d: /etc/passwd | sort | uniq | wc -l

ls -l $(tty)

ls -l /dev/sda

mkfifo mypipe

ls -F mypipe

ls > mypipe

wc -l < mypipe

ls | tee f89

sudo echo '127.0.0.1 bob' >> /etc/hosts

# Permission denied

echo '127.0.0.1' | sudo tee -a /etc/hosts
```
