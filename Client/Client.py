import socket

s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
host ="127.0.0.1"
port =8007
s.connect((host,port))

def ts(str,string):
   s.send(string.encode()) 
   data = ''
   data = s.recv(1024).decode()

while 2:
   r = input('')
   ts(s,r)

s.close ()