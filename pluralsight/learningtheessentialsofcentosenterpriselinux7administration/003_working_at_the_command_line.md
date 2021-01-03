# Working at the Command Line

CTRL+SHIFT+T

````sh
pwd

exit
````

CTRL+D

````sh
cd Desktop

cd
````

RIGHT CTRL+F2

RIGHT CTRL+F1

````sh
tty

who

ip a s

ls

type ls

ls --color=auto

ls -a

ls -aF

ls -lrlt /etc

ls -lhrlt /etc

tty

ls -l /dev/pts/1

ls -l $(tty)

lsblk

ls /dev/sda

ls /dev/sda*

ls /dev/sda?

ls /dev/sda[12]

ls -l /etc/sytem-release

ls -l /etc/centos-release /etc/system-release /etc/redhat-release

lsb_release -d

ls -l $(which lsb_release)

ls -lF $(which lsb_release)

rpm -qf /usr/bin/lsb_release

rpm -qf $(which lsb_release)

pwd

cd Documents

cp /etc/hosts .

cp /etc/passwd .

cp /etc/hosts ./passwd

cp -i /etc/hosts ./passwd

mv ./hosts ./localhosts

cp ./localhosts ./hosts

rm -i *

mkdir test

mkdir -p sales/test

rmdir test

rmdir sales

!rm

rm -rf sales

mkdir one two

touch one/file{1..5}

cp -R one two

yum install tree

tree two

mkdir -m 777 d1

mkdir -m 700 d2

ls -ld d1 d2
````
