# KnoxySays

Simple Windows Command Line Task Runner

This is a simple task runner using bat files to execute commands from the command line.

**Examples:**

Start Visual Studio 2013 as administrator:

	KnoxySays start visualstudio 

Starts SQLEXPRESS service

	KnoxySays start sql

Stops SQLEXPRESS service

	KnoxySays stop sql

Chain together bat files to create a workflow.

Start Visual Studio, SQLEXPRESS, Process Explorer

	KnoxySays start dev 

Start Skype, Dropbox and Chrome

	KnoxySays start utils

You can use an alias rather than KnoxySays (ks already exists)

	ks start chrome
	
The is also an alias for Start (s) and Stop (x)

	ks s dropbox
	ks x dropbox

When running the start action you can omit that argument for brevity

	knoxysays skype
	ks notepad
	
To create your own alias simply make a copy of ks.bat and save with your new alias name (eg. DoWork.bat)

	DoWork start web

You can pipe through any additional commands to the underlying programs

	KnoxySays start chrome --new-window kyroconsulting.co.uk

For help type

	KnoxySays Help


To add a new task simply create a new bat file in the format start-MYTASK.bat or stop-MYTASK.bat

Drop these bat files into the Scripts folder and they will be available to run from the command prompt.

**Installation / Useage Instructions**

To use KnoxySays without compiling in Visual Studio download the files from 'Precompiled' to a location on your PC. You can then add the path this location to your PATH Environment variable. If you want to do this automatically you can run the 'SetPath.ps1' script. When executed this will set your user PATH variable based upon the location of the containing folder.

If you add your own scripts you can manually update start-help.bat to include your shortcuts.