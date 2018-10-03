﻿using Greatbone;

namespace Samp
{
    /// <summary>
    /// A user data object that can act as a principal.
    /// </summary>
    public class User : IData
    {
        public static readonly User Empty = new User();

        public const byte ID = 1, PRIVACY = 2, MISC = 4;

        public static readonly Map<short, string> Teamly = new Map<short, string>
        {
            {1, "成员"},
            {3, "副手"},
            {7, "团长"},
        };

        public static readonly Map<short, string> Shoply = new Map<short, string>
        {
            {1, "副手"},
            {3, "经理"},
        };

        public static readonly Map<short, string> Hubly = new Map<short, string>
        {
            {1, "成员"},
            {3, "副手"},
            {7, "经理"},
        };

        internal int id;
        internal string hubid;
        internal string name;
        internal string tel;
        public string credential;
        internal string wx; // wexin openid
        internal string addr;
        internal short teamat;
        internal short teamly;
        internal short shopat;
        internal short shoply;
        internal short hubly;
        internal short created;

        public void Read(ISource s, byte proj = 0x0f)
        {
            if ((proj & ID) > 0)
            {
                s.Get(nameof(id), ref id);
            }
            s.Get(nameof(hubid), ref hubid);
            s.Get(nameof(name), ref name);
            s.Get(nameof(tel), ref tel);
            if ((proj & PRIVACY) > 0)
            {
                s.Get(nameof(credential), ref credential);
            }
            s.Get(nameof(wx), ref wx);
            s.Get(nameof(addr), ref addr);
            if ((proj & MISC) > 0)
            {
                s.Get(nameof(teamat), ref teamat);
                s.Get(nameof(teamly), ref teamly);
                s.Get(nameof(shopat), ref shopat);
                s.Get(nameof(shoply), ref shoply);
                s.Get(nameof(hubly), ref hubly);
                s.Get(nameof(created), ref created);
            }
        }

        public void Write(ISink s, byte proj = 0x0f)
        {
            if ((proj & ID) > 0)
            {
                s.Put(nameof(id), id);
            }
            s.Put(nameof(hubid), hubid);
            s.Put(nameof(name), name);
            s.Put(nameof(tel), tel);
            if ((proj & PRIVACY) > 0)
            {
                s.Put(nameof(credential), credential);
            }
            s.Put(nameof(wx), wx);
            s.Put(nameof(addr), addr);
            if ((proj & MISC) > 0)
            {
                s.Put(nameof(teamat), teamat);
                s.Put(nameof(teamly), teamly);
                s.Put(nameof(shopat), shopat);
                s.Put(nameof(shoply), shoply);
                s.Put(nameof(hubly), hubly);
                s.Put(nameof(created), created);
            }
        }

        public bool IsIncomplete => name == null || tel == null | addr == null;
    }
}