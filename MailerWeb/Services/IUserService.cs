﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailerWeb.Models;

namespace MailerWeb.Services
{
    public interface IUserService
    {
        string GetLoginFromToken(string token);
        Task<Signature> AddSignatureAsync(string token, Signature signature);
        Task<Signature> GetSignatureAsync(string token, int signatureId);
        Task<IList<Signature>> GetSignaturesAsync(string token);
        Task DeleteSignatureAsync(string token, int signatureId);
        Task<Signature> EditSignatureAsync(string token, int signatureId, Signature newSignature);
        Task EditNames(string token, string name, string nickname);

    }
}