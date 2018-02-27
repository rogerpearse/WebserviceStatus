# WebserviceStatus
VB.Net util to say when a webservice is up.  Calls a SOAP service for its wsdl.  Icon on taskbar turns green once found.  

Written in Visual Studio 2017 (Community edition).

The Java app that I am working on takes ages to come up, and gives no clear message when it has done so. 
It includes a SOAP webservice that serves a WSDL.  So you end up hitting refresh on a browser tab with the WSDL in,
just to see if it's up yet.

This util starts up.  You set it polling for the WSDL, and the taskbar icon is red.
It turns green once it's there.
