## REPORTS

<ol>
<li>Install the .NET SDK from Microsoft: https://dotnet.microsoft.com/download</li>
<li>Trial .NET Core Controls Via NuGet: https://docs.devexpress.com/GeneralInformation/120534/installation/install-devexpress-controls-using-nuget-packages/net-core-controls-via-nuget</li>
<li>Execute this at command line: dotnet add package DevExpress.AspNetCore.Reporting -s [NuGet Feed URL]  (you may wait for a couple of minutes for this to successfully execute)</li>
</ol>


Troubleshooting:
1. To enable saving of database credentials, open the report designer in Visual Studio and change the ReportDesigner property below: 
	* https://supportcenter.devexpress.com/ticket/details/t592038/end-user-report-designer-does-not-save-connection
	
2. Error when calling report: Error when trying to populate the datasource
	* Solution: https://supportcenter.devexpress.com/ticket/details/t990122/error-when-trying-to-populate-the-datasource
		* execute the command: dotnet add package MySql.Data --version 8.0.23
		* reference: https://www.nuget.org/packages/MySql.Data/