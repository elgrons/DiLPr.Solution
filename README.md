#  _DiLPr_ 

####  By Eliot Gronstal, E Luckie, Jannon Sielaff, Brishna Bakshev, Carl Sustrich

#### _A Mvc app for Dogs to find other dogs and see if they're inpupatible or down to woof. Made for Team Week at Epicodus Coding School._

## Technologies Used 

* _C#_
* _.NET_
* _HTML_
* _MVC_
* _SQL Workbench_
* _Entity Framework_
* _CSS_

## Description

TBD

## Setup/Installation Requirements

*  _Clone this repo._
*  _Open your terminal (e.g., Terminal or GitBash) and navigate to this project's production directory called "DiLPr"._
*  _In the command line, run the command ``dotnet run`` to compile and execute the console application. Since this is a console application, you'll interact with it through text commands in your terminal._
*  _Optionally, you can run ``dotnet build`` to compile this console app without running it._
*  _This program was built using `Microsoft .NET SDK 6.0`, and may not be compatible with other versions._

*  _If you want to run the project in production mode with a watcher, you can use a command line flag to specify that you want to run the "production" profile. ``dotnet watch run --launch-profile "production"``_
*  _Open the browser to [https://localhost:5001]. If you cannot access localhost:5001 it is likely because you have not configured a .NET developer security certificate for HTTPS. To learn about this, review this lesson: [Redirecting to HTTPS and Issuing a Security Certificate.](https://www.learnhowtoprogram.com/c-and-net/basic-web-applications/redirecting-to-https-and-issuing-a-security-certificate)_

## SQL Workbench Configuration
* 🔧 _Create an `appsetting.json` file in the "Factory" directory of the project._
* 🔧 _Within `appsettings.json`, put in the following code, replacing the `uid` and `pwd` values with your own username and password for MySQL._ 
```json
{
    "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Port=3306;database=dilpr_data;uid=[YOUR-USERNAME-HERE];pwd=[YOUR-PASSWORD-HERE];"
    }
}
```
* 🔧 _If you'd like to push this cloned project to a public-facing repository, remember to add the appsettings.json file to your .gitignore first._
* 🔧 _Once "appsettings.json" file has been created, follow the below directions for Entity Framework Migration Configuration._ 

## Entity Framework Migration Configuration

* _In root directory of project folder "DiLPr", run `dotnet ef migrations add restoreDatabase`_
* _Then run $ `dotnet ef database update`_
* _Open SQL Workbench._
* _Navigate to "" schema._
* _Click the drop down, select "Tables" drop down._
* _Verify the tables. There should be: ._

## Known Bugs

* _No known bugs._

* _Please reach out with any questions or concerns to [eliot.lauren@gmail.com](eliot.lauren@gmail.com), [carl.sustrich@gmail.com](carl.sustrich@gmail.com), [jannon.sielaff@gmail.com](jannon.sielaff@gmail.com), [b.bakshev@gmail.com](b.bakshev@gmail.com), [eluckie.d@gmail.com](eluckie.d@gmail.com)_

## License

_[MIT](https://opensource.org/license/mit/)_

Copyright (c) _2023_ _Eliot Gronstal, E Luckie, Jannon Sielaff, Brishna Bakshev, Carl Sustrich_