﻿using System;
using System.Collections.Generic;
using Npgsql;
using NpgsqlTypes;

namespace Greatbone.Core
{
    ///
    /// A wrapper of db parameter collection.
    ///
    public class DbParameters : IDataOutput<DbParameters>
    {
        static readonly string[] Defaults =
        {
            "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24"
        };

        readonly NpgsqlParameterCollection coll;

        // current parameter index
        int position;

        internal DbParameters(NpgsqlParameterCollection coll)
        {
            this.coll = coll;
        }

        internal void Clear()
        {
            coll.Clear();
            position = 0;
        }


        public DbParameters PutEnter(bool multi)
        {
            return this;
        }

        public DbParameters PutExit(bool multi)
        {
            return this;
        }

        public DbParameters PutRaw(string name, string raw)
        {
            return this;
        }

        public DbParameters PutNull(string name)
        {
            if (name == null)
            {
                name = Defaults[position++];
            }
            coll.AddWithValue(name, DBNull.Value);
            return this;
        }

        public DbParameters Put(string name, bool v)
        {
            if (name == null)
            {
                name = Defaults[position++];
            }
            coll.Add(new NpgsqlParameter(name, NpgsqlDbType.Boolean)
            {
                Value = v
            });
            return this;
        }

        public DbParameters Put(string name, short v)
        {
            if (name == null)
            {
                name = Defaults[position++];
            }
            coll.Add(new NpgsqlParameter(name, NpgsqlDbType.Smallint)
            {
                Value = v
            });
            return this;
        }

        public DbParameters Put(string name, int v)
        {
            if (name == null)
            {
                name = Defaults[position++];
            }
            coll.Add(new NpgsqlParameter(name, NpgsqlDbType.Integer)
            {
                Value = v
            });
            return this;
        }

        public DbParameters Put(string name, long v)
        {
            if (name == null)
            {
                name = Defaults[position++];
            }
            coll.Add(new NpgsqlParameter(name, NpgsqlDbType.Bigint)
            {
                Value = v
            });
            return this;
        }

        public DbParameters Put(string name, double v)
        {
            if (name == null)
            {
                name = Defaults[position++];
            }
            coll.Add(new NpgsqlParameter(name, NpgsqlDbType.Double)
            {
                Value = v
            });
            return this;
        }

        public DbParameters Put(string name, decimal v)
        {
            if (name == null)
            {
                name = Defaults[position++];
            }
            coll.Add(new NpgsqlParameter(name, NpgsqlDbType.Money)
            {
                Value = v
            });
            return this;
        }

        public DbParameters Put(string name, JNumber v)
        {
            if (name == null)
            {
                name = Defaults[position++];
            }
            coll.Add(new NpgsqlParameter(name, NpgsqlDbType.Numeric)
            {
                Value = v.Decimal
            });
            return this;
        }

        public DbParameters Put(string name, DateTime v)
        {
            if (name == null)
            {
                name = Defaults[position++];
            }
            coll.Add(new NpgsqlParameter(name, NpgsqlDbType.Timestamp)
            {
                Value = v
            });
            return this;
        }

        public DbParameters Put(string name, NpgsqlPoint v)
        {
            if (name == null)
            {
                name = Defaults[position++];
            }
            coll.Add(new NpgsqlParameter(name, NpgsqlDbType.Point)
            {
                Value = v
            });
            return this;
        }

        public DbParameters Put(string name, char[] v)
        {
            if (name == null)
            {
                name = Defaults[position++];
            }
            coll.Add(new NpgsqlParameter(name, NpgsqlDbType.Char, v.Length)
            {
                Value = v
            });
            return this;
        }

        public DbParameters Put(string name, string v, bool? anylen = null)
        {
            if (name == null)
            {
                name = Defaults[position++];
            }
            int len = v?.Length ?? 0;
            coll.Add(new NpgsqlParameter(name, !anylen.HasValue ? NpgsqlDbType.Varchar : anylen.Value ? NpgsqlDbType.Text : NpgsqlDbType.Char, len)
            {
                Value = (v != null) ? (object)v : DBNull.Value
            });
            return this;
        }

        public DbParameters Put(string name, byte[] v)
        {
            if (name == null)
            {
                name = Defaults[position++];
            }
            coll.Add(new NpgsqlParameter(name, NpgsqlDbType.Bytea)
            {
                Value = (v != null) ? (object)v : DBNull.Value
            });
            return this;
        }

        public DbParameters Put(string name, ArraySegment<byte> v)
        {
            if (name == null)
            {
                name = Defaults[position++];
            }
            coll.Add(new NpgsqlParameter(name, NpgsqlDbType.Bytea, v.Count)
            {
                Value = (v.Array != null) ? (object)v : DBNull.Value
            });
            return this;
        }

        public DbParameters Put(string name, IData v, ushort sel = 0)
        {
            if (name == null)
            {
                name = Defaults[position++];
            }
            if (v == null)
            {
                coll.Add(new NpgsqlParameter(name, NpgsqlDbType.Jsonb) { Value = DBNull.Value });
            }
            else
            {
                coll.Add(new NpgsqlParameter(name, NpgsqlDbType.Jsonb)
                {
                    Value = JsonUtility.ObjectToString(v, sel)
                });
            }
            return this;
        }

