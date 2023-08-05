﻿using System;
using System.Collections.Generic;

namespace ChainFx
{
    /// <summary>
    /// To generate multipart/form-data binary content, with the part Content-Length extension.
    /// </summary>
    public sealed class FormMpBuilder : ContentBuilder, ISink
    {
        public const string BOUNDARY = "~7^E!3#A&W";

        // deliberately not longer than 40 characters
        const string Mime = "multipart/form-data; boundary=" + BOUNDARY;

        readonly string boundary;

        public FormMpBuilder(int capacity, string boundary = "~7^E!3#A&W") : base(true, capacity)
        {
            this.boundary = boundary;
        }

        public override string CType { get; set; } = Mime;

        //
        // SINK
        //

        void Part(string name)
        {
            Add(BOUNDARY);
            Add("Content-Disposition: form-data; name=\"");
            Add(name);
            Add("\"\r\n\r\n");
        }

        public void PutNull(string name)
        {
        }

        public void Put(string name, JNumber v)
        {
            Part(name);
            Add(v.bigint);
            if (v.Pt)
            {
                Add('.');
                Add(v.fract);
            }
        }

        public void Put(string name, bool v)
        {
            Part(name);
            Add(v ? "true" : "false");
        }

        public void Put(string name, char v)
        {
            Part(name);
            Add(v);
        }

        public void Put(string name, short v)
        {
            Part(name);
            Add(v);
        }

        public void Put(string name, int v)
        {
            Part(name);
            Add(v);
        }

        public void Put(string name, long v)
        {
            Part(name);
            Add(v);
        }

        public void Put(string name, double v)
        {
            Part(name);
            Add(v);
        }

        public void Put(string name, decimal v)
        {
            Part(name);
            Add(v);
        }

        public void Put(string name, DateTime v)
        {
            Part(name);
            Add(v);
        }

        public void Put(string name, TimeSpan v)
        {
            throw new NotImplementedException();
        }

        public void Put(string name, string v)
        {
            Part(name);
            Add(v ?? "null");
        }

        public void Put(string name, IList<byte> v)
        {
        }

        public void Put(string name, IList<short> v)
        {
            Part(name);
            if (v == null)
            {
                Add("null");
            }
            else
            {
                Add('[');
                for (int i = 0; i < v.Count; i++)
                {
                    if (i > 0) Add(',');
                    Add(v[i]);
                }
                Add(']');
            }
        }

        public void Put(string name, IList<int> v)
        {
            Part(name);
            if (v == null)
            {
                Add("null");
            }
            else
            {
                Add('[');
                for (int i = 0; i < v.Count; i++)
                {
                    if (i > 0) Add(',');
                    Add(v[i]);
                }
                Add(']');
            }
        }

        public void Put(string name, IList<long> v)
        {
            if (v == null)
            {
                Add("null");
            }
            else
            {
                Add('[');
                for (int i = 0; i < v.Count; i++)
                {
                    if (i > 0) Add(',');
                    Add(v[i]);
                }
                Add(']');
            }
        }

        public void Put(string name, IList<string> v)
        {
            Part(name);
            if (v == null)
            {
                Add("null");
            }
            else
            {
                Add('[');
                for (int i = 0; i < v.Count; i++)
                {
                    if (i > 0) Add(',');
                    string str = v[i];
                    Add(str ?? "null");
                }
                Add(']');
            }
        }

        public void Put(string name, JObj v)
        {
        }

        public void Put(string name, JArr v)
        {
        }

        public void Put(string name, XElem v)
        {
        }

        public void Put(string name, IData v, short msk = 0xff)
        {
            Part(name);
            if (v == null)
            {
                Add("null");
            }
            else
            {
                Add('{');
                v.Write(this, msk);
                Add('}');
            }
        }

        public void Put<D>(string name, IList<D> v, short msk = 0xff) where D : IData
        {
            Part(name);
            if (v == null)
            {
                Add("null");
            }
            else
            {
                Add('[');
                for (int i = 0; i < v.Count; i++)
                {
                    Put(null, v[i], msk);
                }
                Add(']');
            }
        }

        public void PutFromSource(ISource s)
        {
        }
    }
}