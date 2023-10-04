# DataAccessSamples

### Overview
TodoSampleApp is a .Net 7.0, .Net Maui and Xunit app that has been created as a template that includes best practices for app development.  To that end it includes the following:

  - Separation of Concerns: loosely coupling database and UI through the use of interfaces and MVVM architecture
  - DRY principles:  abstractions of database operations, use of base classes
  - Modularity that allows for unit testing the data and business logic
  - Dependency Inversion: High level modules are not dependent on low level modules.  The TodoSampleApp uses dependency injection, interfaces and abstraction.

    _Techniques_
    - MVVM architecture
    - Localization wire-up with Spanish and English
    - Shell navigation
    - CRUD services with local Sqlite db
    - Orientation detection and change of UI (Portrait and Landscape)

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

- TodoSample.Core
  
  - CommunityToolkit.Mvvm
  - sqlite-net-pcl
  - SQLitePCLRaw.bundle_green
  - SQLitePCLRaw.provider.dynamic_cdecl
 
- TodoSampleApp.Maui

  - Microsoft.Extensions.Logging.Debug
  - CommunityToolkit.Mvvm
 
- TodoSampleApp.Test (NO TESTS, YET)

  - Microsoft.NET.Test.Sdk
  - xunit
  - xunit.runner.visualstudio
  - coverlet.collector
  - Moq
  - FluentAssertions
 
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
  
