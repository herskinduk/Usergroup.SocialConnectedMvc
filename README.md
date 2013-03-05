# Sitecore User Group project: Social Connected and Sitecore MVC

This project is a demonstration of how the Sitecore Social Connected module can be made to work with Sitecore MVC.

Besides the basic conversion form Webforms to MVC there
 is an emphesis on demonstrating refactoring, abstractions and unit testing.

## Building

Open in Visual Studio and build. 

## Usage

The Visual Studio solution contains all the files needed to build and deploy the solution.

There is a Sitecore package in the Website project located under <code>/App_Data/packages</code>. 
The package contains Rendering Definitions for the UI components.

Examples of using the Sitecore MVC Connector Rendering inline:

    // The NetworkName could also be set as a RenderingParameter if added via item layout configuration. What a wonderful inline GUID :)
	@Html.Sitecore().Rendering("{853B9105-DD1C-4163-882E-E5BB8925D87F}", new { Parameters = "NetworkName=Facebook" })

## Contact

If you experience any problems or have questions contact: @herskinduk
