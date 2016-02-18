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
    public abstract class DBObject
    {
        [DisplayName("Datensatz")]
        [Browsable(false)]
        public virtual int id
        {
            get;
            set;
        }

        [DisplayName("Datentyp")]
        [Browsable(false)]
        public virtual string objectType
        {
            get
            {
                return this.GetType().ToString().Replace("SerWalterClient.Data", "");
            }
        }

        public virtual void Pull()
        {
        }

        [NonSerialized]
        [Browsable(false)]
        public string lastPushResponse;

        public virtual bool Push()
        {
            lastPushResponse = Network.Request.Send("push", this);
            try
            {
                Network.SimplifiedResponse simpleResponse = JsonConvert.DeserializeObject<Network.SimplifiedResponse>(lastPushResponse);
                return simpleResponse.success;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public virtual void TryDelete()
        {
            throw new System.NotImplementedException();
        }
    }
}