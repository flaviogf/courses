# Scheduling Tasks in Linux

```sh
df -h

df -h >> df.txt

mail -s "df $(date +%F)" root < df.txt

rm df.txt

sudo vim /etc/crontab

crontab -e

sudo apt install anacron

sudo vim /etc/anacrontab
```

```txt
# /etc/crontab

*/1 * * * * root df -h >> /tmp/df.log
```

```txt
# /etc/anacrontab

1 5 update apt update &> update.log
```
