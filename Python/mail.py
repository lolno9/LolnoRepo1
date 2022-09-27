import smtplib
from email.mime.multipart import MIMEMultipart
from email.mime.text import MIMEText

datos = open('mpip','r')
message = datos.read()
s = smtplib.SMTP(host='smtp.gmail.com', port=587)
s.starttls()
s.login('lolno9@gmail.com','kaosX1993!')
msg = MIMEMultipart()
mesag = message.toPlainText()
mesg = str(mesag)
#message = message_template.substitute(PERSON_NAME=name.title())
msg['From']='lolno9@gmail.com'
msg['To']='lolno9@gmail.com'
msg['Subject']='This is TEST'
msg.attach(MIMEText(mesg.encode('utf-8'),'utf-8'))
s.send_message(msg)
del msg
