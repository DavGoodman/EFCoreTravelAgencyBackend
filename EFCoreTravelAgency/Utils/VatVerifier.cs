using EU_VIES;

class VatVerifier
{
    internal enum VerificationStatus
    {
        Valid = 0,
        Invalid = 1,
        // Unable to get status (e.g. service unavailable)
        Unavailable = 2
    }

    public static async Task<VerificationStatus> VerifyAsync(string countryCode, string vatId)
    {
        try
        {
            var client = new checkVatPortTypeClient(checkVatPortTypeClient.EndpointConfiguration.checkVatPort);
            
            
            var request = new checkVatRequest(countryCode, vatId);

            var response = await client.checkVatAsync(request);
            await client.CloseAsync();

            if (response != null && response.valid)
            {
                return VerificationStatus.Valid;
            }
            else
            {
                return VerificationStatus.Invalid;
            }
            
        }
        catch (Exception)
        {
            return VerificationStatus.Unavailable;
        }
    }
}