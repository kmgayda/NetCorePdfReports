# Net Core Pdf Reports
Demonstrates how to use PhantomJS to convert an HTML file to a PDF file in .NET Core, Windows or Linux, without expensive 3rd party libraries.  This example was created on Windows. You will need to install the Linux version of the exe on your target machine for this to work in a Linux environment.

This is a simple example using a static HTML file.  For a real life application, you would generate the HTML dynamically that would be used as the input to the PhantomJS.exe command line instruction.  The command line takes three parameters:

 var command = $"{rasterizeFile } { outputFile} {targetFile}";
 
The rasterize file is the JavaScript instruction for formatting the page output of the PDF.  You can find more details about this file here: https://phantomjs.org/api/
 
PhantomJS is a “headless” browser, that can render a web page like any other browser, from the command line. It can convert HTML files to images or pdf files. If you can render it in HTML, you can output it as a PDF report...for free. And since it is a command line utility, you can call it from any language that can shell execute. 

The PhantomJS browser, like all browsers, may not render exactly the same. In my testing, I have found no issues that I could not work around.  It rendered about 97% the same as Chrome.
