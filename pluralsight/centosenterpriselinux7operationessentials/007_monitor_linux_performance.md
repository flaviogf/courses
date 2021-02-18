# Monitor Linux Performance

```sh
rpm -ql procps-ng

rpm -qf /usr/bin/top

rpm -ql procps-ng | grep '^/usr/bin'

rpm -ql procps-ng | grep '^/usr/bin' | wc -l

free

free -m

free -g

pgrep sshd

pmap $$

echo $$

pwdx $$

pwdx $(pgrep sshd)

sudo pwdx $(pgrep sshd)

cd /proc/$$

pwd

ls

uptime

lscpu

cat /proc/uptime

cat /proc/loadavg

watch uptime

watch -n 4 uptime

tload

tar -cJvf doc.tar.xz /usr/share/doc

top

top -b -n 1

top -b -n 1 > file1

less file1

vmstat

vmstat -S K

vmstat -S k

vmstat -S m

vmstat 5 3
```
