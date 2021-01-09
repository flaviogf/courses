# Reading Files

```sh
cat /etc/hosts

cat /etc/hostname

cat /etc/host /etc/hostname

wc -l /etc/services

less /etc/services

!$ # the last argument

head /etc/services

head -n 3 /etc/services

tail -n 3 /etc/services

tail /etc/passwd

yum list installed

yum list installed | grep kernel

yum list installed | grep ^kernel

sudo yum install ntp

cat /etc/ntp.conf

wc -l !$

cp /etc/ntp.conf .

ls

grep server ntp.conf

type grep

grep ^server ntp.conf

grep '\bserver\b' ntp.conf

sudo yum install words

grep -E 'ion$' /usr/share/dict/words

grep -E '^po..ute$' /usr/share/dict/words

grep -E '[aeiou]{5}' /usr/share/dict/words

grep -E '[aeiou]{6}' /usr/share/dict/words

sed '/^#/d' ntp.conf

sed '/^$/d' ntp.conf

sed '/^#/d ; /^$/d' ntp.conf

function clean_file {
  sed -i '/^#/d ; /^$/d' $1
}
```
