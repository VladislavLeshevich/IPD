import os
import subprocess
import re
subprocess.call("sudo hdparm -I /dev/sda > " + os.getcwd() + "/log.txt", shell=True)
logfile = open(os.getcwd() + "/log.txt")
keys = ["Model Number", "Firmware Revision", "Serial Number", "Transport", "DMA", "PIO"]
dictianory = {k: None for k in keys}

for i in logfile:
    for j in keys:
        if ((j + ":") in i):
            temp = i.split(j)[1]
            if (":" in temp):
                temp = temp.split(":")[1]
            if ("\t" in temp):
                temp = temp.split("\t")[1]
            if ("\n" in temp):
                temp = temp.split("\n")[0]
            while (temp[0] == ' '):
                temp = temp[1:]
            while (temp[-1] == ' '):
                temp = temp[:-2]
            dictianory[j] = temp

logfile.close()
subprocess.call("df -hm | grep /dev/sda > " + os.getcwd() + "/log.txt", shell=True)
logfile = open(os.getcwd() + "/log.txt")

memdict = {"all": 0, "free": 0, "used": 0}
line = None
for line in logfile:
    result = re.split(r" +", line)
    if (len(result) > 3):
        memdict["all"] = memdict["all"] + int(result[1])
        memdict["used"] = memdict["used"] + int(result[2])
        memdict["free"] = memdict["free"] + int(result[3])

tempDict = {"Memory": memdict}
dictianory.update(tempDict)
for k in dictianory.keys():
    print(k + " : ")
    print(dictianory[k])
path = os.path.join(os.path.abspath(os.path.dirname(__file__)), os.getcwd() + "/log.txt")
os.remove(path)

#CHS   LBA