#!/bin/bash

DELAY=3

while [[ "$REPLY" != 0 ]]; do
    clear

cat <<-EOF
Please Select:

1. Display System Information
2. Display Disk Space
3. Display Home Space Utilization
0. Quit

EOF

    read -p "Enter selection [0-3]> "

    if [[ "$REPLY" =~ ^[0-3]$ ]]; then
        if [[ "$REPLY" == 1 ]]; then
            echo "Hostname: ${HOSTNAME}"
            uptime
            sleep $DELAY
        fi
    else
        echo "Invalid entry"
        sleep $DELAY
    fi
done
