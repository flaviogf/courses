# Process Priority

```sh
sleep 1000 &

sleep 1000

# ctrl+z

jobs

bg

fg

stty -a

ps -p 13732

ps -F 13732

echo $$

pgrep sleep

jobs

ps -F -p $(pgrep sleep)

pkill sleep

pgrep sleep

sleep 1000 &

ps -l

nice -n 19 sleep 1000

# ctrl+z

bg

ps -l

nice -n 1 sleep 100 &

ps -l

renice -n 10 -p 14145

ps -l

su -

nice -n -20 sleep 1000 &

ps -l

ps -l -p $(pgrep sleep)

vi /etc/security/limits.conf
```

```sh
# /etc/security/limits.conf

tux - priority 10
```

```sh
sleep 250 &

ps -l

su - tux

sleep 250 &

ps -l
```
