# Scheduling Tasks in Linux

```sh
df -h

df -h >> df.txt

mail -s "df $(date +%F)" root < df.txt

rm df.txt

sudo vim /etc/crontab

crontab -e
```

```txt
# /etc/crontab

*/1 * * * * root df -h >> /tmp/df.log
```
