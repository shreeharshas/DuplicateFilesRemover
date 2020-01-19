## General Info:

I wanted to clear some disk space and found that i had copy-pasted some folders randomly causing the duplicates to use up disk space on my laptop.

Since there were too many files and they were distributed too randomly, I didn't want to manually check them one by one.
I also wanted to have control over the files I deleted because I didn't want the program to simple delete them without running them by me.

So I wrote a simple program to quickly group the files which were the same and also show me all of them as options for me to choose before it removed them.

This single-screen app which looks as follows:
![Main Screen](/DFR.png)

## Usage Info:

This app is simple and self explanatory, verbose explanation as below:

--> Select the folder to scan
--> Click refresh to scan the folder
--> Wait till the blank section fills up with the files list or any message.
--> Double click on the file names to preview in Windows explorer.
--> Click Select Duplicate files button to select all files but the first in every section.
--> Click Delete Selected Files button to remove the files.

Relatively bigger files such as videos may take longer time to be processed.
Refer to General Info for the reason behind this app.

## Technical Details:

The main logic behind this is to generate hashcodes based on the file contents and comparing them which is essentially a comparision of the files themselves.
Files with the same hashcodes are grouped under the header having the hashcode value itself as its text.
I have currently used md5 hashing scheme to check for sameness.

## System Requirements

Manual tests executed successfully on my machine with following specs:
OS - Microsoft Windows 10
Development framework - Microsoft Dotnet framework version 4.0

## Warning:

This is a beta version and is to be used at your own risk.
The files are not moved to the recycle bin so make sure you double-check the files before deleting.

## Terms and Conditions:

Use this app at your own risk - I do not guarantee anything and do not want to be legally bound whatsoever if it results in any kind of damage to your machine.

## Future Enhancements:

Delete folder if folder is empty i.e., if hashcode is selected.
Add a waiting screen.
Move file to parent folder and delete the containing folder if there is only one file in the directory.
Send to recyclebin option.
Provide options to hash based on checksum algorithms other than md5 too.
file size zero - special condition - separate tree
system-wide scan option
