﻿using System;

namespace Greatbone.Core
{
    public static class IDataOutputUtility
    {
        //
        // GET SPECIFIC BY NAME
        //

        public static bool GetBool(this IDataInput inp, string name = null)
        {
            bool v = false;
            inp.Get(name, ref v);
            return v;
        }

        public static short GetShort(this IDataInput inp, string name = null)
        {
            short v = 0;
            inp.Get(name, ref v);
            return v;
        }

        public static int GetInt(this IDataInput inp, string name = null)
        {
            int v = 0;
            inp.Get(name, ref v);
            return v;
        }

        public static long GetLong(this IDataInput inp, string name = null)
        {
            long v = 0;
            inp.Get(name, ref v);
            return v;
        }

        public static decimal GetDecimal(this IDataInput inp, string name = null)
        {
            decimal v = 0;
            inp.Get(name, ref v);
            return v;
        }

        public static DateTime GetDateTime(this IDataInput inp, string name = null)
        {
            DateTime v = default(DateTime);
            inp.Get(name, ref v);
            return v;
        }

        public static string GetString(this IDataInput inp, string name = null)
        {
            string v = null;
            inp.Get(name, ref v);
            return v;
        }

        public static ArraySegment<byte> GetByteAS(this IDataInput inp, string name = null)
        {
            ArraySegment<byte> v;
            inp.Get(name, ref v);
            return v;
        }

        public static D GetData<D>(this IDataInput inp, string name = null) where D : IData, new()
        {
            D v = default(D);
            inp.Get(name, ref v);
            return v;
        }

        public static short[] GetShorts(this IDataInput inp, string name = null)
        {
            short[] v = null;
            inp.Get(name, ref v);
            return v;
        }

        public static int[] GetInts(this IDataInput inp, string name = null)
        {
            int[] v = null;
            inp.Get(name, ref v);
            return v;
        }

        public static long[] GetLongs(this IDataInput inp, string name = null)
        {
            long[] v = null;
            inp.Get(name, ref v);
            return v;
        }

        public static string[] GetStrings(this IDataInput inp, string name = null)
        {
            string[] v = null;
            inp.Get(name, ref v);
            return v;
        }

        public static D[] GetDatas<D>(this IDataInput inp, string name = null) where D : IData, new()
        {
            D[] v = null;
            inp.Get(name, ref v);
            return v;
        }


        public static void GetOn(this IDataInput inp, ref string v1, ref string v2)
        {
            inp.Get(null, ref v1);
            inp.Get(null, ref v2);
        }

        public static void GetOn(this IDataInput inp, ref string v1, ref string v2, ref string v3)
        {
            inp.Get(null, ref v1);
            inp.Get(null, ref v2);
            inp.Get(null, ref v3);
        }

        public static void GetOn(this IDataInput inp, ref string v1, ref string v2, ref string v3, ref string v4)
        {
            inp.Get(null, ref v1);
            inp.Get(null, ref v2);
            inp.Get(null, ref v3);
            inp.Get(null, ref v4);
        }

        public static void GetOn(this IDataInput inp, ref int v1, ref string v2, ref string v3)
        {
            inp.Get(null, ref v1);
            inp.Get(null, ref v2);
            inp.Get(null, ref v3);
        }
    }
}