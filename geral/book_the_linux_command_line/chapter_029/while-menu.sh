#!/bin/bash

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
done
