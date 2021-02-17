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
```
