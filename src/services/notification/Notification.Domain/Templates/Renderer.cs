using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using Scriban;
using Scriban.Runtime;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace Notification.Domain.Templates
{
    public static class Renderer
    {
        private static readonly JsonSerializer _serializer = new JsonSerializer()
        {
            Converters =
            {
                new ScriptObjectConverter()
            }
        };

        public static string Render(string layout, IDictionary<string, string> templateParts = null,
            params object[] data)
        {
            var template = Template.Parse(layout);
            templateParts = templateParts ?? new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
            var context = new TemplateContext()
            {
                TemplateLoader = new InMemoryTemplateLoader(templateParts),

            };

            if (data != null)
            {
                var scriptObject = new ScriptObject();
                var merged = MergeData(data);
                scriptObject.Import(merged.ToObject<ScriptObject>(_serializer));
                context.PushGlobal(scriptObject);
            }

            return template.Render(context);
        }

        private static JObject MergeData(params object[] data)
        {
            return data
                .Where(t => t != null)
                .Aggregate(new JObject(), (memo, cur) =>
                {
                    memo.Merge(JObject.FromObject(cur).ToSnakeCasingDictionary());
                    return memo;
                })
                .ToSnakeCasingDictionary();
        }

        private static JObject ToSnakeCasingDictionary(this JToken jObject)
        {
            var expando = jObject.ToObject<ExpandoObject>();
            var snakeCaseString = JsonConvert.SerializeObject(expando, new JsonSerializerSettings()
            {
                ContractResolver = new DefaultContractResolver()
                {
                    NamingStrategy = new SnakeCaseNamingStrategy(
                        processDictionaryKeys: true,
                        overrideSpecifiedNames: false
                    )
                }
            });

            return JObject.Parse(snakeCaseString);
        }
    }
}
