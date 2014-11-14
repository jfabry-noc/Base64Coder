#Base 64 Coder
While working on testing a connectivity to an authenticated SMTP server, I needed to encode my communication as base 64. I decided to code up a quick way to input information to be either encoded or decoded quickly. This application allows for conversion in both directions, and it can run via either command line switches or an interactive mode.

##Running
The following switches are supported:

 - -e : Encodes the supplied string. Note that it will allow for either quoted or unquoted strings.
 - -d : Decodes the supplied string.
 - -h : Displays the help information.

![Encode CLI](http://i.imgur.com/on9X5ch.png)
![Decode CLI](http://i.imgur.com/fbFluHE.png)
![Help Info](http://i.imgur.com/V36F6zo.png)

You can also run from an interactive mode. This will prompt you with options to encode or decode.

![Encode Interactive](http://i.imgur.com/ZF5CJdF.png)
![Decode Interactive](http://i.imgur.com/LhPpuTS.png)

##Requirements
The code is C# and leverages .NET, so you must be running on Windows.
