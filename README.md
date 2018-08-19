# Grouvee Collection Parser
[![nuget](https://img.shields.io/nuget/v/GrouveeCollectionParser.svg)](https://www.nuget.org/packages/GrouveeCollectionParser)
A simple parser for .csv file generated when exporting a collection from grouvee.com.


## Usage examples

```cs
using GrouveeCollectionParser;
using SteamStorefrontAPI.Classes;

        static async Task ImportCollection()
        {
			string grouveeFilePath = @"C:\temp\grouvee.csv"
            GrouveeCollection grouveeCollection = await GrouveeCollection.ImportAsync(grouveeFilePath);
        }
```
