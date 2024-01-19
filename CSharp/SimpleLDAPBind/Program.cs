using System;
using System.Collections.Generic;
using System.DirectoryServices.Protocols;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLDAPBind
{
    internal class Program
    {
        static void Help()
        {
            Console.WriteLine("");
            Console.WriteLine("Oops! Arguments doesn't seem to be right...");
            Console.WriteLine("");
            Console.WriteLine("Example: \"LDAPSimpleBind.exe\" /ldapServer:\"DC01\" /userDN:\"CN=thalpius,OU=Users,DC=yoshis.DC=island\" /password:\"thalpius2024!\"");
            System.Environment.Exit(1);
        }
        static void LdapConnectionBasic(string ldapServer, string userDN, string password)
        {
            var credentials = new NetworkCredential(userDN, password);
            var server = new LdapDirectoryIdentifier(ldapServer);
            var connection = new LdapConnection(server, credentials);

            try
            {
                connection.SessionOptions.ProtocolVersion = 3;
                connection.AuthType = (AuthType)AuthType.Basic;
                connection.Bind();
                Console.WriteLine("");
                Console.WriteLine("Simple LDAP bind done successfully!");
            }
            catch (Exception e)
            {
                Console.WriteLine("");
                Console.WriteLine($"Failed to connect: {e.Message}");
            }

            connection.Dispose();
        }
        static void Main(string[] args)
        {
            if (args.Length != 3)
            {
                Help();
            }
            if (args[0].ToLower().StartsWith("/ldapserver") && args[1].ToLower().StartsWith("/userdn") && args[2].ToLower().StartsWith("/password"))
            {
                string ldapServer = args[0].Remove(0, 12);
                string userDN = args[1].Remove(0, 8);
                string password = args[2].Remove(0, 10);
                LdapConnectionBasic(ldapServer, userDN, password);
            }
            else
            {
                Help();
            }
        }
    }
}
