# HackerNewsWebScraper

A C# Console Application to scrape story data from the Hacker News website (https://news.ycombinator.com/)

## Getting Started

* Clone the repository 
* Navigate to .sln file and open in Visual Studio

### Prerequisites

* Visual Studio (https://visualstudio.microsoft.com/)
* Dotnet Core 2.0+ (https://www.microsoft.com/net/download)
* Dotnet command line tools (https://docs.microsoft.com/en-us/dotnet/core/tools/?tabs=netcore2x)
* Docker (https://docs.docker.com/install/)

## Configuration 

* Defaults used for items that fail validation are set in the 'appsettings.json' file.

## Running the app

1) Open Solution in Visual Studio.
2) Build the app (Right-Click on HackerNewsWebScraper -> Rebuild).
3) In command line/terminal window navigate to the location of the HackerNewWebScraper.dll
4) Run ``` dotnet HackerNewWebScraper.dll n ``` where n is the number of stories to get.

## Run using Docker Image

1) Make sure docker is running
2) From command line/terminal run:
``` 
docker pull markfaiers/hackernewsscraper
docker run markfaiers/hackernewsscraper n
```
where n is the number of stories to get.

## Run the tests
The respository contains a HackerNewsWebScraper.Tests project containing NUnit tests. 
They can be run from Visual Studio by opening the TestExplorer and selecting 'Run All'.

There is a 'TestPage.txt' file contained in the project, which contains html used in the test cases.

## Librarys Used

* ScrapySharp - To simulate a web browser and traverse an html document. (Not all features are compatible with dotnet core but there ones used in this application are.)
* Newtonsoft.Json - To serialize objects to Json and create Json Arrays.
* NUnit - For unit testing.

