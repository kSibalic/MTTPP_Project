# RUAP Project - Selenium WebDriver C# Automation Project

## Project Overview

This project is a **Selenium WebDriver** automation framework written in **C#** using the **NUnit** testing framework. It automates a test cases for navigating the *eBay* and *Thomman Music* websites, interacting with various elements, and verifying functionality.

### Key Features

- Browser automation using Selenium WebDriver
- Test execution in Google Chrome
- Demonstrates handling elements such as buttons, links, login forms, etc.
- Framework supports modular and resuable code

### Tools and Technologies Used

- Programming Language: **C#**
- Testing Framework: **NUnit**
- Browser Automation Tool: **Selenium WebDriver**
- Web Browser: **Google Chrome**
- Driver Management: **WebDriverManager**
- IDE: **JetBrains Rider**

### Prerequisites

1. **Google Chrome** - Install the latest version of Google Chrome [here](https://www.google.com/chrome/)
2. **ChromeDriver** - Install via NuGet or WebDriverManager
3. **.NET SDK** (version 8.0) - Install the .NET SDK from Microsoft [here](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
4. **IDE** - Download JetBrains Rider for development [here](https://www.jetbrains.com/rider/download/#section=mac)

### Setup Instructions

Follow these steps to set up the project:

1. **Clone the Repository**
   ```bash
   git clone https://github.com/kSibalic/ruapProject
   cd ruapProject/
   ```

2. **Install NuGet Packages**
   Open the project in Rider and run the following commands to install all required NuGet packages:
    ```bash
    dotnet add package Selenium.WebDriver
    dotnet add package Selenium.WebDriver.ChromeDriver
    dotnet add package NUnit
    dotnet add package NUnit3TestAdapter
    dotnet add package Microsoft.NET.Test.Sdk
   ```

3. **Running the Tests**
    - Open the project in Rider IDE
    - Locate the test in the **Test Explorer**
    - Run the test directly from the interface.

    Alternatively, run the tests using the **Command Line**:
    ```bash
    cd ruapProject/
    dotnet test
    ```  

### Test Scenario
The test performs the following actions:
1. Navigate to [eBay website](https://www.ebay.com/)
2. Open the main menu and click on "Video Games & Consoles" category
3. Select an item (e.g., Sony PlayStation PSP)
4. Add the item to the cart
5. Navigate to the cart and verify that the item is added with the correct quantity

### Known Issues

- Ensure that the *ChromeDriver* version matches your installed *Google Chrome* version
- Some listings/products that were used as an example may have expired or be unavailable by the time tests are run due to both websites being high-traffic