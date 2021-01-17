# Understanding File Permissions

```sh
df -hT

mount

mount | grep root

ls -l

# user:group:others

# -rwxrwxrwx tux tux 692 Jan 1 16:21 hello.sh

stat hello.sh,v

stat -c %A hello.sh,v

stat -c %a hello.sh,v
```

- 4 read
- 2 write
- 1 execute

```sh
cd Documents

ls

ls -a

touch file1

ls -l

umask

umask 0

touch file2

stat -c %a file2

umask 27

touch file3

ls -l

umask 77

touch file4

ls -l

umask u=rwx,g=rx,o=rx

touch file5

ls -l

umask 033

touch file6

ls -l

umask u=rwx,go=

touch file7

ls -l

vi file1

cat file 1

chmod 467 file1

chmod u=r,g=rw,o=rwx file1

cat file1

ls -l file1

chmod a+x file2

ls -l file2

chmod a-x file2

ls -l file2

chmod o= file2

ls -l file2

chmod 777 file2

ls -l file2

chmod go= file2

ls -l file2

umask

# stick bit

ls -ld /tmp

mkdir -m 1777 test

ls -ld test

chmod o-t test

ls -l test

# user id bit

ls -l $(which wall)

ls -l $(which passwd)
```
