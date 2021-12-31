# Using-the-SMA-Crypto-API-from-Coinslosh-with-Azure-Functions-to-detect-a-Golden-Cross
This Visual Studio 2022 sample contains a Azure Function that is build with the Visual Studio Tools for Azure Functions. The project is created in .NET 6 (C#) 
The Azure Function calls the SMA Crypto API from Coinslosh to detect a Golden Cross in Ethereum (ETH)

### What is a golden cross?
A golden cross means that a short-term simple moving average (SMA) exceeds a long-term SMA. This can be, for example, a 9-day SMA versus a 26-day SMA. This is a positive sign. 
It may indicate a structural appreciation in value and can be the start of a bull market.

Example of a golden cross of the Ethereum price, indicated by a dotted line:
![GoldenCross-dottedline](https://user-images.githubusercontent.com/4686866/147818557-5f74e838-c9eb-4c9a-b35e-2ec869caf9ed.png)

### Azure Functions
Azure Functions allows you to implement your system's logic into readily-available blocks of code. These code blocks are called "functions".

Visual Studio Tools for Azure Functions:
![Azure Functions Core Tools](https://user-images.githubusercontent.com/4686866/147817509-d6e03d01-96fd-4fa7-bb8e-d3ab22d459ec.png)
