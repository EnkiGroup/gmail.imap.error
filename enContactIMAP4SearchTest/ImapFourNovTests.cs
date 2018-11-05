using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace TestePessoalEnki
{
    public class ImapFourNovTests
    {
        public static string GMAIL_USERNAME = "";
        public static string GMAIL_PASSWORD = "";

        public static string OUTLOOK_USERNAME = "";
        public static string OUTLOOK_PASSWORD = "";

        /// <summary>
        /// Simple Tests find e-mails after 11/04/2018 on GMAIL
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ImapNotFoundOnNovember4Gmail()
        {
            var count = 0;
            using (var _clientImap4 = new ImapClient())
            {
                _clientImap4.Connect("imap.gmail.com", 993, true);
                _clientImap4.AuthenticationMechanisms.Remove("XOAUTH2");
                _clientImap4.Authenticate(GMAIL_USERNAME, GMAIL_PASSWORD);


                IMailFolder mailBox = null;
                if ((_clientImap4.Capabilities & (ImapCapabilities.SpecialUse | ImapCapabilities.XList)) != 0)
                {
                    mailBox = _clientImap4.GetFolder("INBOX");
                }

                var selectedFolder = _clientImap4.GetFolder(_clientImap4.PersonalNamespaces[0]);
                foreach (var existentFolder in selectedFolder.GetSubfolders(false))
                {
                    if (existentFolder.Name.ToLower().Contains("INBOX".ToLower().Trim())) mailBox = existentFolder;
                }
                mailBox.Open(FolderAccess.ReadWrite);

                // Filtra todas as mensagens a partir da data indicada e que não foram marcadas como visualizadas.
                // Mais informações em: https://components.xamarin.com/gettingstarted/mailkit
                var dateToFilter = new DateTime(2018, 11, 04);
                var query = SearchQuery.All.And(SearchQuery.DeliveredAfter(dateToFilter));
                var IdsResult = await mailBox.SearchAsync(query).ConfigureAwait(false);
                count = IdsResult.Count();

                _clientImap4.Disconnect(true);

                Assert.True(count > 0);
            }
        }

        /// <summary>
        /// Simple Tests find e-mails after 11/04/2018 on OFFICE365
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task TestImapNotCount4novOutlook()
        {
            var count = 0;
            using (var _clientImap4 = new ImapClient())
            {
                _clientImap4.Connect("outlook.office365.com", 993, true);
                // Como não há autenticação OAuth2 na lib, desabilita o mecanismo de conexão.
                _clientImap4.AuthenticationMechanisms.Remove("XOAUTH2");
                _clientImap4.Authenticate(OUTLOOK_USERNAME, OUTLOOK_PASSWORD);

                IMailFolder mailBox = null;
                if ((_clientImap4.Capabilities & (ImapCapabilities.SpecialUse | ImapCapabilities.XList)) != 0)
                {
                    mailBox = _clientImap4.GetFolder("INBOX");
                }

                var selectedFolder = _clientImap4.GetFolder(_clientImap4.PersonalNamespaces[0]);
                foreach (var existentFolder in selectedFolder.GetSubfolders(false))
                {
                    if (existentFolder.Name.ToLower().Contains("INBOX".ToLower().Trim())) mailBox = existentFolder;
                }
                mailBox.Open(FolderAccess.ReadWrite);

                // Filtra todas as mensagens a partir da data indicada e que não foram marcadas como visualizadas.
                // Mais informações em: https://components.xamarin.com/gettingstarted/mailkit
                var dateToFilter = new DateTime(2018, 11, 04);
                var query = SearchQuery.All.And(SearchQuery.DeliveredAfter(dateToFilter));
                var IdsResult = await mailBox.SearchAsync(query).ConfigureAwait(false);
                count = IdsResult.Count();

                _clientImap4.Disconnect(true);

                Assert.True(count > 0);
            }
        }
    }
}
