# Log Files and Logrotate

```sh
lastlog

lastlog | grep -v "Never"

last

last -n 10

sudo lastb

ls /var/log

awk '/sudo/ { print $0 }' auth.log

awk '/sudo/ { print $5 }' auth.log

awk '/sudo/ { print $5, $6, $14 }' auth.log
```
