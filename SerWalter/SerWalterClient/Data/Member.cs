﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace SerWalterClient.Data
{
    using Newtonsoft.Json;
    using System;
    using System.ComponentModel;
    public class Member : DBObject
    {
        [DisplayName("Vorname")]
        public virtual string first_name
        {
            get;
            set;
        }

        [DisplayName("Nachname")]
        public virtual string last_name
        {
            get;
            set;
        }

        private DateTime _dob = DateTime.Now;

        [DisplayName("Geburtstag")]
        [JsonConverter(typeof(DBDateTime))]
        public virtual DateTime dob
        {
            get { return _dob; }
            set { _dob = value; }
        }

        [DisplayName("Straße")]
        public virtual string street
        {
            get;
            set;
        }

        [DisplayName("PLZ")]
        public virtual string zipcode
        {
            get;
            set;
        }

        [DisplayName("Stadt")]
        public virtual string city
        {
            get;
            set;
        }

        [DisplayName("Land")]
        public virtual string country
        {
            get;
            set;
        }

        [DisplayName("Beschäftigung")]
        public virtual string job_name
        {
            get;
            set;
        }

        [Browsable(false)]
        public virtual int job_type
        {
            get;
            set;
        }

        [Browsable(false)]
        public virtual int bank_account
        {
            get;
            set;
        }

        [DisplayName("Zahlt per Lastschrift")]
        [JsonConverter(typeof(DBBoolean))]
        public virtual bool bank_is_sepa
        {
            get;
            set;
        }

        public virtual Invoice CreateInvoice()
        {
            this.lastPushResponse = Network.Request.Send("invoice", new Network.ReferenceRequestObject(this));
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return String.Format("{1} {2}", this.id, this.first_name, this.last_name);
        }
    }
}