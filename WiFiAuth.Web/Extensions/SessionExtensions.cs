using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace WiFiAuth.Web.Extensions
{
    public static class SessionExtensions
    {

        public static object Get(this ISession session, string key, Type targetType)
        {
            object value;
            session.TryGet(key, out value, targetType);

            return value;
        }

        public static T Get<T>(this ISession session, string key)
        {
            object value;

            return session.TryGet(key, out value, typeof(T)) ? (T)value : default(T);
        }

        public static byte[] GetValue(this ISession session, string key)
        {
            byte[] value = null;
            session.TryGetValue(key, out value);
            
            return value;
        }

        public static bool TryGet(this ISession session, string key, out object value, Type targetType)
        {
            try
            {
                targetType = GetNullunableType(targetType);
                TypeCode code = Type.GetTypeCode(targetType);

                var data = session.GetValue(key);

                if (data == null || data.Length == 0)
                {
                    code = TypeCode.Empty;
                }

                switch (code)
                {
                    case TypeCode.Empty: value = null; break;
                    case TypeCode.String: value = Encoding.UTF8.GetString(data); break; 
                    case TypeCode.Boolean: value = BitConverter.ToBoolean(data, 0); break;
                    case TypeCode.SByte: value= unchecked((sbyte)data[0]); break;
                    case TypeCode.Byte: value = data[0]; break;
                    case TypeCode.Int16: value = BitConverter.ToInt16(data,0); break;
                    case TypeCode.Int32: value = BitConverter.ToInt32(data, 0); break;
                    case TypeCode.Int64: value = BitConverter.ToInt64(data, 0); break;
                    case TypeCode.UInt16: value = BitConverter.ToUInt16(data, 0); break;
                    case TypeCode.UInt32: value = BitConverter.ToUInt32(data, 0); break;
                    case TypeCode.UInt64: value = BitConverter.ToUInt64(data, 0); break;
                    case TypeCode.Char: value = BitConverter.ToChar(data, 0); break;
                    case TypeCode.DateTime: value = DateTime.FromBinary(BitConverter.ToInt64(data, 0)); break;
                    case TypeCode.Double: value = BitConverter.ToDouble(data, 0); break;
                    case TypeCode.Single: value = BitConverter.ToSingle(data, 0); break;
                    case TypeCode.Decimal:
                        {
                            int[] bits = new int[4];
                            Buffer.BlockCopy(data, 0, bits, 0, 16);
                            value = new Decimal(bits);
                            break;
                        }
                    case TypeCode.Object:
                    default:
                        {
                            using (MemoryStream ms = new MemoryStream(data, 0, data.Length))
                            {
                                using (BsonReader br = new BsonReader(ms, targetType.IsArray, DateTimeKind.Local))
                                {
                                    value = new JsonSerializer().Deserialize(br, targetType);
                                }
                            }
                            break;
                        }
                }

                return true;
            }
            catch (Exception)
            {
                value = null;
                return false;
            }
        }

        public static bool Set(this ISession session, string key, object value)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            byte[] data;
            Type targetType = value == null ? null : GetNullunableType(value.GetType());
            TypeCode code = value == null ? TypeCode.Empty : Type.GetTypeCode(targetType);

            switch (code)
            {
                case TypeCode.Empty: data = new byte[0]; break;
                case TypeCode.String: data = Encoding.UTF8.GetBytes((string)value); break;
                case TypeCode.Boolean: data = BitConverter.GetBytes((bool)value); break;
                case TypeCode.SByte: data = new byte[] { (byte)value }; break;
                case TypeCode.Byte: data = new byte[] { (byte)value }; break;
                case TypeCode.Int16: data = BitConverter.GetBytes((short)value); break;
                case TypeCode.Int32: data = BitConverter.GetBytes((int)value); break;
                case TypeCode.Int64: data = BitConverter.GetBytes((long)value); break;
                case TypeCode.UInt16: data = BitConverter.GetBytes((ushort)value); break;
                case TypeCode.UInt32: data = BitConverter.GetBytes((uint)value); break;
                case TypeCode.UInt64: data = BitConverter.GetBytes((ulong)value); break;
                case TypeCode.Char: data = BitConverter.GetBytes((char)value); break;
                case TypeCode.DateTime: data = BitConverter.GetBytes(((DateTime)value).ToBinary()); break;
                case TypeCode.Double: data = BitConverter.GetBytes((double)value); break;
                case TypeCode.Single: data = BitConverter.GetBytes((float)value); break;
                case TypeCode.Decimal:
                    {
                        data = new byte[16];
                        Buffer.BlockCopy(decimal.GetBits((decimal)value), 0, data, 0, 16);
                        break;
                    }
                case TypeCode.Object:
                default:
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            using (BsonWriter bw = new BsonWriter(ms))
                            {
                                new JsonSerializer().Serialize(bw, value);
                                data = ms.ToArray();
                            }
                        }
                        break;
                    }
            }

            session.Set(key, data);

            return true;
        }

        private static Type GetNullunableType(Type type)
        {
            return (type != null && type.GetTypeInfo().IsGenericType &&
                    type.GetGenericTypeDefinition() == typeof(Nullable<>)) ?
                    type.GetGenericArguments()[0] : type;
        }
    }
}
