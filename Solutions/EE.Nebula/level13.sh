# Solution by Farzad E. (me@dNetGuru.com)  / @dNetGuru

echo -e "b main\nr\nb *main+292\nj *main+109" > ~/dnetS
gdb /home/flag13/flag13 -x ~/dnetS -batch
rm -rf ~/dnetS