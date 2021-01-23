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
