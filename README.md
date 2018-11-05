# gmail.imap.error
Project to show Bug on Gmail IMAP Search.

## How to prepare the environment

1. Install Dotnet Core 2.0 or later (or run on Container)
	* Link to download and install: https://www.microsoft.com/net/download
2. Create an Gmail account and send some emails to that.
3. Create an Office365 account and send some emails to that.
4. On root project folder, edit file .\enContactIMAP4SearchTest\ImapFourNovTests.cs
5. Change line 13 set variable GMAIL_USERNAME with your Google Account login.
6. Change line 14 set variable GMAIL_PASSWORD with your Google password.
7. Change line 16 set variable OUTLOOK_USERNAME with your Google Account login.
8. Change line 17 set variable OUTLOOK_PASSWORD with your Google password. 

## How to build and run tests

1. The tests will count server emails by IMAP config, and expected more than one email as result.
2. On root project folder, run the follow command to build project:
	1. dotnet build MailKit.sln
3. On the root folder, run the test command:
	1. dotnet test .\enContactIMAP4SearchTest\enContactIMAP4SearchTest.csproj
4. After the command you will see the Outlook tests pass and Gmail fail.

* NOTE: You can debug this tests to see all code either in Visual Studio Community or Visual Studio Code.
	* More on https://code.visualstudio.com/download
	* or https://visualstudio.microsoft.com/downloads
* NOTE2: The IMAP Client library is a open-source found on https://github.com/jstedfast/MimeKit
