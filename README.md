# KnoxySays
Simple Task Runner

This is a simple task runner using bat files to execute commands from the command line.

Examples:

knoxySays start visualstudio (starts visual studio 2013 as administrator)
knoxySays start sql (starts SQLEXPRESS service)
knoxySays stop sql (stops SQLEXPRESS service)

You can chain together bat files to create a workflow

KnoxySays start dev (this will start Visual Studio, SQLEXPRESS, Process Explorer and SQL Management Studio)
KnoxySays start dev (this will start Skype, Dropbox and Chrome)

You can use an alias rather than KnoxySays (ks already exists)

ks start chrome

To create your own simply make a copy of ks.bat and save with your new alias name (eg. DoWork.bat)

DoWork start web

You can pipe through any additional commands to the underlying programs

KnoxySays start chrome --new-window kyroconsulting.co.uk

For help type- KnoxySays Help






To add a new task simply create a new bat file in the format start-MYTASK.bat or top-MYTASK.bat

Drop these bat files into the scripts folder and they will be availbe to run from the command prompt.