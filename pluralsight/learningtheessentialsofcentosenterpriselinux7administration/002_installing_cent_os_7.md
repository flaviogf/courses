# Installing CentOS 7

- [CentOS](https://www.centos.org)
- [Virtual Box](https://www.virtualbox.org)

````sh
yum update

yum install -y redhat-lsb-core net-tools epel-release kernel-headers kernel-devel

yum groupinstall -y "Development Tools"

yum groupinstall -y "X Window System" "MATE Desktop"

systemctl set-default graphical.target

systemctl isolate graphical.target

su -

nmcli c show

nmcli c up <network-device-name>

nmcli c show

ip a show

sed -i "s/ONBOOT=no/ONBOOT=true/" /etc/sysconfig/network-scripts/<network-device-name>
````
