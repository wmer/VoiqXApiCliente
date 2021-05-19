using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using VoiqXApiCliente;
using VoiqXApiCliente.Models;

namespace VoiqXApiClienteTeste {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void CreateMailingTeste() {
            Mailing mailing = CreateMailing();

            var api = new VoiqX("https://4c.voiqx.cloud", "MTk3NDMwYTczMDFiNmI4NWZhYzI3YzQ2OGU3NDkwNjU3N2Y0ZTFkNjI4ZDgzOGYwZjM4NzIwNjVjNGI3MzM2MA");
            var response = api.CreateMailing(mailing);
            var ststusResposnse = api.StatusMailling(response.id);

            bool result = response != null;
            Assert.IsTrue(result, "OK");
        }

        [TestMethod]
        public void CreateCampaignTeste() {
            Campaign campaign = CreateCampaign(625, 153);

            var api = new VoiqX("https://4c.voiqx.cloud", "MTk3NDMwYTczMDFiNmI4NWZhYzI3YzQ2OGU3NDkwNjU3N2Y0ZTFkNjI4ZDgzOGYwZjM4NzIwNjVjNGI3MzM2MA");
            var response = api.CreateCampaign(campaign);

            bool result = response != null;
            Assert.IsTrue(result, "OK");
        }

        [TestMethod]
        public void StartCampaignTeste() {
            var mm = "";
            var api = new VoiqX("https://4c.voiqx.cloud", "MTk3NDMwYTczMDFiNmI4NWZhYzI3YzQ2OGU3NDkwNjU3N2Y0ZTFkNjI4ZDgzOGYwZjM4NzIwNjVjNGI3MzM2MA");
            Mailing mailing = CreateMailing();
            var mailingResponse = api.CreateMailing(mailing);
            while (api.StatusMailling(mailingResponse.id).status != "finished") {}
            Campaign campaign = CreateCampaign(mailingResponse.id, 4);
            var campaignResponse = api.CreateCampaign(campaign);
            while (api.CampaignContactList(campaignResponse.id)?.phones?.Count() == 0) { }
           // Thread.Sleep(3000);
            //var sendResponse = api.StartCampaign(campaignResponse.id);
           // var response = api.StatusCampaign(campaignResponse.id);
            //bool result = sendResponse != null;
            //Assert.IsTrue(result, "OK");
        }

        [TestMethod]
        public void StatusCampaignTeste() {
            var api = new VoiqX("https://4c.voiqx.cloud", "MTk3NDMwYTczMDFiNmI4NWZhYzI3YzQ2OGU3NDkwNjU3N2Y0ZTFkNjI4ZDgzOGYwZjM4NzIwNjVjNGI3MzM2MA");
            var response = api.StatusCampaign(702);

            bool result = response != null;
            Assert.IsTrue(result, "OK");
        }


        private static Mailing CreateMailing() {
            return new Mailing {
                name = "Mailling API Teste",
                customers = new List<MailingCustomer> {
                    new MailingCustomer {
                        name = "William",
                        reference_code = "1",
                        phones = new List<long> {
                            21968153253
                        }
                    }
                }
            };
        }

        private static Campaign CreateCampaign(int mailingId, int templateId) {
            return new Campaign {
                name = "Campanha API Testes",
                mailing_id = mailingId,
                template_id = templateId
            };
        }
    }
}
