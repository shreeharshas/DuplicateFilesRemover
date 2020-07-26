## General Info:

My dad wanted to clear some disk space on his computer and found that there were some duplicate folders at random locations occuping unnecesary disk space. <br /> <br />

Since there were too many files and they were distributed randomly, he didn't want to manually check them one by one. <br />
He also wanted to have control over the files to be deleted because he didn't want the program to simple delete them without running them by him. <br /> <br />

So I wrote a simple program to quickly group the files which were the same and also show me all of them as options for me to choose before it removed them. <br />

This is a single-screen app which looks as follows: <br /> <br/>
![Main Screen](https://github.com/shreeharshas/DuplicateFilesRemover/blob/master/THE%20APP%20IS%20HERE/DFR.png) <br />

## Binary file

DuplicateFileManager can be downloaded from here: <br />
https://github.com/shreeharshas/DuplicateFilesRemover/tree/master/THE%20APP%20IS%20HERE


## Usage Info:

This app is simple and self explanatory, verbose explanation as below: <br /> <br />

--> Select the folder to scan <br />
--> Click refresh to scan the folder <br />
--> Wait till the blank section fills up with the files list or any message <br />
--> Double click on the file names to preview in Windows explorer <br />
--> Click Select Duplicate files button to select all files but the first in every section <br />
--> Click Delete Selected Files button to remove the files <br /> <br />

## Technical Details:

The main logic behind this is to generate hashcodes based on the file contents and comparing them which is essentially a comparision of the files themselves. <br />
Files with the same hashcodes are grouped under the header having the hashcode value itself as its text. <br />
I have currently used md5 hashing scheme to check for same-ness. <br />

## System Requirements

Manual tests executed successfully on my machine with following specs: <br />
OS - Microsoft Windows 10 <br />
Development framework - Microsoft Dotnet framework version 4.0 <br />

## Warning:

This is a beta version and is to be used at your own risk. <br />
Relatively bigger files such as videos may take longer time to be processed. <br />
The files are not moved to the recycle bin so make sure you double-check the files before deleting. <br />

## Terms and Conditions:

Use this app at your own risk - I do not guarantee anything and do not want to be legally bound whatsoever if it results in any kind of damage to your machine. <br />

## Known Issues:

Visit https://github.com/shreeharshas/DuplicateFilesRemover/labels/bug

## Future Enhancements:

Visit https://github.com/shreeharshas/DuplicateFilesRemover/labels/enhancement

## I'm open to suggestions on these topics:

Visit https://github.com/shreeharshas/DuplicateFilesRemover/labels/help%20wanted
