using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;

namespace EmployeeManagement.Tools
{
    public class JwtTool
    {
        public static string Key { get; set; } = "EmployeeManagement";

        public static string Encode(Dictionary<string, object> payload)
        {
            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);

            string token = encoder.Encode(payload, Key);
            return token;
        }

        public static Dictionary<string, object> Decode(string token)
        {
            try
            {
                IJsonSerializer serializer = new JsonNetSerializer();
                var provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder, algorithm);

                var json = decoder.Decode(token, Key, verify: true);
                return JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
            }
            catch (Exception)
            {
                throw new Exception("验证出错");
            }
        }

        public static Dictionary<string, object> ValidLogin(HttpRequest req)
        {
            if (string.IsNullOrEmpty(req.Headers["token"]))
                throw new Exception("未登录");

            return Decode(req.Headers["token"]);
        }
    }
}