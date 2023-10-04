# DataAccessSamples

### Overview
TodoSampleApp is a .Net 7.0, .Net Maui and Xunit app that has been created as a template that includes best practices for app development.  To that end it includes the following:

 
### Structure
Solution Name: TodoSampleApp
Projects:
- TodoSample.Core
  
  Contains all data and logic-related folders, including all models, view models, services and database context
- TodoSampleApp.Maui
  
  Contains all user interface folders, including all views, images and services directly related to the UI.  These services include navigation between views, display messages and user preferences
  
- TodoSampleApp.Tests

  Contains mocks of services with verification tests.  Also, contains basic test on each view model.


### Libraries

	<ItemGroup>
	  <None Remove="Views\" />
	  <None Remove="ViewModels\" />
	  <None Remove="Services\" />
	  <None Remove="Models\" />
	  <None Remove="Data\" />
	  <None Remove="Resources\Raw\casedata.json" />
	  <None Remove="Controls\" />

- TodoSample.Core
  
  - CommunityToolkit.Mvvm
  - sqlite-net-pcl
  - SQLitePCLRaw.bundle_green
  - CommunityToolkit.Maui
 
- TodoSampleApp.Maui

  - Microsoft.Extensions.Logging.Debug
  - CommunityToolkit.Mvvm
 

 
### Other Features
  - .Core
    - Task Extension
    - Validation Rules
  - .MAUI
      -   Data Triggers, Event Triggers
      -   Shell Flyout Menu with Menu footer and header
      -   QueryProperty
      -   Use of icon library and image
      -   CollectionView Grouping
  
