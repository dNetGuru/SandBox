# Solution by Farzad E. (me@dNetGuru.com)  / @dNetGuru

cd ~
echo -e '#include <iostream>\n#include <fstream>\nusing namespace std; int main () { char ch; int j = 0; ifstream f ("/home/flag14/token"); streambuf *p = f.rdbuf(); while (p->sgetc()!= EOF) { ch = p->sbumpc() - j; cout << ch;j++; } f.close(); return 0; }' > ~/d.c
g++ ~/d.c -o ~/e
~/e /home/flag14/token
echo -e '\nNow su flag14 and use the token as password !'
rm ~/d.c ~/e