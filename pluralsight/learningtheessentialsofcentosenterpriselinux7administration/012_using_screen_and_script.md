# Using Screen and Scripts

```sh
# tux

mkfifo /tmp/pipe

script -f /tmp/pipe
```

```sh
# root

cat /tmp/pipe
```

```sh
sudo yum install screen

# .screenrc

screen -t s1 0 ssh server1

screen -t s2 1 ssh server2
```
