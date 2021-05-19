using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using VoiqXApiCliente.Helpers;
using VoiqXApiCliente.Models;

namespace VoiqXApiCliente {
    public class VoiqX {
        private ApiConsumerHelper _api;

        public VoiqX(string baseAdress, string token) {
            _api = new ApiConsumerHelper(baseAdress, token);
        }

        public MailingCreationResponse CreateMailing(Mailing mailing) {
            var milingResponse = default(MailingCreationResponse);
            (MailingCreationResponse result, string statusCode, string message) = _api.Post<Mailing, MailingCreationResponse>("api/v1/oauth/mailing/create", mailing);

            if (result != null) {
                milingResponse = result;
            }

            return milingResponse;
        }

        public StatusMailing StatusMailling(int mailingId) {
            var campaignResponse = new StatusMailing();
            (StatusMailing result, string statusCode, string message) = _api.Get<StatusMailing>($"api/v1/oauth/mailing/{mailingId}/status");

            if (result != null) {
                campaignResponse = result;
            }

            return campaignResponse;
        }

        public CampaignCreationResponse CreateCampaign(Campaign campaign) {
            var campaignResponse = default(CampaignCreationResponse);
            (CampaignCreationResponse result, string statusCode, string message) = _api.Post<Campaign, CampaignCreationResponse>("api/v1/oauth/messenger/campaign/create", campaign);

            if (result != null) {
                campaignResponse = result;
            }

            return campaignResponse;
        }

        public CampaignsPhones CampaignContactList(int campaignId) {
            var campaignResponse = new CampaignsPhones();
            (CampaignsPhones result, string statusCode, string message) = _api.Get<CampaignsPhones>($"api/v1/oauth/messenger/{campaignId}/contacts/list");

            if (result != null) {
                campaignResponse = result;
            }

            return campaignResponse;
        }

        public CampaignStartResponse StartCampaign(int campaignId) {
            var campaignResponse = default(CampaignStartResponse);
            (CampaignStartResponse result, string statusCode, string message) = _api.Put<int, CampaignStartResponse>($"api/v1/oauth/messenger/campaign/{campaignId}/start", campaignId);

            if (result != null) {
                campaignResponse = result;
            }

            return campaignResponse;
        }

        public List<MailingCostumerStatus> StatusCampaign(int campaignId) {
            var campaignResponse = new List<MailingCostumerStatus>();
            (List< MailingCostumerStatus> result, string statusCode, string message) = _api.Get<List<MailingCostumerStatus>>($"api/v1/oauth/messenger/{campaignId}/details");

            if (result != null) {
                campaignResponse = result;
            }

            return campaignResponse;
        }
    }
}
