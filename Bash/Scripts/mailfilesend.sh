#!/bin/bash
#fast email attachment send where $1 is the path to the attachment

$ echo -e "to: lolno9@gmail.com\nsubject: file send\n"| (cat - && uuencode $1) | ssmtp -v lolno9@gmail.com
