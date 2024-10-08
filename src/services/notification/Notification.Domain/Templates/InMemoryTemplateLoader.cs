using Scriban;
using Scriban.Parsing;
using Scriban.Runtime;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Domain.Templates
{
    public class InMemoryTemplateLoader : ITemplateLoader
    {
        private readonly IDictionary<string, string> _templateParts;

        public InMemoryTemplateLoader(IDictionary<string, string> templateParts)
        {
            _templateParts = templateParts;
        }

        public string GetPath(TemplateContext context, SourceSpan callerSpan, string templateName)
        {
            return templateName;
        }

        public string Load(TemplateContext context, SourceSpan callerSpan, string templatePath)
        {
            return _templateParts.TryGetValue(templatePath, out var template) && template != null
                ? template
                : string.Empty;
        }

        public ValueTask<string> LoadAsync(TemplateContext context, SourceSpan callerSpan, string templatePath)
        {
            return new ValueTask<string>(_templateParts.TryGetValue(templatePath, out var template) && template != null
                ? template
                : string.Empty);
        }
    }
}
