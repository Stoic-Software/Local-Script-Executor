# Local Script Executor

This Local Script Executor is a crutch I use in the absence of Macro buttons on my keyboard. By publishing this code as an executable file, then creating a shortcut to the .exe file, a keyboard shortcut can be applied which will run the program (my preference is ctrl+alt+right-arrow). 

Running this script will present a console window to the user which gives a unique id to each script located in the [Script directory] filepath. The scripts found there must be Python files, which means your version of python must be installed already and your associated environment variables created. Entering in the ID of the script you want to be executed will run the script. Any input-output feed from the Python script will be pulled and pushed by this C# script so that all the execution can happen from the same console window.

This method replaces my macro button preferences with a working alternative, and also removes any limitation caused by the number of buttons you may have.

This code is open-source and can be freely used and/or modified. 
