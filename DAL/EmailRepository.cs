using FluentEmail.Core;
using FluentEmail.Smtp;
using HotelManagementAPI.DTOS;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementAPI.Repositories
{
    public class EmailRepository : IEmailSender
    {
        private readonly IServiceProvider _serviceProvider;

        public EmailRepository(IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;
        }
        public async  Task sendEmail(string email)
        {
            try
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var mail = scope.ServiceProvider.GetRequiredService<IFluentEmail>();
                    var mailer = mail
                        .To(email)
                        .Subject("Bidex Hotel and Suite")
                        .UsingTemplateFromFile($"{Directory.GetCurrentDirectory()}/EmailTemplate/ConfirmRegistrationTemplate", true);
                    await mailer.SendAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
