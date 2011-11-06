Google Page Speed Console
=========================

This is just a little console app that returns the Google Page Speed score for a given url.

Compilation
-----------

	C:\GooglePageSpeedConsole> msbuild GooglePageSpeedConsole.csproj

Prerequisite
------------

A Google Page Speed API key from the [API's console page](https://code.google.com/apis/console/).
	
Usage
-----

	C:\GooglePageSpeedConsole> bin\GooglePageSpeedConsole.exe your_api_key http://www.someurl.com