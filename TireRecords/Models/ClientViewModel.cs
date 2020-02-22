using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TireRecords.Models
{
    public class ClientViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }

        public static ClientViewModel MapTo(ClientDto clientDto)
        {
            var client = new ClientViewModel();

            client.Id = clientDto.Id;
            client.FirstName = clientDto.FirstName;
            client.LastName = clientDto.LastName;
            client.MobilePhone = clientDto.MobilePhone;
            client.Email = clientDto.Email;

            return client;
        }

        public static ClientDto MapFrom(ClientViewModel client)
        {
            var clientDto = new ClientDto();

            clientDto.Id = client.Id;
            clientDto.FirstName = client.FirstName;
            clientDto.LastName = client.LastName;
            clientDto.MobilePhone = client.MobilePhone;
            clientDto.Email = client.Email;

            return clientDto;
        }

        public static ClientDto MapFrom(FormCollection collection)
        {
            var client = new ClientDto();

            client.FirstName = Convert.ToString(collection["firstName"]);
            client.LastName = Convert.ToString(collection["lastName"]);
            client.MobilePhone = Convert.ToString(collection["mobilePhone"]);
            client.Email = Convert.ToString(collection["email"]);

            return client;
        }
    }
}