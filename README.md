# Grouvee Collection Parser

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