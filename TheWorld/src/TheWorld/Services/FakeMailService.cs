using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWorld.Services
{
    public class FakeMailService : IMailService
    {
        public void SendEmail(string to, string from, string subject, string body)
        {
            Debug.WriteLine($"Sending Email, Subject ={subject} , From {from}, To {to}, \n Body : {body}");
        }
    }
}
