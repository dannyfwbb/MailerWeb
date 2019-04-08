﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailerWeb.Models;
using MailerWeb.Models.Repository;
using MailerWeb.Models.Requests;
using MailerWeb.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MailerWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("AddSignature")]
        public async Task<IActionResult> AddSignatureAsync([FromBody]AddSignatureData data)
        {
            var signature = await _userService.AddSignatureAsync(data.Token, data.Signature);
            return StatusCode(200, signature);
        }

        [HttpGet]
        [Route("GetSignature")]
        public async Task<IActionResult> GetSignatureAsync([FromQuery]string token, int signatureId)
        {
            var signature = await _userService.GetSignatureAsync(token, signatureId);
            return StatusCode(200, signature);
        }

        [HttpGet]
        [Route("GetSignatures")]
        public async Task<IActionResult> GetSignatures([FromQuery] string token)
        {
            var signatures = await _userService.GetSignaturesAsync(token);
            return StatusCode(200, signatures);
        }

        [HttpDelete]
        [Route("DeleteSignature")]
        public async Task<IActionResult> DeleteSignatureAsync([FromQuery]string token, int signatureId)
        {
            await _userService.DeleteSignatureAsync(token, signatureId);
            return StatusCode(204);
        }

        [HttpPost]
        [Route("EditSignature")]
        public async Task<IActionResult> EditSignatureAsync([FromBody]EditSignatureData data)
        {
            var signature = await _userService.EditSignatureAsync(data.Token, data.SignatureId, data.NewSignature);
            return StatusCode(200, signature);
        }

        [HttpPost]
        [Route("EditNames")]
        public async Task<IActionResult> EditNames([FromBody]EditNamesData data)
        {
            await _userService.EditNames(data.Token, data.Name, data.Nickname);
            return StatusCode(204);
        }
    }
}