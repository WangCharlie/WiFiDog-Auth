using Microsoft.AspNet.Http.Features;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
#if !DNXCORE50
using System.Runtime.Serialization.Formatters.Binary;
#endif
using System.Text;
using System.Threading.Tasks;

namespace WifiAuth.Web.Extensions
{
    public static class SessionExtensions
    {
        //private static IDictionary<TypeCode,Type> 

        public static object Get(this ISession session, string key)
        {
            return session.Get<object>(key);
        }

        public static T Get<T>(this ISession session, string key)
        {
            object tmp;

            return session.TryGet(key, out tmp, typeof(T)) ? (T)tmp : default(T);
        }

        public static bool TryGet(this ISession session, string key, out object value, Type targetType)
        {
            try
            {
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
                    case TypeCode.SByte: value= unchecked(data[0]); break;
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
                            using (var ms = new MemoryStream(data, 0, data.Length))
                            {
#if !DNXCORE50
                                value = new BinaryFormatter().Deserialize(ms);
#else
                                value = null; 
#endif

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

        public static byte[] GetValue(this ISession session, string key)
        {
            byte[] value = null;
            session.TryGetValue(key, out value);
            
            return value;
        }

        public static bool Set(this ISession session, string key, object value)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            try
            {
                byte[] data;
                TypeCode code = value == null ? TypeCode.Empty : Type.GetTypeCode(value.GetType());
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
                            using (var ms = new MemoryStream())
                            {
#if !DNXCORE50
                                new BinaryFormatter().Serialize(ms, value);
#endif
                                data = ms.ToArray();
                            }
                            break;
                        }
                }

                session.Set(key, data);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
