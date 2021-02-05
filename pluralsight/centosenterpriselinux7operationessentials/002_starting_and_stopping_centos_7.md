# Starting and Stopping CentOS 7

```sh

write tux

cat > hello.txt <<END
Hello how are you doing?
END

wall < hello.txt

reboot

shutdown

poweroff

init --help

shutdown -h 10 "The system goes home in 10 min"

# cancel shutdown

shutdown -c

ls /run

ls /run/nologin

cat /run/nologin
```
