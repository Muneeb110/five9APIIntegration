# Five9 API Integration
Sample Integration with Five9 APIs using SOAP Protocol

## Overview
This project provides a sample implementation of integrating with Five9 APIs using the SOAP protocol. It includes two methods, runReport() and getContactFields(), which demonstrate how to interact with the Five9 Admin Web Service.

## Prerequisites
Before running the project, ensure that you have the following:

Five9 API credentials (username and password)
Access to the Five9 Admin Web Service endpoint (e.g., https://api.five9.com/wsadmin/adminwebservice)
## Getting Started
To get started with the project, follow these steps:

Clone the repository or download the project files.
Open the project in your preferred C# development environment.
Locate the Program.cs file and open it.
Modify the API credentials in the following lines:
webRequest.Headers.Add("Authorization", "Basic QXV0b21hdGlvbjpUZXN0aW5nMTIzIQ==");
Review the sample implementation of the runReport() and getContactFields() methods.
Build the project to ensure all dependencies are resolved.
Run the project to execute the sample integration code.
Observe the console output for the API response and any errors.
## Configuration
The project does not require any additional configuration. However, ensure that you have correctly set the API credentials in the code as mentioned in the "Getting Started" section.

## License
This project is licensed under the MIT license. Refer to the LICENSE file for more information.

## Contact
For any inquiries or further information, please reach out to the project maintainer at muneeb110@live.com.
