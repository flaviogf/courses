# Archiving Files

```sh
tar -c

tar --create

man tar

tar -cf doc.tar /usr/share/doc

tar -cvf doc.tar /usr/share/doc

tar -cvvf doc.tar /usr/share/doc

tar --list --file=doc.tar

tar -tf doc.tar

tar -tvf doc.tar

tar --extract --verbose -f doc.tar

tar -xvf doc.tar

sudo tar --extract --verbose -f --directory=/ doc.tar

mkdir test

cd test

cp /etc/hosts .

cp /etc/hostname .

cp /etc/services .

cd ~

# snapshot + tar = snar

tar -cvf my0.tar -g my.snar test

echo hi >> test/hosts

tar -cvf my1.tar -g my.snar test

rm test/hostname

tar -cvf my2.tar -g my.snar test

rm -rf test

tar -xvf my0.tar -g /dev/null

tar -xvf my1.tar -g /dev/null

tar -xvf my2.tar -g /dev/null

gzip tux.tar

gunzip tux.tar.gz

file tux.tar

bzip2 tux.tar

file tux.tar.bz2

bunzip2 tux.tar.bz2

time tar -cvf tux.tar $HOME

time tar -cvzf tux.tar.gz $HOME

time tar -cvjf tux.tar.bz2 $HOME

tar -xzf tux.tar.gz

tar -xjf tux.tar.bz2

find /usr/share/doc -name '*.pdf'

cd /usr/share/doc

find -name '*.pdf'

find -name '*.pdf' | cpio -o > /tmp/pdf.cpio

cd

mkdir pdf

cd !$

pwd

cpio -id < /tmp/pdf.cpio

ls

cd /tmp

sudo cp /boot/initramfs.img .

ls

file initramfs.img

mkdir work

cd work

cpio -id < ../initramfs-*.img

ls

tree

dd if=/dev/sro of=netinstall.iso

ls -lh

sudo dd if=/dev/sda1 of=boot.img

sudo su -

fdisk -l

dd if=/dev/sda of=sda.mbr count=1 bs=512
```
