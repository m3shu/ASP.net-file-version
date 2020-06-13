# Force browsers to get latest js and css files in asp.net application
I have implemented three method here

use whatever you like

## version system

each version contains 4 element

1.2.3.4

1-major

2-minor

3-build

4-revision

# Method 1
https://stackoverflow.com/questions/2185872/force-browsers-to-get-latest-js-and-css-files-in-asp-net-application
1. we need to add a class in asp.net
2. wrap all js and css in project by a function

advantage

1. no need to change build number   
2. no need to change auto increment for build number   
3. only change version of specific files which is modified 

disadvantage 

1. less readable version number, so user / developer may not understand it's working or not (though it all work 100% in after user interval (default : 5 min))

# Method 2
by using assembly version as version

## code snippet for version

```
@using System.Diagnostics
@using System.Reflection
@{
    string version = FileVersionInfo.GetVersionInfo(Assembly.GetAssembly(typeof(MvcApplication)).Location).FileVersion;
}
```

usage ↓

<link href="~/Content/Site.css?v=@version" rel="stylesheet" />

<script src="~/Scripts/App.js?v=@version"></script>



In this method we need to change assembly version otherwise it will work. so its better to use a auto increment for version number.

http://thinkofdev.com/auto-increase-project-version-number-in-visual-studio/

## for auto increment revision number 

we need to change AssemblyInfo.cs like below

[assembly: AssemblyVersion("1.2.*")]  

//↑ here compiler take care (automatically increase number) of build and revision 

//and we can change major minor as we want 



//or
[assembly: AssemblyVersion("1.2.3.*")]  

//↑ here compiler take care (automatically increase number) of revision 

//and we can change major minor build as we want



//and finally we need to comment this line otherwise auto increment may not work

// [assembly: AssemblyFileVersion("6.7.8.9")]



NB: That line exist in AssemblyFileVersion in Properties/AssemblyInfo.cs 



# Method 3

by using bundle config

https://stackoverflow.com/questions/35901012/how-to-version-javascript-files-in-a-bundle/35901139

MVC will automatically add a version parameter for release builds (i.e. if debug="false" in web.config)

https://docs.microsoft.com/en-us/aspnet/mvc/overview/performance/bundling-and-minification





