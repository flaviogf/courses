# Managing GRUB2

```sh
grub2-install /dev/sda

vi /etc/defaults/grub

grub2-mkconfig -o /boot/grub2/grub.cfg

reboot

grubby --default-kernel

grubby --set-default /boot/vmlinuz

grubby --default-kernel

grubby --info=ALL

grubby --info /boot/vmlinuz

grubby --remove-args="rhgb quiet"

reboot

vi /etc/grub.d/01_users

cat << EOF
    set superusers="flaviogf"
    password flaviogf test123
EFO

vi /etc/grub.d/40_custom
```
