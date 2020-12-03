TextDataMerge v3.10


PURPOSE:
To process text files containing fixed-length records, by performing sort, filter, merge, or collate operations on the lines of text, using 'keys' (defined by a starting column and a number of columns). 
To provide a GUI for defining and testing these functions individually. 
To illustrate rudimentary workflow functionality by chaining these functions together using the provided console application and a custom CMD script.
To illustrate more robust workflow functionality by chaining these functions together using another provided console application and a custom WF workflow.


USAGE:

TextDataMerge Library:
~TextDataMergeLibrary.DLL contains the entities and logic for the functions, and as well as the logic for loading / saving the settings.
~The settings are saved in XML format, with a .TEXTDATAMERGE extension that is associated with the WinForms app. The settings can also be saved in XML format, with an .XML extension.

TextDataMerge WinForms Application:
~TextDataMergeForms.EXE provides a UI to define and save the settings for each function, and to run the functions individually.

TextDataMerge Console Application:
~TextDataMergeConsole.EXE runs a single function, by taking command line parameters, and passing them to the library. Using command line scripts, the individual functions can even be chained together into scratch-built workflows. The sample performs a sequence of merge-collate-sort-filter to create a series of .TXT files, in which the output of one function is the input of the next.

TextDataMerge WF Host Console Application and WF library:
~TextDataMergeWFHostConsole.EXE hosts and runs the WF workflow TextDataMergeWFLibrary.DLL that performs the same sequence of steps as the command line script that accompanies the original console application. The host console is not a reconfigurable tool like the original, nor is the workflow (with the exception that it gets it settings from the hosting console application's config file). Both are provided to illustrate how to use the TextDataMergeLibrary with WF workflows.

SAMPLES:
~There is a sample settings file in the settings folder in the library project.
~There are sample data files in the testdata folder in the library project.
~There is a sample script file in the scripts folder in the console project.
~There is a sample WF workflow library and a sample WF host console to run the workflow.


HISTORY:

4.0: (PLANNED)
~TODO:Refactor object model / UI / WF-samples to allow for sequences of functions.

3.10 (CURRENT)
~Refactored to use new MVVM / MVC hybrid.
~Updated Ssepan.* to 2.6
~Fixed progress bar and status message logic.
~Fixed problem with Model not being instantiated before View form move tries to access it and trigger a Refresh.

3.9:  (RELEASED)
~Refactored Settings / SettingsController, and their bases in Ssepan.Application, to put the static Settings property into the Settings class instead of the SettingsController class. This will make Settings more like SettingsController and the model / controller classes, and hopefully make Settings easier to understand and maintain.
~Projects are using .Net Framework 4.0.
~Using version 2.0 of Ssepan.* libraries, all of which are using .Net Framework 4.0.
~Omitted Activity version of workflow, since something in WF object model changed that I haven't been able to identify.

3.8: 
~Created custom Activity objects for use in WF, and added example to TextDataMergeWFHostConsole.
~Added missing Start and Desktop icons for TextDataMergeWFHostConsole.
~Removed Start and Desktop icons for TextDataMergeConsole; to start script instead of EXE go to scripts subfolder of application folder.
~Added EventSourceRegistrationForm project to solution.
~Added Start and Desktop icons for EventSourceRegistrationForm.exe.

3.7:
~Refactored function object editors to use common inheritance.
~Refactored image resources.

3.6: 
~Fixed inconsistent implementation of file button events.
~Fixed improper implementation of model-view-controller refresh in file button events.
~Refactored text-function object model to use common base.
~Refactored data-file object model to use common base.
~Modified SetViewerLocation and SetViewerSize in TextDataMergeController to wrap changes in _ValueChanging flag.

3.5: 
~Refactor UI File IO logic in menu events to eliminate duplication.
~Refactored IEquality implementation.
~Modified Sepan.Application to include _ValueChanging flag from sub-class, and to check and set it from the Controller base class Refresh method.

3.4:
~Fixed missing display of errors in Catch in model controller, settings.
~Moved common portions of settings I/O into base classes in Ssepan.Application library.

3.3:
~Fixed condition binding on File|New, File|Open.
~Passed up validation error messages from library to GUI.

3.2:
~Implemented a Windows Workflow Foundation (WF) host console and a WF workflow to invoke the TextDataMergeLibrary functions. The workflow uses a configuration file for its settings files' path(s).

3.1:
~Refactored <appnamespace>.frmAbout to Ssepan.Application.WinForms.AboutDialog.
~Refactored Ssepan.Configuration.PropertiesViewer to Ssepan.Application.WinForms.PropertyDialog.
~Refactored Ssepan.Application.CommandLineSwitch and Ssepan.Application.ConsoleApplication to Ssepan.Application.WinConsole.CommandLineSwitch and Ssepan.Application.WinConsole.ConsoleApplication respectively.

3.0:
~Re-written from scratch in C#.Net and Visual Studio 2008. Distributed under GPL license as open-source freeware.
~Model-View-Controller design pattern used. Using simple databinding plus INotifyPorpertyChanged implementation throughout the settings, and relying on MVC observer notifications only at the top level to refresh the view.
~Renamed project from WinMerge (Copyright 1991 PorchView Software) to TextDataMerge, since another product with that name was produced while mine languished on my hard drive awaiting a re-write.

1.0 .. 2x:
~Legacy client app named WinMerge (Copyright 1991 PorchView Software) written in VB1..VB6; legacy libraries written in Turbo Pascal. Distributed under PorchView Software logo as shareware.


KNOWN ISSUES:
~Filename passed in command line argument is converted/passed in DOS 8.3 equivalent format. Cannot compare file extension directly. Status: Research. 
~Running this app under Vista or Windows 7 requires that the library that writes to the event log (Ssepan.Utility.dll) have its name added to the list of allowed 'sources'. Rather than do it manually, the one way to be sure to get it right is to simply run the application the first time As Administrator, and the settings will be added. After that you may run it normally. To register additional DLLs for the event log, you can use this trick any time you get an error indicating that you cannot write to it. Or you can manually register DLLs by adding a key called '<filename>.dll' under HKLM\System\CurrentControlSet\services\eventlog\Application\, and adding the String value 'EventMessageFile' with the value like <C>:\<Windows>\Microsoft.NET\Framework\v2.0.50727\EventLogMessages.dll (where the drive letter and Windows folder match your system). Alternately, run EventSourceRegistrationForm, and enter the name (only, not the path) of the EXE or DLL that was executing. Note: because it checks the Event API, it is subject to the same limitations, and you must run this tool for the first time as Administrator! Status: work-around. Applies-to: TextDataMergeForms, TextDataMergeConsole, TestDataMergeWFHostConsole, Ssepan.Utility.dll
~While it would be ideal for the editor controls to fire certain events immediately after binding, attempting to do so causes CS0079. As a result, the UI event code that calls the control binding code must explicitly call the output list SelectedIndexChanged handler to bind the COndition objects in Collate and Filter. Status: Research, wait for change to System.MultiCast Delegate. 

POSSIBLE ENHANCEMENTS:
~Come up with a way to register the apps and DLLs for the event log in one shot. Status: Research. Target Version: Unknown.  10/3/2009, SJS.
~When I designed version 3 of the app I did not have in mind stringing the functions together. I only implemented the workflow notion in script and WF as I wrapped it up. Now I see an opportunity to consolidate the function object design and define sequences of functions. Note: this might require using DataContractSerialization instead of XmlSerialization.  Status: Design. Target Version: 5.0.  4/18/2010, SJS.
~The design that I am leaning toward for 4.0 is just a collection containing a sequence of TextFunctionBase. Status: Research. Target Version: 4.0 or later.  4/18/2010, SJS.

Steve Sepan
ssepanus@yahoo.com
3/16/2014