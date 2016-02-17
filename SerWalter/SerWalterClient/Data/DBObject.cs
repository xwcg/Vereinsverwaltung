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

    public abstract class DBObject
    {
        public virtual int id
        {
            get;
            set;
        }

        public virtual string objectType
        {
            get
            {
                return this.GetType().ToString();
            }
        }

        public virtual void Pull()
        {
        }

        [NonSerialized]
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