        public DbParameters Put(string name, JObj v)
        {
            if (name == null)
            {
                name = Defaults[position++];
            }
            if (v == null)
            {
                coll.Add(new NpgsqlParameter(name, NpgsqlDbType.Jsonb)
                {
                    Value = DBNull.Value
                });
            }
            else
            {
                coll.Add(new NpgsqlParameter(name, NpgsqlDbType.Jsonb)
                {
                    Value = JsonUtility.JObjToString(v)
                });
            }
            return this;
        }

        public DbParameters Put(string name, JArr v)
        {
            if (name == null)
            {
                name = Defaults[position++];
            }
            if (v == null)
            {
                coll.Add(new NpgsqlParameter(name, NpgsqlDbType.Jsonb)
                {
                    Value = DBNull.Value
                });
            }
            else
            {
                coll.Add(new NpgsqlParameter(name, NpgsqlDbType.Jsonb)
                {
                    Value = JsonUtility.JArrToString(v)
                });
            }
            return this;
        }

        public DbParameters Put(string name, short[] v)
        {
            if (name == null)
            {
                name = Defaults[position++];
            }
            coll.Add(new NpgsqlParameter(name, NpgsqlDbType.Array | NpgsqlDbType.Smallint)
            {
                Value = (v != null) ? (object)v : DBNull.Value
            });
            return this;
        }

        public DbParameters Put(string name, int[] v)
        {
            if (name == null)
            {
                name = Defaults[position++];
            }
            coll.Add(new NpgsqlParameter(name, NpgsqlDbType.Array | NpgsqlDbType.Integer)
            {
                Value = (v != null) ? (object)v : DBNull.Value
            });
            return this;
        }

        public DbParameters Put(string name, long[] v)
        {
            if (name == null)
            {
                name = Defaults[position++];
            }
            coll.Add(new NpgsqlParameter(name, NpgsqlDbType.Array | NpgsqlDbType.Bigint)
            {
                Value = (v != null) ? (object)v : DBNull.Value
            });
            return this;
        }

        public DbParameters Put(string name, string[] v)
        {
            if (name == null)
            {
                name = Defaults[position++];
            }
            coll.Add(new NpgsqlParameter(name, NpgsqlDbType.Array | NpgsqlDbType.Text)
            {
                Value = (v != null) ? (object)v : DBNull.Value
            });
            return this;
        }

        public DbParameters Put<D>(string name, D[] v, ushort sel = 0) where D : IData
        {
            if (name == null)
            {
                name = Defaults[position++];
            }
            if (v == null)
            {
                coll.Add(new NpgsqlParameter(name, NpgsqlDbType.Jsonb)
                {
                    Value = DBNull.Value
                });
            }
            else
            {
                coll.Add(new NpgsqlParameter(name, NpgsqlDbType.Jsonb)
                {
                    Value = JsonUtility.ArrayToString(v, sel)
                });
            }
            return this;
        }

        public DbParameters Put<D>(string name, List<D> v, ushort sel = 0) where D : IData
        {
            if (name == null)
            {
                name = Defaults[position++];
            }
            if (v == null)
            {
                coll.Add(new NpgsqlParameter(name, NpgsqlDbType.Jsonb)
                {
                    Value = DBNull.Value
                });
            }
            else
            {
                coll.Add(new NpgsqlParameter(name, NpgsqlDbType.Jsonb)
                {
                    Value = JsonUtility.ListToString(v, sel)
                });
            }
            return this;
        }

        public DbParameters Put(string name, IDataInput v)
        {
            return this;
        }

        public DbParameters Put(string name, Dictionary<string, string> v)
        {
            return this;
        }

        //
        // positional
        //

        public DbParameters SetNull()
        {
            return PutNull(null);
        }

        public DbParameters Set(bool v)
        {
            return Put(null, v);
        }

        public DbParameters Set(short v)
        {
            return Put(null, v);
        }

        public DbParameters Set(int v)
        {
            return Put(null, v);
        }

        public DbParameters Set(long v)
        {
            return Put(null, v);
        }

        public DbParameters Set(double v)
        {
            return Put(null, v);
        }

        public DbParameters Set(decimal v)
        {
            return Put(null, v);
        }

        public DbParameters Set(JNumber v)
        {
            return Put(null, v);
        }

        public DbParameters Set(DateTime v)
        {
            return Put(null, v);
        }

        public DbParameters Set(NpgsqlPoint v)
        {
            return Put(null, v);
        }

        public DbParameters Set(char[] v)
        {
            return Put(null, v);
        }

        public DbParameters Set(string v, bool? anylen = null)
        {
            return Put(null, v);
        }

        public DbParameters Set(byte[] v)
        {
            return Put(null, v);
        }

        public DbParameters Set(ArraySegment<byte> v)
        {
            return Put(null, v);
        }

        public DbParameters Set(IDataInput v)
        {
            return Put(null, v);
        }

        public DbParameters Set(short[] v)
        {
            return Put(null, v);
        }

        public DbParameters Set(int[] v)
        {
            return Put(null, v);
        }

        public DbParameters Set(long[] v)
        {
            return Put(null, v);
        }

        public DbParameters Set(string[] v)
        {
            return Put(null, v);
        }

        public DbParameters Set(IData v, ushort sel = 0)
        {
            return Put(null, v);
        }

        public DbParameters Set<D>(D[] v, ushort sel = 0) where D : IData
        {
            return Put(null, v);
        }

        public DbParameters Set<D>(List<D> v, ushort sel = 0) where D : IData
        {
            return Put(null, v);
        }
    }
}