﻿namespace E_Commerce.Application.Interfaces.Services;
public interface IEmailService
{
	Task SendEmailAsync(string toEmail, string subject, string body, bool isHtml = true);
}
