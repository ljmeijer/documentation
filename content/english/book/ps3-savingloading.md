Playstation3: Saving and Loading files
======================================


To save and load data files on Unity PS3 you can use the _[PS3SaveDataUtility](ScriptRef:PS3SaveDataUtility.html)_ class.

The PS3 Samples -> Save Load unity package included with the Unity PS3 Addon shows how to save and load data to/from the PS3.

_Please refer to C:\usr\local\cell\samples\common\hl\sysutil\savedata\HL_Save_Data-Overview_e.pdf for a better understanding of the save data utility in PS3_


Steps to use the Save Data Utility.
-----------------------------------


###1. Initialize the Utility

````
// Initialize save data
PS3SaveDataUtility.Init();
````

###2. Set the Save or Load Parameters.

The save parameters define the location of the save files, the icon to be display in the Playstation 3 XMB and the title, subtitle and description of the file.
The load parameters define the directory from which to load the files.

````
// Set the Save Parameters
PS3SaveDataUtility.SetSaveParams(directoryName, iconFilename, titleSaveData, subtitleSaveData, detailsSaveData);

// Set the Load Parameters
PS3SaveDataUtility.SetLoadParams(directoryName);
````

###3. Load or Save a file

````

// To Save
PS3SaveDataUtility.DoAutoSave(filename, dataString);

// To Load
PS3SaveDataUtility.DoAutoLoad(filename);

````

Be aware that these functions are non-blocking. You need to wait for it to complete:

````

while (!PS3SaveDataUtility.HasCompleted())
    yield return null;

````

###4. Verify the result

Once the operation is complete you can check the result to see if it was succesful or not:

````

// Check the result
if (PS3SaveDataUtility.GetResult() == PS3ReturnCode.Success)
{
    // Successful
}
else
{
    // There was an error
}

````

The result is one from the [PS3ReturnCode](ScriptRef:PS3ReturnCode.html) enumeration.
