/*
 * This file is a custom version of the PhantomJS rasterize.js script.  It 
 */
"use strict";
var page = require("webpage").create(),
    system = require("system"),
    address,
    output,
    size;

//check that correct number of args passed into script from command line
if (system.args.length < 3 || system.args.length > 3) {
    console.log("Usage: customeRasterize.js sourceHTMLfile outputFilename");
    phantom.exit(1);
} else {
    address = system.args[1];
    output = system.args[2];

    //Set the output format of the PDF file that will be rendered by the PhantomJS browser
    page.paperSize = {
        format: "A4",
        orientation: "landscape",
        margin: "1cm",
        footer: {
            height: ".75cm",
            contents: phantom.callback(function(pageNum, numPages) {
                return "<h4 style='font-family:helvetica'><span style='float:right'>" +
                    pageNum +
                    " / " +
                    numPages +
                    "</span></h4>";
            })
        }
    };

    //load the source html file and export it to PDF
    page.open(address,
        function(status) {
            if (status !== "success") {
                console.log("Unable to load the address!");
                phantom.exit(1);
                phantom.kill();
            } else {
                window.setTimeout(function() {
                        page.render(output);
                    phantom.exit();
                        phantom.kill();
                    },
                    200);
            }
        });
}