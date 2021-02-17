# Managing Linux Processes

```sh
ps

ps aux

ps -e

man ps

ps -l

ps -ly

pstree

ps aux | grep sshd

ps -p1 -F

cd /proc && ls

echo $$

ps -p $$ -F

cd $$

ls -l cwd

ls -l exe

stty -a

kill -l

kill 8537

kill -15 8537

kill -term 8537

kill -sigterm 8537

kill -9 8537

kill -kill 8537

kill -sigkill 8537

psgrep sshd

ps -F -p $(psgrep sshd)

sleep 100&

psgrep sleep

pkill sleep

top

ps --forest

pstree

cd /proc/$$
```
