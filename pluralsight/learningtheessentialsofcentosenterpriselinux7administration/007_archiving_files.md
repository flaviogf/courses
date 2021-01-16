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
```
