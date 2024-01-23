# Microsoft Defender for Identity Simple LDAP Bind

I created a small program to test the "Entities exposing credentials in clear text" Secure Score Recommended Action for Microsoft Defender for Identity. For more information, please check the official documentation from Microsoft:

https://learn.microsoft.com/en-us/defender-for-identity/security-assessment-clear-text

> **_NOTE:_** The password is transmitted without any form of obfuscation or encryption, so it is strongly recommended that simple authentication be used only for testing purposes.

## ⚙️ Features

- Creates an LDAP connection to a Domain Controller using a simple Bind
- Using arguments for the server, username, and password to make it simple for anyone to use
- Triggers "Exposed Entities" for the "Stop clear text credentials exposure" recommended action in secure score

## 🛠️ Usage

Enter a Domain Controller as the ldapserver, the Distinguished Name of a user account, and the corresponding password. Here is an example:
````
SimpleLDAPBind.exe /ldapServer:"DC01" /userDN:"CN=thalpius,CN=Users,DC=yoshis,DC=island" /password:"SimpleLDAPBin01!"
````

> **_NOTE:_** Use the "Attribute Editor" in "Active Directory Users and Computers" on the object to find the Distinguished Name for a user account.

## 📄 Blog

To find out more about the "Entities exposing credentials in clear text" recommended action, check out my blog post:

https://thalpius.com/2024/01/23/microsoft-defender-for-identity-recommended-actions-stop-clear-text-credentials-exposure/

## 📺 Screenshots
Here is an example of the appliation connecting to a Domain Controller using simple authentication:

![Alt text](/Screenshots/MicrosoftDefenderForIdentitySimpleLDAPBind01.png?raw=true "Microsoft Defender for Identity Simple LDAP Bind")

Here is an example of the Exposed Entities in "Entities exposing credentials in clear text" Secure Score Recommended Action:

![Alt text](/Screenshots/MicrosoftDefenderForIdentitySimpleLDAPBind02.png?raw=true "Microsoft Defender for Identity Exposed Entities")
